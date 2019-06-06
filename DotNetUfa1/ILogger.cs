using System;
using System.IO;

namespace DotNetUfa1
{
    internal interface ILogger
    {
        void Log(string message);
    }

    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    internal class FileLogger : ILogger, IDisposable
    {
        private readonly StreamWriter _writer;

        internal FileLogger()
        {
            string filename = Path.GetTempFileName();
            this._writer = new StreamWriter(File.OpenWrite(filename));
        }

        public void Dispose()
        {
            this._writer?.Dispose();
        }

        public void Log(string message)
        {
            this._writer.Write(message);
        }
    }

    internal class CompositeLogger : ILogger
    {
        private readonly ILogger[] _loggers;

        public CompositeLogger(params ILogger[] loggers)
        {
            this._loggers = loggers;
        }

        public void Log(string message)
        {
            foreach (ILogger logger in this._loggers)
            {
                logger.Log(message);
            }
        }
    }
}