/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/

using System.Linq;

using K2host.Threading.Interface;

namespace K2host.Threading.Extentions
{

    public static class IThreadCpuExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IThread Add(this IThreadCpu e, IThread t)
        {
            t.Uid               = e.Threads.Length;
            t.ThreadCpu         = e;
            t.ProcessorAffinity = (e.CpuId + 1);
            t.OsDependent       = e.Parent.OsDependent;
            t.OnThreadDisposed += e.ThreadDispose;
            e.Threads           = e.Threads.Append(t).ToArray();
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="t"></param>
        private static void ThreadDispose(this IThreadCpu e, IThread t)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public static void DisposeThreads(this IThreadCpu e)
        {

            int count = e.Threads.Length;
            
            try
            {

                for (int j = 0; j < count; j++)
                {
                    IThread t = e.Threads[j];
                    try
                    {
                        if ((t.ManagedThread.ThreadState == System.Threading.ThreadState.Aborted) ||
                            (t.ManagedThread.ThreadState == System.Threading.ThreadState.Stopped) ||
                            (t.ManagedThread.ThreadState == System.Threading.ThreadState.Suspended) ||
                            (t.ManagedThread.ThreadState == System.Threading.ThreadState.Unstarted) ||
                            (t.ManagedThread.ThreadState == System.Threading.ThreadState.AbortRequested) ||
                            (t.ManagedThread.ThreadState == System.Threading.ThreadState.StopRequested) ||
                            (t.ManagedThread.ThreadState == System.Threading.ThreadState.SuspendRequested))
                        {
                            t.Dispose();
                            count--;
                        }
                    }
                    catch
                    {
                        count--;
                    }
                }

            }
            catch { }

        }

    }

}
