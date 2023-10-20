using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelStar.Class
{
    class SigninData
    {
        private string felhasznalonev;
        private string jelszo;
        public List<SigninData> Felhasznalok = new List<SigninData>();


        public SigninData()
        {
            
        }

        public SigninData(string felhasznalonev,string jelszo)
        {
            this.felhasznalonev = felhasznalonev;
            this.felhasznalonev = jelszo;
        }

        public string Felhasznalonev
        {
            get
            {
                return felhasznalonev;
            }
            set
            {
                felhasznalonev = value;
            }
        }
        public string Jelszo
        {
            get
            {
                return jelszo; 
            }
            set
            {
                jelszo = value;
            }
        }

        public void BejelentOlvas()
        {

           
            using (SqlConnection Kapcsolat = new SqlConnection(ServerData.ServerInfo))
            {
                
                string FelhasznaloAdat = "Select felhasznalonev,jelszo FROM Ügyfelek";
                using (SqlCommand command = new SqlCommand(FelhasznaloAdat, Kapcsolat))
                {
                    Kapcsolat.Open();
                    SqlDataReader FelhasznaloAdatOlvas = command.ExecuteReader();
                    while (FelhasznaloAdatOlvas.Read())
                    {
                        Felhasznalok.Add(new SigninData(FelhasznaloAdatOlvas.GetString(0), FelhasznaloAdatOlvas.GetString(0)));
                    }
                }
            }
           
        }
    }
}
