using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=INETZ-PC;Initial Catalog=coresident;Integrated Security=True");
      
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string username = listBox1.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("select * from register where UserName ='" + username + "'",con);
            SqlDataReader da = cmd.ExecuteReader();
            if (da.Read())
            {
                con.Close();
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
