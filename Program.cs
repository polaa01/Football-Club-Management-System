namespace HCI_Fudbalski_Klub
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            ApplicationConfiguration.Initialize();
            CustomApplicationContext appContext = new CustomApplicationContext();
            AppContext.Context = appContext;
            Application.Run(appContext);
        }
    }
}