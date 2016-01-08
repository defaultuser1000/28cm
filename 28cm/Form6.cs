using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace _28cm
{
    public partial class Form6 : Form
    {
        string sql = "";
        SQLiteCommand command;
        SQLiteDataReader reader;
        string group_name = "";
        

        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            int N = 0;
            
            sql = "SELECT COUNT(rowid) FROM Groups";
            command = new SQLiteCommand(sql, m_dbConnection);
            
            m_dbConnection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                N = Convert.ToInt32(reader["COUNT(rowid)"]);
            reader.Close();
            m_dbConnection.Close();


            for (int i = 1; i <= N; i++)
            {
                sql = "SELECT name FROM Groups WHERE rowid = ('" + i + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();


                if (reader.Read())
                {

                    group_name = Convert.ToString(reader["name"]);

                }

                reader.Close();
                m_dbConnection.Close();

                comboBox1.Items.Add(group_name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            //bool exist = false;

            if ((comboBox1.Text.Length > 0) && (comboBox2.Text.Length > 0))
            {
                //string date = Convert.ToString(DateTime.Today);
                //string les_column = comboBox2.Text;

                /*sql = "SELECT date, les_type, group FROM poseshenie WHERE date = ('" + DateTime.Today + "') les_type = ('" + comboBox2.Text + "') group = ('" + comboBox1.Text + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();


                if (reader.Read())
                    exist = true;

                reader.Close();
                m_dbConnection.Close();


                if (!exist)
                {*/
                    int count = 0;
                    sql = "SELECT COUNT(rowid) FROM ('" + comboBox1.Text + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    reader = command.ExecuteReader();


                    if (reader.Read())
                        count = Convert.ToInt32(reader["COUNT(rowid)"]);

                    reader.Close();
                    m_dbConnection.Close();
                    for(int jesus = 1; jesus <= count; jesus++)
                    {
                        sql = "INSERT INTO poseshenie (date, les_type, student, prisut, grou_p) VALUES ('" + DateTime.Today + "' ,  '" + comboBox2.Text + "' , '" + jesus + "' , '" + 0 + "' , '" + comboBox1.Text + "')";
                        command = new SQLiteCommand(sql, m_dbConnection);

                        m_dbConnection.Open();
                        command.ExecuteNonQuery();
                        m_dbConnection.Close();
                    }
                    
                    Form1.tabControl2.TabPages.Clear();
                    Form1.Initialize();
                    Close();
                /*}
                else
                {
                    MessageBox.Show("Занятие существует", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/




                /*sql = "INSERT INTO days (date, les_type, group) VALUES ('" + DateTime.Today + "','" + comboBox2.Text + "', '" + comboBox1.Text + "' )";
                command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            command.ExecuteNonQuery();
            m_dbConnection.Close();*/

                //Close();

            }
            else
            {
                MessageBox.Show("Введите данные", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
