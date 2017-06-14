using QualityMeter.Core.Interfaces;
using System;

namespace QualityMeter.Infrastructure.Common.Services
{
    public class DebugLogger : ILog
    {
        public bool IsDebugEnabled { get; private set; }
        public bool IsInfoEnabled { get; private set; }
        public bool IsWarnEnabled { get; private set; }
        public bool IsErrorEnabled { get; private set; }
        public bool IsFatalEnabled { get; private set; }

        public DebugLogger(bool isDebugEnabled = true, bool isInfoEnabled = true, bool isWarnEnabled = true, bool isErrorEnabled = true, bool isFatalEnabled = true)
        {
            this.IsDebugEnabled = isDebugEnabled;
            this.IsInfoEnabled = isInfoEnabled;
            this.IsWarnEnabled = isWarnEnabled;
            this.IsErrorEnabled = isErrorEnabled;
            this.IsFatalEnabled = isFatalEnabled;
        }
        public void Debug(object message)
        {
            Console.WriteLine(message);
        }

        public void Info(object message)
        {
            Console.WriteLine(message);
        }

        public void Warn(object message)
        {
            Console.WriteLine(message);
        }

        public void Error(object message)
        {
            Console.WriteLine(message);
        }

        public void Fatal(object message)
        {
            Console.WriteLine(message);
        }

        public void Debug(object message, Exception t)
        {
            Console.WriteLine(message);
        }

        public void Info(object message, Exception t)
        {
            Console.WriteLine(message);
        }

        public void Warn(object message, Exception t)
        {
            Console.WriteLine(message);
        }

        public void Error(object message, Exception t)
        {
            Console.WriteLine(message);
        }

        public void Fatal(object message, Exception t)
        {
            Console.WriteLine(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
