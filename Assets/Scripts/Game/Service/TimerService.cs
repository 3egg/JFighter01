using Entitas;
using Module.Timer;
using NotImplementedException = System.NotImplementedException;

namespace Game.Service
{
    public interface ITimerService : IService, ITimerManager
    {
    }

    public class TimerService : ITimerService
    {
        private ITimerManager timerManager;

        public TimerService(TimerManager timerManager)
        {
            this.timerManager = timerManager;
        }

        public void Execute()
        {
            update();
        }

        public void init(Contexts contexts)
        {
            contexts.game.SetGameComponentTimerService(this);
        }

        public void update()
        {
            timerManager.update();
        }


        public ITimer createTimer(float duration, bool isLoop)
        {
            return timerManager.createTimer(duration, isLoop);
        }

        public void continuesAll()
        {
            timerManager.continuesAll();
        }

        public void pauseAll()
        {
            timerManager.pauseAll();
        }

        public void stopAll()
        {
            timerManager.stopAll();
        }

        public int getPriority()
        {
            return 0;
        }
    }
}