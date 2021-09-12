/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/

using K2host.Core;
using K2host.Threading.Interface;

namespace K2host.Threading.Extentions
{

    public static class IThreadManagerExtentions
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static IThread Add(this IThreadManager m, IThread e)
        {

            if (m.SelectedCpuId >= m.Cpus.Length)
                m.SelectedCpuId = 0;

            m.Cpus[m.SelectedCpuId].Add(e);

            m.SelectedCpuId++;

            return e;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="_"></param>
        public static void DisposeThreads(this IThreadManager m, IThreadedTimer _)
        {
            m.Cpus.ForEach(cpu => { cpu.DisposeThreads(); });
        }

    }

}
