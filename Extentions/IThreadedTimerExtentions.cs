/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/
using System.Threading;
using K2host.Threading.Interface;

namespace K2host.Threading.Extentions
{

    public static class IThreadedTimerExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void Initiate(this IThreadedTimer e)
        {
            e.TimeThread = new Thread(new ThreadStart(e.OnTick));
            e.TimeThread.TrySetApartmentState(ApartmentState.MTA);
            e.TimeThread.IsBackground = true;
            try 
            { 
                e.TimeThread.Start();
            }
            catch
            {
                Thread.Sleep(2);
                e.TimeThread = new Thread(new ThreadStart(e.OnTick));
                e.TimeThread.TrySetApartmentState(ApartmentState.MTA);
                e.TimeThread.IsBackground = true;
                e.TimeThread.Start();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void Pause(this IThreadedTimer e)
        {
            e.PauseTimer = true;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void UnPause(this IThreadedTimer e)
        {
            e.PauseTimer = false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void Start(this IThreadedTimer e)
        {

            e.Stop();

            if (e.TimeThread != null)
            {
                try { e.TimeThread = null; }
                catch { }
            }


            if (e.TimeThread == null)
            {

                e.Kill = false;

                e.TimeThread = new Thread(new ThreadStart(e.OnTick));
                e.TimeThread.TrySetApartmentState(ApartmentState.MTA);
                e.TimeThread.IsBackground = true;

                try
                {
                    e.TimeThread.Start();
                }
                catch
                {
                    Thread.Sleep(5);
                    e.Start();
                }

            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void Stop(this IThreadedTimer e)
        {
            e.Kill = true;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private static void OnTick(this IThreadedTimer e)
        {
            while (!e.Kill)
            {
                Thread.Sleep(e.Interval);

                if (!e.PauseTimer)
                    e.OnTickEvent?.Invoke(e);

            }
        }

    }

}
