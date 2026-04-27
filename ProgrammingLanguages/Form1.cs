using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newLang = txtLanguage.Text.Trim();

            // Validation: Empty check
            if (string.IsNullOrWhiteSpace(newLang))
            {
                MessageBox.Show("Please enter a language name.", "Input Empty");
                return;
            }

            // Validation: Duplicate check
            bool exists = lstLanguages.Items.Cast<string>()
                          .Any(item => item.Equals(newLang, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                MessageBox.Show($"{newLang} is already in your list!", "Duplicate Found");
            }
            else
            {
                lstLanguages.Items.Add(newLang);
                txtLanguage.Clear();
                
            }

            txtLanguage.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstLanguages.SelectedIndex != -1)
            {
                lstLanguages.Items.RemoveAt(lstLanguages.SelectedIndex);
               
            }
            else
            {
                MessageBox.Show("Pick  a language from the list first.", "Nothing Selected");
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Ask for confirmation so the user doesn't delete by accident
            DialogResult result = MessageBox.Show("Do you really want to clear the entire list?",
                                  "Clear List", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                lstLanguages.Items.Clear();
               
            }
        }

        private void chkSort_CheckedChanged(object sender, EventArgs e)
        {
            lstLanguages.Sorted = chkSort.Checked;
        }
        

        private void lstLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       
        
            private void btnSearch_Click(object sender, EventArgs e)
        {
            // 1. Get the text from your search textbox
            string searchTerm = textbox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Put in a language name to search for.");
                return;
            }

            // 2. Find the item in the ListBox
            // FindString looks for the first item starting with that text
            int index = lstLanguages.FindString(searchTerm);

            if (index != -1)
            {
                // 3. Highlight the found item
                lstLanguages.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Language not found in the list.");
                lstLanguages.ClearSelected();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

