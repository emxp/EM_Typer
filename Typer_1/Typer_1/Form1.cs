using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        Lessons lessons = new Lessons();
        public Timer timer;
        private String timerString = "00:00:00", Stf = "00", Mtf = "00", Htf = "00";
        ArrayList customEnglishWords = new ArrayList();
        ArrayList customAmharicWords = new ArrayList();
        public static int language = 1;           //0 = amharic, 1 = English, 2 = oromiffa, 3 = tigrigna;
        public static bool layout = true;           //True = usEnglish, false = numeric
        public static bool isCustom = false;
        public static int lessonNum = 0;
        public static int exerciseNum = 0;


        Finishing finishing = new Finishing();

        public static int errors = 0, wpm = 0;
        Boolean doNotPrint;
        int noOfSpaces = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "EM Typer";
            fillCustomEnglishWords();
            fillCustomAmharicWords();
            WindowState = FormWindowState.Maximized;

            uSEnglishToolStripMenuItem.Enabled = false;
            NumericToolStripMenuItem.Enabled = false;

            toBeTypedString = lessons.lesson[0, 0];
            textBox2.Focus();
            initialization(0, 0);
            changeButtonColor();
            language = 1;
        }

        public void fillCustomEnglishWords()
        {
            int initial = 0, destination = 0;
            String normal = "";
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    initial = 0;
                    destination = 0;
                    normal = lessons.englishWords[i, j];
                    for (int k = 0; k < normal.Length; k++)
                    {

                        if (normal[k].Equals(' '))
                        {
                            destination = k;
                            if (normal.Substring(initial, destination - initial).Length > 2)
                                customEnglishWords.Add(normal.Substring(initial, destination - initial));
                            initial = destination + 1;
                        }
                    }
                }
            }
            //foreach (string x in customEnglishWords)
            //{
            //    if (x.Contains(' '))
            //        MessageBox.Show(x);
            //    Console.WriteLine(x);
            //}
            Console.WriteLine(customEnglishWords.Count + "  0000000000zzzzzz");
        }

        public void fillCustomAmharicWords()
        {
            int initial = 0, destination = 0;
            String normal = "";
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    initial = 0;
                    destination = 0;
                    normal = lessons.amharicWords[i, j];
                    for (int k = 0; k < normal.Length; k++)
                    {

                        if (normal[k].Equals(' '))
                        {
                            destination = k;
                            if (normal.Substring(initial, destination - initial).Length > 1)
                                customAmharicWords.Add(normal.Substring(initial, destination - initial));
                            initial = destination + 1;
                        }
                    }
                }
            }
        }

        private void numericKeypadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whenNumericLayoutIsPressed();
        }

        public void whenNumericLayoutIsPressed()
        {
            panel2.Visible = true;
            panel1.Visible = false;
            uSEnglishToolStripMenuItem.Enabled = true;
            numericKeypadToolStripMenuItem.Enabled = false;
            lesson1ToolStripMenuItem.Enabled = false;
            lesson2ToolStripMenuItem.Enabled = false;
            lesson3ToolStripMenuItem.Enabled = false;
            lesson4ToolStripMenuItem.Enabled = false;
            lesson5ToolStripMenuItem.Enabled = false;
            NumericToolStripMenuItem.Enabled = true;
            toolStripMenuItem23.Enabled = false;
            toolStripMenuItem25.Enabled = false;
            toolStripMenuItem24.Enabled = false;

            initialization(5, 0);
        }

        private void uSEnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whenUsEnglishLayoutIsPressed();
        }

        public void whenUsEnglishLayoutIsPressed()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            uSEnglishToolStripMenuItem.Enabled = false;
            numericKeypadToolStripMenuItem.Enabled = true;
            lesson1ToolStripMenuItem.Enabled = true;
            lesson2ToolStripMenuItem.Enabled = true;
            lesson3ToolStripMenuItem.Enabled = true;
            lesson4ToolStripMenuItem.Enabled = true;
            lesson5ToolStripMenuItem.Enabled = true;
            toolStripMenuItem23.Enabled = true;
            toolStripMenuItem25.Enabled = true;
            toolStripMenuItem24.Enabled = true;
            NumericToolStripMenuItem.Enabled = false;

            initialization(0, 0);
        }

        Confirmation confirm = new Confirmation();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            confirm.setForm(this);
            confirm.ShowDialog();
        }

        private void exercise1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 0);
        }

        private void exercise2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 1);
        }

        private void exercise3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 2);
        }

        private void exercise4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 3);
        }

        private void exercise5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 4);
        }

        private void exercise6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 5);
        }

        private void exercise7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 6);
        }

        private void exercise8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 7);
        }

        private void exercise9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 8);
        }

        private void exercise10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(0, 9);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            initialization(1, 0);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            initialization(1, 1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            initialization(1, 2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            initialization(1, 3);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            initialization(1, 4);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            initialization(1, 5);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            initialization(1, 6);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            initialization(1, 7);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            initialization(1, 8);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            initialization(1, 9);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            initialization(2, 0);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            initialization(2, 1);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            initialization(2, 2);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            initialization(2, 3);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            initialization(2, 4);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            initialization(2, 5);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            initialization(2, 6);
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            initialization(2, 7);
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            initialization(2, 8);
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            initialization(2, 9);
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            initialization(3, 0);
        }

        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
            initialization(3, 1);
        }

        private void toolStripMenuItem59_Click(object sender, EventArgs e)
        {
            initialization(3, 2);
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            initialization(3, 3);
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            initialization(3, 4);
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            initialization(3, 5);
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            initialization(3, 6);
        }

        private void toolStripMenuItem64_Click(object sender, EventArgs e)
        {
            initialization(3, 7);
        }

        private void toolStripMenuItem65_Click(object sender, EventArgs e)
        {
            initialization(3, 8);
        }

        private void toolStripMenuItem66_Click(object sender, EventArgs e)
        {
            initialization(3, 9);
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            initialization(4, 0);
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            initialization(4, 1);
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            initialization(4, 2);
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            initialization(4, 3);
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            initialization(4, 4);
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            initialization(4, 5);
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            initialization(4, 6);
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            initialization(4, 7);
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            initialization(4, 8);
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            initialization(4, 9);
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            initialization(5, 0);
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            initialization(5, 1);
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            initialization(5, 2);
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            initialization(5, 3);
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            initialization(5, 4);
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            initialization(5, 5);
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            initialization(5, 6);
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            initialization(5, 7);
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            initialization(5, 8);
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            initialization(5, 9);
        }

        public static String custo = "", customChars = "", toBeTypedString = "";
        public static int noOfWords = 15;
        InputDialoge input = new InputDialoge();

        Random random = new Random();

        public void initialization(int i, int j)
        {
            timer = new Timer();
            timer.Interval = (1000);
            timer.Enabled = false;
            timer_label4.Text = "00 : 00 : 00";
            Stf = Mtf = Htf = "00";
            timer.Tick += new EventHandler(timer_Tick);

            lessonNum = i;
            exerciseNum = j;

            if (i < 5)
            {
                toBeTypedString = differentLesson(lessons.lesson[i, j]);
                isCustom = false;
                layout = true;      //usEnglish
                if (language == 1)      //in english language
                {
                    lessonLable.Text = "Lesson " + (i + 1);
                    Excersice_Label.Text = ", Exercise " + (j + 1);
                }
                else if(language == 0)
                {                                                   //amharic
                    lessonLable.Text = "ትምህርት " + (i + 1);
                    Excersice_Label.Text = ", መልመጃ " + (j + 1);
                }
                else if (language == 2)
                {                                                   //oromiffa
                    lessonLable.Text = "ትምህርት " + (i + 1);
                    Excersice_Label.Text = ", መልመጃ " + (j + 1);
                }
                else
                {                                                   //tigrigna
                    lessonLable.Text = "ትምህርቲ " + (i + 1);
                    Excersice_Label.Text = ", መልመዲ " + (j + 1);
                }
            }
            else if (i == 5)
            {
                toBeTypedString = differentLesson(lessons.lesson[i, j]);
                isCustom = false;
                layout = false;     //numeric layout
                if (language == 1)      //in english language
                {
                    lessonLable.Text = "Numeric Lesson";
                    Excersice_Label.Text = ", Exercise " + (j + 1);
                }
                else if (language == 0)
                {                                                   //amharic
                    lessonLable.Text = "        የቁጥር";
                    Excersice_Label.Text = ", መልመጃ " + (j + 1);
                }
                else if (language == 2)
                {                                                   //oromiffa
                    lessonLable.Text = "        የቁጥር";
                    Excersice_Label.Text = ", መልመጃ " + (j + 1);
                }
                else
                {                                                   //tigrigna
                    lessonLable.Text = "        ናይ ቁጽሪ";
                    Excersice_Label.Text = ", መልመዲ " + (j + 1);
                }
            }
            else if (i > 5 && i < 10)
            {
                toBeTypedString = differentLesson(lessons.lesson[i, j]);
                isCustom = false;
                layout = true;      //usEnglish
                if (language == 1)      //in english language
                {
                    lessonLable.Text = "Lesson " + (i + 1);
                    Excersice_Label.Text = ", Exercise " + (j + 1);
                }
                else if(language == 0)
                {                                                   //amharic
                    lessonLable.Text = "ትምህርት " + (i + 1);
                    Excersice_Label.Text = ", መልመጃ " + (j + 1);
                }
                else if(language == 2)
                {                                                   //oromiffa
                    lessonLable.Text = "ትምህርት " + (i + 1);
                    Excersice_Label.Text = ", መልመጃ " + (j + 1);
                }
                else
                {                                                   //tigrigna
                    lessonLable.Text = "ትምህርቲ " + (i + 1);
                    Excersice_Label.Text = ", መልመዲ " + (j + 1);
                }
            }
            else
            {
                if (language == 1)      //in english language
                {
                    lessonLable.Text = "Custom Lesson";
                }
                else if(language == 0)
                {                                                   //amharic
                    lessonLable.Text = "የግል ምርጫ";
                }
                else if(language == 2)
                {                                                   //oromiffa
                    lessonLable.Text = "የግል ምርጫ";
                }
                else
                {                                                   //tigrigna
                    lessonLable.Text = "ናይ ውልቀ ምርጫ";
                }

                Excersice_Label.Text = "";
                isCustom = true;
            }
            typedKeys.Clear();
            currentPosition = 0;
            middleIndex = 0;
            errors = 0;
            wpm = 0;
            noOfSpaces = 0;
            textBox1.Text = toBeTypedString;
            textBox2.Text = null;
            doNotPrint = true;
            if (language == 1)      //in english language
            {
                Error_label.Text = "ERRORS : " + errors;
                WPM_label.Text = "WPM : " + wpm;
            }
            else if(language == 0)
            {
                Error_label.Text = "ስህተቶች : " + errors;     //amharic
                WPM_label.Text = "ፍጥነት : " + wpm;
            }
            else if(language == 2)
            {
                Error_label.Text = "ስህተቶች : " + errors;     //oromiffa
                WPM_label.Text = "ፍጥነት : " + wpm;
            }
            else
            {
                Error_label.Text = "ስሕተታት : " + errors;     //tigrigna
                WPM_label.Text = "ፍጥነት : " + wpm;
            }
            removeButtonColor(bb, cc);
            changeButtonColor();
        }

        public void initialization(String orginal)
        {
            timer = new Timer();
            timer.Interval = (1000);
            timer.Enabled = false;
            timer_label4.Text = "00 : 00 : 00";
            Stf = "00";
            Mtf = "00";
            Htf = "00";
            timer.Tick += new EventHandler(timer_Tick);

            toBeTypedString = orginal;

            typedKeys.Clear();
            currentPosition = 0;
            middleIndex = 0;
            errors = 0;
            wpm = 0;
            noOfSpaces = 0;
            textBox1.Text = toBeTypedString;
            textBox2.Text = null;
            doNotPrint = true;
            if (language == 1)      //in english language
            {
                Error_label.Text = "ERRORS : " + errors;
                WPM_label.Text = "WPM : " + wpm;
            }
            else if (language == 0)
            {
                Error_label.Text = "ስህተቶች : " + errors;     //amharic
                WPM_label.Text = "ፍጥነት : " + wpm;
            }
            else if (language == 2)
            {
                Error_label.Text = "ስህተቶች : " + errors;     //oromiffa
                WPM_label.Text = "ፍጥነት : " + wpm;
            }
            else
            {
                Error_label.Text = "ስሕተታት : " + errors;     //tigrigna
                WPM_label.Text = "ፍጥነት : " + wpm;
            }
            removeButtonColor(bb, cc);
            changeButtonColor();
        }


        ArrayList newLesson = new ArrayList();

        public String differentLesson(String normal)
        {
            normal += " ";
            newLesson.Clear();
            int initial = 0, destination = 0;

            for (int i = 0; i < normal.Length; i++)
            {
                if (normal[i].Equals(' ') || normal[i].Equals('/') || normal[i].Equals('*') || normal[i].Equals('-') || normal[i].Equals('+'))
                {
                    destination = i;
                    newLesson.Add(normal.Substring(initial, destination - initial));
                    initial = destination + 1;
                }
            }

            Console.WriteLine(newLesson.Count + "NewLesson.Count");
            //foreach (string x in newLesson)
            //{
            //    if (x.Contains(' '))
            //        MessageBox.Show(x);
            //    Console.WriteLine(x);
            //}
            return makeDifferent();
        }

        public String makeDifferent()
        {
            String newString = "";

            for (int i = 0; i < newLesson.Count; i++)
            {
                int rand = random.Next(newLesson.Count);
                if (numericKeypadToolStripMenuItem.Enabled)
                {
                    newString += newLesson[rand] + " ";
                }
                else
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            newString += newLesson[rand] + "/";
                            break;
                        case 2:
                            newString += newLesson[rand] + "*";
                            break;
                        case 3:
                            newString += newLesson[rand] + "-";
                            break;
                        case 4:
                            newString += newLesson[rand] + "+";
                            break;
                    }
                }
                newLesson.RemoveAt(rand);
                i--;
            }

            while (newString.Contains("  "))
            {
                newString = newString.Replace("  ", " ");
            }

            newString = newString.Trim();

            return newString;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (sender == timer)
            {
                change();
            }
        }

        void change()
        {
            int Sec, Min, Hor;
            Sec = Convert.ToInt32(Stf);
            Sec++;
            if (Sec > 59)
            {
                Min = Convert.ToInt32(Mtf);
                Min++;
                if (Min > 59)
                {
                    Hor = Convert.ToInt32(Htf);
                    Stf = "00";
                    Mtf = "00";
                    Htf = (formal(++Hor)) + "";
                }
                else
                {
                    Mtf = formal(Min) + "";
                    Stf = "00";
                }
            }
            else
            {
                Stf = formal(Sec) + "";
            }

            timerString = "" + Htf + " : " + Mtf + " : " + Stf;
            timer_label4.Text = timerString;
        }

        String formal(int time)
        {
            if (time < 10)
            {
                return "0" + time;
            }
            else
            {
                return "" + time;
            }
        }


        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            
        }

        public void acceptCustomText()
        {
            input.setForm_1(this);
            input.ShowDialog();
            customChars = custo;
            if (customChars.Length > 2)
            {
                if (layout)     //usEnglish
                {
                    makingWords();
                }
                else            //numeric
                {
                    makingNumeric();
                }
            }
        }

        public void acceptCustomText(String custo)
        {
            customChars = custo;
            if (customChars != null && custo != null)
            {
                if (customChars.Length > 2)
                {
                    if (layout)         //usEnglish
                    {
                        makingWords();
                    }
                    else            //numeric
                    {
                        makingNumeric();
                    }
                }
            }
        }

        public void makingWords()
        {
            String word = "";
            String finalWord = "";
            toBeTypedString = "";
            layout = true;             //usEnglish layout

            if (customChars[0] > 4000)
            {
                if (makingAmharicWords() < noOfWords)
                {
                    for (int i = 0; i < noOfWords - makingAmharicWords(); i++)
                    {
                        int noLetter = random.Next(2, customChars.Length);
                        for (int j = 0; j < noLetter; j++)
                        {
                            int LetterIndex = random.Next(customChars.Length);
                            word += customChars.ElementAt(LetterIndex) + "";
                        }
                        finalWord += (word + " ");
                        word = "";
                    }
                    toBeTypedString += finalWord;
                    custo = null;
                    initialization(10, 0);
                }
                else
                {
                    custo = null;
                    initialization(10, 0);
                }
            }
            else
            {
                if (makingEnglishWords() < noOfWords)
                {
                    for (int i = 0; i < noOfWords - makingEnglishWords(); i++)
                    {
                        int noLetter = random.Next(2, customChars.Length);
                        for (int j = 0; j < noLetter; j++)
                        {
                            int LetterIndex = random.Next(customChars.Length);
                            word += customChars.ElementAt(LetterIndex) + "";
                        }
                        finalWord += (word + " ");
                        word = "";
                    }
                    toBeTypedString += finalWord;
                    custo = null;
                    initialization(10, 0);
                }
                else
                {
                    custo = null;
                    initialization(10, 0);
                }
            }


        }

        public int makingEnglishWords()
        {
            String word = "";
            Boolean flag;
            int position = random.Next(customEnglishWords.Count);
            int noOfGeneratedWords = 0;

            for (int k = 0; k < noOfWords; k++)
            {
                for (int i = position; i < customEnglishWords.Count; i++)
                {
                    flag = true;
                    for (int j = 0; j < (customEnglishWords[i] + "").Length; j++)
                    {
                        if (!customChars.Contains((customEnglishWords[i] + "").ElementAt(j)))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        word += customEnglishWords[i] + " ";
                        position = i + 1;
                        noOfGeneratedWords++;
                        break;
                    }
                }
            }
            toBeTypedString = word;
            return noOfGeneratedWords;
        }

        public int makingAmharicWords()
        {
            String word = "";
            Boolean flag;
            int position = random.Next(customAmharicWords.Count);
            int noOfGeneratedWords = 0;

            for (int k = 0; k < noOfWords; k++)
            {
                for (int i = position; i < customAmharicWords.Count; i++)
                {
                    flag = true;
                    for (int j = 0; j < (customAmharicWords[i] + "").Length; j++)
                    {
                        if (!customChars.Contains((char)getMainLetter((int)(customAmharicWords[i] + "").ElementAt(j))))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        word += customAmharicWords[i] + " ";
                        position = i + 1;
                        noOfGeneratedWords++;
                        break;
                    }
                }
            }
            toBeTypedString = word;
            return noOfGeneratedWords;
        }

        public void makingNumeric()
        {
            String word = "";
            String finalWord = "";
            layout = false;             //numeric layout
            for (int i = 0; i < noOfWords; i++)
            {
                int noLetter = random.Next(2, customChars.Length);
                for (int j = 0; j < noLetter; j++)
                {
                    int LetterIndex = random.Next(customChars.Length);
                    word += customChars.ElementAt(LetterIndex) + "";
                }
                switch (random.Next(1, 5))
                {
                    case 1:
                        finalWord += (word + "/");
                        break;
                    case 2:
                        finalWord += (word + "*");
                        break;
                    case 3:
                        finalWord += (word + "-");
                        break;
                    case 4:
                        finalWord += (word + "+");
                        break;
                }
                word = "";
            }
            toBeTypedString = finalWord;
            custo = null;
            initialization(10, 0);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            Help help = new Help();
            help.setForm_1(this);
            help.ShowDialog();
        }

        public int currentPosition = 0, middleIndex = 0;
        ArrayList typedKeys = new ArrayList();

        public void shiftTypedStringBack()
        {
            String finalString = "";
            for (int i = middleIndex; i < typedKeys.Count; i++)
            {
                finalString += typedKeys[i];
            }
            textBox2.Text = finalString;
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.SelectionLength = 0;
        }

        public void shiftToBeTypedStringBack()
        {
            String finalString = "";
            for (int i = middleIndex; i < toBeTypedString.Length; i++)
            {
                finalString += (toBeTypedString.ElementAt(i) + "");
            }
            textBox1.Text = finalString;
        }

        

        public int countSeconds(int hr, int min, int sec)
        {
            return ((hr * 3600) + (min * 60) + (sec));
        }

        public int calculateWPM()
        {
            try
            {
                return (noOfSpaces * 60) / countSeconds(Convert.ToInt32(Htf), Convert.ToInt32(Mtf), Convert.ToInt32(Stf));
            }
            catch (ArithmeticException ee)
            {
                return 0;
            }
        }

        public int getMainLetter(int letter)
        {
            int Decimal = letter;
            for (int i = Decimal; i > Decimal - 12; i--)
            {
                if(i==4680 || i==4744 || i==4784 || i==4800 || i==4880){
                    continue;
                }
                if (i % 8 == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public bool isMember(int typedKey, int toBeTypedKey) {
            //Console.WriteLine("__________" + typedKey + "______" + toBeTypedKey);
            if (typedKey >= getMainLetter(toBeTypedKey) && typedKey <= (getMainLetter(toBeTypedKey) + 6))
            {
                return true;
            }
            return false;
        }

        public bool isBastaredMember(int typedKey, int toBeTypedKey)
        {
            if (toBeTypedKey == (getMainLetter(typedKey) + 7) || toBeTypedKey == (getMainLetter(typedKey) + 11))
            {
                return true;
            }
            return false;
        }

        int toBeTypedLetter;

        public void validateEnglishLetter(String x, int keycode) {
            toBeTypedLetter = (int)toBeTypedString.ElementAt(currentPosition);
            int typedLetter = (int)x[0];

            if (typedLetter == toBeTypedLetter)
            {
                currentPosition++;
                if (currentPosition > 20)
                {
                    middleIndex++;
                }
                typedKeys.Add((char)keycode);
                shiftToBeTypedStringBack();
                shiftTypedStringBack();
                removeButtonColor(bb, cc);
            }
            else {
                if (keycode != (int)Keys.Back)
                {
                    errors++;
                }
            }
        }

        bool secondTap = false;

        public void validateAmharicNormalLetter(String x, int keycode)
        {
            toBeTypedLetter = (int)toBeTypedString.ElementAt(currentPosition);
            int typedLetter = (int)x[0];

            if (isMember(typedLetter, toBeTypedLetter))
            {
                if (toBeTypedLetter % 8 == 0) //tobetyped letter is main letter
                { 
                    currentPosition++;
                    if (currentPosition > 20)
                    {
                        middleIndex++;
                    }
                    typedKeys.Add((char)keycode);
                    shiftToBeTypedStringBack();
                    shiftTypedStringBack();
                    removeButtonColor(bb, cc);
                }
                else    //tobetyped letter is not main letter
                {
                    if (typedLetter == toBeTypedLetter) //typedletter is equal to tobetypedletter
                    {
                        typedKeys.RemoveAt(typedKeys.Count - 1);
                        currentPosition++;
                        if (currentPosition > 20)
                        {
                            middleIndex++;
                        }
                        typedKeys.Add((char)keycode);
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        removeButtonColor(bb, cc);
                        secondTap = false;
                    }
                    else { //typedletter is typed half of tobetypedletter
                        if (secondTap)  //person secondly typed the wrong vowel key
                        {
                            typedKeys.RemoveAt(typedKeys.Count - 1);
                            shiftToBeTypedStringBack();
                            shiftTypedStringBack();
                            errors++;
                            secondTap = false;
                        }
                        else {      //person secondly typed the correct key
                            typedKeys.Add((char)typedLetter);
                            shiftToBeTypedStringBack();
                            shiftTypedStringBack();
                            secondTap = true;
                        }
                    }
                }
            }
            else {      //the typed key is not a member of tobetypedletter
                if (keycode != (int)Keys.Back) {        //the typed key is not backspace ( it is system driven)
                    errors++;
                    if (secondTap)          //person secondly typed the wrong consonant key 
                    {
                        typedKeys.RemoveAt(typedKeys.Count - 1);
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        secondTap = false;
                    }
                }
            }
        }

        bool secondBastaredTap = false;
        bool thirdBastaredTap = false;

        public void validateAmharicBastardLetter(String x, int keycode)
        {
            toBeTypedLetter = (int)toBeTypedString.ElementAt(currentPosition);
            int typedLetter = (int)x[0];

            if (isBastaredMember(typedLetter, toBeTypedLetter))
            {
                if(typedLetter == getMainLetter(typedLetter)){
                    if (!secondBastaredTap)
                    {
                        typedKeys.Add((char)keycode);
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        secondBastaredTap = true;
                    }
                    else {
                        errors++;
                        typedKeys.RemoveAt(typedKeys.Count - 1);
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        secondBastaredTap = false;
                    }
                    
                }else if(typedLetter == getMainLetter(typedLetter) + 3){
                    if (secondBastaredTap)
                    {
                        typedKeys.Add((char)getMainLetter(keycode));
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        secondBastaredTap = false;
                    }
                    else {
                        errors++;
                        typedKeys.RemoveAt(typedKeys.Count - 1);
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        secondBastaredTap = false;
                    }
                }
                else if (typedLetter == toBeTypedLetter)
                {
                    typedKeys.RemoveAt(typedKeys.Count - 1);
                    currentPosition++;
                    if (currentPosition > 20)
                    {
                        middleIndex++;
                    }
                    typedKeys.Add((char)keycode);
                    shiftToBeTypedStringBack();
                    shiftTypedStringBack();
                    removeButtonColor(bb, cc);
                    secondBastaredTap = false;
                }
                else {
                    errors++;
                    typedKeys.RemoveAt(typedKeys.Count - 1);
                    shiftToBeTypedStringBack();
                    shiftTypedStringBack();
                    secondBastaredTap = false;
                }
            }
            else {
                if (keycode != (int)Keys.Back)
                {        //the typed key is not backspace ( it is system driven)
                    errors++;
                    if (secondBastaredTap)          //person secondly typed the wrong consonant key 
                    {
                        typedKeys.RemoveAt(typedKeys.Count - 1);
                        shiftToBeTypedStringBack();
                        shiftTypedStringBack();
                        secondBastaredTap = false;
                    }
                }
            }
        }

        public bool isBastard(int keycode) {
            if (keycode % 8 == 7 || keycode == 4683 || keycode == 4747 || keycode == 4787 || keycode == 4883)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public void ValidateTypedText(String x, int keycode)
        {
            toBeTypedLetter = (int)toBeTypedString.ElementAt(currentPosition);

            
            if(toBeTypedLetter > 4600) {
                if (isBastard(toBeTypedLetter))
                {
                    validateAmharicBastardLetter(x, (int)x[0]);
                }
                else
                {
                    validateAmharicNormalLetter(x, (int)x[0]);
                }
            }
            else if (toBeTypedLetter < 4600)
            {
                validateEnglishLetter(x, keycode);
            }
            
        }
                
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer.Start();

            ValidateTypedText((char)e.KeyChar + "", e.KeyChar);

            Console.WriteLine((char)e.KeyChar + "_______" + (int)e.KeyChar);

            if( (char)e.KeyChar==' ' || (char)e.KeyChar=='+' || (char)e.KeyChar=='-' || (char)e.KeyChar=='*' || (char)e.KeyChar=='/'){
                noOfSpaces++;
            }

            Error_label.Text = "ERRORS : " + errors;
            WPM_label.Text = "WPM : " + calculateWPM();

            if (currentPosition > toBeTypedString.Length - 1) {
                timer.Stop();
                finishing.setForm(this);
                finishing.ShowDialog();
            }
            changeButtonColor();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) // when backspace button is clicked
            {
                if (currentPosition > 0) //means that there is letters in the second textbox
                {
                    if (toBeTypedLetter > 4000) //to be typed letter is amharic letter
                    {
                        if (currentPosition == typedKeys.Count)//when the typer is on the correct path
                        {
                            currentPosition--;
                            typedKeys.RemoveAt(currentPosition);
                        }
                        else if (currentPosition == typedKeys.Count - 1) //when to be typed word is ክፍል and person typed ክፈ ...... the typedKeys arraylist have one extra item
                        {
                            typedKeys.RemoveAt(currentPosition);
                        }
                    }
                    else //to be typed letter is english letter
                    {
                        currentPosition--;
                        typedKeys.RemoveAt(currentPosition);
                    }
                }
                else if (currentPosition == 0)//when to be typed word is ክፍል and person typed ከ ...... the typedKeys arraylist have one extra item and currentPosition is zero.
                {
                    if (currentPosition == typedKeys.Count - 1)
                    {
                        typedKeys.RemoveAt(currentPosition);
                    }
                }
                if (middleIndex > 0)
                {
                    middleIndex--;
                }
                if (secondTap)
                {
                    secondTap = false;
                }
                shiftToBeTypedStringBack();
                shiftTypedStringBack();
                removeButtonColor(bb, cc);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomizeForm custom = new CustomizeForm();
            custom.setForm_1(this);
            custom.ShowDialog();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            this.ActiveControl = textBox2;              //nice way to remove focus from everything except this textbox2;
        }

        public Button bb = null, cc = null;

        public void changeButtonColor()
        {
            String currentPositionString = "";

            try
            {
                currentPositionString = toBeTypedString.ElementAt(currentPosition) + "";
            }
            catch (Exception e)
            {
            }

            if ((int)currentPositionString[0] > 4000)
            {
                amharicButtonColoring(currentPositionString);
            }
            else
            {
                englishButtonColoring(currentPositionString);
            }
        }

        public void englishButtonColoring(String currentPositionString)
        {
            String[] englishList = { "AR", "BR", "CR", "DR", "ER", "FR", "GR", "HL", "IL", "JL", "KL", "LL", "ML", "NL", "OL", "PL", "QR", "RR", "SR", "TR", "UL", "VR", "WR", "XR", "YL", "ZR" };
            
            if (!(uSEnglishToolStripMenuItem.Enabled))
            {
                foreach (Control b in this.panel1.Controls)
                {
                    try
                    {
                        if (b is Button)
                        {
                            if (b.Text.Length == 1)
                            {
                                if (String.Compare(currentPositionString, b.Text, true) == 0)
                                {
                                    //MessageBox.Show("abcd");
                                    b.BackColor = Color.Red;
                                    bb = (Button)b;
                                    if ((int)currentPositionString[0] > 64 && (int)currentPositionString[0] < 91)
                                    {
                                        for (int i = 0; i < 26; i++)
                                        {
                                            if (String.Compare(englishList[i][0] + "", currentPositionString[0] + "", true) == 0)
                                            {
                                                if (englishList[i][1] == 'L') //left shift case
                                                {
                                                    button43.BackColor = Color.Green;
                                                    cc = button43;
                                                    break;
                                                }
                                                else
                                                {                           //right shift case
                                                    button54.BackColor = Color.Green;
                                                    cc = button54;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            else if (b.Text.Length == 4)
                            {
                                if (String.Compare(currentPositionString, b.Text.ElementAt(0) + "", true) == 0 && !b.Text.StartsWith("C"))
                                {
                                    b.BackColor = Color.Red;
                                    bb = (Button)b;
                                    break;
                                }
                                else if (String.Compare(currentPositionString, b.Text.ElementAt(3) + "", true) == 0 && !b.Text.StartsWith("C"))
                                {
                                    b.BackColor = Color.Red;
                                    bb = (Button)b;
                                    break;
                                }
                            }
                            else if (b.Text.Length == 5)
                            {
                                if (String.Compare(currentPositionString, b.Text.ElementAt(0) + "", true) == 0 && !b.Text.StartsWith("S"))
                                {
                                    b.BackColor = Color.Red;
                                    bb = (Button)b;
                                    break;
                                }
                                else if (String.Compare(currentPositionString, b.Text.ElementAt(4) + "", true) == 0 && !b.Text.StartsWith("S"))
                                {
                                    b.BackColor = Color.Red;
                                    bb = (Button)b;
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            else
            {
                foreach (Control b in this.panel2.Controls)
                {
                    try
                    {
                        if (b is Button)
                        {
                            if (String.Compare(currentPositionString, b.Text, true) == 0)
                            {
                                b.BackColor = Color.Red;
                                bb = (Button)b;
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        public void amharicButtonColoring(String currentPositionString)
        {
            String[] amharicList = {"ሀ", "ለ", "መ", "ሰ", "ረ", "ቀ", "በ", "ተ", "ቸ", "ነ", "አ", "ከ", "ወ", "ዘ", "ደ", "ጀ", "ገ", "ፈ", "ፐ", "ቨ",
                                   "ሐ","ሠ","ኘ","ዐ","ዠ","የ","ጠ","ጨ","ጰ",
                                   "ሸ","ኀ","ጸ",
                                   "ፀ","ኸ"};
            String[] englishList = {"H", "L", "M", "S", "R", "Q", "B", "T", "C", "N", "X", "K", "W", "Z", "D", "J", "G", "F", "P", "V",
                                   "HL","SR","NL","XR","ZR","YL","TR","CR","PL",
                                   "S","H","T",
                                   "TR","HL"};

            String bastard = "ቋኳኋጓ";

            changeMemberColor(currentPositionString);

            for (int i = 0; i < 34; i++)
            {

                if (bastard.Contains(currentPositionString[0]))
                {
                    switch (currentPositionString[0])
                    {
                        case 'ቋ':
                            button16.BackColor = Color.Red;
                            bb = (Button)button16;
                            break;
                        case 'ኳ':
                            button34.BackColor = Color.Red;
                            bb = (Button)button34;
                            break;
                        case 'ኋ':
                            button36.BackColor = Color.Red;
                            bb = (Button)button36;
                            break;
                        case 'ጓ':
                            button37.BackColor = Color.Red;
                            bb = (Button)button37;
                            break;
                    }
                }
                else if (getMainLetter((int)currentPositionString[0]) == (int)amharicList[i][0])
                {
                    foreach (Control b in this.panel1.Controls)
                    {
                        if (b is Button)
                        {
                            if (b.Text.Length == 1)
                            {
                                if (String.Compare(englishList[i][0] + "", b.Text, true) == 0)
                                {
                                    //MessageBox.Show("abcd");
                                    if (i > 28 && i < 32)
                                    { // capslock case
                                        button30.BackColor = Color.Yellow;
                                    }
                                    else if (i > 19 && i < 29) // shift case
                                    {
                                        if (englishList[i][1] == 'L') //left shift case
                                        {
                                            button43.BackColor = Color.Green;
                                        }
                                        else
                                        {//right shift case
                                            button54.BackColor = Color.Green;
                                        }
                                    }
                                    else if (i > 31)
                                    { // capslock and shift case
                                        button30.BackColor = Color.Yellow;
                                        if (englishList[i][1] == 'L') //left shift case
                                        {
                                            button43.BackColor = Color.Green;
                                        }
                                        else
                                        {//right shift case
                                            button54.BackColor = Color.Green;
                                        }
                                    }
                                    b.BackColor = Color.Red;
                                    bb = (Button)b;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void changeMemberColor(String currentPositionString)
        {
            String bastard = "ቋኳኋጓ";
            if (bastard.Contains(currentPositionString[0]))
            {
                button30.BackColor = Color.Yellow;
                button28.BackColor = Color.FromArgb(0, 144, 210);
                button41.BackColor = Color.Purple;
                cc = button28;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 1)
            {
                button18.BackColor = Color.FromArgb(0, 144, 210);
                cc = button18;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 2)
            {
                button24.BackColor = Color.FromArgb(0, 144, 210);
                cc = button24;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 3)
            {
                button41.BackColor = Color.FromArgb(0, 144, 210);
                cc = button41;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 4)
            {
                button17.BackColor = Color.FromArgb(0, 144, 210);
                cc = button17;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 5)
            {
                button27.BackColor = Color.FromArgb(0, 144, 210);
                cc = button27;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 6)
            {
                button25.BackColor = Color.FromArgb(0, 144, 210);
                cc = button25;
            }
            else if ((int)currentPositionString[0] - getMainLetter((int)currentPositionString[0]) == 7)
            {
                button30.BackColor = Color.Yellow;
                button28.BackColor = Color.FromArgb(0, 144, 210);
                button41.BackColor = Color.Purple;
                cc = button28;
            }
        }

        public void removeButtonColor(Button b, Button c)
        {
            try
            {
                b.BackColor = SystemColors.Control;
                b.UseVisualStyleBackColor = true;

                c.BackColor = SystemColors.Control;
                c.UseVisualStyleBackColor = true;

                if (button41.BackColor == Color.Purple)
                {
                    button41.BackColor = SystemColors.Control;
                    button41.UseVisualStyleBackColor = true;
                }

                if (button30.BackColor == Color.Yellow)
                {
                    button30.BackColor = SystemColors.Control;
                    button30.UseVisualStyleBackColor = true;
                }
                if (button43.BackColor == Color.Green || button54.BackColor == Color.Green)
                {
                    button43.BackColor = SystemColors.Control;
                    button43.UseVisualStyleBackColor = true;
                    button54.BackColor = SystemColors.Control;
                    button54.UseVisualStyleBackColor = true;
                }
            }
            catch (Exception e)
            {
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            About about = new About();
            about.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            acceptCustomText();
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)          //ye ha bet 
        {
            initialization(6, 0);
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)          //bet le bet
        {
            initialization(6, 1);
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)          //ye hameroha bet
        {
            initialization(6, 2);
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)          //ye me bet
        {
            initialization(6, 3);
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)          //ye se bet 
        {
            initialization(6, 4);
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            initialization(6, 5);
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            initialization(6, 6);
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            initialization(6, 7);
        }

        private void toolStripMenuItem74_Click(object sender, EventArgs e)
        {
            initialization(6, 8);
        }

        private void yeHaBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(6, 9);
        }

        private void yeቨBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(7, 0);
        }

        private void yeተBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(7, 1);
        }

        private void toolStripMenuItem73_Click(object sender, EventArgs e)
        {
            initialization(7, 2);
        }

        private void toolStripMenuItem72_Click(object sender, EventArgs e)
        {
            initialization(7, 3);
        }

        private void toolStripMenuItem71_Click(object sender, EventArgs e)
        {
            initialization(7, 4);
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            initialization(7, 5);
        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {
            initialization(7, 6);
        }

        private void toolStripMenuItem68_Click(object sender, EventArgs e)
        {
            initialization(7, 7);
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            initialization(7, 8);
        }

        private void toolStripMenuItem56_Click(object sender, EventArgs e)
        {
            initialization(7, 9);
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            initialization(8, 0);
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            initialization(8, 1);
        }

        private void yeሀBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(8, 2);
        }

        private void yeየBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialization(8, 3);
        }

        private void toolStripMenuItem85_Click(object sender, EventArgs e)
        {
            initialization(8, 4);
        }

        private void toolStripMenuItem84_Click(object sender, EventArgs e)
        {
            initialization(8, 5);
        }

        private void toolStripMenuItem83_Click(object sender, EventArgs e)
        {
            initialization(8, 6);
        }

        private void toolStripMenuItem82_Click(object sender, EventArgs e)
        {
            initialization(8, 7);
        }

        private void toolStripMenuItem81_Click(object sender, EventArgs e)
        {
            initialization(8, 8);
        }

        private void toolStripMenuItem80_Click(object sender, EventArgs e)
        {
            initialization(8, 9);
        }

        private void toolStripMenuItem79_Click(object sender, EventArgs e)
        {
            initialization(9, 0);
        }

        private void toolStripMenuItem78_Click(object sender, EventArgs e)
        {
            initialization(9, 1);
        }

        private void toolStripMenuItem77_Click(object sender, EventArgs e)
        {
            initialization(9, 2);
        }

        private void toolStripMenuItem76_Click(object sender, EventArgs e)
        {
            initialization(9, 3);
        }
        
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
