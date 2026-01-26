using System;

namespace ServoControlApp
{
    /// <summary>
    /// Generic PID Controller implementation for motor control
    /// Consolidates duplicate PID_Control and PID_Control_Axis1 classes
    /// </summary>
    public class PIDController
    {
        // PID Constants
        private float _kp;   // Proportional constant
        private float _ki;   // Integral constant
        private float _kd;   // Derivative constant

        // PID State
        private float _setPoint;         // Target set point
        private float _integral;         // Integral accumulator
        private float _previousError;    // Previous error for derivative calculation
        
        // Output constraints
        private const float MAX_OUTPUT = 120f;
        private const float MIN_OUTPUT = 0f;
        private const float OUTPUT_SCALE = 6f;
        private const float MAX_INTEGRAL = 10f;
        private const float MIN_INTEGRAL = -10f;

        // Motor axis this controller manages
        private readonly MotorAxis _axis;
        
        // Reference to parent form for communication
        private readonly exoskeleton _parentForm;

        public bool IsEnabled { get; set; }
        public float Error { get; private set; }
        public float Derivative { get; private set; }
        public float Output { get; private set; }

        /// <summary>
        /// Initialize PID controller for specific motor axis
        /// </summary>
        public PIDController(MotorAxis axis, float kp, float ki, float kd, float initialSetPoint, exoskeleton parentForm)
        {
            _axis = axis;
            _kp = kp;
            _ki = ki;
            _kd = kd;
            _setPoint = initialSetPoint;
            _parentForm = parentForm;
            
            Reset();
        }

        /// <summary>
        /// Calculate PID output based on current position
        /// </summary>
        public float Calculate(float currentValue)
        {
            // Calculate error
            Error = _setPoint - currentValue;

            // Reset if at setpoint
            if (Math.Abs(currentValue - _setPoint) < 0.001f)
            {
                Reset();
                return 0f;
            }

            // Integral with anti-windup
            _integral += Error;
            _integral = Clamp(_integral, MIN_INTEGRAL, MAX_INTEGRAL);

            // Derivative
            Derivative = Error - _previousError;

            // PID calculation
            float rawOutput = _kp * Error + _ki * _integral + _kd * Derivative;
            
            // Apply output constraints
            rawOutput = Clamp(rawOutput, MIN_OUTPUT, MAX_OUTPUT);
            
            // Scale output
            Output = rawOutput / OUTPUT_SCALE;

            // Update state for next iteration
            _previousError = Error;

            // Update global state for UI display (maintain compatibility with existing code)
            UpdateGlobalState();

            // Send command to motor if enabled
            if (IsEnabled)
            {
                Console.WriteLine($"[PID {_axis}] Output: {Output:F2}, Error: {Error:F2}");
                SendCommandToMotor(Output);
            }

            return Output;
        }

        /// <summary>
        /// Set new target position
        /// </summary>
        public void SetSetPoint(float newSetPoint)
        {
            _setPoint = newSetPoint;
        }

        /// <summary>
        /// Update PID gains
        /// </summary>
        public void SetGains(float kp, float ki, float kd)
        {
            _kp = kp;
            _ki = ki;
            _kd = kd;
        }

        /// <summary>
        /// Reset PID controller state
        /// </summary>
        public void Reset()
        {
            _integral = 0;
            _previousError = 0;
            Error = 0;
            Derivative = 0;
            Output = 0;

            // Update global state
            UpdateGlobalState();

            // Send zero command if enabled
            if (IsEnabled)
            {
                Console.WriteLine($"[PID {_axis}] Reset");
                SendCommandToMotor(0f);
            }
        }

        /// <summary>
        /// Update global static variables for backward compatibility
        /// </summary>
        private void UpdateGlobalState()
        {
            if (_axis == MotorAxis.Axis0)
            {
                exoskeleton.kp = Error;
                exoskeleton.ki = _integral;
                exoskeleton.kd = Derivative;
                exoskeleton.pid_out = Output * OUTPUT_SCALE; // Unscaled for display
                exoskeleton.pid_calc_out = Output;
            }
            // Axis1 doesn't update global state in original implementation
        }

        /// <summary>
        /// Send command to appropriate motor axis
        /// </summary>
        private void SendCommandToMotor(float value)
        {
            if (_parentForm != null)
            {
                if (_axis == MotorAxis.Axis0)
                {
                    _parentForm.ConvertFloatFirst(value);
                }
                else
                {
                    _parentForm.ConvertFloatFirst_Ax1(value);
                }
            }
        }

        /// <summary>
        /// Utility method to clamp values
        /// </summary>
        private float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Get current PID state as string for debugging
        /// </summary>
        public override string ToString()
        {
            return $"PID[{_axis}] SP:{_setPoint:F2} E:{Error:F2} I:{_integral:F2} D:{Derivative:F2} Out:{Output:F2}";
        }
    }
}
