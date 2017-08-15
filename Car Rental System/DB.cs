using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace Car_rental_system
{
    public class DBTools
    {
        private SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
        private SqlConnection con = null;
        private SqlCommand cmd = null;
        private SqlDataReader dr = null;
        private SqlDataAdapter da;
        private DataSet ds;

        #region 构造函数
        public DBTools(string dbLocation, string dbname, bool c, string uname, string pwd)
        {
            if (c == true)
            {
                b.DataSource = dbLocation;
                b.InitialCatalog = dbname;
                b.IntegratedSecurity = true;
                con = new SqlConnection(b.ConnectionString);
            }
            else
            {
                b.DataSource = dbLocation;
                b.InitialCatalog = dbname;
                b.UserID = uname;
                b.Password = pwd;
                con = new SqlConnection(b.ConnectionString);
            }
        }
        #endregion

        #region 返回结果集
        public SqlDataReader getResult(string sql)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
        #endregion

        #region 增删改
        public int execSQl(string sql)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return -9999;
            }
        }
        #endregion

        #region 返回String型结果集
        public int getSpResult(string sql)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Connection.Open();

                int x = (int)cmd.ExecuteScalar();
                return x;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return -9999;
            }
        }
        #endregion

        #region 关闭数据库
        public void Disconnect()
        {
            con.Close();
        }
        #endregion

        #region 返回数据集
        public DataSet getDataSet(string sql)
        {
            try
            {                
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception)
            {
                MessageBox.Show("Test");
                return null;
            }

        }
        #endregion
    }
}
