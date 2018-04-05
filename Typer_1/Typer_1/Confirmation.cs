using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typer_1
{
    public partial class Confirmation : Form
    {
        Form1 form1;

        public Confirmation()
        {
            InitializeComponent();
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            if (Form1.language == 0)        //english language
            {
                richTextBox1.Text = "\nእርግጠኛ  ነዎት?";
                yes_button1.Text = "አዎ";
                no_button2.Text = "በፍጹም";
                this.Text = "ማረጋገጫ";   
            }
            else if (Form1.language == 1)   
            {
                richTextBox1.Text = "\n       Are you sure?";
                yes_button1.Text = "Yes";
                no_button2.Text = "No";
                this.Name = "Confirmation";
            }
            else if (Form1.language == 2)
            {
                richTextBox1.Text = "\nእርግጠኛ  ነዎት?";
                yes_button1.Text = "አዎ";
                no_button2.Text = "በፍጹም";
                this.Text = "ማረጋገጫ";
            }
            else if (Form1.language == 3)
            {
                richTextBox1.Text = "\nእርግጠኛ  ነዎት tigrigna?";
                yes_button1.Text = "አዎ";
                no_button2.Text = "በፍጹም";
                this.Text = "ማረጋገጫ";
            }
            
            this.ActiveControl = no_button2;
        }

        private void yes_button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.Close();
        }

        public void setForm(Form1 f) {
            this.form1 = f;
        }

        private void no_button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = no_button2;
        }
    }
}
