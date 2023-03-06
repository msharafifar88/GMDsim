using network;
using persistent.enumeration;
using persistent.line;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace GUI.Line.Condcutor_Data
{
    public partial class TransmissionLine_CondcutorData : UserControl
    {
        ConductorDataOnce ConductorDataOnce;
        LineBranches line;
        public TransmissionLine_CondcutorData(LineBranches lineBranches)
        {
            InitializeComponent();
            line = lineBranches;
            lengthTypeUnitT.DataSource = Enum.GetValues(typeof(LengthUnitType)).Cast<LengthUnitType>().ToList();
            ConductorDataOnce = lineBranches.LineConductor.conductorDataOnce;
            numberofphasesevalue.Value = ConductorDataOnce.NumberOfPhase;
            Rzerosequencevalue.Value = ConductorDataOnce.Rzerosequence;
            Lzerosequencevalue.Value = ConductorDataOnce.Lzerosequence;
            Gzerosequencevalue.Value = ConductorDataOnce.Gzerosequence;
            Czerosequencevalue.Value = ConductorDataOnce.Czerosequence;
            Rpositiveequencevalue.Value = ConductorDataOnce.Rpositionsequence;
            Lpositiveequencevalue.Value = ConductorDataOnce.Lpositionsequence;
            Gpositiveequencevalue.Value = ConductorDataOnce.Gpositionsequence;
            Cpositiveequencevlue.Value = ConductorDataOnce.Cpositionsequence;
            Frequencyvalue.Value = ConductorDataOnce.Frequency;
            DCresistancevalue.Value = ConductorDataOnce.DCresistance;
        }
        private void lengthTypeUnitT_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lengthTypeUnitT.SelectedItem.Equals(LengthUnitType.Metric))
            {
                kmT.Visible = true;
                mileT.Visible = false;

            }
            else
            {
                kmT.Visible = false;
                mileT.Visible = true;
            }
        }

        private void TransmissionLine_CondcutorData_Leave(object sender, EventArgs e)
        {
            ConductorDataOnce.Rzerosequence = (double)Rzerosequencevalue.Value;
            ConductorDataOnce.Lzerosequence = (double)Lzerosequencevalue.Value;
            ConductorDataOnce.Gzerosequence = (double)Gzerosequencevalue.Value;
            ConductorDataOnce.Czerosequence = (double)Czerosequencevalue.Value;
            ConductorDataOnce.Rpositionsequence = (double)Rpositiveequencevalue.Value;
            ConductorDataOnce.Lpositionsequence = (double)Lpositiveequencevalue.Value;
            ConductorDataOnce.Gpositionsequence = (double)Gpositiveequencevalue.Value;
            ConductorDataOnce.Cpositionsequence = (double)Cpositiveequencevlue.Value;
            ConductorDataOnce.Frequency = (double)Frequencyvalue.Value;
            ConductorDataOnce.DCresistance = (double)DCresistancevalue.Value;
        }
    }

}
