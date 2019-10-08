using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface ILogService
    {
        void log(string message);
        void logError(string message);
    }
    public class LogService : ILogService
    {
        public void log(string message)
        {
            Debug.Log(message);
        }

        public void logError(string message)
        {
            Debug.LogError(message);
        }
    }
}