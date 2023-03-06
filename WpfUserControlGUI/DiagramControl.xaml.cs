using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using network;
using persistent;
using System.Runtime.CompilerServices;
using WpfUserControlGUI;

namespace WpfUserControlGUI
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DiagramControl : UserControl
    {
        public DiagramControl()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY5MDI2QDMxMzgyZTM0MmUzMFZjTkJxdlBzcFY3V2c1aWNuRWRSdm9vbzlxQnpzcHlxbnc3N3o1Unh0YVU9");
            InitializeComponent();
        }
    }
}
