/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/
using System;
using System.Linq;

using K2host.Core;
using K2host.Threading.Extentions;
using K2host.Threading.Interface;

namespace K2host.Threading.Classes
{
    /// <summary>
    /// This class helps you manage threads in any application / and OS
    /// </summary>
    public class OThreadManager : IThreadManager
    {

        /// <summary>
        /// 
        /// </summary>
        public IThreadedTimer Threadtimer { get; }

        /// <summary>
        /// 
        /// </summary>
        public int SelectedCpuId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool OsDependent { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public IThreadCpu[] Cpus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OThreadManager()
        {

            Threadtimer = new OThreadedTimer(1000);
            Cpus        = Array.Empty<IThreadCpu>();

            for (int k = 0; k < Environment.ProcessorCount; k++)
                Cpus = Cpus.Append(new OThreadCpu(k, this)).ToArray();

            Threadtimer.OnTickEvent += this.DisposeThreads;
            Threadtimer.Start();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOsDependent"></param>
        public OThreadManager(bool isOsDependent)
            : this()
        {
            OsDependent = isOsDependent;
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
                    Cpus.ForEach(cpu => { cpu.Dispose(); });
                    Cpus.Dispose(out _);
                }

            IsDisposed = true;
        }

        #endregion

    }

}
