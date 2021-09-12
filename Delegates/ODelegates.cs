/*
' /====================================================\
'| Developed Tony N. Hyde (www.k2host.co.uk)            |
'| Projected Started: 2019-07-13                        | 
'| Use: General                                         |
' \====================================================/
*/

using K2host.Threading.Interface;

namespace K2host.Threading.Delegates
{
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    public delegate void OnThreadDisposedHandler(IThread e);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    public delegate void OnTickEventHandler(IThreadedTimer e);

}
