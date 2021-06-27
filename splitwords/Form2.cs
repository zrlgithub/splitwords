using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace splitwords
{
    public partial class Form2 : Form
    {
        Random rnd = new Random();

        private ListViewColumnSorter lvwColumnSorter;
        private int id { get; set; }

        public Form2(Word w)
        {
            InitializeComponent();
            wordsBindingSource.DataSource = w;
     
            lvwColumnSorter = new ListViewColumnSorter();
            this.listWithFreq.ListViewItemSorter = lvwColumnSorter;

            this.id = (int)w.id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'pSODataSet.Words' table. You can move, or remove it, as needed.
            this.wordsTableAdapter.Fill(this.pSODataSet.Words);
            using (PSOEntities db = new PSOEntities())
            {
                List<Word> List = db.Words.ToList();
                foreach (Word p in List)
                {
                    if (p.id_people == id)
                    {
                        ListViewItem item = new ListViewItem(p.frequency);
                        item.SubItems.Add(p.word1);
                        listWithFreq.Items.Add(item);
                    }
                }

            }
            //size each column header to fit the column header text
            foreach (ColumnHeader ch in this.listWithFreq.Columns)
            {
                ch.Width = -2;
            }
            

        }

        private void listWithFreq_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                if (e.Column == 0)
                {

                }
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listWithFreq.Sort();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListView ls = new ListView();
            ls = listWithFreq;

            listWithFreq.SelectedItems.Clear();
            for (int i = listWithFreq.Items.Count - 1; i >= 0; i--)
            {

                if (listWithFreq.Items[i].SubItems[1].ToString().ToLower().Contains(searchWord.Text.ToLower()))
                {
                    listWithFreq.Items[i].BackColor = Color.Red;
                    
                }
            }
            //if(searchWord.Text=="")
            //{
            //    for (int i = listWithFreq.Items.Count - 1; i >= 0; i--)
            //    {
            //        if (listWithFreq.Items[i].BackColor == Color.Red)
            //        {
            //            listWithFreq.Items[i].BackColor = DefaultBackColor;
            //        }
            //    }

            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (searchWord.Text == "")
            {
                for (int i = listWithFreq.Items.Count - 1; i >= 0; i--)
                {
                    if (listWithFreq.Items[i].BackColor == Color.Red)
                    {
                        listWithFreq.Items[i].BackColor = SystemColors.Info;
                    }
                }

            }

        }
    }
}