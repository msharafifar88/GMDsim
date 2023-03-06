using areaandzone;
using BL;
using GUI.Calculation.Transformer_pu;
using GUI.GUIUtils;
using GUI.search;
using GUI.Transformer.TestData;
using network;
using persistent.enumeration;
using persistent.enumeration.Transformer;
using persistent.network.Transformers;
using Shapes.Transformer;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.Transformer
{
    public partial class Main3WTransformerMenu : Form
    {
        List<WindingTypeVectorHVLV> windingTypeVectorHVLVList;
        List<WindingTypeVectorHVTV> windingTypeVectorHVTVList;
        C3WTransformer transformer;
        TransformersCondition transformersCondition;
        public Main3WTransformerMenu(C3WTransformer input)
        {
            InitializeComponent();


            C3WTransformerBL transformerBL;
            transformerBL = new C3WTransformerBL();
            //transformer = transformerBL.add( CustomContentControl.getCurrentCase());
            transformer = input;
            ColorForm.ChangeCollorOFLabel(this);
            LoadData();
            comboBoxNominalUnit.DataSource = Enum.GetValues(typeof(NominalRatingUnit)).Cast<NominalRatingUnit>().ToList();
            comboBoxNominalUnit.SelectedItem = transformer.nominalData.NominalRatingUnit;
            comboBoxRatedVoltageUnit.DataSource = Enum.GetValues(typeof(RatedVoltageUnit)).Cast<RatedVoltageUnit>().ToList();
            comboBoxRatedVoltageUnit.SelectedItem = transformer.nominalData.RatedVoltageUnit;
            comboTransformerType.DataSource = Enum.GetValues(typeof(TransformerType)).Cast<TransformerType>().ToList();
            comboTransformerType.SelectedItem = transformer.transformertype;
            comboBoxCoreConstruction.DataSource = Enum.GetValues(typeof(CoreConstruction)).Cast<CoreConstruction>().ToList();
            comboBoxCoreConstruction.SelectedItem = transformer.coreConstruction;


            //  The following item is not added in the save method (limit tab)
            InsulationType.DataSource = InsulationList.getInsulations();
            InsulationType.SelectedItem = "Liquid-Fill";
            //
            CoolingClass.DataSource = CoolingClassList.getCoolingClass();
            CoolingClass.SelectedItem = "ONAN/ONAF/OFAF";
            //
            BIL.DataSource = BILValuesList.getBILValues();
            BIL.SelectedItem = "0";
            //
            TempRiseClass.DataSource = TempRiseList.getTempRise();
            TempRiseClass.SelectedItem = "65";


            transformersCondition = new TransformersCondition();
            if (Autotransformercheckboc.Checked == true)
            {
                autoWinding();

            }

            else
            {
                initWinding();
            }

            windingTypeVectorHVLVList = new List<WindingTypeVectorHVLV>();
            windingTypeVectorHVTVList = new List<WindingTypeVectorHVTV>();
            //selector();

        }

        public void LoadData()
        {
            transformerNameBox.Text = transformer.name;
            ID.Text = transformer.Identity;
            if (transformer.PrimaryBUS != null)
            {
                busNameHV.Text = transformer.PrimaryBUS.BusName;
                busNumberHV.Text = transformer.PrimaryBUS.BusNumber.ToString();
                AreaNameHV.Text = transformer.PrimaryBUS.area.Name;
                NaminalHV.Text = transformer.PrimaryBUS.nominalVoltage.ToString();
                areaNameTXT.Text = transformer.PrimaryBUS.area.Name;
                areaNumberTXT.Value = transformer.PrimaryBUS.area.Number;
                zoneNameTXT.Text = transformer.PrimaryBUS.zone.Name;
                zoneNumberTXT.Value = transformer.PrimaryBUS.zone.Number;
            }
            //ownerNameTXT.Text = transformer.o
            //subStationNumberTXT.Value = transformer.substation.Number;
            //subStationNameTXT.Text= transformer.substation.Name;
            comboBoxTV.SelectedItem = new ImageAndText(Properties.Resources.tr_tYg, LVtypeWindingConfiguration.yn, new Font("Times New Roman", 14));
            /// TAB General
            if (transformer.SecondaryBUS != null)
            {
                busNumberLV.Text = transformer.SecondaryBUS.BusNumber.ToString();
                busNameLV.Text = transformer.SecondaryBUS.BusName;
                AreaNameLV.Text = transformer.SecondaryBUS.area.Name;
                NaminalLV.Text = transformer.SecondaryBUS.nominalVoltage.ToString();

            }
            if (transformer.TertiaryBUS != null)
            {

                busNumberTV.Text = transformer.TertiaryBUS.BusNumber.ToString();
                busNameTV.Text = transformer.TertiaryBUS.BusName;
                AreaNameTV.Text = transformer.TertiaryBUS.area.Name;
                NaminalTV.Text = transformer.TertiaryBUS.nominalVoltage.ToString();
            }

            X1R1checkbox.Checked = transformer.X1R1check;
            PSCcheckbox.Checked = transformer.PSCcheck;
            NominalFrequencyBox.Text = transformer.nominalFrequency.ToString();
            NominalratingHV.Text = transformer.nominalData.PrimaryNominalRating.ToString();
            NominalratingLV.Text = transformer.nominalData.SecondaryNominalRating.ToString();
            NominalratingTV.Text = transformer.nominalData.TertiaryNominalRating.ToString();
            RatedVoltageHV.Text = transformer.nominalData.PrimaryRatedVoltage.ToString();
            RatedVoltageLV.Text = transformer.nominalData.SecondaryRatedVoltage.ToString();
            RatedVoltageTV.Text = transformer.nominalData.TertiaryRatedVoltage.ToString();
            Inservice.Checked = transformer.Inservice;

            /// TAB 3PART 1
            Z1HVLV.Text = transformer.impedances.Z1_HVLV.ToString();
            Z1HVTV.Text = transformer.impedances.Z1_HVTV.ToString();
            Z1LVTV.Text = transformer.impedances.Z1_LVTV.ToString();

            PscHVLV.Text = transformer.impedances.Psc_HVLV.ToString();
            PscHVTV.Text = transformer.impedances.Psc_HVTV.ToString();
            PscLVTV.Text = transformer.impedances.Psc_LVTV.ToString();

            X1HVLV.Text = transformer.impedances.X1_HVLV.ToString();
            X1HVTV.Text = transformer.impedances.X1_HVTV.ToString();
            X1LVTV.Text = transformer.impedances.X1_LVTV.ToString();


            R1HVLV.Text = transformer.impedances.R1_HVLV.ToString();
            R1HVTV.Text = transformer.impedances.R1_HVTV.ToString();
            R1LVTV.Text = transformer.impedances.R1_LVTV.ToString();
            //TAB3 PART 2
            Z0HVLV.Text = transformer.impedances.Z0_HVLV.ToString();
            Z0HVTV.Text = transformer.impedances.Z0_HVTV.ToString();
            Z0LVTV.Text = transformer.impedances.Z0_LVTV.ToString();

            X0HVLV.Text = transformer.impedances.X0_HVLV.ToString();
            X0HVTV.Text = transformer.impedances.X0_HVTV.ToString();
            X0LVTV.Text = transformer.impedances.X0_LVTV.ToString();


            R0HVLV.Text = transformer.impedances.R0_HVLV.ToString();
            R0HVTV.Text = transformer.impedances.R0_HVTV.ToString();
            R0LVTV.Text = transformer.impedances.R0_LVTV.ToString();



            //TAB 3 PART 3

            MagnetizConductace.Text = transformer.impedances.Magnetization_Conductance.ToString();
            MagnetizSusceptance.Text = transformer.impedances.Magnetization_Susceptance.ToString();
            NoLoadloss.Text = transformer.impedances.NoLosses.ToString();
            noMagnetizingCurrent.Text = transformer.impedances.MagnetizConductace_Current.ToString();

            //TAB3 PART 4
            RGHV.Text = transformer.impedances.RG_HVLV.ToString();
            RGLV.Text = transformer.impedances.RG_HVTV.ToString();
            RGTV.Text = transformer.impedances.RG_LVTV.ToString();
            XGHV.Text = transformer.impedances.XG_HVLV.ToString();
            XGLV.Text = transformer.impedances.XG_HVTV.ToString();
            XGTV.Text = transformer.impedances.XG_LVTV.ToString();

            //TAB4 PART FIX

            PrimHVNominalBox.Text = transformer.ltccontrol.FIXPrimNominalTurnRateHV.ToString();
            SecLVNominalBox.Text = transformer.ltccontrol.FIXSecNominalTurnRateLV.ToString();
            TerTVNominalBox.Text = transformer.ltccontrol.FIXTerNominalTurnRateTV.ToString();

            PrimHV_PhaseShiftBox.Text = transformer.ltccontrol.FIXPrimPhaseHV.ToString();
            SecLV_PhaseShiftBox.Text = transformer.ltccontrol.FIXSecPhaseLV.ToString();
            TerTV_PhaseShiftBox.Text = transformer.ltccontrol.FIXTerPhaseTV.ToString();

            // TAB 4 PART AVR

            PrimHVInitBox.Text = transformer.ltccontrol.AVRPrimNominalTurnRateHV.ToString();
            SecLVInitBox.Text = transformer.ltccontrol.AVRSecNominalTurnRateLV.ToString();
            TerTVInitBox.Text = transformer.ltccontrol.AVRerNominalTurnRateTV.ToString();

            // TAB 5 FIX LODING LIMITS

            NominPrim.Text = transformer.mvalimits.PrimaryNominal.ToString();
            NominSec.Text = transformer.mvalimits.SecendrayNominal.ToString();
            NominTer.Text = transformer.mvalimits.TertiaryNominal.ToString();
            SummerPrim.Text = transformer.mvalimits.PrimarySummer.ToString();
            SummerSec.Text = transformer.mvalimits.SecendraySummer.ToString();
            SummerTer.Text = transformer.mvalimits.TertiarySummer.ToString();
            WinterPrim.Text = transformer.mvalimits.PrimaryWinter.ToString();
            WinterSec.Text = transformer.mvalimits.SecendrayWinter.ToString();
            WinterTer.Text = transformer.mvalimits.TertiaryWinter.ToString();
            SummerEmergPrim.Text = transformer.mvalimits.PrimarySummerEmergancy.ToString();
            SummerEmergSec.Text = transformer.mvalimits.SecendraySummerEmergancy.ToString();
            SummerEmergTer.Text = transformer.mvalimits.TertiarySummerEmergancy.ToString();
            WinterEmergPrim.Text = transformer.mvalimits.PrimaryWinterEmergancy.ToString();
            WinterEmergSec.Text = transformer.mvalimits.SecendrayWinterEmergancy.ToString();
            WinterEmergTer.Text = transformer.mvalimits.TertiaryWinterEmergancy.ToString();

            // TAB 6 TOPOLOGY

            YokeAR.Text = transformer.topology.YMArea.ToString();
            YokeLR.Text = transformer.topology.YMAlength.ToString();
            ReturnAR.Text = transformer.topology.RMArea.ToString();
            ReturnLR.Text = transformer.topology.RMAlength.ToString();
            CoretoTank.Text = transformer.topology.CtoTAirgap.ToString();
            Tanksaturlvl.Text = transformer.topology.TSL.ToString();
            AircoreHV.Text = transformer.topology.AirHV.ToString();
            AircoreLV.Text = transformer.topology.AirLV.ToString();
            AircoreTV.Text = transformer.topology.AirTV.ToString();

            // TAB 7 TEST DATA

            WDCRHV.Text = transformer.testData.windingDCResistances.HV.ToString();
            WDCRLV.Text = transformer.testData.windingDCResistances.LV.ToString();
            WDCRTV.Text = transformer.testData.windingDCResistances.TV.ToString();

            WINDCAPHVG.Text = transformer.testData.windingCapacitances.HV_Ground.ToString();
            WINDCAPLVG.Text = transformer.testData.windingCapacitances.LV_Ground.ToString();
            WINDCAPTVG.Text = transformer.testData.windingCapacitances.TV_Ground.ToString();

            WINDCAPHLV.Text = transformer.testData.windingCapacitances.HV_LV.ToString();
            WINDCAPHTV.Text = transformer.testData.windingCapacitances.HV_TV.ToString();
            WINDCAPLTV.Text = transformer.testData.windingCapacitances.LV_TV.ToString();

            // TAB 9 EMT

            EMTPA.Text = transformer.emt.A.ToString();
            EMTPB.Text = transformer.emt.B.ToString();
            EMTPC.Text = transformer.emt.C.ToString();

            //TAB 12 RELIABILITY

            RPLAMA.Text = transformer.reliability.lambdaA.ToString();
            RPLAMP.Text = transformer.reliability.lambdaP.ToString();
            RPMu.Text = transformer.reliability.Mu.ToString();
            RPFOR.Text = transformer.reliability.FOR.ToString();
            RPMR.Text = transformer.reliability.MR.ToString();
            RPMTTF.Text = transformer.reliability.MTTF.ToString();
            RPMTTR.Text = transformer.reliability.MTTR.ToString();
            RArP.Text = transformer.reliability.rP.ToString();
            ASST.Text = transformer.reliability.SWtime.ToString();

            //Owner
            foreach (Owner o in transformer.ownerList)
            {

                OwnerNum1.Text = o.Number.ToString();
                OwnerNum2.Text = o.Number.ToString();
                OwnerNum3.Text = o.Number.ToString();
                OwnerNum4.Text = o.Number.ToString();
                OwnerNum5.Text = o.Number.ToString();
                OwnerNum6.Text = o.Number.ToString();
                OwnerNum7.Text = o.Number.ToString();
                OwnerNum8.Text = o.Number.ToString();
                OwnerName1.Text = o.Name;
                OwnerName2.Text = o.Name;
                OwnerName3.Text = o.Name;
                OwnerName4.Text = o.Name;
                OwnerName5.Text = o.Name;
                OwnerName6.Text = o.Name;
                OwnerName7.Text = o.Name;
                OwnerName8.Text = o.Name;
                OwnerFactor1.Value = (int)o.Percentage;
                OwnerFactor2.Value = (int)o.Percentage;
                OwnerFactor3.Value = (int)o.Percentage;
                OwnerFactor4.Value = (int)o.Percentage;
                OwnerFactor5.Value = (int)o.Percentage;
                OwnerFactor6.Value = (int)o.Percentage;
                OwnerFactor7.Value = (int)o.Percentage;
                OwnerFactor8.Value = (int)o.Percentage;


            }





        }
        public void autoWinding()
        {
            Font font = new Font("Times New Roman", 14);




            ImageAndText[] WindingHV =
            {
                new ImageAndText(Properties.Resources.tr_tY,HVtypeeWindingConfiguration.Y,font),
                new ImageAndText(Properties.Resources.tr_tYg,HVtypeeWindingConfiguration.YN,font),

            };
            ImageAndText[] WindingLV =
            {
                new ImageAndText(Properties.Resources.tr_tY,LVtypeWindingConfiguration.y,font),
                new ImageAndText(Properties.Resources.tr_tYg,LVtypeWindingConfiguration.yn,font),


            };
            ImageAndText[] WindingTV =
            {
                new ImageAndText(Properties.Resources.tr_tY,TVtypeWindingConfiguration.y,font),
                new ImageAndText(Properties.Resources.tr_tYg,TVtypeWindingConfiguration.yn,font),
                new ImageAndText(Properties.Resources.tr_tZg,TVtypeWindingConfiguration.zn,font),
                new ImageAndText(Properties.Resources.tr_tZ,TVtypeWindingConfiguration.z,font),
                new ImageAndText(Properties.Resources.tr_delta,TVtypeWindingConfiguration.d,font),
                new ImageAndText(Properties.Resources.tr_tDeltapng,TVtypeWindingConfiguration.od,font),

            };


            comboBoxHV.DisplayImagesAndText(WindingHV);
            comboBoxHV.Size = new System.Drawing.Size(60, 30);

            comboBoxLV.DisplayImagesAndText(WindingHV);
            comboBoxLV.Size = new System.Drawing.Size(60, 30);

            comboBoxLV.Enabled = false;
            /*
                        comboBoxTV.DisplayImagesAndText(WindingTV);
                        comboBoxTV.Size = new System.Drawing.Size(60, 30);*/
            comboBoxTV.Enabled = false;

        }
        public void initWinding()
        {
            Font font = new Font("Times New Roman", 14);




            ImageAndText[] WindingHV =
            {
                new ImageAndText(Properties.Resources.tr_tY,HVtypeeWindingConfiguration.Y,font),
                new ImageAndText(Properties.Resources.tr_tYg,HVtypeeWindingConfiguration.YN,font),
                new ImageAndText(Properties.Resources.tr_tZg,HVtypeeWindingConfiguration.ZN,font),
                new ImageAndText(Properties.Resources.tr_tZ,HVtypeeWindingConfiguration.Z,font),
                new ImageAndText(Properties.Resources.tr_delta,HVtypeeWindingConfiguration.D,font),

            };
            ImageAndText[] WindingLV =
            {
                new ImageAndText(Properties.Resources.tr_tY,LVtypeWindingConfiguration.y,font),
                new ImageAndText(Properties.Resources.tr_tYg,LVtypeWindingConfiguration.yn,font),
                new ImageAndText(Properties.Resources.tr_tZg,LVtypeWindingConfiguration.zn,font),
                new ImageAndText(Properties.Resources.tr_Z1,LVtypeWindingConfiguration.z,font),
                new ImageAndText(Properties.Resources.tr_delta,LVtypeWindingConfiguration.d,font),
                new ImageAndText(Properties.Resources.tr_tDeltapng,LVtypeWindingConfiguration.od,font),

            };
            ImageAndText[] WindingTV =
            {
                new ImageAndText(Properties.Resources.tr_tY,TVtypeWindingConfiguration.y,font),
                new ImageAndText(Properties.Resources.tr_tYg,TVtypeWindingConfiguration.yn,font),
                new ImageAndText(Properties.Resources.tr_tZg,TVtypeWindingConfiguration.zn,font),
                new ImageAndText(Properties.Resources.tr_tZ,TVtypeWindingConfiguration.z,font),
                new ImageAndText(Properties.Resources.tr_delta,TVtypeWindingConfiguration.d,font),
                new ImageAndText(Properties.Resources.tr_tDeltapng,TVtypeWindingConfiguration.od,font),

            };


            comboBoxHV.DisplayImagesAndText(WindingHV);
            comboBoxHV.SelectedItem = WindingHV[1];
            comboBoxHV.Size = new System.Drawing.Size(60, 30);

            comboBoxLV.DisplayImagesAndText(WindingLV);
            comboBoxLV.SelectedItem = WindingLV[1];
            comboBoxLV.Size = new System.Drawing.Size(60, 30);

            comboBoxTV.DisplayImagesAndText(WindingTV);
            comboBoxTV.SelectedItem = WindingTV[1];
            comboBoxTV.Size = new System.Drawing.Size(60, 30);

            comboBoxLV.Enabled = true;
            comboBoxTV.Enabled = true;

        }


        public void selector()
        {
            TransformersCondition transformersCondition = new TransformersCondition();
            ConditionWrapper conditionWrapperHVLV = new ConditionWrapper((HVtypeeWindingConfiguration)((ImageAndText)comboBoxHV.SelectedItem).Enumm, (LVtypeWindingConfiguration)((ImageAndText)comboBoxLV.SelectedItem).Enumm);
            List<string> degreeListHVLV = transformersCondition.FetchDegree(conditionWrapperHVLV);

            foreach (string degree in degreeListHVLV)
            {

                WindingTypeVectorHVLV windingTypeVectorHV = new WindingTypeVectorHVLV();
                windingTypeVectorHV.HVtypeeWinding = (HVtypeeWindingConfiguration)((ImageAndText)comboBoxHV.SelectedItem).Enumm;
                windingTypeVectorHV.LVtypeWinding = (LVtypeWindingConfiguration)((ImageAndText)comboBoxLV.SelectedItem).Enumm;
                windingTypeVectorHV.degre = degree;
                windingTypeVectorHVLVList.Add(windingTypeVectorHV);
            }
            vectorGroupHVLV.DataSource = windingTypeVectorHVLVList;

            WindingTypeVectorHVLV windingType = (WindingTypeVectorHVLV)vectorGroupHVLV.SelectedItem;
            int dgree = transformersCondition.FetchDegreeValue(windingType.degre);
            PhaseShiftdegHVLV.Text = dgree.ToString();

            ConditionWrapper conditionWrapperHVTV = new ConditionWrapper((HVtypeeWindingConfiguration)((ImageAndText)comboBoxHV.SelectedItem).Enumm, (TVtypeWindingConfiguration)((ImageAndText)comboBoxTV.SelectedItem).Enumm);
            List<string> degreeListHVTV = transformersCondition.FetchDegree(conditionWrapperHVTV);
            foreach (string degree in degreeListHVTV)
            {

                WindingTypeVectorHVTV windingTypeVectorHVTV = new WindingTypeVectorHVTV();
                windingTypeVectorHVTV.HVtypeeWinding = (HVtypeeWindingConfiguration)((ImageAndText)comboBoxHV.SelectedItem).Enumm;
                windingTypeVectorHVTV.TVtypeWinding = (TVtypeWindingConfiguration)((ImageAndText)comboBoxTV.SelectedItem).Enumm;
                windingTypeVectorHVTV.degre = degree;
                windingTypeVectorHVTVList.Add(windingTypeVectorHVTV);
            }


            vectorGroupHVTV.DataSource = windingTypeVectorHVTVList;

            WindingTypeVectorHVTV windingTypeVector = (WindingTypeVectorHVTV)vectorGroupHVTV.SelectedItem;
            int windingTypeVectordgree = transformersCondition.FetchDegreeValue(windingTypeVector.degre);
            PhaseShiftdegHVTV.Text = windingTypeVectordgree.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            selector();
            transformerNameBox.Text = vectorGroupHVLV.SelectedItem.ToString() + vectorGroupHVTV.SelectedItem.ToString();
        }

        private void changeSubstationBTN_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.LoadSubstationData();
            changeForm.ShowDialog();
        }

        private void changeZoneBTN_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.LoadZoneData();
            changeForm.ShowDialog();
        }

        private void changeAreaBTN_Click(object sender, EventArgs e)
        {
            ChangeForm changeForm = new ChangeForm();
            changeForm.LoadAreaData();
            changeForm.ShowDialog();
        }

        private void Autotransformercheckboc_CheckedChanged(object sender, EventArgs e)
        {
            if (Autotransformercheckboc.Checked == true)
            {
                autoWinding();

            }

            else
            {
                initWinding();
            }

        }

        private void comboBoxHV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Autotransformercheckboc.Checked == true)
            {
                comboBoxLV.SelectedItem = comboBoxHV.SelectedItem;
            }
        }

        private void vectorGroupHVLV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            WindingTypeVectorHVLV windingTypeVector = (WindingTypeVectorHVLV)vectorGroupHVLV.SelectedItem;
            int dgree = transformersCondition.FetchDegreeValue(windingTypeVector.degre);
            PhaseShiftdegHVLV.Text = dgree.ToString();
        }

        private void vectorGroupHVTV_SelectionChangeCommitted(object sender, EventArgs e)
        {
            WindingTypeVectorHVTV windingTypeVector = (WindingTypeVectorHVTV)vectorGroupHVTV.SelectedItem;
            int dgree = transformersCondition.FetchDegreeValue(windingTypeVector.degre);
            PhaseShiftdegHVTV.Text = dgree.ToString();
        }



        private void tabTransformetControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabTransformetControl.SelectedTab.Name.Contains("Impedances"))
            {
                HVpic.Image = ((ImageAndText)comboBoxHV.SelectedItem).Picture;
                LVpic.Image = ((ImageAndText)comboBoxLV.SelectedItem).Picture;
                TVpic.Image = ((ImageAndText)comboBoxTV.SelectedItem).Picture;
                showRGTVXGTV();

            }
            if (tabTransformetControl.SelectedTab.Name.Contains("Topology") && (((CoreConstruction)comboBoxCoreConstruction.SelectedItem).Equals(CoreConstruction.ThreeLeggedCoreType)))
            {
                ReturnAR.Enabled = false;
                ReturnLR.Enabled = false;

            }
            else
            {
                ReturnAR.Enabled = true;
                ReturnLR.Enabled = true;
            }

        }
        public void showRGTVXGTV()
        {

            if (((HVtypeeWindingConfiguration)((ImageAndText)comboBoxHV.SelectedItem).Enumm).Equals(HVtypeeWindingConfiguration.YN)
                   || (((HVtypeeWindingConfiguration)((ImageAndText)comboBoxHV.SelectedItem).Enumm).Equals(HVtypeeWindingConfiguration.ZN)))
            {
                RGHV.Enabled = XGHV.Enabled = true;
            }
            else
            {
                RGHV.Enabled = XGHV.Enabled = false;
            }
            if (((LVtypeWindingConfiguration)((ImageAndText)comboBoxLV.SelectedItem).Enumm).Equals(LVtypeWindingConfiguration.yn)
                  || (((LVtypeWindingConfiguration)((ImageAndText)comboBoxLV.SelectedItem).Enumm).Equals(LVtypeWindingConfiguration.zn)))
            {
                RGLV.Enabled = XGLV.Enabled = true;
            }
            else
            {
                RGLV.Enabled = XGLV.Enabled = false;
            }
            if (((TVtypeWindingConfiguration)((ImageAndText)comboBoxTV.SelectedItem).Enumm).Equals(TVtypeWindingConfiguration.yn)
                  || (((TVtypeWindingConfiguration)((ImageAndText)comboBoxTV.SelectedItem).Enumm).Equals(TVtypeWindingConfiguration.zn)))
            {
                RGTV.Enabled = XGTV.Enabled = true;
            }
            else
            {
                RGTV.Enabled = XGTV.Enabled = false;
            }

        }

        private void panelofLTC_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabTransformetControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboTransformerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTransformerType.SelectedItem.Equals(TransformerType.ThreePhase))
            {
                Windingconfig.Enabled = true;
                Zeroseqgroup1.Enabled = true;

            }
            else if (comboTransformerType.SelectedItem.Equals(TransformerType.SinglePhase))
            {
                Windingconfig.Enabled = false;
                Zeroseqgroup1.Enabled = false;
            }

        }

        private void PSCcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (PSCcheckbox.Checked == true)
            {

                X1HVLV.Enabled = false;
                X1HVTV.Enabled = false;
                X1LVTV.Enabled = false;
                R1HVTV.Enabled = false;
                R1HVLV.Enabled = false;
                R1LVTV.Enabled = false;
                PscHVLV.Enabled = true;
                PscHVTV.Enabled = true;
                PscLVTV.Enabled = true;
                Z1HVLV.Enabled = true;
                Z1HVTV.Enabled = true;
                Z1LVTV.Enabled = true;

            }
            else if (X1R1checkbox.Checked == true)
            {
                X1HVLV.Enabled = true;
                X1HVTV.Enabled = true;
                X1LVTV.Enabled = true;
                R1HVTV.Enabled = true;
                R1HVLV.Enabled = true;
                R1LVTV.Enabled = true;
                PscHVLV.Enabled = false;
                PscHVTV.Enabled = false;
                PscLVTV.Enabled = false;
                Z1HVLV.Enabled = false;
                Z1HVTV.Enabled = false;
                Z1LVTV.Enabled = false;
            }
        }

        private void checkBoxFIXTAB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFIXTAB.Checked == true)
            {
                groupBoxFix.Enabled = true;
                panelofLTC.Enabled = false;
                checkBoxAVR.CheckState = 0;
                checkBoxRPC.CheckState = 0;
                checkBoxPSC.CheckState = 0;
                labelPSC1.Text = "% Tap";
                labelPSC2.Text = "% Tap";
                labelPSC2.Visible = false;
                labelPSC1.Visible = false;
                labelaAVRtab1.Visible = true;
                labelaAVRtab2.Visible = true;
            }
        }


        private void checkBoxAVR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAVR.Checked == true)
            {

                groupBoxFix.Enabled = false;
                panelofLTC.Enabled = true;
                checkBoxFIXTAB.CheckState = 0;
                checkBoxRPC.CheckState = 0;
                checkBoxPSC.CheckState = 0;
                labelPSC1.Text = "% Tap";
                labelPSC2.Text = "% Tap";
                labelPSC2.Visible = false;
                labelPSC1.Visible = false;
                labelaAVRtab1.Visible = true;
                labelaAVRtab2.Visible = true;
            }

        }

        private void checkBoxRPC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRPC.Checked == true)
            {

                groupBoxFix.Enabled = false;
                panelofLTC.Enabled = true;
                checkBoxFIXTAB.CheckState = 0;
                labelPSC1.Text = "% Tap";
                labelPSC2.Text = "% Tap";
                checkBoxAVR.CheckState = 0;
                checkBoxPSC.CheckState = 0;
                labelPSC2.Visible = false;
                labelPSC1.Visible = false;
                labelaAVRtab1.Visible = true;
                labelaAVRtab2.Visible = true;
            }
        }

        private void checkBoxPSC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPSC.Checked == true)
            {

                groupBoxFix.Enabled = false;
                panelofLTC.Enabled = true;
                checkBoxFIXTAB.CheckState = 0;
                checkBoxAVR.CheckState = 0;
                checkBoxRPC.CheckState = 0;
                labelaAVRtab1.Visible = false;
                labelaAVRtab2.Visible = false;
                labelPSC1.Text = "Phase Shift";
                labelPSC2.Text = "Phase Shift";
                labelPSC2.Visible = true;
                labelPSC1.Visible = true;
            }
        }

        private void TAP_DIC_Click(object sender, EventArgs e)
        {
            LTC_TapDependentImpedance tapDependentImpedance = new LTC_TapDependentImpedance(transformer);
            tapDependentImpedance.ShowDialog();
        }

        private void buttonHVLTC_Click(object sender, EventArgs e)
        {
            LoadTAPChanger loadTAP = new LoadTAPChanger(checkBoxAVR.Checked, checkBoxRPC.Checked, checkBoxPSC.Checked, transformer);
            loadTAP.ShowDialog();
        }

        private void buttonSecLV_Click(object sender, EventArgs e)
        {
            LoadTAPChanger loadTAP = new LoadTAPChanger(checkBoxAVR.Checked, checkBoxRPC.Checked, checkBoxPSC.Checked, transformer);
            loadTAP.ShowDialog();
        }

        private void buttonTerTV_Click(object sender, EventArgs e)
        {
            LoadTAPChanger loadTAP = new LoadTAPChanger(checkBoxAVR.Checked, checkBoxRPC.Checked, checkBoxPSC.Checked, transformer);
            loadTAP.ShowDialog();
        }

        private void X1R1checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (PSCcheckbox.Checked == true)
            {

                X1HVLV.Enabled = false;
                X1HVTV.Enabled = false;
                X1LVTV.Enabled = false;
                R1HVTV.Enabled = false;
                R1HVLV.Enabled = false;
                R1LVTV.Enabled = false;
                PscHVLV.Enabled = true;
                PscHVTV.Enabled = true;
                PscLVTV.Enabled = true;
                Z1HVLV.Enabled = true;
                Z1HVTV.Enabled = true;
                Z1LVTV.Enabled = true;

            }
            else if (X1R1checkbox.Checked == true)
            {
                X1HVLV.Enabled = true;
                X1HVTV.Enabled = true;
                X1LVTV.Enabled = true;
                R1HVTV.Enabled = true;
                R1HVLV.Enabled = true;
                R1LVTV.Enabled = true;
                PscHVLV.Enabled = false;
                PscHVTV.Enabled = false;
                PscLVTV.Enabled = false;
                Z1HVLV.Enabled = false;
                Z1HVTV.Enabled = false;
                Z1LVTV.Enabled = false;
            }
        }

        private void magnetizationcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (magnetizationcheckbox.Checked == true)
            {

                MagnetizConductace.Enabled = true;
                MagnetizSusceptance.Enabled = true;
                noload.Checked = false;
                NoLoadloss.Enabled = false;
                noMagnetizingCurrent.Enabled = false;

            }
            else if (noload.Checked == true)
            {

                MagnetizConductace.Enabled = false;
                MagnetizSusceptance.Enabled = false;
                magnetizationcheckbox.Checked = false;
                NoLoadloss.Enabled = true;
                noMagnetizingCurrent.Enabled = true;

            }
        }



        private void checkBoxHV_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBoxAVR.Checked == true || checkBoxRPC.Checked == true || checkBoxPSC.Checked == true) && checkBoxHV.Checked == true)
            {
                buttonHVLTC.Enabled = true;
                checkBoxStateEstimateHV.Enabled = true;
            }
            else if ((checkBoxAVR.Checked == true || checkBoxRPC.Checked == true || checkBoxPSC.Checked == true) && checkBoxHV.Checked == false)
            {
                buttonHVLTC.Enabled = false;
                checkBoxStateEstimateHV.Enabled = false;

            }
        }

        private void checkBoxTV_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBoxAVR.Checked == true || checkBoxRPC.Checked == true || checkBoxPSC.Checked == true) && checkBoxTV.Checked == true)
            {
                buttonTerTV.Enabled = true;
                checkBoxStateEstimateTV.Enabled = true;
            }
            else if ((checkBoxAVR.Checked == true || checkBoxRPC.Checked == true || checkBoxPSC.Checked == true) && checkBoxTV.Checked == false)
            {
                buttonTerTV.Enabled = false;
                checkBoxStateEstimateTV.Enabled = false;
            }
        }

        private void checkBoxLV_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBoxAVR.Checked == true || checkBoxRPC.Checked == true || checkBoxPSC.Checked == true) && checkBoxLV.Checked == true)
            {
                buttonSecLV.Enabled = true;
                checkBoxStateEstimateLV.Enabled = true;
            }
            else if ((checkBoxAVR.Checked == true || checkBoxRPC.Checked == true || checkBoxPSC.Checked == true) && checkBoxLV.Checked == false)
            {
                buttonSecLV.Enabled = false;
                checkBoxStateEstimateLV.Enabled = false;
            }
        }

        private void DynamicRatings_CheckedChanged(object sender, EventArgs e)
        {
            if (DynamicRatings.Checked == true)
            {

                DynamicRatePanel.Enabled = true;

            }
            else if (DynamicRatings.Checked == false)
            {

                DynamicRatePanel.Enabled = false;

            }
        }

        private void FixLoadLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (FixLoadLimit.Checked == true)
            {

                FixLoadLimitpanle.Enabled = true;

            }
            else if (FixLoadLimit.Checked == false)
            {

                FixLoadLimitpanle.Enabled = false;

            }
        }

        private void checkBoxAirHV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAirHV.Checked == true)
            {
                AircoreHV.Enabled = true;
            }
            else if (checkBoxAirHV.Checked == false)
            {
                AircoreHV.Enabled = false;
            }
        }

        private void checkBoxAirLV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAirLV.Checked == true)
            {
                AircoreLV.Enabled = true;
            }
            else if (checkBoxAirLV.Checked == false)
            {
                AircoreLV.Enabled = false;
            }
        }

        private void checkBoxAirTV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAirTV.Checked == true)
            {
                AircoreTV.Enabled = true;
            }
            else if (checkBoxAirTV.Checked == false)
            {
                AircoreTV.Enabled = false;
            }
        }

        private void ChecklWindCap_CheckedChanged(object sender, EventArgs e)
        {
            if (ChecklWindCap.Checked == true)
            {
                gradientPanelWindCap.Enabled = true;

            }
            else if (ChecklWindCap.Checked == false)
            {
                gradientPanelWindCap.Enabled = false;

            }
        }

        private void checkWindDCRes_CheckedChanged(object sender, EventArgs e)
        {

            if (checkWindDCRes.Checked == true)
            {
                gradientPanelWindDCRes.Enabled = true;

            }
            else if (checkWindDCRes.Checked == false)
            {
                gradientPanelWindDCRes.Enabled = false;

            }
        }



        private void buttonZeroSeqImped_Click(object sender, EventArgs e)
        {
            gradientPanelZeroSeqImpedance ZeroSeqImpedancepanle = new gradientPanelZeroSeqImpedance(transformer);
            ZeroSeqImpedancepanle.ShowDialog();
        }

        private void ButtonNoLoad_Click(object sender, EventArgs e)
        {
            gradientPanelNoLoadTest noloadtestpanel = new gradientPanelNoLoadTest(transformer);
            noloadtestpanel.ShowDialog();
        }

        private void ZeroSeqChara_Click(object sender, EventArgs e)
        {
            gradientPanelZeroSeqCharacteristic ZeroSeqCharacteristicpanel = new gradientPanelZeroSeqCharacteristic(transformer);
            ZeroSeqCharacteristicpanel.ShowDialog();
        }

        private void QGIC_Click(object sender, EventArgs e)
        {
            QGIC ZQGICpanel = new QGIC(transformer);
            ZQGICpanel.ShowDialog();
        }

        private void checkReplacmentAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkReplacmentAvailable.Checked == true)
            {
                ReplacmentAvailablepanel.Enabled = true;
            }
            else if (checkReplacmentAvailable.Checked == false)
            {
                ReplacmentAvailablepanel.Enabled = false;
            }

        }

        private void Sele(object sender, EventArgs e)
        {
            //  selector();
        }

        //Set format, default value and naming depending on the selected Cooling Class
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CoolingClass.SelectedItem.ToString().Split('/')).Count() == 3)
            {
                coolType1Box.Text = CoolingClass.SelectedItem.ToString().Split('/')[0];
                coolType1Box.Visible = true;
                coolType2Box.Text = CoolingClass.SelectedItem.ToString().Split('/')[1];
                coolType2Box.Visible = true;
                coolType3Box.Text = CoolingClass.SelectedItem.ToString().Split('/')[2];
                coolType3Box.Visible = true;
                coolType1Double.Text = "1000";
                coolType2Double.Text = "1000";
                coolType3Double.Text = "1000";

            }
            else if ((CoolingClass.SelectedItem.ToString().Split('/')).Count() == 2)
            {
                coolType1Box.Text = CoolingClass.SelectedItem.ToString().Split('/')[0];
                coolType1Box.Visible = true;
                coolType2Box.Text = CoolingClass.SelectedItem.ToString().Split('/')[1];
                coolType2Box.Visible = true;
                coolType3Box.Visible = false;
                coolType1Double.Text = "1000";
                coolType2Double.Text = "1000";
                coolType3Double.Text = "-9999";

            }
            else
            {
                coolType1Box.Text = CoolingClass.SelectedItem.ToString().Split('/')[0];
                coolType1Box.Visible = true;
                coolType2Box.Visible = false;
                coolType3Box.Visible = false;
                coolType1Double.Text = "1000";
                coolType2Double.Text = "-9999";
                coolType3Double.Text = "-9999";

            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Boolean save()
        {
            try
            {

                transformer.nominalData.NominalRatingUnit = (NominalRatingUnit)comboBoxNominalUnit.SelectedItem;
                transformer.nominalData.RatedVoltageUnit = (RatedVoltageUnit)comboBoxRatedVoltageUnit.SelectedItem;
                transformer.transformertype = (TransformerType)comboTransformerType.SelectedItem;
                transformer.coreConstruction = (CoreConstruction)comboBoxCoreConstruction.SelectedItem;


                transformer.name = transformerNameBox.Text;
                transformer.Identity = ID.Text;
                if (transformer.PrimaryBUS != null)
                {
                    transformer.PrimaryBUS.area.Name = areaNameTXT.Text;
                    transformer.PrimaryBUS.area.Number = Convert.ToInt64(areaNumberTXT.Value);
                    transformer.PrimaryBUS.zone.Name = zoneNameTXT.Text;
                    transformer.PrimaryBUS.zone.Number = Convert.ToInt64(zoneNumberTXT.Value);
                }

                // ??  comboBoxTV.SelectedItem = new ImageAndText(Properties.Resources.tr_tYg, LVtypeWindingConfiguration.yn, new Font("Times New Roman", 14));
                /// TAB General
                if (transformer.SecondaryBUS != null)
                {
                    /*   transformer.PrimaryBUS.BusName = busNameHV.Text;
                       transformer.PrimaryBUS.BusNumber= long.Parse(busNumberHV.Text );
                       transformer.PrimaryBUS.area.Name = AreaNameHV.Text;
                       transformer.PrimaryBUS.nominalVoltage =float.Parse( NaminalHV.Text);
   */
                    transformer.SecondaryBUS.BusNumber = long.Parse(busNumberLV.Text);
                    transformer.SecondaryBUS.BusName = busNameLV.Text;
                    transformer.SecondaryBUS.area.Name = AreaNameLV.Text;
                    transformer.SecondaryBUS.nominalVoltage = float.Parse(NaminalLV.Text);






                }
                if (transformer.TertiaryBUS != null)
                {
                    transformer.TertiaryBUS.BusNumber = long.Parse(busNumberLV.Text);
                    transformer.TertiaryBUS.BusName = busNameLV.Text;
                    transformer.TertiaryBUS.area.Name = AreaNameLV.Text;
                    transformer.TertiaryBUS.nominalVoltage = float.Parse(NaminalLV.Text);
                }

                transformer.X1R1check = X1R1checkbox.Checked;
                transformer.PSCcheck = PSCcheckbox.Checked;
                transformer.nominalFrequency = float.Parse(NominalFrequencyBox.Text);
                transformer.nominalData.PrimaryNominalRating = double.Parse(NominalratingHV.Text);
                transformer.nominalData.SecondaryNominalRating = double.Parse(NominalratingLV.Text);
                transformer.nominalData.TertiaryNominalRating = double.Parse(NominalratingTV.Text);
                transformer.nominalData.PrimaryRatedVoltage = double.Parse(RatedVoltageHV.Text);
                transformer.nominalData.SecondaryRatedVoltage = double.Parse(RatedVoltageLV.Text);
                transformer.nominalData.TertiaryRatedVoltage = double.Parse(RatedVoltageTV.Text);
                transformer.Inservice = Inservice.Checked;

                /// TAB 3PART 1
                transformer.impedances.Z1_HVLV = double.Parse(Z1HVLV.Text);
                transformer.impedances.Z1_HVTV = double.Parse(Z1HVTV.Text);
                transformer.impedances.Z1_LVTV = double.Parse(Z1LVTV.Text);

                transformer.impedances.Psc_HVLV = double.Parse(PscHVLV.Text);
                transformer.impedances.Psc_HVTV = double.Parse(PscHVTV.Text);
                transformer.impedances.Psc_LVTV = double.Parse(PscLVTV.Text);

                transformer.impedances.X1_HVLV = double.Parse(X1HVLV.Text);
                transformer.impedances.X1_HVTV = double.Parse(X1HVTV.Text);
                transformer.impedances.X1_LVTV = double.Parse(X1LVTV.Text);


                transformer.impedances.R1_HVLV = double.Parse(R1HVLV.Text);
                transformer.impedances.R1_HVTV = double.Parse(R1HVTV.Text);
                transformer.impedances.R1_LVTV = double.Parse(R1LVTV.Text);
                //TAB3 PART 2
                transformer.impedances.Z0_HVLV = double.Parse(Z0HVLV.Text);
                transformer.impedances.Z0_HVTV = double.Parse(Z0HVTV.Text);
                transformer.impedances.Z0_LVTV = double.Parse(Z0LVTV.Text);

                transformer.impedances.X0_HVLV = double.Parse(X0HVLV.Text);
                transformer.impedances.X0_HVTV = double.Parse(X0HVTV.Text);
                transformer.impedances.X0_LVTV = double.Parse(X0LVTV.Text);


                transformer.impedances.R0_HVLV = double.Parse(R0HVLV.Text);
                transformer.impedances.R0_HVTV = double.Parse(R0HVTV.Text);
                transformer.impedances.R0_LVTV = double.Parse(R0LVTV.Text);



                //TAB 3 PART 3

                transformer.impedances.Magnetization_Conductance = double.Parse(MagnetizConductace.Text);
                transformer.impedances.Magnetization_Susceptance = double.Parse(MagnetizSusceptance.Text);
                transformer.impedances.NoLosses = double.Parse(NoLoadloss.Text);
                transformer.impedances.MagnetizConductace_Current = double.Parse(noMagnetizingCurrent.Text);

                //TAB3 PART 4
                transformer.impedances.RG_HVLV = double.Parse(RGHV.Text);
                transformer.impedances.RG_HVTV = double.Parse(RGLV.Text);
                transformer.impedances.RG_LVTV = double.Parse(RGTV.Text);
                transformer.impedances.XG_HVLV = double.Parse(XGHV.Text);
                transformer.impedances.XG_HVTV = double.Parse(XGLV.Text);
                transformer.impedances.XG_LVTV = double.Parse(XGTV.Text);

                //TAB4 PART FIX

                transformer.ltccontrol.FIXPrimNominalTurnRateHV = int.Parse(PrimHVNominalBox.Text);
                transformer.ltccontrol.FIXSecNominalTurnRateLV = int.Parse(SecLVNominalBox.Text);
                transformer.ltccontrol.FIXTerNominalTurnRateTV = int.Parse(TerTVNominalBox.Text);

                transformer.ltccontrol.FIXPrimPhaseHV = int.Parse(PrimHV_PhaseShiftBox.Text);
                transformer.ltccontrol.FIXSecPhaseLV = int.Parse(SecLV_PhaseShiftBox.Text);
                transformer.ltccontrol.FIXTerPhaseTV = int.Parse(TerTV_PhaseShiftBox.Text);

                // TAB 4 PART AVR

                transformer.ltccontrol.AVRPrimNominalTurnRateHV = Convert.ToInt32(PrimHVInitBox.Value);
                transformer.ltccontrol.AVRSecNominalTurnRateLV = Convert.ToInt32(SecLVInitBox.Value);
                transformer.ltccontrol.AVRerNominalTurnRateTV = Convert.ToInt32(TerTVInitBox.Value);

                // TAB 5 FIX LODING LIMITS

                transformer.mvalimits.PrimaryNominal = double.Parse(NominPrim.Text);
                transformer.mvalimits.SecendrayNominal = double.Parse(NominSec.Text);
                transformer.mvalimits.TertiaryNominal = double.Parse(NominTer.Text);
                transformer.mvalimits.PrimarySummer = double.Parse(SummerPrim.Text);
                transformer.mvalimits.SecendraySummer = double.Parse(SummerSec.Text);
                transformer.mvalimits.TertiarySummer = double.Parse(SummerTer.Text);
                transformer.mvalimits.PrimaryWinter = double.Parse(WinterPrim.Text);
                transformer.mvalimits.SecendrayWinter = double.Parse(WinterSec.Text);
                transformer.mvalimits.TertiaryWinter = double.Parse(WinterTer.Text);

                transformer.mvalimits.PrimarySummerEmergancy = double.Parse(SummerEmergPrim.Text);
                transformer.mvalimits.SecendraySummerEmergancy = double.Parse(SummerEmergSec.Text);
                transformer.mvalimits.TertiarySummerEmergancy = double.Parse(SummerEmergTer.Text);
                transformer.mvalimits.PrimaryWinterEmergancy = double.Parse(WinterEmergPrim.Text);
                transformer.mvalimits.SecendrayWinterEmergancy = double.Parse(WinterEmergSec.Text);
                transformer.mvalimits.TertiaryWinterEmergancy = double.Parse(WinterEmergTer.Text);

                // TAB 6 TOPOLOGY

                transformer.topology.YMArea = double.Parse(YokeAR.Text);
                transformer.topology.YMAlength = double.Parse(YokeLR.Text);
                transformer.topology.RMArea = double.Parse(ReturnAR.Text);
                transformer.topology.RMAlength = double.Parse(ReturnLR.Text);
                transformer.topology.CtoTAirgap = double.Parse(CoretoTank.Text);
                transformer.topology.TSL = double.Parse(Tanksaturlvl.Text);
                transformer.topology.AirHV = double.Parse(AircoreHV.Text);
                transformer.topology.AirLV = double.Parse(AircoreLV.Text);
                transformer.topology.AirTV = double.Parse(AircoreTV.Text);

                // TAB 7 TEST DATA

                transformer.testData.windingDCResistances.HV = double.Parse(WDCRHV.Text);
                transformer.testData.windingDCResistances.LV = double.Parse(WDCRLV.Text);
                transformer.testData.windingDCResistances.TV = double.Parse(WDCRTV.Text);

                transformer.testData.windingCapacitances.HV_Ground = double.Parse(WINDCAPHVG.Text);
                transformer.testData.windingCapacitances.LV_Ground = double.Parse(WINDCAPLVG.Text);
                transformer.testData.windingCapacitances.TV_Ground = double.Parse(WINDCAPTVG.Text);

                transformer.testData.windingCapacitances.HV_LV = double.Parse(WINDCAPHLV.Text);
                transformer.testData.windingCapacitances.HV_TV = double.Parse(WINDCAPHTV.Text);
                transformer.testData.windingCapacitances.LV_TV = double.Parse(WINDCAPLTV.Text);

                // TAB 9 EMT

                transformer.emt.A = double.Parse(EMTPA.Text);
                transformer.emt.B = double.Parse(EMTPB.Text);
                transformer.emt.C = double.Parse(EMTPC.Text);

                //TAB 12 RELIABILITY

                transformer.reliability.lambdaA = double.Parse(RPLAMA.Text);
                transformer.reliability.lambdaP = double.Parse(RPLAMP.Text);
                transformer.reliability.Mu = double.Parse(RPMu.Text);
                transformer.reliability.FOR = double.Parse(RPFOR.Text);
                transformer.reliability.MR = double.Parse(RPMR.Text);
                transformer.reliability.MTTF = double.Parse(RPMTTF.Text);
                transformer.reliability.MTTR = double.Parse(RPMTTR.Text);
                transformer.reliability.rP = double.Parse(RArP.Text);
                transformer.reliability.SWtime = double.Parse(ASST.Text);

                //Owner
                foreach (Owner o in transformer.ownerList)
                {

                    o.Number = long.Parse(OwnerNum1.Text);
                    o.Number = long.Parse(OwnerNum2.Text);
                    o.Number = long.Parse(OwnerNum3.Text);
                    o.Number = long.Parse(OwnerNum4.Text);
                    o.Number = long.Parse(OwnerNum5.Text);
                    o.Number = long.Parse(OwnerNum6.Text);
                    o.Number = long.Parse(OwnerNum7.Text);
                    o.Number = long.Parse(OwnerNum8.Text);
                    o.Name = OwnerName1.Text;
                    o.Name = OwnerName2.Text;
                    o.Name = OwnerName3.Text;
                    o.Name = OwnerName4.Text;
                    o.Name = OwnerName5.Text;
                    o.Name = OwnerName6.Text;
                    o.Name = OwnerName7.Text;
                    o.Name = OwnerName8.Text;
                    o.Percentage = Convert.ToInt32(OwnerFactor1.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor2.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor3.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor4.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor5.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor6.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor7.Value);
                    o.Percentage = Convert.ToInt32(OwnerFactor8.Value);


                }




                return true;
            }
            catch
            {
                MessageBox.Show("Save Record Exception");
                return false;
            }

        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (Main_Menu.GetClickedDiagramNode() is CustomC3WShape)
            {
                var item = ((Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).FirstOrDefault();
                if (item != null && item is CustomC3WShape)
                {
                    int i = 0;
                    foreach (AnnotationEditorViewModel img in (item as CustomC3WShape).Annotations as IEnumerable<object>)
                    {
                        if (i == 0)
                        {
                            img.Content = (Main_Menu.GetClickedDiagramNode() as CustomC3WShape).getImageListLocation()[comboBoxHV.SelectedIndex];
                        }
                        else if (i == 1)
                        {
                            img.Content = (Main_Menu.GetClickedDiagramNode() as CustomC3WShape).getImageListLocation()[comboBoxLV.SelectedIndex];
                        }
                        else
                        {
                            img.Content = (Main_Menu.GetClickedDiagramNode() as CustomC3WShape).getImageListLocation()[comboBoxTV.SelectedIndex];
                        }
                        i++;
                    };
                }
            }


            if (PSCcheckbox.Checked == true && X1R1checkbox.Checked == false)
            {
                transformer.transformer_pu.R1_2_pu = Convert_w3ctransformer_pu.calculateR1_2_puPsc(transformer);
                transformer.transformer_pu.X1_2_pu = Convert_w3ctransformer_pu.calculateX1_2_puPsc(transformer);

                transformer.transformer_pu.R1_3_pu = Convert_w3ctransformer_pu.calculateR1_3_puPsc(transformer);
                transformer.transformer_pu.X1_3_pu = Convert_w3ctransformer_pu.calculateX1_3_puPsc(transformer);


                transformer.transformer_pu.R2_3_pu = Convert_w3ctransformer_pu.calculateR2_3_puPsc(transformer);
                transformer.transformer_pu.X2_3_pu = Convert_w3ctransformer_pu.calculateX2_3_puPsc(transformer);
            }

            if (X1R1checkbox.Checked == true && PSCcheckbox.Checked == false)
            {
                transformer.transformer_pu.R1_2_pu = Convert_w3ctransformer_pu.calculateR1_2_puX1R1(transformer);
                transformer.transformer_pu.X1_2_pu = Convert_w3ctransformer_pu.calculateX1_2_puX1R1(transformer);

                transformer.transformer_pu.R1_3_pu = Convert_w3ctransformer_pu.calculateR1_3_puX1R1(transformer);
                transformer.transformer_pu.X1_3_pu = Convert_w3ctransformer_pu.calculateX1_3_puX1R1(transformer);


                transformer.transformer_pu.R2_3_pu = Convert_w3ctransformer_pu.calculateR2_3_puX1R1(transformer);
                transformer.transformer_pu.X2_3_pu = Convert_w3ctransformer_pu.calculateX2_3_puX1R1(transformer);
            }

            save();
        }

        private void OwnerSameAsBus_CheckStateChanged(object sender, EventArgs e)
        {
            if (OwnerSameAsBus.CheckState.Equals(1))
            {
                List<Owner> owners = transformer.PrimaryBUS.owners;
                transformer.ownerList = owners;
            }
            else if (OwnerSameAsBus.CheckState.Equals(0))
            {
                transformer.ownerList = new List<Owner>(7);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (Main_Menu.GetClickedDiagramNode() is CustomC3WShape)
            {
                var item = ((Main_Menu.GetCurrentDiagram().SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).FirstOrDefault();
                if (item != null && item is CustomC3WShape)
                {
                    int i = 0;
                    foreach (AnnotationEditorViewModel img in (item as CustomC3WShape).Annotations as IEnumerable<object>)
                    {
                        if (i == 0)
                        {
                            img.Content = (Main_Menu.GetClickedDiagramNode() as CustomC3WShape).getImageListLocation()[comboBoxHV.SelectedIndex];
                        }
                        else if (i == 1)
                        {
                            img.Content = (Main_Menu.GetClickedDiagramNode() as CustomC3WShape).getImageListLocation()[comboBoxLV.SelectedIndex];
                        }
                        else
                        {
                            img.Content = (Main_Menu.GetClickedDiagramNode() as CustomC3WShape).getImageListLocation()[comboBoxTV.SelectedIndex];
                        }
                        i++;
                    };
                }
            }


            if (PSCcheckbox.Checked == true && X1R1checkbox.Checked == false)
            {
                transformer.transformer_pu.R1_2_pu = Convert_w3ctransformer_pu.calculateR1_2_puPsc(transformer);
                transformer.transformer_pu.X1_2_pu = Convert_w3ctransformer_pu.calculateX1_2_puPsc(transformer);

                transformer.transformer_pu.R1_3_pu = Convert_w3ctransformer_pu.calculateR1_3_puPsc(transformer);
                transformer.transformer_pu.X1_3_pu = Convert_w3ctransformer_pu.calculateX1_3_puPsc(transformer);


                transformer.transformer_pu.R2_3_pu = Convert_w3ctransformer_pu.calculateR2_3_puPsc(transformer);
                transformer.transformer_pu.X2_3_pu = Convert_w3ctransformer_pu.calculateX2_3_puPsc(transformer);
            }

            if (X1R1checkbox.Checked == true && PSCcheckbox.Checked == false)
            {
                transformer.transformer_pu.R1_2_pu = Convert_w3ctransformer_pu.calculateR1_2_puX1R1(transformer);
                transformer.transformer_pu.X1_2_pu = Convert_w3ctransformer_pu.calculateX1_2_puX1R1(transformer);

                transformer.transformer_pu.R1_3_pu = Convert_w3ctransformer_pu.calculateR1_3_puX1R1(transformer);
                transformer.transformer_pu.X1_3_pu = Convert_w3ctransformer_pu.calculateX1_3_puX1R1(transformer);


                transformer.transformer_pu.R2_3_pu = Convert_w3ctransformer_pu.calculateR2_3_puX1R1(transformer);
                transformer.transformer_pu.X2_3_pu = Convert_w3ctransformer_pu.calculateX2_3_puX1R1(transformer);

            }
            this.Close();
        }
    }

}
