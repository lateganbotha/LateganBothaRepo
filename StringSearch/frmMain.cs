using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringSearch
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void txtSearchString_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var textboxSender = (TextBox)sender;

                var cursorPosition = textboxSender.SelectionStart;

                textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z]", "");

                textboxSender.SelectionStart = cursorPosition;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.CheckFileExists = true;

                dlg.CheckPathExists = true;

                dlg.Multiselect = false;

                dlg.Filter = "Text|*.txt|All|*.*";

                dlg.ShowDialog();

                txtPath.Text = dlg.FileName;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lstResults.Items.Clear();

                if (txtPath.Text == string.Empty)
                {
                    MessageBox.Show("Please Select a File First");

                    return;
                }

                if (txtSearchString.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter String to Seach.");

                    return;
                }

                string sorted = string.Empty;

                string inPutString = txtSearchString.Text;

                sorted = SortString(inPutString.ToUpper());

                string line = string.Empty;

                System.IO.StreamReader file = new System.IO.StreamReader(txtPath.Text);

                while ((line = file.ReadLine()) != null)
                {
                    string fileString = SortString(line.ToUpper());

                    if (sorted.Equals(fileString))
                    {
                        lstResults.Items.Add(line);
                    }
                }

                if (lstResults.Items.Count <= 0)
                {
                    MessageBox.Show("No matches found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string SortString(string input)
        {
            try
            {
                string returnString = string.Empty;

                string letters = new String(input.Where(Char.IsLetter).OrderBy(c => c).ToArray());
                string numbers = new String(input.Where(Char.IsNumber).OrderBy(c => c).ToArray());

                return returnString = letters + numbers;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
