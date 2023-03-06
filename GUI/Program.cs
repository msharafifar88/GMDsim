using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Reducing blurry test and elements
            //if (Environment.OSVersion.Version.Major >= 6)

            Console.WriteLine("args[{0}] == {1}");
            //    SetProcessDPIAware();
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkWFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSHxWd0NnWn9ZdHBTRg==;Mgo+DSMBPh8sVXJ0S0J+XE9AclRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0dmWHlac3RSQmZZUQ==;ORg4AjUWIQA/Gnt2VVhkQlFacltJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRhXH5YdHdVQWRUVEQ=;MTAwNjQ4MEAzMjMwMmUzNDJlMzBFQTNBUGRId25qa3NkaWp0U3RuekxwbnJ6eG1kLytZR1FRNGhkL2l3d3l3PQ==;MTAwNjQ4MUAzMjMwMmUzNDJlMzBkR2pPTmpVOGZWYmpDMkJaSm1Mcy90aXU4bm80elg1cFd1T3B4YkxQU3pBPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtGVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUViW3pfdnBWRmdZWUR2;MTAwNjQ4M0AzMjMwMmUzNDJlMzBYQzdmRmdRczRvcjBZbld2V2d5NzJKSkt1eDRueFViVE5ybU92WFlxMUkwPQ==;MTAwNjQ4NEAzMjMwMmUzNDJlMzBJclBQcDVvVjNtcTkvVlJsR3lsekNMcjJla3VJRG9Gd3VLb1AxTGU5eFc0PQ==;Mgo+DSMBMAY9C3t2VVhkQlFacltJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRhXH5YdHdVQWZbVUQ=;MTAwNjQ4NkAzMjMwMmUzNDJlMzBnYU42T1hyelBVRGh4cmc2QjFRbVEvcXVySUliSWczNWdHR05BbUtnWkc0PQ==;MTAwNjQ4N0AzMjMwMmUzNDJlMzBha1lhTHkvNmhaMmVwUVhWVHBpbEF2L0hDZnQzNXN1eXo3RW5uWnBqWDdvPQ==;MTAwNjQ4OEAzMjMwMmUzNDJlMzBYQzdmRmdRczRvcjBZbld2V2d5NzJKSkt1eDRueFViVE5ybU92WFlxMUkwPQ==");
                if (args.Contains("-silent"))
                {

                    for (int i = 0; i < args.Length; i++)
                    {
                        Console.WriteLine("args[{0}] == {1}", i, args[i]);
                    }
                    // commandline
                }
                else

                    SfSkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);
                SfSkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2019Theme).Assembly);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form form = new Main_Menu();
                Application.Run(form);

                SfSkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);
                SfSkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2019Theme).Assembly);
                Application.EnableVisualStyles();
               // Application.SetCompatibleTextRenderingDefault(false);
                //Form form = new Main_Menu();
               // Application.Run(form);
            }
            catch (Exception e)
            {
                MessageBox.Show (e.ToString());
            }
          

        }
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern bool SetProcessDPIAware();
    }
}
