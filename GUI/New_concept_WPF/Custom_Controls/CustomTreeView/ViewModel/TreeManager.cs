using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Utility;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace GUI.New_concept_WPF
{
    public class TreeManager
    {
        private ObservableCollection<TreeNodeWPF> elementNodeInfo;

        public TreeManager()
        {
            GenerateSource();
        }

        public ObservableCollection<TreeNodeWPF> ElementNodeInfo
        {
            get { return elementNodeInfo; }
            set { this.elementNodeInfo = value; }
        }

        public static BitmapSource ImageSourceFromBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        private void GenerateSource()
        {
            
/*            var nodeImageInfo = new ObservableCollection<TreeNodeWPF>();
            var machines = new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.root, ElementName = "Machines", ElementIcon = ImageSourceFromBitmap(Properties.Resources.generator_tree) };
            var buses = new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.root, ElementName = "Buses", ElementIcon = ImageSourceFromBitmap(Properties.Resources.bus_tree) };
            var loads = new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.root, ElementName = "Loads", ElementIcon = ImageSourceFromBitmap(Properties.Resources.load2_tree) };
            var transformers = new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.root, ElementName = "Transformers", ElementIcon = ImageSourceFromBitmap(Properties.Resources.transformer_tree) };
            var lines = new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.root, ElementName = "Lines", ElementIcon = ImageSourceFromBitmap(Properties.Resources.lines_tree) };
            var rlc = new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.root, ElementName = "RLC Elements", ElementIcon = ImageSourceFromBitmap(Properties.Resources.rlc_tree) };

            machines.SubFiles = new ObservableCollection<TreeNodeWPF> {
                new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.Generator, ElementName = "Generator", ElementIcon =  ImageSourceFromBitmap(Properties.Resources.generator_tree) },
                new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.SyncGen, ElementName = "Sync Gen.", ElementIcon = ImageSourceFromBitmap(Properties.Resources.synchgen) },
                new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.Wind, ElementName = "Wind Generator", ElementIcon = ImageSourceFromBitmap(Properties.Resources.WindGen) },              
                new TreeNodeWPF() { EnumItem = persistent.common.ItemEnum.PVPnels, ElementName = "PV Panels", ElementIcon = ImageSourceFromBitmap(Properties.Resources.PV_panel1) }

            };

            buses.SubFiles = new ObservableCollection<TreeNodeWPF>
            {
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.Bus, ElementName = "Bus", ElementIcon = ImageSourceFromBitmap(Properties.Resources.bus)}
            };

            loads.SubFiles = new ObservableCollection<TreeNodeWPF>
            {
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.Load, ElementName = "Load", ElementIcon = ImageSourceFromBitmap(Properties.Resources.load)},
                new TreeNodeWPF() {  EnumItem = persistent.common.ItemEnum.EvMachine, ElementName = "EV Machine", ElementIcon = ImageSourceFromBitmap(Properties.Resources.EV) }
            };
            transformers.SubFiles = new ObservableCollection<TreeNodeWPF>
            {
              //  new TreeNodeWPF(){ ElementName = "Triphasic", ElementIcon = null},
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.W2, ElementName = "Custom 2W", ElementIcon = ImageSourceFromBitmap(Properties.Resources.tr_Y)},
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.YgDD, ElementName = "YgDD", ElementIcon = null},
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.YgD, ElementName = "YgD", ElementIcon = null},
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.W3, ElementName = "Custom 3W", ElementIcon = null}
            };

            lines.SubFiles = new ObservableCollection<TreeNodeWPF>
            {
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.ThreePhase, ElementName = "Three-Phase", ElementIcon = null},
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.SinglePhase,ElementName = "Single circuit", ElementIcon = null},
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.DualPhase, ElementName = "Double circuit", ElementIcon = null}
            };

            rlc.SubFiles = new ObservableCollection<TreeNodeWPF>
            {
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.C, ElementName = "C", ElementIcon = null},
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.L, ElementName = "L", ElementIcon = null},
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.R, ElementName = "R", ElementIcon = null},
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.LC, ElementName = "LC", ElementIcon = null},
                new TreeNodeWPF(){ EnumItem = persistent.common.ItemEnum.RL , ElementName = "RL", ElementIcon = null},
                new TreeNodeWPF(){  EnumItem = persistent.common.ItemEnum.RLC, ElementName = "RLC", ElementIcon = null}
            };

            nodeImageInfo.Add(machines);
            nodeImageInfo.Add(buses);
            nodeImageInfo.Add(loads);
            nodeImageInfo.Add(transformers);
            nodeImageInfo.Add(lines);
            nodeImageInfo.Add(rlc);*/
            TreeCreator treeCreator = new TreeCreator();
            elementNodeInfo = treeCreator.CreateWpfTree();
        }
    }
}


