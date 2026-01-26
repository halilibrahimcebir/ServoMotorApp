using System;
using System.Threading;

namespace ServoControlApp
{
    /// <summary>
    /// Manages dual motor synchronization and coordination
    /// </summary>
    public class MotorSynchronizationController
    {
        private readonly PIDController _pidAxis0;
        private readonly PIDController _pidAxis1;
        private readonly object _syncLock = new object();
        
        // Synchronization state
        private bool _axis0Ready;
        private bool _axis1Ready;
        private bool _isSynchronizedMode;
        
        // Position tracking
        private float _previousPosAxis0;
        private float _previousPosAxis1;
        
        // Thread safety
        private volatile bool _isRunning;
        private Thread _syncThread;

        public bool IsSynchronizedMode
        {
            get { return _isSynchronizedMode; }
            set
            {
                lock (_syncLock)
                {
                    _isSynchronizedMode = value;
                    if (!value)
                    {
                        // Reset sync state when disabling synchronized mode
                        _axis0Ready = false;
                        _axis1Ready = false;
                    }
                }
            }
        }

        public MotorSynchronizationController(PIDController pidAxis0, PIDController pidAxis1)
        {
            _pidAxis0 = pidAxis0;
            _pidAxis1 = pidAxis1;
            _isRunning = false;
        }

        /// <summary>
        /// Start synchronized motor control thread
        /// </summary>
        public void Start()
        {
            if (_isRunning) return;

            _isRunning = true;
            _syncThread = new Thread(SynchronizationLoop)
            {
                Name = "MotorSyncThread",
                IsBackground = true
            };
            _syncThread.Start();
        }

        /// <summary>
        /// Stop synchronized motor control
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
            if (_syncThread != null && _syncThread.IsAlive)
            {
                _syncThread.Join(1000); // Wait up to 1 second
            }
        }

        /// <summary>
        /// Main synchronization loop
        /// </summary>
        private void SynchronizationLoop()
        {
            while (_isRunning)
            {
                try
                {
                    float currentPosAxis0 = exoskeleton.f_Pos_Estimate_Ax0;
                    float currentPosAxis1 = exoskeleton.f_Pos_Estimate_Ax1;

                    if (_isSynchronizedMode)
                    {
                        UpdateSynchronizedControl(currentPosAxis0, currentPosAxis1);
                    }
                    else
                    {
                        UpdateIndependentControl(currentPosAxis0, currentPosAxis1);
                    }

                    // Update previous positions
                    _previousPosAxis0 = currentPosAxis0;
                    _previousPosAxis1 = currentPosAxis1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[MotorSync] Error in sync loop: {ex.Message}");
                }

                Thread.Sleep(Constants.PID_UPDATE_INTERVAL_MS);
            }
        }

        /// <summary>
        /// Update motors in synchronized mode - both must be ready before either moves
        /// </summary>
        private void UpdateSynchronizedControl(float currentPosAxis0, float currentPosAxis1)
        {
            lock (_syncLock)
            {
                float deltaAxis0 = currentPosAxis1 - _previousPosAxis1;
                float deltaAxis1 = currentPosAxis0 - _previousPosAxis0;

                Console.WriteLine($"[Sync] Δ0:{deltaAxis0:F2} Δ1:{deltaAxis1:F2}");

                // Check if Axis1 is ready to move
                if (deltaAxis1 > Constants.POSITION_CHANGE_THRESHOLD_HIGH)
                {
                    _axis0Ready = true;
                    Console.WriteLine("[Sync] Axis0 ready");
                }
                else if (deltaAxis1 > Constants.POSITION_CHANGE_THRESHOLD_LOW && 
                         deltaAxis1 <= Constants.POSITION_CHANGE_THRESHOLD_HIGH)
                {
                    _axis0Ready = false;
                    exoskeleton.Pid_1_Can_Run = false;
                    _pidAxis1.Reset();
                    Console.WriteLine("[Sync] Axis0 reset");
                }

                // Check if Axis0 is ready to move
                if (deltaAxis0 > Constants.POSITION_CHANGE_THRESHOLD_HIGH)
                {
                    _axis1Ready = true;
                    Console.WriteLine("[Sync] Axis1 ready");
                }
                else if (deltaAxis0 > Constants.POSITION_CHANGE_THRESHOLD_LOW && 
                         deltaAxis0 <= Constants.POSITION_CHANGE_THRESHOLD_HIGH)
                {
                    _axis1Ready = false;
                    exoskeleton.Pid_2_Can_Run = false;
                    _pidAxis0.Reset();
                    Console.WriteLine("[Sync] Axis1 reset");
                }

                // Both motors must be ready before allowing movement
                if (_axis0Ready && _axis1Ready)
                {
                    exoskeleton.Pid_1_Can_Run = true;
                    exoskeleton.Pid_2_Can_Run = true;
                    
                    _pidAxis1.IsEnabled = true;
                    _pidAxis0.IsEnabled = true;
                    
                    _pidAxis1.Calculate(currentPosAxis1);
                    _pidAxis0.Calculate(currentPosAxis0);
                    
                    Console.WriteLine("[Sync] Both motors active");
                }
                else
                {
                    // Disable motors if not both ready
                    if (!_axis0Ready)
                    {
                        _pidAxis1.IsEnabled = false;
                        exoskeleton.Pid_1_Can_Run = false;
                    }
                    if (!_axis1Ready)
                    {
                        _pidAxis0.IsEnabled = false;
                        exoskeleton.Pid_2_Can_Run = false;
                    }
                }
            }
        }

        /// <summary>
        /// Update motors in independent mode - original behavior
        /// </summary>
        private void UpdateIndependentControl(float currentPosAxis0, float currentPosAxis1)
        {
            // Axis1 logic (original thrd_PID_Control_ax1)
            float deltaAxis1 = currentPosAxis1 - _previousPosAxis1;
            
            if (deltaAxis1 > Constants.POSITION_CHANGE_THRESHOLD_HIGH)
            {
                exoskeleton.Pid_1_Can_Run = true;
                if (exoskeleton.Pid_2_Can_Run)
                {
                    _pidAxis1.IsEnabled = true;
                    _pidAxis1.Calculate(currentPosAxis1);
                }
            }
            else if (deltaAxis1 > Constants.POSITION_CHANGE_THRESHOLD_LOW && 
                     deltaAxis1 <= Constants.POSITION_CHANGE_THRESHOLD_HIGH)
            {
                exoskeleton.Pid_1_Can_Run = false;
                _pidAxis1.IsEnabled = false;
                _pidAxis1.Reset();
                Console.WriteLine("[PID] Axis1 reset");
            }

            // Axis0 logic (original thrd_PID_Control)
            float deltaAxis0 = currentPosAxis0 - _previousPosAxis0;
            
            if (deltaAxis0 > Constants.POSITION_CHANGE_THRESHOLD_HIGH && exoskeleton.Pid_1_Can_Run)
            {
                exoskeleton.Pid_2_Can_Run = true;
                if (exoskeleton.Pid_1_Can_Run)
                {
                    _pidAxis0.IsEnabled = true;
                    _pidAxis0.Calculate(currentPosAxis0);
                }
            }
            else if (deltaAxis0 > Constants.POSITION_CHANGE_THRESHOLD_LOW && 
                     deltaAxis0 <= Constants.POSITION_CHANGE_THRESHOLD_HIGH)
            {
                exoskeleton.Pid_2_Can_Run = false;
                _pidAxis0.IsEnabled = false;
                _pidAxis0.Reset();
                Console.WriteLine("[PID] Axis0 reset");
            }
        }

        /// <summary>
        /// Emergency stop both motors
        /// </summary>
        public void EmergencyStop()
        {
            lock (_syncLock)
            {
                _pidAxis0.IsEnabled = false;
                _pidAxis1.IsEnabled = false;
                _pidAxis0.Reset();
                _pidAxis1.Reset();
                _axis0Ready = false;
                _axis1Ready = false;
                exoskeleton.Pid_1_Can_Run = false;
                exoskeleton.Pid_2_Can_Run = false;
                Console.WriteLine("[MotorSync] EMERGENCY STOP");
            }
        }

        /// <summary>
        /// Get synchronization status
        /// </summary>
        public string GetStatus()
        {
            lock (_syncLock)
            {
                return $"Mode: {(_isSynchronizedMode ? "Synchronized" : "Independent")}, " +
                       $"Axis0: {(_axis0Ready ? "Ready" : "Waiting")}, " +
                       $"Axis1: {(_axis1Ready ? "Ready" : "Waiting")}";
            }
        }
    }
}
