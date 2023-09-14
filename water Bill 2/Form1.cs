using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace water_Bill_2
{
    public partial class Form1 : Form
    {
        string[] months = new string[] { "January" ,"February","March","April","May","June","July","August","September","November",
            "December" };
    
      
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < months.Length; i++)
            {
                comboBox2.Items.Add(months[i]);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            
            string month, name;
           int usage;
            bool error = false ;
            
            usage = 0;
            if(txt_name.Text==""||txt_usage.Text==""|| comboBox1.SelectedIndex == -1
                || txt_usage.Text == "" || !Int32.TryParse(txt_usage.Text, out usage))
            {
                error = true;
            }
            if (!error)
            {
                dataGridView1.Rows.Add(txt_name.Text, comboBox1.SelectedItem.ToString(),
                    txt_usage.Text);
               
            }
            else
            {
                MessageBox.Show("Invalid input");
            }

        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            try
            {
                var customersList = new List<string>();
                var unitsList = new List<int>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(comboBox2.SelectedItem.ToString()))
                    {
                        customersList.Add(row.Cells[0].Value.ToString());
                        unitsList.Add(int.Parse(row.Cells[2].Value.ToString()));
                    }
                }

                string[] customersArray = customersList.ToArray();
                int[] unitsArray = unitsList.ToArray();

                Form2 f2 = new Form2(comboBox2.SelectedItem.ToString(),
                    customersArray, unitsArray);

                f2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
