/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/
using System;

namespace K2host.Threading.Interface
{

    /// <summary>
    /// This is used to help create the object class you define.
    /// </summary>
    public interface IThreadCpu : IDisposable
    {
        
        /// <summary>
        /// 
        /// </summary>
        int CpuId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        IThreadManager Parent { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        IThread[] Threads { get; set; }

    }

}
