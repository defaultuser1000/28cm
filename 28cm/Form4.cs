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
    public partial class Form4 : Form
    {
        string temp_group = "";
        string sql = "";
        SQLiteCommand command;
        SQLiteDataReader reader;
        int N = 42;
        int i = 42;
        string Name_of_group = "";
        

        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");

            sql = "SELECT COUNT(rowid) FROM Groups";
            command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                N = Convert.ToInt32(reader["COUNT(rowid)"]);
            reader.Close();
            m_dbConnection.Close();


            for (i = 1; i <= N; i++)
            {
                sql = "SELECT name, year FROM Groups WHERE rowid = ('" + i + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();


                if (reader.Read())
                {

                    Name_of_group = Convert.ToString(reader["name"]);
                    
                }

                reader.Close();
                m_dbConnection.Close();

                comboBox1.Items.Add(Name_of_group);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string student = "";
            temp_group = comboBox1.Text;

            label1.Visible = false;
            label2.Visible = true;

            comboBox1.Items.Clear();
            comboBox1.Text = "";
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");

            sql = "SELECT COUNT(rowid) FROM '" + temp_group + "'";
            command = new SQLiteCommand(sql, m_dbConnection);

            m_dbConnection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                N = Convert.ToInt32(reader["COUNT(rowid)"]);
            reader.Close();
            m_dbConnection.Close();


            for (i = 1; i <= N; i++)
            {
                sql = "SELECT name FROM '" + temp_group + "' WHERE rowid = ('" + i + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();


                if (reader.Read())
                {

                    student = Convert.ToString(reader["name"]);
                    
                }

                reader.Close();
                m_dbConnection.Close();

                comboBox1.Items.Add(student);
            }
            button1.Visible = false;
            button2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp_student = "";

            temp_student = comboBox1.Text;
            
            Form Form5 = new Form5(temp_student, temp_group);
            Form5.Show();

        }
    }
}
