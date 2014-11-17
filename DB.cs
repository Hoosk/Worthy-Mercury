using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeGame
{
    class DB
    {
        private String strConnexio = Properties.Settings.Default.gameConnectionString;
       

        public void save(string fusername, int fpuntuacion)
        {
           // MessageBox.Show(strConnexio);
            SqlConnection conDataBase = new SqlConnection(this.strConnexio);
            String save = "INSERT INTO dbo.Scores (Username, Puntuacion) values('" + fusername + "', '" + fpuntuacion + "');";
            SqlCommand cmdDatabase = new SqlCommand(save, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDatabase.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pinchependejeada padre wey)" + ex.Message);
            }
            finally
            {
                if (conDataBase.State == ConnectionState.Open)
                {
                    conDataBase.Close();
                }
            }
        }
       

    }
}
