using System;
using System.Collections.Generic;
using System.Text;

namespace ServoControlApp
{
    /// <summary>
    /// Structured error handling with proper logging and recovery mechanisms
    /// </summary>
    public class ErrorHandler
    {
        private readonly List<ErrorEntry> _errorLog;
        private readonly object _lockObject = new object();
        private const int MAX_LOG_ENTRIES = 1000;

        public ErrorHandler()
        {
            _errorLog = new List<ErrorEntry>();
        }

        /// <summary>
        /// Log an error with context information
        /// </summary>
        public void LogError(ErrorCode errorCode, string message, Exception exception = null)
        {
            lock (_lockObject)
            {
                var entry = new ErrorEntry
                {
                    Timestamp = DateTime.Now,
                    ErrorCode = errorCode,
                    Message = message,
                    Exception = exception
                };

                _errorLog.Add(entry);

                // Prevent memory issues in long-running sessions
                if (_errorLog.Count > MAX_LOG_ENTRIES)
                {
                    _errorLog.RemoveAt(0);
                }

                // Console output for debugging (can be replaced with proper logging framework)
                Console.WriteLine($"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] ERROR {errorCode}: {message}");
                if (exception != null)
                {
                    Console.WriteLine($"  Exception: {exception.Message}");
                }
            }
        }

        /// <summary>
        /// Log a success or informational message
        /// </summary>
        public void LogInfo(string message)
        {
            lock (_lockObject)
            {
                var entry = new ErrorEntry
                {
                    Timestamp = DateTime.Now,
                    ErrorCode = ErrorCode.None,
                    Message = message
                };

                _errorLog.Add(entry);

                if (_errorLog.Count > MAX_LOG_ENTRIES)
                {
                    _errorLog.RemoveAt(0);
                }

                Console.WriteLine($"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] INFO: {message}");
            }
        }

        /// <summary>
        /// Get formatted error log as string for display
        /// </summary>
        public string GetErrorLogText()
        {
            lock (_lockObject)
            {
                var sb = new StringBuilder();
                foreach (var entry in _errorLog)
                {
                    sb.AppendLine($"[{entry.Timestamp:HH:mm:ss}] {GetErrorMessage(entry)}");
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Get recent errors (last N entries)
        /// </summary>
        public List<ErrorEntry> GetRecentErrors(int count)
        {
            lock (_lockObject)
            {
                int startIndex = Math.Max(0, _errorLog.Count - count);
                return _errorLog.GetRange(startIndex, _errorLog.Count - startIndex);
            }
        }

        /// <summary>
        /// Clear the error log
        /// </summary>
        public void ClearLog()
        {
            lock (_lockObject)
            {
                _errorLog.Clear();
            }
        }

        /// <summary>
        /// Check if there are any critical errors
        /// </summary>
        public bool HasCriticalErrors()
        {
            lock (_lockObject)
            {
                return _errorLog.Exists(e => IsCriticalError(e.ErrorCode));
            }
        }

        /// <summary>
        /// Get user-friendly error message
        /// </summary>
        public static string GetUserFriendlyMessage(ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.SerialPortOpenFailed:
                    return "Failed to open serial port. Please check port availability and permissions.";
                case ErrorCode.SerialPortClosedUnexpectedly:
                    return "Serial port closed unexpectedly. Check cable connection.";
                case ErrorCode.NoReplyTimeout:
                    return "No response from motor controller. Check communication settings and motor power.";
                case ErrorCode.SerialWriteException:
                    return "Failed to send command to motor. Check connection.";
                case ErrorCode.PacketCountExceeded:
                    return "Received too many packets. Communication buffer overflow.";
                case ErrorCode.IncompletePacketReceived:
                    return "Incomplete data packet received. Check communication integrity.";
                case ErrorCode.SerialReadException:
                    return "Failed to read from serial port. Check connection.";
                case ErrorCode.PortNotOpenDuringRead:
                    return "Serial port is not open. Please connect to motor first.";
                case ErrorCode.ParseError:
                    return "Failed to parse motor response. Data may be corrupted.";
                case ErrorCode.None:
                    return "No error";
                default:
                    return $"Unknown error occurred (Code: {errorCode})";
            }
        }

        private string GetErrorMessage(ErrorEntry entry)
        {
            if (entry.ErrorCode == ErrorCode.None)
            {
                return entry.Message;
            }
            return $"{entry.ErrorCode}: {entry.Message}";
        }

        private bool IsCriticalError(ErrorCode errorCode)
        {
            return errorCode == ErrorCode.SerialPortOpenFailed ||
                   errorCode == ErrorCode.SerialPortClosedUnexpectedly ||
                   errorCode == ErrorCode.NoReplyTimeout;
        }
    }

    /// <summary>
    /// Error log entry structure
    /// </summary>
    public class ErrorEntry
    {
        public DateTime Timestamp { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
