using System;
using System.Collections.Concurrent;
namespace ThrottleWebAPI.Services
{
    public class QueueService
    {
        public static ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();

        public QueueService()
        {
        }


    }
}
