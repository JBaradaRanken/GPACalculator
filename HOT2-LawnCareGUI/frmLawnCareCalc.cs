using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOT2_LawnCareGUI
{
    public partial class frmLawnCareCalc : Form
    {
        public frmLawnCareCalc()
        {
            InitializeComponent();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            txtLength.Text = "";
            txtWidth.Text = "";
            txtResult.Text = "";
            txtLength.Focus();
        }
        //CONSTANT
        const int SEASONLENGTH = 20;
        private void ReturnOrder()
        {
            decimal length = 0M;
            decimal width = 0M;
            int weeklyFee = 25;
            decimal total = 0;
            string outputStr = "";
            Decimal.TryParse(txtLength.Text, out length);
            Decimal.TryParse(txtWidth.Text, out width);

            total = length * width;

            if (total >= 600)
            {
                weeklyFee = weeklyFee + 25;
            }
            else if (total >= 400 && total < 600)
            {
                weeklyFee = weeklyFee + 15;
            }
            outputStr = "Area: \t\t";
            outputStr += total.ToString() + " square feet \r\n"
                + "Weekly Fee: \t\n"
                + weeklyFee.ToString("c") + "\r\n"
                + "Season Length:\t"
                + SEASONLENGTH.ToString() + " Weeks \r\n"
                + "Total: \t\t"
                + total.ToString("c");
            txtResult.Text = outputStr;
        }
        private void CheckOrder()
        {   bool resultA;
            decimal resultB;
            if (txtLength.Text.Trim() == "" || txtWidth.Text.Trim() == "")
            {
                ShowMessage("Please Enter a Valid Quantity",
                            "No Quantity Found");
                txtLength.Text = "";
                txtWidth.Text = "";
                txtLength.Focus();
                return;
            }
            resultA = Decimal.TryParse(txtLength.Text, out resultB);
            if (!resultA || resultB<=0 )
            {
                ShowMessage("Please Enter a Valid Quantity",
                            "Zero and Negative Not Available");
                txtLength.Text = "";
                txtWidth.Text = "";
                txtLength.Focus();
                return;
            }
            else
            {
                ReturnOrder();
            }
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CheckOrder();
        }
        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question);
        }
    }
}