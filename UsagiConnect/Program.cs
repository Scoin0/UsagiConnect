using log4net;
using System;
using System.Threading;
using System.Windows.Forms;
using UsagiConnect.WForms;

namespace UsagiConnect
{
    internal static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program).Name);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new MainForm());
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Debug(e.Exception.StackTrace);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Debug((e.ExceptionObject as Exception).StackTrace);
        }
    }
}