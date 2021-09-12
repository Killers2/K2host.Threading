/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/
using System;
using System.Threading;

using K2host.Threading.Delegates;
using K2host.Threading.Interface;

namespace K2host.Threading.Classes
{

    public class OThreadedTimer : IThreadedTimer
    {
        
        /// <summary>
        /// The thread this time will run on
        /// </summary>
        public Thread TimeThread { get; set; }
        
        /// <summary>
        /// Used to kill the thread the time is using
        /// </summary>
        public bool Kill { get; set; }
        
        /// <summary>
        /// Used to pause and unpause the timer.
        /// </summary>
        public bool PauseTimer { get; set; }

        /// <summary>
        /// The call back event on timer tick
        /// </summary>
        public OnTickEventHandler OnTickEvent { get; set; }
        
        /// <summary>
        /// The interval timeout
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// The constuctor
        /// </summary>
        public OThreadedTimer()
        {
            TimeThread  = null;
            Kill        = false;
            PauseTimer  = false;
            Interval    = 1000;
        }

        /// <summary>
        /// The constuctor with the interval timeout
        /// </summary>
        /// <param name="interval">interval timeout</param>
        public OThreadedTimer(int interval)
        {
            TimeThread  = null;
            Kill        = false;
            PauseTimer  = false;
            Interval    = interval;
        }

        #region Deconstuctor

        private bool IsDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
                if (disposing)
                {
                    if (TimeThread != null)
                        TimeThread = null;

                }
            IsDisposed = true;
        }

        #endregion

    }

}
