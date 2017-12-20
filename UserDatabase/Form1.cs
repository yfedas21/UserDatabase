using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserDatabase
{
    public partial class Form1 : Form
    {
        int numInputTextboxes = 4;

        public Form1()
        {
            InitializeComponent();
            firstNameTextBox.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDataSet.Student' table. 
            // You can move, or remove it, as needed. <--this code was auto-generated -YF
            this.studentTableAdapter.Fill(this.schoolDataSet.Student);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void validateInput()
        {
            if (firstNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter your first name.");
                firstNameTextBox.Focus();
            }
            else if (lastNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter your last name.");
                lastNameTextBox.Focus();
            }
            else if (majorTextBox.Text == "")
            {
                MessageBox.Show("Please enter your major.");
                majorTextBox.Focus();
            }
            else if (yearTextBox.Text == "")
            {
                MessageBox.Show("Please enter your anticipated graduation year.");
                yearTextBox.Focus();
            }
            else
            { 
                try 
                {
                    string trimmed = yearTextBox.Text.Trim();
                    if (Int32.TryParse(trimmed, out int year))
                    {
                        MessageBox.Show("The year you entered is " + year + ", and the next ID should be " + getNextId());
                    }
                    else
                    {
                        char[] yearArr = trimmed.ToCharArray();
                        for (int i = 0; i < yearArr.Length; i++)
                        {
                            if (yearArr[i] == '.')
                            {
                                MessageBox.Show("Please enter a positive integer for the year.");
                                yearTextBox.Text = "";
                                yearTextBox.Focus();
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a positive integer for the year.");
                    yearTextBox.Text = "";
                    yearTextBox.Focus();
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Please enter a reasonable year.");
                    yearTextBox.Text = "";
                    yearTextBox.Focus();
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            validateInput();

        }

        private void updateDataBase()
        {
            studentTableAdapter.Fill(schoolDataSet.Student); //Update the dataGridView 
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            updateDataBase();
        }

        private int getNextId()
        {
            return ((int)studentTableAdapter.GetLastIdUsed() + 1);
        }
    }
}
