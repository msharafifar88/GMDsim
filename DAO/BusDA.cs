using network;
using persistent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;


namespace DAO.da
{
    public class BusDA : AbstractDA<Bus>
    {

        public void Create(Bus bus, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Buses.Add(bus);
                gmdsimModel.SaveChanges();
            }
            else
            {
                bus.ID = findLastId(loadAll(cases));
                DataStored.addBus(bus, cases);

            }
        }

        public void Update(Bus bus, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Buses.AddOrUpdate(bus);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.editBus(bus, cases);

            }

        }

        public void Delete(Bus bus, Case cases)
        {
            if (false)
            {
                GmdsimModel gmdsimModel = new GmdsimModel();
                gmdsimModel.Buses.Remove(bus);
                gmdsimModel.SaveChanges();
            }
            else
            {
                DataStored.removeBus(bus, cases);
            }

        }
        public List<Bus> loadAll(Case cases)
        {
            return DataStored.findAllBuses(cases).ToList();
        }
        public Bus findByID(Case cases, long ID)
        {
            List<Bus> buses = loadAll(cases);
            foreach (Bus bus in buses)
            {
                if (bus.ID == ID)
                {
                    return bus;
                }
            }
            return null;
        }

        public Bus findByCode(Case cases, long code)
        {
            List<Bus> buses = loadAll(cases);
            foreach (Bus bus in buses)
            {
                if (bus.BusNumber == code)
                {
                    return bus;
                }
            }
            return null;
        }

        /*  public void CallDB()
          {
              string connectionString = "Data Source=localhost;Initial Catalog=test;Integrated Security=True";
              string sql = "SelectAllCustomersByName";
              using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
              {
                  using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                  {
                      conn.Open();

                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = "gholi";


                      using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1));

                          }
                      }
                  }
              }
          }*/

    }
}
