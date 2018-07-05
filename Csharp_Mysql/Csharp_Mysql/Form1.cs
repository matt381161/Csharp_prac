using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Csharp_Mysql
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            tabPage3.Parent = null;
        }
        private String LoggedInAcc = "";
        private String LoggedInPwd = "";

        //註冊
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == "" | txtRep.Text=="" |txtPwd.Text != txtRep.Text)
            {
                MessageBox.Show("Passwords can not be null or are not equal!");
                txtPwd.Text = "";
                txtRep.Text = "";
            }
            else if (txtPwd.Text.Length <= 7)
            {
                MessageBox.Show("Passwords can not be less than 7 letters!");
            }
            else
            {
                string dbHost = "localhost";
                string dbUser = "root";
                string dbPass = "";
                string dbName = "forCsharp";

                string connStr = "server=" + dbHost + ";uid=" + dbUser +
                    ";pwd=" + dbPass + ";database=" + dbName;
                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
                String SQL = "select * from users where account = '" + txtAcc.Text + "'";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(SQL, conn);
                    MySqlDataReader myData = cmd.ExecuteReader();

                    if (myData.HasRows)
                    {
                        //myData.Read();
                        //MessageBox.Show(myData.GetString(1) +"  "+ myData.GetString(2));
                        MessageBox.Show("Account is exist already!");
                        txtAcc.Text = "";
                        myData.Close();
                    }
                    else
                    {
                        myData.Close();
                        SQL = "insert into users(account,password,register_time) values('" + txtAcc.Text + "','" + txtPwd.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        cmd = new MySqlCommand(SQL, conn);
                        myData = cmd.ExecuteReader();
                        MessageBox.Show("Success!Use your Account and Password to log in!");
                        txtAcc.Text = "";
                        txtPwd.Text = "";
                        txtRep.Text = "";
                        tabControl1.SelectedTab = tabPage1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }
        //登入
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtAcc1.Text == "" | txtPwd1.Text == "")
                MessageBox.Show("Can not be null");
            else
            {
                string dbHost = "localhost";
                string dbUser = "root";
                string dbPass = "";
                string dbName = "forCsharp";
                string connStr = "server=" + dbHost + ";uid=" + dbUser +
                    ";pwd=" + dbPass + ";database=" + dbName;
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                String SQL = "select * from users where account = '" + txtAcc1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataReader myData = cmd.ExecuteReader();
                if (myData.HasRows)
                {
                    myData.Read();
                    if (myData.GetString(2) == txtPwd1.Text)
                    {
                        //成功登入
                        MessageBox.Show("Logged In");
                        tabPage3.Parent = tabControl1;
                        LoggedInAcc = txtAcc1.Text;
                        LoggedInPwd = txtPwd1.Text;
                        txtAcc1.Text = "";
                        txtPwd1.Text = "";
                        lblstatu.Text = "已登入";
                        tabPage2.Parent = null;
                        tabControl1.SelectedTab = tabPage3;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password!");
                        txtPwd1.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Account is not exist!");
                    txtAcc1.Text = "";
                    txtPwd1.Text = "";
                }
            }
        }
        //修改密碼
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPwdUpdate.Text == "" | txtRepUpdate.Text == "")
                MessageBox.Show("Can not be null!");
            else if (txtPwdUpdate.Text != txtRepUpdate.Text)
            {
                MessageBox.Show("Passwords are not equal!");
                txtPwdUpdate.Text = "";
                txtRepUpdate.Text = "";
            }
            else
            {
                string dbHost = "localhost";
                string dbUser = "root";
                string dbPass = "";
                string dbName = "forCsharp";
                string connStr = "server=" + dbHost + ";uid=" + dbUser +
                    ";pwd=" + dbPass + ";database=" + dbName;
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                String SQL = "update users set password='" + txtPwdUpdate.Text + 
                    "' where account = '" + LoggedInAcc + "'";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(SQL, conn);
                    MySqlDataReader myData = cmd.ExecuteReader();
                    MessageBox.Show("Update Success!Please re-log in!");
                    LoggedInAcc = "";
                    LoggedInPwd = "";
                    lblstatu.Text = "尚未登入";
                    tabControl1.SelectedTab = tabPage1;
                    txtPwdUpdate.Text = "";
                    txtRepUpdate.Text = "";
                    tabPage3.Parent = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}