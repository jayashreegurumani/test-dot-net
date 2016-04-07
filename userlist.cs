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
    public partial class userlist : Form
    {
        SqlConnection con = new SqlConnection("Data Source=JAYA-PC\\SQLEXPRESS;Initial Catalog=coresident;Integrated Security=True");
        public userlist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (listBox2.SelectedItem.ToString() == "VM1")
            {
                string path;
                path = @"E:\VM1\" + listBox1.SelectedItem.ToString();

                con.Open();
                SqlCommand cmd7 = new SqlCommand("select UserName from VM1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd7);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //SqlDataReader dr1 = cmd7.ExecuteReader();
                //if (dr1.Read())
                //{
                //string user1 = dr1[0].ToString();
                //int userr = 0;
                //userr = Int32.Parse(user1);

                if (dt.Rows.Count > 2)
                {






                    MessageBox.Show("VM1 is Filled Try Otherone");


                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into VM1 values('" + listBox1.SelectedItem.ToString() + "','" + listBox2.SelectedItem.ToString() + "','" + path + "')", con);
                    cmd.ExecuteNonQuery();
                    // path = @"E:\VM1\" + listBox1.SelectedItem.ToString(); 
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    MessageBox.Show("VM1  IS ALLOCATED");
                    con.Close();
                }
            }

            else if (listBox2.SelectedItem.ToString() == "VM2")
             {
                string path1;
                path1 = @"E:\VM2\" + listBox1.SelectedItem.ToString();

                con.Close();
                con.Open();
                SqlCommand cmd10 = new SqlCommand("select UserName from VM2", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd10);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                //SqlCommand cmd8 = new SqlCommand("select * from VM2", con);
                //SqlDataReader dr2 = cmd8.ExecuteReader();
                //if (dr2.Read())
                //{
                //    string user1 = dr2["UserName"].ToString();
                //    int userr = 0;
                //    userr = Int32.Parse(user1);
                //    if (userr > 3)
                if (dt1.Rows.Count > 2)
                {
                    MessageBox.Show("VM2 is Filled Try Otherone");

                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into VM2 values('" + listBox1.SelectedItem.ToString() + "','" + listBox2.SelectedItem.ToString() + "','" + path1 + "')", con);
                    cmd2.ExecuteNonQuery();
                    //path1 = @"E:\VM2\" + listBox1.SelectedItem.ToString();
                    if (!Directory.Exists(path1))
                    {
                        Directory.CreateDirectory(path1);

                    }
                    MessageBox.Show("VM2  IS ALLOCATED");
                    con.Close();
                }
            }

            else if (listBox2.SelectedItem.ToString() == "VM3")
            {
                string path2;
                path2 = @"E:\VM3\" + listBox1.SelectedItem.ToString();
                con.Close();
                 con.Open();
                SqlCommand cmd11 = new SqlCommand("select UserName from VM3", con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd11);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                 if (dt2.Rows.Count > 2)
                
                //con.Open();
                //SqlCommand cmd9 = new SqlCommand("select * from VM3", con);
                //SqlDataReader dr3 = cmd9.ExecuteReader();
                //if (dr3.Read())
                //{
                //    string user1 = dr3["UserName"].ToString();
                //    int userr = 0;
                //    userr = Int32.Parse(user1);
                //    if (userr > 2)
                    {





                        MessageBox.Show("VM3 is Filled Try Otherone");



                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand("insert into VM3 values('" + listBox1.SelectedItem.ToString() + "','" + listBox2.SelectedItem.ToString() + "','" + path2 + "')", con);
                        cmd3.ExecuteNonQuery();
                        //path2 = @"H:\VM3\" + listBox1.SelectedItem.ToString();
                        if (!Directory.Exists(path2))
                        {
                            Directory.CreateDirectory(path2);
                        }
                        MessageBox.Show("VM3  IS ALLOCATED");
                        con.Close();
                    }
                }
            }
        

        private void userlist_Load(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Register", con);
            SqlDataAdapter dr = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                //listBox1.Items.Add(dr[0].ToString());
            }
           
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
