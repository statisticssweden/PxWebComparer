using System;
using System.Windows.Forms;
using PxWebComparer.Business;
using PxWebComparer.Forms;

namespace PxApiComparer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var handler = new CompareHandler();

            try
            {
                
                handler.CompareSavedQueryMetaPxsq();
                handler.CompareSavedQueryMetaDatabase();
                handler.Compare();
                            
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ResultForm());
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
