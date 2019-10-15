using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface ILogService : IService
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

        public void init(Contexts contexts)
        {
            contexts.game.SetGameComponentLogService(this);
        }

        public void update()
        {
            
        }

        public int getPriority()
        {
            return 0;
        }
    }
}