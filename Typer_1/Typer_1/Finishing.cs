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
    public partial class Finishing : Form
    {
        int errors, wpm;
        int lessons, exercise;
        Form1 form1;

        public Finishing()
        {
            InitializeComponent();
        }

        private void Finishing_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button3;
            String lessonString = form1.lessonLable.Text;
            String excerciseString = form1.Excersice_Label.Text;
            this.errors = Form1.errors;
            this.wpm = Form1.wpm;

            if (!Form1.isCustom)
            {
                if (Form1.layout)
                {
                    this.lessons = Form1.lessonNum;
                }
                else
                {
                    this.lessons = 5;
                }
                this.exercise = Form1.exerciseNum;
            }
            else
            {
                this.lessons = 10;
                this.exercise = 0;
            }

            if(Form1.language == 0) {      //in amharic language
                amharicLanguage();
            }
            else if (Form1.language == 1)   //in english language
            {      
                englishLanguage();
            }
            else if(Form1.language == 2) {      //in oromiffa language
                oromiffaLanguage();
            } 
            else if(Form1.language == 3) {      //in tigrigna language
                tigrignaLanguage();
            } 
                        
        }

        public void setForm(Form1 f) {
            this.form1 = f;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            whenNextButtonIsClicked();
        }

        public void whenNextButtonIsClicked()
        {
            this.Close();
            if ((lessons == 5 && exercise == 9) || (lessons == 4 && exercise == 9) || (lessons == 9 && exercise == 3))     //rewinds lessons;
            {
                if (!Form1.layout)
                {
                    lessons = 5;
                }
                else
                {
                    if(lessons == 5) {
                        lessons = 0;
                    } else if(lessons == 9) {
                        lessons = 6;
                    }
                }
                exercise = 0;
            }
            else if (exercise == 9)
            {
                lessons++;
                exercise = 0;
            }
            else if (exercise < 10)
            {
                exercise++;
            }

            if (!Form1.isCustom)
            {
                form1.initialization(lessons, exercise);
            }
            else
            {
                if (!form1.uSEnglishToolStripMenuItem.Enabled)
                {
                    form1.makingWords();
                }
                else
                {
                    form1.makingNumeric();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.initialization(Form1.toBeTypedString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Confirmation confirm = new Confirmation();
            confirm.setForm(form1);
            confirm.ShowDialog();
        }
        public void amharicLanguage()
        {
            this.Text = "ጨርሰዋል";
            richTextBox1.Text = "    ይህንን  ትም ህርት  ጨ ርሰዋል! \n     -----------------------------\n\n    ስህተቶችዎ : " + errors + "\n    ፍጥነትዎ    : " + form1.calculateWPM() + "  ቃላት በደቂቃ፡፡";
            button1.Text = "ዝጋ";
            button2.Text = "ድጋሚ";
            button3.Text = "ቀጣይ";
        }
        public void englishLanguage()
        {
            this.Text = "Finished";
            richTextBox1.Text = "   You have finished this lesson! \n    ---------------------------------\n\n   Errors Commited : " + errors + "\n   Word Per Minute : " + form1.calculateWPM();
            button1.Text = "Exit";
            button2.Text = "Restart";
            button3.Text = "Next";
        }

        public void oromiffaLanguage()  
        {
            this.Text = "ጨርሰዋል";
            richTextBox1.Text = "    ይህንን  ትም ህርት  ጨ ርሰዋል! \n     -----------------------------\n\n    ስህተቶችዎ : " + errors + "\n    ፍጥነትዎ    : " + form1.calculateWPM() + "  ቃላት በደቂቃ፡፡";
            button1.Text = "ዝጋ";
            button2.Text = "ድጋሚ";
            button3.Text = "ቀጣይ";
        }

        public void tigrignaLanguage()
        {
            this.Text = "Finished";
            richTextBox1.Text = "   You have finished this lesson! \n    ---------------------------------\n\n   ስሕተታት: " + errors + "\n   ፍጥነት: " + form1.calculateWPM() + "  ቃላት በደቂቃ፡፡";
            button1.Text = "ዕጾ";
            button2.Text = "Restart";
            button3.Text = "Next";
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = button3;
        }
    }
}
