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
    public interface IThreadManager : IDisposable
    {

        /// <summary>
        /// 
        /// </summary>
        IThreadedTimer Threadtimer { get; }

        /// <summary>
        /// 
        /// </summary>
        int SelectedCpuId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool OsDependent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IThreadCpu[] Cpus { get; set; }

    }

}
