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
    public partial class Form3 : Form
    {
        string sql = "";
        SQLiteCommand command;
        SQLiteDataReader reader;
        bool exist;
        int N = 42;
        int i = 42;
        string Name_of_group = "";
        string group_year = "";
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
                    group_year = Convert.ToString(reader["year"]);
                }

                reader.Close();
                m_dbConnection.Close();

                comboBox1.Items.Add(Name_of_group);
            }
        }

        private void cancelButton_form3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_form3_Click(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");

            if ((comboBox1.Text.Length > 0)&&(textBox1.Text.Length > 0)&&(textBox2.Text.Length > 0))
            {
                string Student_Name = textBox1.Text + " " + textBox2.Text;

                sql = "SELECT name FROM '" + comboBox1.Text + "' WHERE name = ('" + Student_Name + "')";
                command = new SQLiteCommand(sql, m_dbConnection);
                
                m_dbConnection.Open();
                reader = command.ExecuteReader();
                exist = false;

                if (reader.Read())
                    exist = true;

                reader.Close();
                m_dbConnection.Close();


                if (!exist)
                {
                    int row = Form1.id_growth(comboBox1.Text) + 1;
                    sql = "INSERT INTO '" + comboBox1.Text + "' (rowid,name,balls,lefts,pefts) VALUES ('" + row + "','" + Student_Name + "', '" + 0 + "' , '" + 0 + "' , '" + 0 + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                    Form1.tabControl2.TabPages.Clear();
                    Form1.Initialize();
                    Close();
                }
                else
                {
                    MessageBox.Show("Студент существует", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите данные", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
