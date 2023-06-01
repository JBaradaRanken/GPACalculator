using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace HOT_2JohnBaradaFinal
{
    public partial class frmTShirtDiscount : Form
    {
        public frmTShirtDiscount()
        {
            InitializeComponent();
        }
        const decimal TSHIRT = 13.75M;
        const decimal SALESTAX = 0.08M;

        private decimal CheckDiscountCode(string code)
        {
            decimal discount;

            switch (code)
            {
                case "8264":
                    discount = 0.3M;
                    break;

                case "5679":
                    discount = 0.2M;
                    break;

                case "6483":
                    discount = 0.1M;
                    break;

                default:
                    discount = 0M;
                    break;
            }

            return discount;
        }
        private void ShowInvoice(int qty, decimal discount)
        {
            decimal shirtCost = (discount == 0M) ? TSHIRT
                                                 : TSHIRT - (TSHIRT * discount);
            decimal subTotal = qty * shirtCost;
            decimal taxTotal = subTotal * SALESTAX;
            decimal finalTotal = subTotal + taxTotal;
            string outputStr = "";

            outputStr += qty.ToString() + " T-Shirts @ " +
                        shirtCost.ToString("c") + " each\r\n";
            outputStr += ("-----------------------------\r\n");
            outputStr += "Subtotal:\t\t" + subTotal.ToString("c");
            outputStr += "\r\nTax:\t\t" + taxTotal.ToString("c");
            outputStr += "\r\nTotal:\t\t" + finalTotal.ToString("c");

            txtResult.Text = outputStr;

        }
        private void CheckOrder()
        {
            bool result;
            bool retVal;
            int qty;
            string code = txtDiscountCode.Text;

            if (txtQuantity.Text.Trim() == "")
            {
                ShowMessage("Please Enter a Valid Quantity",
                            "No Quantity Found");
                txtQuantity.Text = "";
                txtQuantity.Focus();
                return;
            }
            result = Int32.TryParse(txtQuantity.Text, out qty);
            if (!result || qty<=0 )
            {
                ShowMessage("Please Enter a Valid Quantity",
                            "Enter a Positive Number");
                txtQuantity.Text = "";
                txtQuantity.Focus();
                return;
            }
            decimal discount = CheckDiscountCode(code);
            ShowInvoice(qty, discount);
        }
        private void ClearAll()
        {
            txtDiscountCode.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtResult.Text = string.Empty;
            txtQuantity.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            CheckOrder();
        }
    }
}