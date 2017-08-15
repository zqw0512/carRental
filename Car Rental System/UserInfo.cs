using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Car_rental_system
{
    public partial class UserInfo : Form
    {
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private SqlConnection con;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da;
        private DataSet ds;
        int x;
        int y;

        public UserInfo()
        {
            InitializeComponent();
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        private void LoadDGV()
        {
            cmd.CommandText = "select uFullName,uAddress,uPhone,uReservation from userlogin where usa = 'member'";
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Address";
            dataGridView1.Columns[2].HeaderText = "Phone Number";
            dataGridView1.Columns[3].HeaderText = "Reservation";
            dataGridView1.RowHeadersVisible = false;

            setFridViewProperty();
        }

        private void setFridViewProperty()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.Rows[0].Selected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = dataGridView1.Rows[x].Cells[0].Value.ToString();
            DBTools db = new DBTools(".", "wkdl", true, "sa", "wdxg");
            SqlDataReader b = db.getResult("delete from userlogin where uFullName='" + name + "'");
            MessageBox.Show("Delete Successfully！");
            LoadDGV();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            
                if (textBox1.Text.Length != 0 || comboBox1.Text !="")
                {

                    string str = "select uFullName,uAddress,uPhone,uReservation from userlogin where usa = 'member' and";

                    dataGridView1.Columns[0].HeaderText = "Name";
                    dataGridView1.Columns[1].HeaderText = "Address";
                    dataGridView1.Columns[2].HeaderText = "Phone Number";
                    dataGridView1.Columns[3].HeaderText = "Reservation";

                    string oth = "";
                    string[] name = new string[2];
                    for (int j = 0; j < name.Length; j++)
                    {
                        name[j] = "";
                    }
                    if (textBox1.Text.Length != 0)
                    {
                        name[0] = " uFullName ='" + textBox1.Text.Trim() + "'";
                    }

                    if (comboBox1.Text.Length != 0)
                    {
                        if (comboBox1.Text == "Yes")
                        {
                            name[1] = " uReservation != ''";
                        } else
                        {
                            name[1] = " uReservation = ''";
                        }
                    }
                    
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[i].Length != 0)
                        {
                            str += name[i] + "and";
                        }
                    }
                    if (str == "select id,warename,price,zip,type,stocks from userlogin where usa = 'member' and")
                    {
                        oth = "select id,warename,price,zip,type,stocks from userlogin where usa = 'member'";
                        MessageBox.Show("不能为空!");
                        return;
                    }
                    else
                    {
                        oth = str.Substring(0, str.Length - 3);
                    }
                    
                    da = new SqlDataAdapter(oth, con);
                    ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No result!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    dataGridView1.DataSource = ds.Tables[0];
                    setFridViewProperty();
                }
                else
                {
                    MessageBox.Show("Please enter valid information.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = e.RowIndex;
            y = e.ColumnIndex;
            
        }
        
             
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            LoadDGV();
        }
    }
}