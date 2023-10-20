using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelStar
{
    class DataGridView
    {
        #region DataGridKod
        /* private void Adatkezeles()
         {
             List<DataList> MettolAdatok = new List<DataList>();
             string Lekerdezes = "Select keresztnev from Foglalas";
             using (SqlConnection connect = new SqlConnection(ServerData.ServerInfo))
             {
                 connect.Open();
                 using (SqlCommand Parancs= new SqlCommand(Lekerdezes,connect))
                 {
                     var datareader =Parancs.ExecuteReader();
                     MettolAdatok = Getlist<DataList>(datareader);

                 }
             }
             if (MettolAdatok!=null)
             {
                 datalist.DataSource = MettolAdatok;

             }

         }

         private List<T> Getlist<T>(IDataReader reader)
         {
             List<T> list = new List<T>();
             while (reader.Read())
             {
                 var type = typeof(T);
                 T obj = (T)Activator.CreateInstance(type);
                 foreach (var prop  in type.GetProperties())
                 {
                     var propType = prop.PropertyType;
                     prop.SetValue(obj,Convert.ChangeType( reader[prop.Name].ToString(),propType));
                 }
                 list.Add(obj);
             }
             return list;
         }*/
        #endregion
    }
}
