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
    public partial class FileUpload : Form
    {
        SqlConnection con = new SqlConnection("Data Source=JAYA-PC\\SQLEXPRESS;Initial Catalog=coresident;Integrated Security=True");

        string name;

        public FileUpload(string n)
        {
            name = n;
            InitializeComponent();



        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            string filename = Path.GetFileName(textBox1.Text);

            SqlCommand cmd1 = new SqlCommand("select * from VM1 where UserName= '" + name + "'", con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string user = dr["UserName"].ToString();
                if (user == name)
                {
                    string path = @"E:\VM1\" + user;
                    if (!Directory.Exists(path))
                    {

                        Directory.CreateDirectory(path);
                    }
                    string name1 = openFileDialog1.FileName;


                    File.Copy(name1, path + "\\" + filename);
                    con.Close();
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into VM1USER values('" + user + "','" + path + "','" + filename + "','ONLINE','VM1')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    con.Open();
                    SqlCommand cmd55 = new SqlCommand("select TOP 1 * from VM1USER", con);
                    SqlDataReader dr55 = cmd55.ExecuteReader();
                    if(dr55.Read())
                    {
                        string hacker = dr55["UserName"].ToString();
                               path = @"E:\VM1\" + hacker;
                     if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    name1 = openFileDialog1.FileName;

                    if (File.Exists(path + "\\" + filename))
                    {
                        
                        MessageBox.Show(" file upload sucessfully");
                    }
                    else
                    {
                        File.Copy(name1, path + "\\" + filename);
                        MessageBox.Show(" file upload sucessfully");
                    }


                        con.Close();



                   
                }
            }}
                else if (!dr.Read())
                {
                    dr.Close();
                    SqlCommand cmd2 = new SqlCommand("select * from VM2 where UserName= '" + name + "'", con);
                    SqlDataReader dr1 = cmd2.ExecuteReader();
                    if (dr1.Read())
                    {
                        string user = dr1["UserName"].ToString();
                        if (user == name)
                        {
                            string path = @"E:\VM2\" + user;
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            string name1 = openFileDialog1.FileName;


                            File.Copy(name1, path + "\\" + filename);
                            con.Close();
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into VM2USER values('" + user + "','" + path + "','" + filename + "','ONLINE','VM2')", con);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("file upload sucessfully");
                        }
                    }
             
                else if (!dr1.Read())
                {
                    dr1.Close();

                    SqlCommand cmd3 = new SqlCommand("select * from VM3 where UserName= '" + name + "'", con);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    if (dr3.Read())
                    {
                        string user = dr3["UserName"].ToString();
                        if (user == name)
                        {
                            string path = @"E:\VM3\" + user;
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            string name1 = openFileDialog1.FileName;


                            File.Copy(name1, path + "\\" + filename);
                            con.Close();
                            con.Open();
                            SqlCommand cmd25 = new SqlCommand("insert into VM3USER values('" + user + "','" + path + "','" + filename + "','0NLINE','VM3')", con);
                            cmd25.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("file upload sucessfully");
                        }
                    }

               


                        //if
                        //(!Directory.Exists(path))
                        //{
                        //    Directory.CreateDirectory(path + "\\" + label1 + "\\");
                        //}
                    }
                }

             

            }



        

        private void button3_Click(object sender, EventArgs e)
        {
            
                     
            con.Close();
            con.Open();
            SqlCommand cmd18 = new SqlCommand("update login set UserMode='OFFLINE' where Username='" + name + "'", con);
            cmd18.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd21 = new SqlCommand("Select Allocation from VM1USER where UserName='" + name + "'", con);
            SqlDataReader dr22 = cmd21.ExecuteReader();
            if (dr22.Read())
            {
                string allocation = dr22["Allocation"].ToString();
                if (allocation == "VM1")
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd19 = new SqlCommand("update VM1USER set status='OFFLINE' where Username='" + name + "'", con);
                    cmd19.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    MessageBox.Show("VM1 USER IS OFFLINE");
                    SqlCommand cmd26 = new SqlCommand("select status from VM1USER where Username='" + name + "'", con);
                    SqlDataReader dr26 = cmd26.ExecuteReader();
                    if (dr26.Read())
                    {
                        string status = dr26["status"].ToString();
                        if (status == "OFFLINE")
                        {
                            con.Close();
                            con.Open();
                            SqlCommand cmd27 = new SqlCommand("select TOP 1 * from VM2USER where status='ONLINE'", con);
                            SqlDataReader dr27 = cmd27.ExecuteReader();
                            if (dr27.Read())
                            {
                                string suser = dr27["UserName"].ToString();
                                string spath = dr27["filepath"].ToString();
                                string sfilename=dr27["FileName"].ToString();
                                string path = @"E:\VM1\" + suser;
                                if (Directory.Exists(spath))
                                {
                                    Directory.Move(spath, path);
                                    MessageBox.Show("SO ONE VM2 USER IS SHIFTED TO VM1");

                                }

                                

                                else
                                {
                                    MessageBox.Show("its not correct user");
                                }
                                con.Close();
                                con.Open();
                                 SqlCommand cmd60 = new SqlCommand("select TOP 1 * from VM1USER", con);
                    SqlDataReader dr60 = cmd60.ExecuteReader();
                    if (dr60.Read())
                    {
                        string hacker = dr60["UserName"].ToString();
                        if (name == hacker)
                        {
                            con.Close();
                            con.Open();
                            MessageBox.Show("YOU ARE BLOCKED!!!!"+ name);
                            SqlCommand cmd61 = new SqlCommand("DELETE from Register where UserName='"+hacker+"'",con);
                            cmd61.ExecuteNonQuery();



                        }

                    }
                    con.Close();
                                con.Open();
                                SqlCommand cmd50 = new SqlCommand("update VM1USER SET UserName='" + suser + "',filepath='" + spath + "',FileName='" + sfilename + "',status='ONLINE',Allocation='VM1' where UserName='" + name + "'", con);
                                cmd50.ExecuteNonQuery();
                                con.Close();
                                con.Open();
                                SqlCommand cmd51 = new SqlCommand("DELETE from VM2USER where UserName='"+suser+"'",con);
                                cmd51.ExecuteNonQuery();
                                con.Close();

                               
                    
                   



                            }
                        }
                    }

                }
            }

            else if (!dr22.Read())
            {
                dr22.Close();
                con.Close();
                con.Open();
                SqlCommand cmd22 = new SqlCommand("Select Allocation from VM2USER where UserName='" + name + "'", con);
                SqlDataReader dr23 = cmd22.ExecuteReader();
                if (dr23.Read())
                {
                    string allocation = dr23["Allocation"].ToString();
                    if (allocation == "VM2")
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmd23 = new SqlCommand("update VM2USER set status='OFFLINE' where Username='" + name + "'", con);
                        cmd23.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        MessageBox.Show("VM2 USER IS OFFLINE");
                        
                        SqlCommand cmd41 = new SqlCommand("select status from VM2USER where Username='" + name + "'", con);
                        SqlDataReader dr41 = cmd41.ExecuteReader();
                        if (dr41.Read())
                        {
                            string status = dr41["status"].ToString();
                            if (status == "OFFLINE")
                            {
                                con.Close();
                                con.Open();
                                SqlCommand cmd88 = new SqlCommand("select TOP 1 * from VM3USER", con);
                                SqlDataReader dr88 = cmd88.ExecuteReader();
                                if (dr88.Read())
                                {
                                    string suser = dr88["UserName"].ToString();
                                    string spath = dr88["filepath"].ToString();
                                    string sfilename = dr88["FileName"].ToString();
                                    string path = @"E:\VM2\" + suser;
                                    if (Directory.Exists(spath))
                                    {
                                        Directory.Move(spath, path);
                                        MessageBox.Show("SO ONE VM3 USER IS SHIFTED TO VM2");

                                    }
                                    else 
                                    {
                                        MessageBox.Show("its not correct user");
                                    }
                                    con.Close();
                                    con.Open();
                                    SqlCommand cmd52 = new SqlCommand("update VM2USER SET UserName='" + suser + "',filepath='" + spath + "',FileName='" + sfilename + "',status='ONLINE',Allocation='VM2' where UserName='" + name + "'", con);
                                    cmd52.ExecuteNonQuery();
                                    con.Close();
                                    con.Open();
                                    SqlCommand cmd53 = new SqlCommand("DELETE from VM3USER where UserName='" + suser + "'", con);
                                    cmd53.ExecuteNonQuery();
                               

                                }
                            }
                        }

                        

                    }
                }
                else if (!dr23.Read())
                {
                    dr23.Close();
                    con.Close();
                    con.Open();
                    SqlCommand cmd24 = new SqlCommand("Select Allocation from VM3USER where UserName='" + name + "'", con);
                    SqlDataReader dr24 = cmd24.ExecuteReader();
                    if (dr24.Read())
                    {
                        string allocation = dr24["Allocation"].ToString();
                        if (allocation == "VM3")
                        {
                            con.Close();
                            con.Open();
                            SqlCommand cmd25 = new SqlCommand("update VM3USER set status='OFFLINE' where Username='" + name + "'", con);
                            cmd25.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("VM3 USER IS OFFLINE");

                        }
                    }
                }




            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd56 = new SqlCommand("select UserName from VM1USER", con);
            SqlDataAdapter da56 = new SqlDataAdapter(cmd56);
            DataTable dt56 = new DataTable();
            da56.Fill(dt56);
            string seconduser=dt56.Rows[1][0].ToString();


        

         
            SqlCommand cmd31 = new SqlCommand("Select Allocation from VM1USER where UserName='" + name + "'", con);
            SqlDataReader dr31 = cmd31.ExecuteReader();
            if (dr31.Read())
            {
                string allocation = dr31["Allocation"].ToString();
                if (allocation == "VM1")
                {
                    con.Close();
                    VM1USER VM1 = new VM1USER();
                  
                    VM1.Show();
                    
                    con.Open();
                    SqlCommand cmd57 = new SqlCommand("select UserName from VM1USER where UserName='" + seconduser + "'", con);
                    SqlDataAdapter da57 = new SqlDataAdapter(cmd57);
            DataTable dt57 = new DataTable();
            da57.Fill(dt57);
                    string suser=dt57.Rows[0][0].ToString();
                    if (suser ==name)
                    {



                        MessageBox.Show("HI!!!!!!! I'M ADMIN SOMEBODY HACK UR DATAS SO JUST LOGOUT UR ACCOUNT THEN LOGIN AFTER 1 MINUTE I WILL ALLOCATE ANOTHER VM");
                    }
                    else
                    {
                        VM1USER VM7 = new VM1USER();

                        VM7.Show();
                      
                    }

                }
            }
            else if (!dr31.Read())
            {
                dr31.Close();
                con.Close();
                con.Open();
                SqlCommand cmd32 = new SqlCommand("Select Allocation from VM2USER where UserName='" + name + "'", con);
                SqlDataReader dr32 = cmd32.ExecuteReader();
                if (dr32.Read())
                {
                    string allocation = dr32["Allocation"].ToString();
                    if (allocation == "VM2")
                        con.Close();
                    VM2USER VM2 = new VM2USER();
                   
                    VM2.Show();
                }

                else if (!dr32.Read())
                {
                    dr32.Close();
                    con.Close();
                    con.Open();
                    SqlCommand cmd33 = new SqlCommand("Select Allocation from VM3USER where UserName='" + name + "'", con);
                    SqlDataReader dr33 = cmd33.ExecuteReader();
                    if (dr33.Read())
                    {
                        string allocation = dr33["Allocation"].ToString();
                        if (allocation == "VM3")
                            con.Close();
                        VM3USER VM3 = new VM3USER();
                      
                        VM3.Show();
                    }



                }
            }
        }

    }
}

    




