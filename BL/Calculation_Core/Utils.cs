using BL.Calculation_Core.ItemWraper;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Calculation_Core
{
    public class Utils {

        public static Dictionary<String, PointerInt> test = new Dictionary<String, PointerInt>();
        public static float StringToFloat(string s)
        {
            return s.Contains("-") ? -float.Parse(s.Replace("-", ""), NumberStyles.Float) : float.Parse(s, NumberStyles.Float) ;
        }
        public static double StringToDouble(string s)
        {
            return s.Contains("-") ? -double.Parse(s.Replace("-", "")) : double.Parse(s);
        }

        public static Boolean ISSparse(Matrix<System.Numerics.Complex> matrix)
        {
            int counter = 0;
            for(int i= 0; i<matrix.RowCount; i++)
            {
                for (int j =0; j<matrix.ColumnCount; j++)
                {
                    var v = matrix[i, j];
                    if (v ==0)
                    {
                        counter++;
                    }
                }
            }

            return (counter > (matrix.RowCount * matrix.ColumnCount) / 2);
        }

        public static Matrix<System.Numerics.Complex> createSparseMatirix(int row,int column ,Vector<System.Numerics.Complex> data)
        {
            Matrix<System.Numerics.Complex> matrix = Matrix<System.Numerics.Complex>.Build.Sparse(row, column);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == j)
                        matrix[i, j] = data[i];
                }
            }
            return matrix;
        }
        public static Matrix<System.Numerics.Complex> createSparseMatirix(int row, int column, Matrix<System.Numerics.Complex> data)
        {
            Matrix<System.Numerics.Complex> matrix = Matrix<System.Numerics.Complex>.Build.Sparse(row, column);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == j)
                        matrix[i, j] = data[i,j];
                }
            }
            return matrix;
        }

        public static Vector<System.Numerics.Complex> Creat_vecor_conj(Vector<System.Numerics.Complex> vector)
        {

            Vector<System.Numerics.Complex> vector_ =Vector<System.Numerics.Complex>.Build.Dense(vector.Count());
           
            vector_ = vector.Conjugate();

           

                return vector_;
        }

        public static Matrix<Double> Cal_dS_dVa_PVPQ_Real(Matrix<System.Numerics.Complex> dS_dVa, List<BusDataWrapper> busDataWrapperList)
        {
            
       
        
            List<BusDataWrapper> FindPVPQ = Utils.FindPVPQ(busDataWrapperList);
           
            int count =  FindPVPQ.Count;
     
            List<PointerInt> pointerInt = FindListOfPointerPVPQForMatrix(busDataWrapperList);
            pointerInt.Count();
           // test.Count();
            List<double> lis = new List<double>();
            // test.ForEach(x => lis.Add(dS_dVa[x.i, x.j].Real));
            pointerInt.ForEach(x => lis.Add(dS_dVa[x.i, x.j].Real));

            Matrix<double> matrix_ = Matrix<double>.Build.Dense(count, count);
            int k = 0;
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    {
                        /*int index = i * count + j;
                        */
                        matrix_[i, j] = lis[k++];
                    }

                }
            Console.WriteLine(" Cal_PVPQ_Real" + matrix_);
            return matrix_;

            
        }
        public static Matrix<Double> Cal_dS_dVm_PVPQ_Real(Matrix<System.Numerics.Complex> dS_dVm, List<BusDataWrapper> busDataWrapperList)
        {
      
      
            List<BusDataWrapper> FindPQ = Utils.FindPQ(busDataWrapperList);
            List<BusDataWrapper> FindPVPQ = Utils.FindPVPQ(busDataWrapperList);
            int countPQ = FindPQ.Count;
            int countPVPQ = FindPVPQ.Count;
            List<PointerInt> pointerInt = FindListOfPointerPQForMatrix(busDataWrapperList);
           // test.Count();
            List<double> lis = new List<double>();
            pointerInt.ForEach(x => lis.Add(dS_dVm[x.i, x.j].Real));
           

            Matrix<double> matrix_ = Matrix<double>.Build.Dense(countPVPQ, countPQ);
            int k = 0;
            for (int i = 0; i < countPVPQ; i++)
                for (int j = 0; j < countPQ; j++)
                {
                    {
                        /*int index = i * count + j;
                        */

                        matrix_[i, j] = lis[k++];

                    }

                }



          //  Console.WriteLine(" Cal_dS_dVm_PVPQ_Real" + matrix_);
            return matrix_;
        }
        public static Matrix<Double> Cal_dS_dVa_PQ_Imaginery(Matrix<System.Numerics.Complex> dS_dVa, List<BusDataWrapper> busDataWrapperList)
        {

            List<BusDataWrapper> FindPQ = Utils.FindPQ(busDataWrapperList);
            List<BusDataWrapper> FindPVPQ = Utils.FindPVPQ(busDataWrapperList);
            int countPQ = FindPQ.Count;
            int countPVPQ = FindPVPQ.Count;
            List<PointerInt> pointerInt = FindListOfPointerPQForMatrix_PVPQ(busDataWrapperList);
            List<double> lis = new List<double>();
            // test.Count();
            pointerInt.ForEach(x => lis.Add(dS_dVa[x.i, x.j].Imaginary));
           
            Matrix<double> matrix_ = Matrix<double>.Build.Dense(countPQ,countPVPQ );
            int k = 0;
            for (int i = 0; i < countPQ; i++)
                for (int j = 0; j < countPVPQ; j++)
                {
                    {
                    

                        matrix_[i, j] = lis[k++];

                    }

                }



           // Console.WriteLine(" Cal_dS_dVa_PQ_Imaginery" + matrix_);
            return matrix_;
        }
        public static Matrix<Double> Cal_dS_dVm_PQ_Imaginery(Matrix<System.Numerics.Complex> dS_dVm, List<BusDataWrapper> busDataWrapperList)
        {

            List<BusDataWrapper> FindPQ = Utils.FindPQ(busDataWrapperList);
            
            int countPQ = FindPQ.Count;
        
            List<PointerInt> pointerInt = FindListOfPointerPQForMatrix_PQ(busDataWrapperList);
            List<double> lis = new List<double>();
            // test.Count();
            pointerInt.ForEach(x => lis.Add(dS_dVm[x.i, x.j].Imaginary));

            Matrix<double> matrix_ = Matrix<double>.Build.Dense(countPQ, countPQ);
            int k = 0;
            for (int i = 0; i < countPQ; i++)
                for (int j = 0; j < countPQ; j++)
                {
                    {


                        matrix_[i, j] = lis[k++];

                    }

                }



         //   Console.WriteLine(" Cal_dS_dVm_PQ_Imaginery" + matrix_);
            return matrix_;
        }

        //

        public static Matrix<Double> Cal_BP_PVPQ(Matrix<double> Bp, List<BusDataWrapper> busDataWrapperList)
        {


            List<BusDataWrapper> FindPV = new List<BusDataWrapper>();
            List<BusDataWrapper> FindPQ = new List<BusDataWrapper>();
            List<BusDataWrapper> FindPVPQ = Utils.FindPVPQ(busDataWrapperList);

            int count = FindPVPQ.Count;

            List<PointerInt> pointerInt = FindListOfPointerPVPQForMatrix(busDataWrapperList);
            List<double> lis = new List<double>();
            pointerInt.Count();
            pointerInt.ForEach(x => lis.Add(Bp[x.i, x.j]));
           

            Matrix<double> matrix_ = Matrix<double>.Build.Dense(count, count);
            int k = 0;
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    {
                        /*int index = i * count + j;
                        */

                        matrix_[i, j] = lis[k++];

                    }

                }



            //Console.WriteLine(" Cal_PVPQ_Real" + matrix_);
            return matrix_;


        }


        public static Matrix<Double> Cal_Bpp_PQ_PQ(Matrix<double> Bpp, List<BusDataWrapper> busDataWrapperList)
        {

            List<BusDataWrapper> FindPQ = Utils.FindPQ(busDataWrapperList);

            int countPQ = FindPQ.Count;

            List<PointerInt> pointerInt = FindListOfPointerPQForMatrix_PQ(busDataWrapperList);
            List<double> lis = new List<double>();
            pointerInt.Count();
            pointerInt.ForEach(x => lis.Add(Bpp[x.i, x.j]));
            

            Matrix<double> matrix_ = Matrix<double>.Build.Dense(countPQ, countPQ);
            int k = 0;
            for (int i = 0; i < countPQ; i++)
                for (int j = 0; j < countPQ; j++)
                {
                    {


                        matrix_[i, j] = lis[k++];

                    }

                }



            //   Console.WriteLine(" Cal_dS_dVm_PQ_Imaginery" + matrix_);
            return matrix_;
        }


        public static List<BusDataWrapper> FindPVPQ (List<BusDataWrapper> busDataWrappers)
        {
            List<BusDataWrapper> PVPQ = new List<BusDataWrapper>();

            PVPQ.AddRange(busDataWrappers.FindAll(bus => bus.bus_type.Equals(2)).ToList());
            PVPQ.AddRange(busDataWrappers.FindAll(bus => bus.bus_type.Equals(1)).ToList());
            return PVPQ;
        }
        public static List<BusDataWrapper> FindPQ(List<BusDataWrapper> busDataWrappers)
        {
            List<BusDataWrapper> PQ = new List<BusDataWrapper>();

            
            PQ.AddRange(busDataWrappers.FindAll(bus => bus.bus_type.Equals(1)).ToList());
            return PQ;
        }
        public static List<BusDataWrapper> FindPV(List<BusDataWrapper> busDataWrappers)
        {
            List<BusDataWrapper> PV = new List<BusDataWrapper>();


            PV.AddRange(busDataWrappers.FindAll(bus => bus.bus_type.Equals(2)).ToList());
            return PV;
        }
        public static Queue<string> CreatePVPQQueue(List<BusDataWrapper> busData)
        {
            List<BusDataWrapper> PVPQ = FindPVPQ(busData);

            Queue<string> QueuePVPQ = new Queue<string>();
            List<string> tests = new List<string>();
           
            foreach (BusDataWrapper firstBus in PVPQ)
            {
                foreach (BusDataWrapper secondBus in PVPQ)
                {
                   // QueuePVPQ.Enqueue(firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString());
                    QueuePVPQ.Enqueue(secondBus.bus_number.ToString() + "-" + firstBus.bus_number.ToString());
                    //tests.Add(firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString());
                    // test.Add(new PointerInt(busData.IndexOf(firstBus), busData.IndexOf(secondBus),firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString()));
                }
            }
            
            return QueuePVPQ;
        }

        public static Queue<string> CreatePQQueue(List<BusDataWrapper> busData)
        {
            List<BusDataWrapper> PQ = FindPQ(busData);
            List<BusDataWrapper> PVPQ = FindPVPQ(busData);
            Queue<string> QueuePQ = new Queue<string>();

            foreach (BusDataWrapper firstBus in PVPQ)
            {
                foreach (BusDataWrapper secondBus in PQ)
                {
                    QueuePQ.Enqueue(firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString());

                }
            }

            return QueuePQ;
        }

        public static Queue<string> CreatePQQueuebasePVPQ(List<BusDataWrapper> busData)
        {
            List<BusDataWrapper> PQ = FindPQ(busData);
            List<BusDataWrapper> PVPQ = FindPVPQ(busData);
            Queue<string> QueuePQ_PVPQ = new Queue<string>();

            foreach (BusDataWrapper firstBus in PQ)
            {
                foreach (BusDataWrapper secondBus in PVPQ)
                {
                    QueuePQ_PVPQ.Enqueue(firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString());
                }
            }

            return QueuePQ_PVPQ;
        }
        public static Queue<string> CreatePQQueuebasePQ(List<BusDataWrapper> busData)
        {
            List<BusDataWrapper> PQ = FindPQ(busData);
            //List<BusDataWrapper> PVPQ = FindPVPQ(busData);
            Queue<string> QueuePQ_PQ = new Queue<string>();

            foreach (BusDataWrapper firstBus in PQ)
            {
                foreach (BusDataWrapper secondBus in PQ)
                {
                    QueuePQ_PQ.Enqueue(firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString());
                }
            }

            return QueuePQ_PQ;
        }
        public static List<PointerInt> FindListOfPointerPQForMatrix(List<BusDataWrapper> busDataWrappers)
        {

            Queue<string> QS = CreatePQQueue(busDataWrappers);

            List<PointerInt> ListPointer = new List<PointerInt>();
            int countQ = QS.Count();
            for (int i = 0; i < countQ; i++)
            {
                ListPointer.Add(FindObjectInMatrix(QS.Dequeue()));

            }
            return ListPointer;
        }
        public static List<PointerInt> FindListOfPointerPQForMatrix_PVPQ(List<BusDataWrapper> busDataWrappers)
        {

            Queue<string> QS = CreatePQQueuebasePVPQ(busDataWrappers);

            List<PointerInt> ListPointer = new List<PointerInt>();
            int countQ = QS.Count();
            for (int i = 0; i < countQ; i++)
            {
                ListPointer.Add(FindObjectInMatrix(QS.Dequeue()));

            }
            return ListPointer;
        }
        public static List<PointerInt> FindListOfPointerPQForMatrix_PQ(List<BusDataWrapper> busDataWrappers)
        {

            Queue<string> QS = CreatePQQueuebasePQ(busDataWrappers);

            List<PointerInt> ListPointer = new List<PointerInt>();
            int countQ = QS.Count();
            for (int i = 0; i < countQ; i++)
            {
                ListPointer.Add(FindObjectInMatrix(QS.Dequeue()));

            }
            return ListPointer;
        }
        public static List<PointerInt> FindListOfPointerPVPQForMatrix(List<BusDataWrapper> busDataWrappers)
        {
            
            Queue<string> QS = CreatePVPQQueue(busDataWrappers);

            List<PointerInt> ListPointer = new List<PointerInt>();
            int countQ = QS.Count();
            for (int i =  0; i< countQ; i++)
            {
                ListPointer.Add(FindObjectInMatrix(QS.Dequeue())); 


            }
            return ListPointer;
        }

        public static PointerInt FindObjectInMatrix(string s, List<BusDataWrapper> busDataWrappers)
        {
            
            foreach (var firstBus in busDataWrappers)
            {
                foreach (var secondBus in busDataWrappers)
                {
                    if (s.Equals(firstBus.bus_number.ToString() + "-" + secondBus.bus_number.ToString()))
                    {
                        return new PointerInt(busDataWrappers.IndexOf(firstBus), busDataWrappers.IndexOf(secondBus));
                    }
                }
                
            }

            return null;
        }
        public static PointerInt FindObjectInMatrix(string s)
        {
            return test[s];
            
        }
        public static void SetupBusDataMatrix( List<BusDataWrapper> busDataWrappers)
        {

            foreach (var firstBus in busDataWrappers)
            {
                foreach (var secondBus in busDataWrappers)
                {
                    
                    
                    test.Add(firstBus.bus_number+"-"+secondBus.bus_number, new PointerInt(busDataWrappers.IndexOf(firstBus), busDataWrappers.IndexOf(secondBus)));
                    
                }

            }
        }

    }


}


// sample code for tread 


/*    Task.Run(async () =>
            {
                var behnnam = test1();
    var behnnam2 = test2();
    Task.WhenAll(behnnam, behnnam2);
                var resul = behnnam.Result + behnnam2.Result;
});

async Task<string> test1()
{
    return "1";
}
async Task<string> test2()
{
    return "2";
}*/