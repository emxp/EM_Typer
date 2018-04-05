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
    public partial class Help : Form
    {
        Lessons lessons = new Lessons();
        Form1 form_1;

        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            label1.Focus();
            this.ActiveControl = label1;


            if (Form1.language == 0)            //amharic language
            {
                this.Text = "እገዛ";
                HelptextBox.Font = new System.Drawing.Font("Nyala", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                HelptextBox.Text = lessons.amharicHelp;
            }
            else if (Form1.language == 1)        //english language
            {
                this.Text = "Help";
                HelptextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                HelptextBox.Text = lessons.englishHelp;
            }
            else if (Form1.language == 2)        //oromiffa language
            {
                this.Text = "እገዛ";
                HelptextBox.Font = new System.Drawing.Font("Nyala", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                HelptextBox.Text = lessons.amharicHelp;
            }
            else if (Form1.language == 3)        //tigrigna language
            {
                this.Text = "ሓገዝ";
                HelptextBox.Font = new System.Drawing.Font("Nyala", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                HelptextBox.Text = lessons.tigrignaHelp;
            }

        }

        public void setForm_1(Form1 formzz)
        {
            this.form_1 = formzz;
        }

        private void label1_Leave(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }
    }
}
