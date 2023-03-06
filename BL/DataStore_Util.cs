using DAO;

namespace BL
{
    public class DataStore_Util
    {
        public bool DataStore_HasData(persistent.Case cases)
        {

            if (DataStored.findAllBuses(cases).Count == 0 && DataStored.findAllC2WTransformer(cases).Count == 0 && DataStored.findAllMultiPhaseLine(cases).Count == 0 && DataStored.findAllC(cases).Count == 0
                && DataStored.findAllDoubleCircuitLine(cases).Count == 0 && DataStored.findAllEVs(cases).Count == 0 && DataStored.findAllGenerator(cases).Count == 0 && DataStored.findAllwires(cases).Count == 0
                   && DataStored.findAllL(cases).Count == 0 && DataStored.findAllLC(cases).Count == 0 && DataStored.findAllLoads(cases).Count == 0 && DataStored.findAllPVGen(cases).Count == 0
                      && DataStored.findAllR(cases).Count == 0 && DataStored.findAllRL(cases).Count == 0 && DataStored.findAllRLC(cases).Count == 0 && DataStored.findAllSingle3phaseLine(cases).Count == 0
                         && DataStored.findAllWindGen(cases).Count == 0 && DataStored.findAllSwitchedShunt(cases).Count == 0 && DataStored.findAllSyncGen(cases).Count == 0 && DataStored.findAllTriTransformer(cases).Count == 0)
            {
                return true;
            }
            else { return false; }

        }
        public void remove_Data(persistent.Case cases)
        {
            DataStored.removeAllBuses(cases);
            DataStored.removeAllC2WTransformer(cases);
            DataStored.removeAllMultiPhaseLine(cases);
            DataStored.removeAllC(cases);
            DataStored.removeAllDoubleCircuitLine(cases);
            DataStored.removeAllEVs(cases);
            DataStored.removeAllGenerator(cases);
            DataStored.removeAllWire(cases);
            DataStored.removeAllL(cases);
            DataStored.removeAllLC(cases);
            DataStored.removeAllLoads(cases);
            DataStored.removeAllPVGen(cases);
            DataStored.removeAllR(cases);
            DataStored.removeAllRL(cases);
            DataStored.removeAllRLC(cases);
            DataStored.removeAllSingle3phaseLine(cases);
            DataStored.removeAllWindGen(cases);
            DataStored.removeAllSwitchedShunt(cases);
            DataStored.removeAllSyncGen(cases);
            DataStored.removeAllTriTransformer(cases);


        }

    }



}
