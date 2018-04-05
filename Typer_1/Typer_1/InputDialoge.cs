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
    public partial class InputDialoge : Form
    {
        public Form1 form_1;

        public InputDialoge()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateInput(inputedText.Text) == true)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool validateInput(String inputed)
        {
            if (inputed == null || inputed == "")
            {
                label3.Text = "Please enter some text";
                return false;
            }
            else if (inputed.Length < 3)
            {
                label3.Text = "Please enter at least 3 letters!";
                return false;
            }
            else
            {
                if (checkAllUnicode(inputed))
                {
                    inputed = convertToMainLetter(inputed);
                    Form1.custo = inputed;
                    Form1.noOfWords = (int)numericUpDown1.Value;
                    return true;
                }
                else
                {
                    Form1.custo = inputed;
                    Form1.noOfWords = (int)numericUpDown1.Value;
                    return true;
                }

            }
        }

        public bool checkAllUnicode(String inputed)
        {
            Boolean flag = true;
            foreach (char item in inputed)
            {
                if ((int)item < 4000)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public String convertToMainLetter(String inputed)
        {
            String newInput = "";
            char[] input = new char[inputed.Length];
            for (int i = 0; i < inputed.Length; i++)
            {
                input[i] = (char)getMainLetter((int)inputed[i]);
                newInput += input[i] + "";
            }
            return newInput;
        }

        public int getMainLetter(int letter)
        {
            int Decimal = letter;
            for (int i = Decimal; i > Decimal - 8; i--)
            {
                if (i % 8 == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public void setForm_1(Form1 formz)
        {
            this.form_1 = formz;
        }

        private void InputDialoge_Load(object sender, EventArgs e)
        {
            this.ActiveControl = inputedText;
            inputedText.Text = "";

            if (Form1.language == 0)
            {
                amharicLanguage();
            }
            else if (Form1.language == 1)
            {
                englishLanguage();
            }
            else if (Form1.language == 2)
            {
                oromiffaLanguage();
            }
            else if (Form1.language == 3)
            {
                tigrignaLanguage();
            }
        }

        public void englishLanguage()
        {
            label1.Text = "Enter The Keys You Wish To Practice";
            label2.Text = "Words";
            button1.Text = "Ok";
            button2.Text = "Cancel";
            this.Text = "Custom Lesson";
        }

        public void amharicLanguage()
        {
            label1.Text = "መለማመድ የሚፈልጉቸዉን ቁልፎች ያስገቡ";
            label2.Text = "ቃላቶች";
            button1.Text = "እሺ";
            button2.Text = "ይቅር";
            this.Text = "የግል ምርጫ";
        }

        public void oromiffaLanguage()
        {
            label1.Text = "መለማመድ የሚፈልጉቸዉን ቁልፎች ያስገቡ";
            label2.Text = "ቃላቶች";
            button1.Text = "እሺ";
            button2.Text = "ይቅር";
            this.Text = "የግል ምርጫ";
        }

        public void tigrignaLanguage()
        {
            label1.Text = "መለማመድ የሚፈልጉቸዉን ቁልፎች ያስገቡ";
            label2.Text = "ቃላቶች";
            button1.Text = "እሺ";
            button2.Text = "ይቕረ";
            this.Text = "ናይ ውልቀ ምርጫ";
        }

    }
}
