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
    public partial class Form8 : Form
    {
        string les_type = "";
        string sql = "";
        SQLiteCommand command;
        SQLiteDataReader reader;
        int N = 42;
        int i = 42;
        string Name_of_group = "";
        int temp_lefts = 42;
        int temp_pefts = 42;

        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form8_Load(object sender, EventArgs e)
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
                sql = "SELECT name FROM Groups WHERE rowid = ('" + i + "')";
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

        private void button3_Click(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
            bool exist = false;
            if ((comboBox1.Text.Length > 0) && (comboBox2.Text.Length > 0))
            {
                sql = "SELECT * FROM poseshenie WHERE date = ('" + DateTime.Today + "') AND les_type = ('" + comboBox2.Text + "') AND grou_p = ('" + comboBox1.Text + "')";
                command = new SQLiteCommand(sql, m_dbConnection);

                m_dbConnection.Open();
                reader = command.ExecuteReader();
                

                if (reader.Read())
                    exist = true;

                reader.Close();
                m_dbConnection.Close();

                if (exist)
                {
                    Name_of_group = comboBox1.Text;
                    les_type = comboBox2.Text;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    checkedListBox1.Visible = true;
                    button3.Visible = false;
                    button1.Visible = true;

                    

                    sql = "SELECT COUNT(rowid) FROM ('" + Name_of_group + "')";
                    command = new SQLiteCommand(sql, m_dbConnection);

                    m_dbConnection.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                        N = Convert.ToInt32(reader["COUNT(rowid)"]);
                    reader.Close();
                    m_dbConnection.Close();

                    for (int i = 0; i < N; i++)
                    {
                        sql = "SELECT name FROM ('" + Name_of_group + "') WHERE rowid = ('" + i + "')";
                        command = new SQLiteCommand(sql, m_dbConnection);

                        m_dbConnection.Open();
                        reader = command.ExecuteReader();
                        if (reader.Read())
                            checkedListBox1.Items.AddRange(new object[] {reader["name"]});
                        reader.Close();
                        m_dbConnection.Close();
                        
                    }
                }
                else {
                    MessageBox.Show("Сегодняшнее занятие не создано, создайте занятие сначала!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else {
                   MessageBox.Show("Введите данные", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=28cm_db.sqlite;Version=3;");
             
                for(int i = 1; i <= checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.CheckedIndices.Contains(i))
                    {
                        sql = "UPDATE poseshenie SET prisut = ('" + 1 + "') WHERE date = ('" + DateTime.Today + "') AND student = ('" + i + "') AND les_type = ('" + les_type + "') AND grou_p = ('" + Name_of_group + "')";
                        command = new SQLiteCommand(sql, m_dbConnection);

                        m_dbConnection.Open();
                        command.ExecuteNonQuery();
                        m_dbConnection.Close();
                    }else {
                        switch(les_type)
                        {
                            case "Лекция":

                                sql = "SELECT lefts FROM ('" + Name_of_group + "') WHERE rowid = ('" + i + "')";
                                command = new SQLiteCommand(sql, m_dbConnection);

                                m_dbConnection.Open();
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                    temp_lefts = Convert.ToInt32(reader["lefts"]);
                                reader.Close();
                                m_dbConnection.Close();

                                temp_lefts++;
                                //temp_lefts.ToString();

                                sql = "UPDATE '" + Name_of_group + "' SET lefts = ('" + temp_lefts + "') WHERE rowid = ('" + i + "')";
                                command = new SQLiteCommand(sql, m_dbConnection);

                                m_dbConnection.Open();
                                command.ExecuteNonQuery();
                                m_dbConnection.Close();

                                break;

                            case "Практика":

                                sql = "SELECT pefts FROM ('" + Name_of_group + "') WHERE rowid = ('" + i + "')";
                                command = new SQLiteCommand(sql, m_dbConnection);

                                m_dbConnection.Open();
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                    temp_pefts = Convert.ToInt32(reader["pefts"]);
                                reader.Close();
                                m_dbConnection.Close();

                                temp_pefts++;
                                //temp_pefts.ToString();

                                sql = "UPDATE '" + Name_of_group + "' SET lefts = ('" + temp_pefts + "') WHERE rowid = ('" + i + "')";
                                command = new SQLiteCommand(sql, m_dbConnection);

                                m_dbConnection.Open();
                                command.ExecuteNonQuery();
                                m_dbConnection.Close();

                                break;
                            

                        }
                    }
                    
                }
            Form1.tabControl1.TabPages.Clear();
            Form1.Initialize();
            Close();


        }
    }
}
