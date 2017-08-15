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
    public partial class Update : Form
    {
        private SqlDataAdapter da;
        public delegate void dele();
        public event dele evt;       
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private DataSet ds;
        private DBTools db;
        DLbh c = DLbh.getIns();
        public Update()
        {
            InitializeComponent();
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            da = new SqlDataAdapter("select * from ", con);
            ds = new DataSet();
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void Update_Load(object sender, EventArgs e)
        {
            db = new DBTools(".", "wkdl", true, "sa", "wdxg");
            SqlDataReader b = db.getResult("Select * from ware where id=" + c.Num);

            while (b.Read())
            {
           
                textBox1.Text = b["id"].ToString();
                textBox2.Text = b["warename"].ToString();
                textBox3.Text = b["price"].ToString();
                textBox4.Text = b["zip"].ToString();
                textBox5.Text = b["type"].ToString();
                textBox6.Text = b["stocks"].ToString();
            }

            db.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Length == 0)
                    {
                        MessageBox.Show("Any item cannot be empty！", "System");
                    }
                    else
                    {

                        string strc = "update ware set warename='" + textBox2.Text.Trim().ToString() + "',price=" + int.Parse(textBox3.Text.Trim()) + ",zip=" + int.Parse(textBox4.Text.Trim()) + ",type='" + textBox5.Text.Trim().ToString() + "',stocks=" + int.Parse(textBox6.Text.Trim()) + " where [id]=" + c.Num;
                        da.InsertCommand = con.CreateCommand();
                        da.InsertCommand.CommandText = strc;
                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        con.Close();
                        this.Dispose(true);
                        evt();
                    }      

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }
        }
    }
}