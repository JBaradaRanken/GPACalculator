using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace HOT2_GPA2LetterGradeGUI
{
    public partial class frmLetterGrade : Form
    {
        public frmLetterGrade()
        {
            InitializeComponent();
        }
        private void CheckGrade(decimal grade)
        {
            string letter = "";
            if (grade >= 0M && grade < 1.0M)
            {
                letter = "F";
            }
            else if (grade >= 1.0M && grade < 1.5M)
            {
                letter = "D";
            }
            else if (grade >= 1.5M && grade < 2.5M)
            {
                letter = "C";
            }
            else if (grade >= 2.5M && grade < 3.2M)
            {
                letter = "B";
            }
            else if (grade >= 3.2M && grade <= 4.0M)
            {
                letter = "A";
            }
            txtResult.Text = "Your Letter Grade is : " + letter;
            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CheckInvalid();
        }
        private void ClearAll()
        {
            txtResult.Text = "";
            txtNumericGrade.Text = "";
            txtNumericGrade.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitPrompt();
        }
        private void ExitPrompt()
        {
            DialogResult dialog = MessageBox.Show(

        "Do You Really Want To Exit The Program?",

        "EXIT NOW?",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)

            {

                Application.Exit();
            }
        }
        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question);
        }
        private void CheckInvalid()
        {
            decimal grade;
            bool result;
            if (txtNumericGrade.Text.Trim() == "")
            {
                ShowMessage("Please Enter a Valid Quantity",
                            "No Quantity Found");
                txtNumericGrade.Text = "";
                txtNumericGrade.Focus();
                return;
            }
            //result = Int32.TryParse(txtQuantity.Text, out qty);
            result = Decimal.TryParse(txtNumericGrade.Text, out grade);
            if (grade <= 0M || grade > 4.0M)
            {
                ShowMessage("Please Enter a Valid Quantity",
                            "Enter a Number between 0 and 4");
                txtNumericGrade.Text = "";
                txtNumericGrade.Focus();
                return;
            }
            CheckGrade(grade);
        }

    }
}