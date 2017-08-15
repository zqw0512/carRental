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
    public partial class Insert : Form
    {
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private DataSet ds;                
        public delegate void dele();
        public event dele evt;        
        public Insert()
        {
            InitializeComponent();
            b.DataSource = ".";
            b.InitialCatalog = "wkdl";
            b.IntegratedSecurity = true;
            con = new SqlConnection(b.ConnectionString);
            da = new SqlDataAdapter("select id as ÉÌÆ·±àºÅ,warename as ÉÌÆ·Ãû³Æ,price as µ¥¼Û,type as ÒÑÊÛ³öÊýÁ¿,zip as ±£ÖÊÆÚ from ", con);
            ds = new DataSet();
            //this.skinengine1.skinfile = "macos.ssk";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && textBox5.Text.Length != 0 && textBox6.Text.Length != 0)
                {
                    
                        try
                        {
                            string str = "insert into ware (wareName,price,zip,type,stocks) values('" + textBox2.Text.Trim().ToString() + "'," + int.Parse(textBox3.Text.Trim()) + "," + int.Parse(textBox4.Text.Trim()) + ",'" + textBox5.Text.Trim().ToString() + "'," + int.Parse(textBox6.Text.Trim()) + ")";
                            da.InsertCommand = con.CreateCommand();
                            da.InsertCommand.CommandText = str;
                            con.Open();
                            da.InsertCommand.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Insert successfully!");
                            this.Dispose(true);
                            evt();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }

                    
                }
                else
                {
                    MessageBox.Show("不能有任何一项为空");
                }
        }

        /// <summary>
        /// ÅÐ¶ÏÊÇ·ñÊÇÊý×Ö
        /// </summary>
        /// <param name="str">×Ö·û´®</param>
        /// <returns></returns>
        private bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);
            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57 || c!=46)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}