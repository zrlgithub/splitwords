using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;


namespace splitwords
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            listClients.Items.Clear();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void buttonInit_Click(object sender, EventArgs e)
        {
            listClients.Items.Clear();
            List<fileHandler> listOfFiles = new List<fileHandler>();

            foreach (string file in Directory.EnumerateFiles("your dir\\splitwords\\Clients\\", "*.txt"))
            {
                string nameFile = file.Remove(0, 45);
                fileHandler newIn = new fileHandler(nameFile);

                listOfFiles.Add(newIn);

            
            }

            Dictionary <fileHandler, List<WordCounter>> list = new Dictionary<fileHandler, List<WordCounter>>();
            foreach ( var file in listOfFiles)
            {
                //var temporaryList = new List<WordCounter>();
                string nameFile = file.ipSource + ' ' + file.clientName;
                
                var fileContent = File.ReadAllText("your dir\\splitwords\\Clients\\"+nameFile+".txt");
                string allWords = fileContent;
                string[] wordsArray = allWords.Split(' ', ',', '[', ']', '!', ':', '?','"','^','(',')');

                List<WordCounter> listOfWordCounters = new List<WordCounter>();

                foreach (string WORD in wordsArray)
                {
                    WordCounter foundWord = listOfWordCounters.Find(X => X.word == WORD);
                    if (foundWord == null)
                    {
                        listOfWordCounters.Add(new WordCounter(WORD, 1));
                    }
                    else
                    {
                        foundWord.frequency++;
                    }
                }
                list.Add(file, listOfWordCounters);

            }

            string connectionString;
            SqlConnection conn;
            connectionString = "Server=?????\\MSSQLSERVER01;Database=PSO;Integrated Security=true;";
            conn = new SqlConnection(connectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();
            //stergere valori tabele pt initializare
            string sqlTruncPeople = "TRUNCATE TABLE " + "People";
            string sqlTruncWords = "TRUNCATE TABLE " + "Words";
            SqlCommand cmd_truncate = new SqlCommand(sqlTruncPeople, conn);

            if (cmd_truncate.Connection.State != ConnectionState.Open)
                cmd_truncate.Connection.Open();

            cmd_truncate.ExecuteNonQuery();
            cmd_truncate.Connection.Close();

            SqlCommand cmd_truncate2 = new SqlCommand(sqlTruncWords, conn);

            if (cmd_truncate2.Connection.State != ConnectionState.Open)
                cmd_truncate2.Connection.Open();

            cmd_truncate2.ExecuteNonQuery();
            cmd_truncate2.Connection.Close();

            //comanda de inserare in tabele

           
            foreach (var item in list)
            {
                SqlCommand cmd = conn.CreateCommand();
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.Clear();
                cmd.CommandText = "Insert into People(Ip,Name) Values (@ip,@name)";
                cmd.Parameters.AddWithValue("@ip", item.Key.ipSource);
                cmd.Parameters.AddWithValue("@name", item.Key.clientName);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                cmd.Dispose();

               
                //adaugare in table Words pt fiecare utilizator
                foreach (var itemPeople in item.Value)
                {

                    SqlCommand getID = conn.CreateCommand();
                    getID.Connection.Open();
                    getID.CommandText = "select id from People where Name like @user";
                    getID.Parameters.AddWithValue("@user", item.Key.clientName.ToString());

                    int rez = (Int32) (getID.ExecuteScalar());
                    getID.Connection.Close();
                    getID.Dispose();

                    SqlCommand cmdwords = conn.CreateCommand();
                    if (cmdwords.Connection.State != ConnectionState.Open)
                        cmdwords.Connection.Open();

                    cmdwords.Parameters.Clear();
                    cmdwords.CommandText = " insert into Words values (@wordd, @frequency,@user)";
                    cmdwords.Parameters.AddWithValue("@frequency", itemPeople.frequency);
                    cmdwords.Parameters.AddWithValue("@wordd", itemPeople.word);
                    cmdwords.Parameters.AddWithValue("@user",rez);

                    cmdwords.ExecuteNonQuery();
                    cmdwords.Connection.Close();
                    cmdwords.Dispose();

                }

        
            }
          
            conn.Close();
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.Default;

            using (PSOEntities db = new PSOEntities())
            {
                List<Person> List = db.People.ToList();
                foreach (Person p in List)
                {
                    ListViewItem item = new ListViewItem(p.IP);
                    item.SubItems.Add(p.Name);
                    listClients.Items.Add(item);
                }

            }
        }
        private void createCombination(List<fileHandler> listOfFiles)
        {
            
        }
        private async void listClients_ItemActivate(object sender, EventArgs e)
        {
            if(listClients.SelectedItems.Count>0)
            {
                ListViewItem item = listClients.SelectedItems[0];

                using (PSOEntities db = new PSOEntities())
                {
                    string name = item.SubItems[1].Text;
                    SqlConnection conn;
                    string connectionString = "Server=???\\MSSQLSERVER01;Database=PSO;Integrated Security=true;";
                    conn = new SqlConnection(connectionString);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    SqlCommand getID = conn.CreateCommand();

                    //getID.Connection.Open();
                    getID.CommandText = "select id from People where Name like @user";
                    getID.Parameters.AddWithValue("@user", name);

                    int rez = (Int32)(getID.ExecuteScalar());

                    getID.Connection.Close();
                    getID.Dispose();

                    conn.Close();

                    Person p = await db.People.FindAsync(rez);
                    Word w = await db.Words.FindAsync(rez);
                    if (p != null)
                    {
                        using (Form2 details = new Form2(w))
                        {
                            if(details.ShowDialog() == DialogResult.OK)
                            {
                                //
                            }
                        }
                    }
                }

                  
            }
        }
    }
}
