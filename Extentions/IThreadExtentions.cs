/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/

using System;
using System.Runtime.InteropServices;
using System.Threading;

using K2host.Threading.Interface;

namespace K2host.Threading.Extentions
{

    public static class IThreadExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool Start(this IThread e, object o = null)
        {

            if ((e.ManagedThreadStart == null) && (e.ManagedParameterizedThreadStart == null))
                throw new InvalidOperationException();

            if (e.ManagedThreadStart != null)
                e.ManagedThread = new Thread(e.ManagedThreadStart);

            if (e.ManagedParameterizedThreadStart != null)
                e.ManagedThread = new Thread(e.ManagedParameterizedThreadStart);

            e.ManagedThread.TrySetApartmentState(e.ManagedApartmentState);
            e.ManagedThread.IsBackground = e.IsBackground;

            if (!e.OsDependent)
            {
                try
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && e.ProcessorAffinity != 0)
                    {
                        Thread.BeginThreadAffinity();
                        e.CurrentThread.ProcessorAffinity = new IntPtr(e.ProcessorAffinity);
                    }
                    else 
                    {
                        e.OsDependent                   = true;
                        e.ThreadCpu.Parent.OsDependent  = true;
                    }
                }
                catch
                {
                    e.OsDependent                   = true;
                    e.ThreadCpu.Parent.OsDependent  = true;
                }
            }

            if (e.ManagedThreadStart != null)
                e.ManagedThread.Start();

            if (e.ManagedParameterizedThreadStart != null)
                e.ManagedThread.Start(o);

            if (!e.OsDependent)
            {
                try
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        e.CurrentThread.ProcessorAffinity = new IntPtr(0xFFFF);
                        Thread.EndThreadAffinity();
                    }
                    else
                    {
                        e.OsDependent                   = true;
                        e.ThreadCpu.Parent.OsDependent  = true;
                    }
                }
                catch
                {
                    e.OsDependent                   = true;
                    e.ThreadCpu.Parent.OsDependent  = true;
                }
            }

            return true;
        }




    }

}
