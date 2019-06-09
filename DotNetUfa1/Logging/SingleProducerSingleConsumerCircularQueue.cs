using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sparrow.Logging
{
    public class WebSocketMessageEntry
    {
        public MemoryStream Data;
        public TaskCompletionSource<object> Task;

        public readonly List<WebSocket> WebSocketsList = new List<WebSocket>();

        public override string ToString()
        {
            return Encoding.UTF8.GetString(this.Data.ToArray());
        }
    }

    public class SingleProducerSingleConsumerCircularQueue<T>
    {
        private readonly Queue<T> _buffer;

        public SingleProducerSingleConsumerCircularQueue(int queueSize)
        {
            _buffer = new Queue<T>(queueSize);
        }

        public bool Enqueue(T entry)
        {
            _buffer.Enqueue(entry);
            return true;
        }

        private int _numberOfTimeWaitedForEnqueue;

        public bool Enqueue(T entry, int timeout)
        {
            if (Enqueue(entry))
            {
                _numberOfTimeWaitedForEnqueue = 0;
                return true;
            }
            while (timeout > 0)
            {
                _numberOfTimeWaitedForEnqueue++;
                var timeToWait = _numberOfTimeWaitedForEnqueue / 2;
                if (timeToWait < 2)
                    timeToWait = 2;
                else if (timeToWait > timeout)
                    timeToWait = timeout;
                timeout -= timeToWait;
                Thread.Sleep(timeToWait);
                if (Enqueue(entry))
                    return true;
            }
            return false;
        }

        public bool Dequeue(out T entry)
        {
            if (this._buffer.Count == 0)
            {
                entry = default(T);
                return false;
            }

            entry = _buffer.Dequeue();
            if (entry != null)
            {
                return true;
            }
            
            entry = default(T);
            return false;
        }
    }
}
