﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class CountDownTimer : IDisposable
    {
        public Stopwatch _stpWatch = new Stopwatch();

        public Action TimeChanged;
        public Action CountDownFinished;

        public bool IsRunnign => timer.Enabled;

        public int StepMs
        {
            get => timer.Interval;
            set => timer.Interval = value;
        }

        private Timer timer = new Timer();

        private TimeSpan _max = TimeSpan.FromMilliseconds(30000);

        public TimeSpan TimeLeft => (_max.TotalMilliseconds - _stpWatch.ElapsedMilliseconds) > 0 ? TimeSpan.FromMilliseconds(_max.TotalMilliseconds - _stpWatch.ElapsedMilliseconds) : TimeSpan.FromMilliseconds(0);

        private bool _mustStop => (_max.TotalMilliseconds - _stpWatch.ElapsedMilliseconds) < 0;

        public string TimeLeftStr => TimeLeft.ToString(@"hh\:mm\:ss");

        public string TimeLeftMsStr => TimeLeft.ToString(@"hh\:mm\:ss");

        private void TimerTick(object sender, EventArgs e)
        {
            TimeChanged?.Invoke();

            if (_mustStop)
            {
                CountDownFinished?.Invoke();
                _stpWatch.Stop();
                timer.Enabled = false;
            }
        }

        public CountDownTimer(long sec, int a)
        {
            SetTime(sec, a);
            Init();
        }

        public CountDownTimer(TimeSpan ts)
        {
            SetTime(ts);
            Init();
        }

        public CountDownTimer()
        {
            Init();
        }

        private void Init()
        {
            StepMs = 1000;
            timer.Tick += new EventHandler(TimerTick);
        }

        public void SetTime(TimeSpan ts)
        {
            _max = ts;
            TimeChanged?.Invoke();
        }

        public void SetTime(long? second, int a) => SetTime(TimeSpan.FromSeconds((long)second));

        public void Start()
        {
            timer.Start();
            _stpWatch.Start();
        }

        public void Pause()
        {
            timer.Stop();
            _stpWatch.Stop();
        }

        public void Stop()
        {
            Reset();
            Pause();
        }

        public void Reset()
        {
            _stpWatch.Reset();
        }

        public void Restart()
        {
            _stpWatch.Reset();
            timer.Start();
        }

        public void Dispose() => timer.Dispose();
    }
}
