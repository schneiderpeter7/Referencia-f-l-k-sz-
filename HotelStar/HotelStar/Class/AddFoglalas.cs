using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelStar
{
    class AddFoglalas
    {
        public string Vezeteknev;
        public string Keresztnev;
        public string Email;
        public string Kinek;
        public string Mettol;
        public string Meddig;
        public int Letszam;
        public string Kategoria;

        
        public void FoglalasSql(string Vezeteknev, string Keresztnev, string Email, string Mettol, string Meddig, int Letszam, string Kinek, string Kategoria)
        {
            SqlConnection con = new SqlConnection(ServerData.ServerInfo);
            string Feltoltes = "INSERT INTO Foglalas (vezeteknev,keresztnev,email,mettol,meddig,letszam,kinek,kateg) VALUES('" + Vezeteknev + "','" + Keresztnev + "','" + Email + "','" + Mettol + "','" + Meddig + "','" + Letszam + "','" + Kinek + "','" + Kategoria + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(Feltoltes, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
