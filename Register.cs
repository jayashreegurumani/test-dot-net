using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication2
{


    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string Gender="";
            if (radioButton1.Checked==true)
        {
            Gender="Male";
        }
        else if(radioButton2.Checked==true)
        {
            Gender="Female";
        }

            SqlConnection con = new SqlConnection("Data Source=JAYA-PC\\SQLEXPRESS;Initial Catalog=coresident;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Register values('" + textBox1.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + Gender + "','" + textBox3.Text + "','" + textBox4.Text + "','Inactive')", con);
            cmd.ExecuteNonQuery();
             MessageBox.Show("register Successfull");
             con.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {


            MessageBox.Show("please Wait............");


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
