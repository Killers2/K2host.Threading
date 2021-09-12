/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/
using System;
using System.Diagnostics;
using System.Threading;

using K2host.Core;
using K2host.Threading.Delegates;
using K2host.Threading.Interface;

namespace K2host.Threading.Classes
{
   
    public class OThread : IThread
    {

        /// <summary>
        /// 
        /// </summary>
        public OnThreadDisposedHandler OnThreadDisposed { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public IThreadCpu ThreadCpu { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Uid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int ProcessorAffinity { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool OsDependent { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ProcessThread CurrentThread { get { return Process.GetCurrentProcess().Threads[0]; } }
        
        /// <summary>
        /// 
        /// </summary>
        public Thread ManagedThread { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsBackground { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ThreadStart ManagedThreadStart { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ParameterizedThreadStart ManagedParameterizedThreadStart { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ApartmentState ManagedApartmentState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public OThread(ThreadStart e)
        {
            ManagedThreadStart      = e;
            ManagedApartmentState   = ApartmentState.MTA;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public OThread(ParameterizedThreadStart e)
        {
            ManagedParameterizedThreadStart = e;
            ManagedApartmentState           = ApartmentState.MTA;
        }

        /// <summary>
        /// Used to block wait rather than sleep, therefor can only be used in side a thread (MTA)
        /// This is an alternative to Thread.Sleep() and can be lower than 1ms
        /// </summary>
        /// <param name="durationSeconds">The amount of seconds you want to wait.</param>
        public static void Sleep(double durationSeconds)
        {
            var a = Stopwatch.StartNew();
            while (a.ElapsedTicks < Math.Round(durationSeconds * Stopwatch.Frequency)) { }
        }


        #region Destructor

        bool IsDisposed = false;

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

                    ManagedThreadStart              = null;
                    ManagedParameterizedThreadStart = null;

                    if (OnThreadDisposed != null)
                        OnThreadDisposed.Invoke(this);

                    ThreadCpu.Threads = ThreadCpu.Threads.Filter(t => t != this);

                }

            IsDisposed = true;
        }

        #endregion

    }


}
