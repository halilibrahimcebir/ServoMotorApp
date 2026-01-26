using System;

namespace ServoControlApp
{
    /// <summary>
    /// Application-wide constants for motor control and communication
    /// </summary>
    public static class Constants
    {
        // Serial Communication
        public const int DEFAULT_BAUD_RATE = 115200;
        public const int CAN_PACKET_SIZE = 13;
        public const int SERIAL_TIMEOUT_MS = 1000;
        public const int MAX_RETRY_ATTEMPTS = 6;
        
        // CAN Protocol
        public const byte CAN_HEADER = 0xAA;
        public const byte CAN_WRITE_CMD = 0xC8;
        public const byte CAN_READ_CMD = 0xD8;
        public const byte CAN_CHECKSUM = 0x85;
        
        // Motor Control
        public const int MOTOR_AXIS_0 = 0;
        public const int MOTOR_AXIS_1 = 1;
        public const float ENCODER_SCALING_FACTOR = 5.625f;
        public const int PID_UPDATE_INTERVAL_MS = 100;
        
        // Position thresholds for PID activation
        public const float POSITION_CHANGE_THRESHOLD_HIGH = 4.0f;
        public const float POSITION_CHANGE_THRESHOLD_LOW = 1.0f;
        
        // PID Default Values
        public const float DEFAULT_KP = 0.5f;
        public const float DEFAULT_KI = 0.05f;
        public const float DEFAULT_KD = 0.01f;
        public const float DEFAULT_SETPOINT = 0f;
        
        // UI Layout
        public const int COMBOBOX_HEIGHT = 10;
        public const int COMBOBOX_WIDTH = 100;
        public const int CONTROL_SPACING_X = 20;
        public const int CONTROL_SPACING_Y = 40;
    }
    
    /// <summary>
    /// Motor axis identifiers
    /// </summary>
    public enum MotorAxis
    {
        Axis0 = 0,
        Axis1 = 1
    }
    
    /// <summary>
    /// Motor control modes
    /// </summary>
    public enum ControlMode
    {
        Idle = 0,
        VelocityControl = 1,
        PositionControl = 2,
        TorqueControl = 3,
        TrapezoidalTrajectory = 4
    }
    
    /// <summary>
    /// Motor state machine states
    /// </summary>
    public enum AxisState
    {
        Undefined = 0,
        Idle = 1,
        StartupSequence = 2,
        FullCalibrationSequence = 3,
        MotorCalibration = 4,
        EncoderIndexSearch = 5,
        EncoderOffsetCalibration = 6,
        ClosedLoopControl = 7,
        LockinSpin = 8,
        EncoderDirFind = 9,
        Homing = 10
    }
    
    /// <summary>
    /// Input control modes
    /// </summary>
    public enum InputMode
    {
        Inactive = 0,
        Passthrough = 1,
        VelocityRamp = 2,
        PositionFilter = 3,
        TrapezoidalTrajectory = 4
    }
    
    /// <summary>
    /// Error code categories
    /// </summary>
    public enum ErrorCategory
    {
        None = 0,
        General = 1,
        Motor = 2,
        Encoder = 3,
        Controller = 4,
        Communication = 5,
        Synchronization = 6
    }
    
    /// <summary>
    /// Structured error codes for better error handling
    /// </summary>
    public enum ErrorCode
    {
        None = 0,
        SerialPortOpenFailed = 3,
        SerialPortClosedUnexpectedly = 4,
        NoReplyTimeout = 5,
        SerialWriteException = 6,
        PacketCountExceeded = 7,
        IncompletePacketReceived = 8,
        SerialReadException = 9,
        PortNotOpenDuringRead = 10,
        ParseError = 11
    }
    
    /// <summary>
    /// CAN command identifiers
    /// </summary>
    public enum CanCommand
    {
        GetMotorError = 0x03,
        GetEncoderError = 0x04,
        GetSensorlessError = 0x05,
        SetAxisNodeId = 0x06,
        SetAxisRequestState = 0x07,
        GetEncoderEstimate = 0x09,
        GetEncoderCount = 0x0A,
        SetControllerMode = 0x0B,
        SetInputPosition = 0x0C,
        SetInputVelocity = 0x0D,
        SetInputTorque = 0x0E,
        SetVelocityCurrentLimit = 0x0F,
        SetTrapTrajVelocityLimit = 0x11,
        SetTrapTrajAccelDecelLimit = 0x12,
        SetInertia = 0x13,
        GetIqMeasured = 0x14,
        GetSensorlessEstimate = 0x15,
        Reboot = 0x16,
        GetVbusVoltage = 0x17,
        ClearError = 0x18,
        SetVelocityGain = 0x1A,
        SetPositionGain = 0x1B
    }
}
