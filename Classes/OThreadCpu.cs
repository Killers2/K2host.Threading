/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

using System.Threading;
using K2host.Core;
using K2host.Threading.Delegates;
using K2host.Threading.Extentions;
using K2host.Threading.Interface;

namespace K2host.Threading.Classes
{
   
    public class OThreadCpu : IThreadCpu
    {

        /// <summary>
        /// 
        /// </summary>
        public int CpuId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IThreadManager Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IThread[] Threads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="parent"></param>
        public OThreadCpu(int uid, IThreadManager parent)
        {
            Threads     = Array.Empty<IThread>();
            CpuId       = uid;
            Parent      = parent;
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
                    Threads?.ForEach(t => {
                        try { t.Dispose(); } catch { }
                    });

                    Threads?.Dispose(out _);
                }

            IsDisposed = true;
        }

        #endregion

    }


}
