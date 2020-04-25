using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;


namespace lab12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            dataGridView1.Rows.Clear();
           


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  
                    var sr = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                    string s =sr.ReadToEnd();
                    string[] worlds = s.ToString().Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    // List<string> l = new List<string>(worlds);
                    var h = worlds.AsQueryable().Distinct();
                    Console.WriteLine(h.Count().ToString());
                    foreach (string hh in h)
                    {
                        int nc = 0;
                        for (int i = 0; i < worlds.Count(); i++)
                        {
                            if (worlds[i] == hh) nc++;
                        }
                            object[] row1 = new object[] { hh, nc };
                            dataGridView1.Rows.Add(row1);
                    }

                    dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
                    richTextBox1.Text = s.ToString();
                    dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                  dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                           
                            break;
                        }
            }
        }
    }
}
