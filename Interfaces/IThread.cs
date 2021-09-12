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
using K2host.Threading.Delegates;

namespace K2host.Threading.Interface
{

    /// <summary>
    /// This is used to help create the object class you define.
    /// </summary>
    public interface IThread : IDisposable
    {
        
        /// <summary>
        /// 
        /// </summary>
        int Uid { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        IThreadCpu ThreadCpu { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        OnThreadDisposedHandler OnThreadDisposed { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        int ProcessorAffinity { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        bool OsDependent { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        ProcessThread CurrentThread { get; }
        
        /// <summary>
        /// 
        /// </summary>
        Thread ManagedThread { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool IsBackground { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ThreadStart ManagedThreadStart { get; }

        /// <summary>
        /// 
        /// </summary>
        public ParameterizedThreadStart ManagedParameterizedThreadStart { get; }

        /// <summary>
        /// 
        /// </summary>
        public ApartmentState ManagedApartmentState { get; set; }

    }

}
