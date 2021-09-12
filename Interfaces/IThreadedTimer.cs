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

namespace K2host.Threading.Interface
{

    /// <summary>
    /// This is used to help create the object class you define.
    /// </summary>
    public interface IThreadedTimer : IDisposable
    {
        /// <summary>
        /// The thread this time will run on
        /// </summary>
        Thread TimeThread { get; set; }
        
        /// <summary>
        /// Used to kill the thread the time is using
        /// </summary>
        bool Kill { get; set; }
        
        /// <summary>
        /// Used to pause and unpause the timer.
        /// </summary>
        bool PauseTimer { get; set; }

        /// <summary>
        /// The call back event on timer tick
        /// </summary>
        OnTickEventHandler OnTickEvent { get; set; }

        /// <summary>
        /// The interval timeout
        /// </summary>
        int Interval { get; set; }


    }

}
