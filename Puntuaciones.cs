using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeGame
{
    /*Adventure Time!!
     * 
     *   | (• ◡•)| (❍ᴥ❍ʋ)
     *   
           /|________________
     O|===|*>________________ >
           \|  
     * 
     *  Take your sword and debug!
     */
    public partial class Puntuaciones : Form
    {
        private Form1 puntu = new Form1();


        public Puntuaciones()
        {
           
            InitializeComponent();
            load_table();
        }

   
        private void Puntuaciones_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'estoConLaravelNoPasa.Scores' table. You can move, or remove it, as needed.
            this.scoresTableAdapter.Fill(this.estoConLaravelNoPasa.Scores);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.puntu.newGame();
            this.puntu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        public void load_table()
        {   
           /* //String strConnexio = Properties.Settings.Default.gameConnectionString;
             //SqlConnection conDataBase = new SqlConnection(strConnexio);
            //SqlCommand cmdDatabase = new SqlCommand("SELECT * FROM dbo.Scores order by Puntuacion ASC", conDataBase);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception e)
            {

            }*/
        }
    }
}
