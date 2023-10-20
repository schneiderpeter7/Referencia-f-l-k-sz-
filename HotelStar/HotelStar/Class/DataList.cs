using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelStar
{
    class DataList
    {
        public DateTime Mettol { get; set; }
        public List<DataList> MettolAdatok = new List<DataList>();
        public DataList(DateTime Mettol)
        {
            this.Mettol = Mettol;   
        }
        public DataList()
        {
            
        }
        public void DataMettol()
        {

            string Lekerdezes = "Select mettol from Foglalas";
            using (SqlConnection connect = new SqlConnection(ServerData.ServerInfo))
            {

                using (SqlCommand Parancs = new SqlCommand(Lekerdezes, connect))
                {
                    connect.Open();
                    SqlDataReader LekerdezesParancs = Parancs.ExecuteReader();
                    while (LekerdezesParancs.Read())
                    {
                        MettolAdatok.Add(new DataList(LekerdezesParancs.GetDateTime(0)));
                    }
                }
            }
        }
    }
}
