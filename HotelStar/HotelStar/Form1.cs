using System;
using HotelStar.Class;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelStar
{
    public partial class Form1 : Form
    {


        DataList idopontlista = new DataList();
        //Form
        public Form1()
        {
            InitializeComponent();
            PanelSignin.Hide();
            PanelSignup.Hide();
            MenuPanel.Hide();
            UdvozloPanel.Show();
            FoglalasPanel.Hide();
            SzobakPanel.Hide();
            idopontlista.DataMettol();
            CmbFeltolt();
            timer1.Start();


        }
        // Bejelentkezés
        private void btnsignin_Click(object sender, EventArgs e)
        {
            SigninData userdata = new SigninData();
            userdata.BejelentOlvas();
            bool sikeres = false;
            for (int i = 0; i < userdata.Felhasznalok.Count; i++)
            { 
                if (txtfelhasznev.Text == userdata.Felhasznalok[i].Felhasznalonev && txtjelszo.Text == userdata.Felhasznalok[i].Jelszo)
                {
                    sikeres = true;
                }
            }
            if (sikeres == true)
            {
                MessageBox.Show("Sikeres Bejelentkezés!");
                
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés!");
            }

        }
        //Regisztrálás
        private void regisztbutton_Click(object sender, EventArgs e)
        {
            Regfeltolt();
        }
        //Regisztrációs Panel előhozás
        private void Regisztraciolbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelSignup.Show();

        }
        //Bejelentkezés Panel előhozás
        private void Bejelentkezeslbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelSignin.Show();
            PanelSignup.Hide();
        }
        //Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            idopontlista.DataMettol();
            timer1.Start();
        }
        // Sign in (Menü gomb)
        private void Signinlbl_Click_1(object sender, EventArgs e)
        {
            PanelSignin.Show();
            SzobakPanel.Hide();
            FoglalasPanel.Hide();
            UdvozloPanel.Hide();
        }
        //Menü Icon
        private void MenuIcon_Click(object sender, EventArgs e)
        {
            if (this.MenuPanel.Visible == false)
            {
                this.MenuPanel.Visible = true;
            }
            else if (this.MenuPanel.Visible == true)
            {
                this.MenuPanel.Visible = false;
            }
        }
        //Szobák (Menü gomb)
        private void Szobaklbl_Click(object sender, EventArgs e)
        {
            SzobakPanel.Show();
            FoglalasPanel.Hide();
            UdvozloPanel.Hide();
            PanelSignin.Hide();

        }
        //Foglalás(Menü gomb)
        private void Foglalaslbl_Click(object sender, EventArgs e)
        {
            FoglalasPanel.Show();
            SzobakPanel.Hide();
            UdvozloPanel.Hide();
            PanelSignin.Hide();
        }
        //Szobák foglalása gomb
        private void btnFoglalás_Click(object sender, EventArgs e)
        {
            Szerepele();

        }

        //Private void Adatbázishoz
        private void Szerepele()
        {
            bool szerepele = false;
            bool idojoe = true;
            for (int i = 0; i < idopontlista.MettolAdatok.Count; i++)
            {
                if (idopontlista.MettolAdatok[i].Mettol == MettolDate.Value.Date)
                {
                    szerepele = true;
                }
                if (MettolDate.Value.Date <= DateTime.Today ||
                    MettolDate.Value.Date > MeddigDate.Value.Date)
                {
                    idojoe = false;
                }
            }
            if (szerepele == true)
            {
                MessageBox.Show("Sajnáljuk az időpont foglalt már!");
            }
            else if (idojoe == false)
            {
                MessageBox.Show("Rosszul töltötte ki az időpontokat!");
            }
            else if (szerepele == false && idojoe == true)
            {
                DbData();
            }
        }

        // Foglalás adatok feltöltése adatbázisba
        private void DbData()
        {
            #region Kod
            /*
            
       
            AddFoglalas fog = new AddFoglalas();
            fog.FoglalasSql(txtVezeteknev.Text, txtKeresztnev.Text, txtEmail.Text, MettolDate.Value.ToString(),MeddigDate.Value.ToString(), Convert.ToInt32(cmbLetszam.SelectedItem),cmbKinek.SelectedItem.ToString(), cmbKateg.SelectedItem.ToString());
            MessageBox.Show("Succed");
             */
            #endregion

            try
            {
                using (SqlConnection con = new SqlConnection(ServerData.ServerInfo))
                {

                    string Feltoltes = "INSERT INTO Foglalas VALUES(@vezeteknev,@keresztnev,@email,@mettol,@meddig,@letszam,@kinek,@kateg)";

                    using (SqlCommand cmd = new SqlCommand(Feltoltes, con))
                    {

                        if (txtVezeteknev.Text == "" || txtKeresztnev.Text == "" || txtEmail.Text == "" || cmbLetszam.SelectedIndex == null
                            || cmbKinek.SelectedItem.ToString() == null || cmbKateg.SelectedItem.ToString() == null)
                        {
                            MessageBox.Show("Nincsenek jól kitöltve az adatok!");
                        }
                        cmd.Parameters.AddWithValue("@vezeteknev", txtVezeteknev.Text);
                        cmd.Parameters.AddWithValue("@keresztnev", txtKeresztnev.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@mettol", MettolDate.Value);
                        cmd.Parameters.AddWithValue("@meddig", MeddigDate.Value);
                        cmd.Parameters.AddWithValue("@letszam", cmbLetszam.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@kinek", cmbKinek.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@kateg", cmbKateg.SelectedItem.ToString());
                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        if (result < 0)
                        {
                            MessageBox.Show("Nem sikerült a lefoglalása.Kérlek nézd át az adatokat hogy mindent jól adtál-e meg");
                        }
                        else
                        {
                            MessageBox.Show($"Sikeresen lefoglalta a HotelStar {cmbKateg.Text} kategóriájú szobáját");
                        }
                        con.Close();


                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nem sikerult a csatlakozás");
            }
        }
        //Regisztráció feltöltés
        public void Regfeltolt()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ServerData.ServerInfo))
                {

                    string Feltoltes = "INSERT INTO Ügyfelek VALUES(@vezeteknev,@keresztnev,@felhasznalonev,@email,@jelszo,@bankkartya,@elerhetoseg)";

                    using (SqlCommand cmd = new SqlCommand(Feltoltes, con))
                    {
                        cmd.Parameters.AddWithValue("@vezeteknev",vezeteklbl.Text);
                        cmd.Parameters.AddWithValue("@keresztnev",keresztlbl.Text);
                        cmd.Parameters.AddWithValue("@felhasznalonev",felhaszlbl.Text);
                        cmd.Parameters.AddWithValue("@email",emailbl.Text);
                        cmd.Parameters.AddWithValue("@jelszo",jelszolbl.Text);
                        cmd.Parameters.AddWithValue("@bankkartya",bankkartyalbl.Text);
                        cmd.Parameters.AddWithValue("@elerhetoseg",elerhetlbl.Text);
                        con.Open();
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        if (result < 0)
                        {
                            MessageBox.Show("Nem sikerült a regisztrálás.Kérlek nézd át az adatokat hogy mindent jól adtál-e meg");
                        }
                        else
                        {
                            MessageBox.Show($"Sikeresen regisztráltál.");
                        }
                        con.Close();


                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nem sikerult a csatlakozás");
            }

        }
        //Form cmbBox Feltöltése
        private void CmbFeltolt()
        {
            cmbLetszam.Items.Add("1");
            cmbLetszam.Items.Add("2");
            cmbLetszam.Items.Add("3");
            cmbLetszam.Items.Add("4");
            cmbLetszam.Items.Add("5");
            cmbLetszam.Items.Add("6");
            cmbLetszam.Items.Add("7");
            cmbLetszam.Items.Add("8");

            cmbKinek.Items.Add("Én vagyok a vendég");
            cmbKinek.Items.Add("Más vendég számára foglalok");

            cmbKateg.Items.Add("A");
            cmbKateg.Items.Add("B");
            cmbKateg.Items.Add("C");
        }

        
    }
}
