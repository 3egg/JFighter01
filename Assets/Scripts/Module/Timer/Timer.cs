using System;

namespace Module.Timer
{
    /// <summary>
    /// 计时器接口
    /// </summary>
    public interface ITimer
    {
        void addUpdateListener(Action action);
        void addCompleteLister(Action action);

        float currentTime { get; }
        float percent { get; }
        float duration { get; }

        void register(float durationTime);
        void update();
        void reStart();
        void pause();
        void stop();
    }

    public class Timer : ITimer
    {
        public Timer(float currentTime, float percent, float duration)
        {
            this.currentTime = currentTime;
            this.percent = percent;
            this.duration = duration;
        }

        private Action onUpdate;
        private Action onComplete;

        private bool isTiming;
        private bool isComplete;
        private DateTime startTime;
        private float runTIme;

        public void addUpdateListener(Action update)
        {
            onUpdate += update;
        }

        public void addCompleteLister(Action complete)
        {
            onComplete += complete;
        }

        public float currentTime { get; private set; }
        public float percent { get; private set; }
        public float duration { get; private set; }

        /// <summary>
        /// 持续时间单位为秒
        /// </summary>
        /// <param name="durationTime"></param>
        public void register(float durationTime)
        {
            duration = durationTime;
            isTiming = true;
            isComplete = false;
            startTime = DateTime.Now;
            runTIme = 0;
        }

        public void update()
        {
            if (!isComplete)
            {
                return;
            }
        }

        public void reStart()
        {
            throw new NotImplementedException();
        }

        public void pause()
        {
            
        }

        public void stop()
        {
            throw new NotImplementedException();
        }
    }
}