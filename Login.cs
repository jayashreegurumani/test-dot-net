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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=JAYA-PC\\SQLEXPRESS;Initial Catalog=coresident;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Register where UserName='" + textuser.Text + "' and Password='" + textBox1.Text + "' and Status='Active'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


               


                MessageBox.Show("login successfully");
                FileUpload upload = new FileUpload(textuser.Text);
                this.Hide();
                upload.Show();



                dr.Close();
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("select * from VM1 where UserName= '" + textuser.Text + "'", con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    string user = dr2["UserName"].ToString();
                    string Allocation = dr2["Allocation"].ToString();
                    if (user == textuser.Text)
                    {
                        dr2.Close();
                        SqlCommand cmd1 = new SqlCommand("insert into login values('" + textuser.Text + "','online', '" + Allocation + "')", con);
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else if (!dr2.Read())
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("select * from VM2 where UserName= '" + textuser.Text + "'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {
                        string user = dr3["UserName"].ToString();
                        string Allocation = dr3["Allocation"].ToString();
                        if (user == textuser.Text)
                        {
                            dr3.Close();
                            SqlCommand cmd4 = new SqlCommand("insert into login values('" + textuser.Text + "','online', '" + Allocation + "')", con);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    else if (!dr3.Read())
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmd6 = new SqlCommand("select * from VM3 where UserName= '" + textuser.Text + "'", con);
                        SqlDataReader dr4 = cmd6.ExecuteReader();
                        if (dr4.Read())
                        {
                            string user = dr4["UserName"].ToString();
                            string Allocation = dr4["Allocation"].ToString();
                            if (user == textuser.Text)
                            {
                                dr4.Close();
                                SqlCommand cmd7 = new SqlCommand("insert into login values('" + textuser.Text + "','online', '" + Allocation + "')", con);
                                cmd7.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("invalid user");
                        }
                        con.Close();



                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.Show();
        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
