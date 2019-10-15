using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

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

        void update();
        void continues();
        void pause();
        void stop();

        bool isLoop { get; }

        bool isComplete
        {
            get
            ;
        }

        void resetData(float durationTime, bool loop);
    }

    public interface ITimerManager
    {
        void update();
        ITimer createTimer(float duration, bool isLoop);
        void continuesAll();
        void pauseAll();
        void stopAll();
    }


    /// <summary>
    /// 计时器管理类
    /// </summary>
    public class TimerManager : ITimerManager
    {
        private class Timer : ITimer
        {
            private Action onUpdate;
            private Action onComplete;

            //是否正在计时
            private bool isTiming;

            //计时器是否完成
            public bool isComplete
            {
                get { return runTimeTotal >= duration; }
            }

            //计时开始时间
            private DateTime startTime;

            //总运行时间
            private float runTimeTotal;

            //是否循环执行
            public bool isLoop { get; private set; }

            public void addUpdateListener(Action update)
            {
                onUpdate += update;
            }

            public void addCompleteLister(Action complete)
            {
                onComplete += complete;
            }

            /// <summary>
            /// 当前运行时间
            /// </summary>
            public float currentTime
            {
                get { return runTimeTotal; }
            }

            /// <summary>
            /// 运行百分比
            /// </summary>
            public float percent
            {
                get { return runTimeTotal / duration; }
            }

            /// <summary>
            /// 单次循环持续时间
            /// </summary>
            public float duration
            {
                get { return _duration; }
            }

            private float _duration;

            public Timer(float durationTime, bool loop)
            {
                initData(durationTime, loop);
            }

            private void initData(float durationTime, bool loop)
            {
                this.isLoop = loop;
                _duration = durationTime;
                isTiming = true;
                startTime = DateTime.Now;
                runTimeTotal = 0;
            }

            public void update()
            {
                if (isComplete || !isTiming)
                {
                    return;
                }

                if (isLoop)
                {
                    isLooping();
                }
                else
                {
                    notLoop();
                }

                onUpdate?.Invoke();
            }

            private void notLoop()
            {
                if (isComplete)
                {
                    onComplete?.Invoke();
                }
            }

            private void isLooping()
            {
                if (isComplete)
                {
                    onComplete?.Invoke();
                    resetData();
                }
            }


            public void continues()
            {
                isTiming = true;
                startTime = DateTime.Now;
            }

            public void pause()
            {
                isTiming = false;
                runTimeTotal += getCurrentTimingTime();
            }

            public void stop()
            {
                if (isComplete)
                {
                    onComplete?.Invoke();
                }

                isTiming = false;
                runTimeTotal = 0;
            }

            public void resetData(float durationTime, bool loop)
            {
                initData(durationTime, loop);
            }

            private void resetData()
            {
                isTiming = true;
                startTime = DateTime.Now;
                runTimeTotal = 0;
            }

            private float getCurrentTimingTime()
            {
                TimeSpan timeSpan = DateTime.Now - startTime;
                return (float) timeSpan.TotalSeconds;
            }
        }

        private HashSet<ITimer> activeTimers;
        private HashSet<ITimer> deactiveTimers;

        public TimerManager()
        {
            activeTimers = new HashSet<ITimer>();
            deactiveTimers = new HashSet<ITimer>();
        }

        /// <summary>
        /// 创建一个新计时器
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="isLoop"></param>
        /// <returns></returns>
        public ITimer createTimer(float duration, bool isLoop)
        {
            ITimer timer = null;
            if (deactiveTimers.Count > 0)
            {
                timer = deactiveTimers.First();
                deactiveTimers.Remove(timer);
                timer.resetData(duration, isLoop);
                activeTimers.Add(timer);
            }
            else
            {
                timer = new Timer(duration, isLoop);
                activeTimers.Add(timer);
            }

            timer = new Timer(duration, isLoop);
            activeTimers.Add(timer);
            return timer;
        }

        public void update()
        {
            if (activeTimers.Count > 0)
            {
                foreach (var timer in activeTimers)
                {
                    timer.update();
                    setDeactiveTimer(timer);
                }
            }
        }

        /// <summary>
        /// 设置执行完毕的计时器
        /// </summary>
        /// <param name="timer"></param>
        private void setDeactiveTimer(ITimer timer)
        {
            if (!timer.isLoop && timer.isComplete)
            {
                activeTimers.Remove(timer);
                deactiveTimers.Add(timer);
            }
        }

        /// <summary>
        /// 继续执行所有的计时器
        /// </summary>
        public void continuesAll()
        {
            foreach (ITimer timer in activeTimers)
            {
                timer.continues();
            }
        }

        public  void pauseAll()
        {
            foreach (var timer in activeTimers)
            {
                timer.pause();
            }
        }

        public  void stopAll()
        {
            foreach (var timer in activeTimers)
            {
                timer.stop();
            }
        }
    }
}