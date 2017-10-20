using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyToBinaryTranslator
{
    public partial class NIOSII_Translator : Form
    {
        public NIOSII_Translator()
        {
            InitializeComponent();

            solution1Box.ReadOnly = true;
            solution2Box.ReadOnly = true;

            inputBox.Multiline = false;

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string input = inputBox.Text.Trim();

            string rawBinary = AssemblyTranslator.Translate(input);

            solution1Box.Text = BinaryUtilities.ApplyPadding(rawBinary, 4);

            solution2Box.Text = "0x"+Convert.ToString(Convert.ToInt32(rawBinary, 2), 16);

        }

    }
}
