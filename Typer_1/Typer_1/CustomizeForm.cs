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
    public partial class CustomizeForm : Form
    {
        Form1 form_1;
        int lesson = 0, exercise = 0;
        string previousText = "";
        bool isCombobox1Changed = false, isCombobox2Changed = false, isButton4Clicked = false, timerStopped = false;
        int combobox1previousSelected, combobox2previousSelected;
        
        public CustomizeForm()
        {
            InitializeComponent();
        }

        private void CustomizeForm_Load(object sender, EventArgs e)
        {
            if (form_1.timer.Enabled)
            {
                form_1.timer.Stop();
                timerStopped = true;
            }

            this.ActiveControl = button3;

            if (Form1.language == 1)
            {
                englishCostomization();     //English
            }
            else if (Form1.language == 0)
            {
                amharicCustomization();     //Amharic
            }
            else if (Form1.language == 2)
            {
                oromiffaCustomization();        //Oromiffa
            }
            else
            {
                tigrinaCustomization();         //Tigrigna;
            }

            String lessonString = form_1.lessonLable.Text;
            String excerciseString = form_1.Excersice_Label.Text;
            previousText = form_1.textBox1.Text;

            if (Form1.isCustom)
            {
                lesson = 10;
                if (!Form1.layout)      //if it's already on numeric layout
                {
                    comboBox1.SelectedIndex = 1;
                    combobox1previousSelected = 1;
                }
                else if (Form1.layout)  //if it's already on UsEnglish
                {
                    comboBox1.SelectedIndex = 0;
                    combobox1previousSelected = 0;
                }
            }
            else
            {
                lesson = Form1.lessonNum;
                exercise = Form1.exerciseNum;
                if (!Form1.layout)      //if it's already on numeric layout 
                {      
                    comboBox1.SelectedIndex = 1;
                    combobox1previousSelected = 1;
                }
                else 
                {       
                    comboBox1.SelectedIndex = 0;
                    combobox1previousSelected = 0;
                }

            }

            if (Form1.language == 1)      //English
            {
                comboBox2.SelectedIndex = 1;
                combobox2previousSelected = 1;
            }
            else if (Form1.language == 0)  //Amharic
            {
                comboBox2.SelectedIndex = 0;
                combobox2previousSelected = 0;
            }
            else if (Form1.language == 2) //Oromiffa
            {
                comboBox2.SelectedIndex = 2;
                combobox2previousSelected = 2;
            }
            else if (Form1.language == 3) //Tigrigna
            {
                comboBox2.SelectedIndex = 3;
                combobox2previousSelected = 3;
            }
        }

        public void setForm_1(Form1 formm)
        {
            this.form_1 = formm;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {                   //addCustomeLesson button is clicked
            InputDialoge input = new InputDialoge();
            
            input.setForm_1(form_1);
            
            input.ShowDialog();
            if (Form1.custo == null || Form1.custo == "")
                isButton4Clicked = false;
            else
            {
                isButton4Clicked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {               //cancel button is clicked;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {                       //ok button is clicked
            applyChanges();
            Close();
        }

        public void applyChanges()
        {
            if (comboBox1.SelectedIndex == 1 && isCombobox1Changed)
            {
                form_1.whenNumericLayoutIsPressed();
            }
            
            else if (comboBox1.SelectedIndex == 0 && isCombobox1Changed)
            {              //Us-English is pressed;
                form_1.whenUsEnglishLayoutIsPressed();
            }

            try
            {
                if(comboBox2.SelectedIndex == 0 && isCombobox2Changed)    //if amharic language is selected;
                {
                    Form1.language = 0;
                    changeToAmharicLanguage();
                }
                else if (comboBox2.SelectedIndex == 1 && isCombobox2Changed)    //if english language is selected
                {
                    Form1.language = 1;
                    changeToEnglishLanguage();
                }
                else if (comboBox2.SelectedIndex == 2 && isCombobox2Changed)    //if oromiffa language is selected
                {
                    Form1.language = 2;
                    changeToAmharicLanguage();
                    //changeToOromiffaLanguage();
                }
                else if (comboBox2.SelectedIndex == 3 && isCombobox2Changed)    //if tigrigna language is selected
                {
                    Form1.language = 3;
                    changeToTigrignaLanguage();
                }
            } catch (Exception e) {
                MessageBox.Show("Somma Exception!");
            }
            
            if (isButton4Clicked && (Form1.custo != null && Form1.custo != ""))
            {
                form_1.acceptCustomText(Form1.custo);
                if (Form1.language == 1)
                {
                    form_1.lessonLable.Text = "Custom Lesson";
                }
                else if (Form1.language == 0)
                {
                    form_1.lessonLable.Text = "የግል ምርጫ";
                }
                else if (Form1.language == 2)
                {
                    form_1.lessonLable.Text = "የግል ምርጫ";
                }
                else
                {
                    form_1.lessonLable.Text = "ናይ ውልቀ ምርጫ";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox1previousSelected != comboBox1.SelectedIndex)
            {
                isCombobox1Changed = true;
            }
            else {
                isCombobox1Changed = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox2previousSelected != comboBox2.SelectedIndex)
            {
                isCombobox2Changed = true;
            }
            else if ((Form1.language == 1) && comboBox2.SelectedIndex != 1)      //on english
            {
                isCombobox2Changed = true;
            }
            else if ((Form1.language == 0) && comboBox2.SelectedIndex != 0)      //on amharic
            {
                isCombobox2Changed = true;
            }
            else if ((Form1.language == 2) && comboBox2.SelectedIndex != 2)      //on oromiffa
            {
                isCombobox2Changed = true;
            }
            else if ((Form1.language == 3) && comboBox2.SelectedIndex != 3)      //on tigrigna
            {
                isCombobox2Changed = true;
            }
            else
            {
                isCombobox2Changed = false;
            }
        }

        public void changeToAmharicLanguage()
        {
            form_1.menuToolStripMenuItem.Text = "ማዉጫ";
            form_1.aboutToolStripMenuItem.Text = "ቅንብር";
            form_1.helpToolStripMenuItem.Text = "እገዛ";
            form_1.toolStripMenuItem1.Text = "ስለ እኛ";

            form_1.lessonsToolStripMenuItem.Text = "ትምህርቶች";
            form_1.layoutsToolStripMenuItem.Text = "ገጽታዎች";
            form_1.exitToolStripMenuItem.Text = "ዝጋ";

            if (Form1.layout)
            {
                if (isButton4Clicked && (Form1.custo != null && Form1.custo != ""))
                {
                    form_1.lessonLable.Text = "የግል ምርጫ";
                }
                if (lesson == 10)
                {
                    form_1.lessonLable.Text = "የግል ምርጫ";
                }
                else{
                    form_1.lessonLable.Text = "ትምህርት " + (Form1.lessonNum + 1);
                    form_1.Excersice_Label.Text = ", መልመጃ " + (Form1.exerciseNum + 1);
                }
            }
            else
            {
                form_1.lessonLable.Text = "      የቁጥር";
                form_1.Excersice_Label.Text = ", መልመጃ " + (Form1.exerciseNum + 1);
            }
            form_1.Error_label.Text = "ስህተቶች: " + Form1.errors;
            form_1.WPM_label.Text = "ፍጥነት: " + Form1.wpm;


            form_1.uSEnglishToolStripMenuItem.Text = "የፊደል ገበታ";
            form_1.numericKeypadToolStripMenuItem.Text = "የቁጥር ገበታ";


            form_1.lesson1ToolStripMenuItem.Text = "(የቁልፍ) ትምህርት 1";
            form_1.lesson2ToolStripMenuItem.Text = "(የቁልፍ) ትምህርት 2";
            form_1.lesson3ToolStripMenuItem.Text = "(የቃላት) ትምህርት 3";
            form_1.lesson4ToolStripMenuItem.Text = "(የቃላት) ትምህርት 4";
            form_1.lesson5ToolStripMenuItem.Text = "(የቃላት) ትምህርት 5";
            form_1.toolStripMenuItem23.Text = "አማርኛ 1";
            form_1.toolStripMenuItem25.Text = "አማርኛ 2";
            form_1.toolStripMenuItem24.Text = "አማርኛ 3";
            form_1.NumericToolStripMenuItem.Text = "የቁጥር  ት/ት";
            
            form_1.exercise1ToolStripMenuItem.Text = "መልመጃ 1";
            form_1.exercise2ToolStripMenuItem.Text = "መልመጃ 2";
            form_1.exercise3ToolStripMenuItem.Text = "መልመጃ 3";
            form_1.exercise4ToolStripMenuItem.Text = "መልመጃ 4";
            form_1.exercise5ToolStripMenuItem.Text = "መልመጃ 5";
            form_1.exercise6ToolStripMenuItem.Text = "መልመጃ 6";
            form_1.exercise7ToolStripMenuItem.Text = "መልመጃ 7";
            form_1.exercise8ToolStripMenuItem.Text = "መልመጃ 8";
            form_1.exercise9ToolStripMenuItem.Text = "መልመጃ 9";
            form_1.exercise10ToolStripMenuItem.Text = "መልመጃ 10";

            form_1.toolStripMenuItem2.Text = "መልመጃ 1";
            form_1.toolStripMenuItem3.Text = "መልመጃ 2";
            form_1.toolStripMenuItem4.Text = "መልመጃ 3";
            form_1.toolStripMenuItem5.Text = "መልመጃ 4";
            form_1.toolStripMenuItem6.Text = "መልመጃ 5";
            form_1.toolStripMenuItem7.Text = "መልመጃ 6";
            form_1.toolStripMenuItem8.Text = "መልመጃ 7";
            form_1.toolStripMenuItem9.Text = "መልመጃ 8";
            form_1.toolStripMenuItem10.Text = "መልመጃ 9";
            form_1.toolStripMenuItem11.Text = "መልመጃ 10";

            form_1.toolStripMenuItem13.Text = "መልመጃ 1";
            form_1.toolStripMenuItem14.Text = "መልመጃ 2";
            form_1.toolStripMenuItem15.Text = "መልመጃ 3";
            form_1.toolStripMenuItem16.Text = "መልመጃ 4";
            form_1.toolStripMenuItem17.Text = "መልመጃ 5";
            form_1.toolStripMenuItem18.Text = "መልመጃ 6";
            form_1.toolStripMenuItem19.Text = "መልመጃ 7";
            form_1.toolStripMenuItem20.Text = "መልመጃ 8";
            form_1.toolStripMenuItem21.Text = "መልመጃ 9";
            form_1.toolStripMenuItem22.Text = "መልመጃ 10";

            form_1.toolStripMenuItem57.Text = "መልመጃ 1";
            form_1.toolStripMenuItem58.Text = "መልመጃ 2";
            form_1.toolStripMenuItem59.Text = "መልመጃ 3";
            form_1.toolStripMenuItem60.Text = "መልመጃ 4";
            form_1.toolStripMenuItem61.Text = "መልመጃ 5";
            form_1.toolStripMenuItem62.Text = "መልመጃ 6";
            form_1.toolStripMenuItem63.Text = "መልመጃ 7";
            form_1.toolStripMenuItem64.Text = "መልመጃ 8";
            form_1.toolStripMenuItem65.Text = "መልመጃ 9";
            form_1.toolStripMenuItem66.Text = "መልመጃ 10";

            form_1.toolStripMenuItem46.Text = "መልመጃ 1";
            form_1.toolStripMenuItem47.Text = "መልመጃ 2";
            form_1.toolStripMenuItem48.Text = "መልመጃ 3";
            form_1.toolStripMenuItem49.Text = "መልመጃ 4";
            form_1.toolStripMenuItem50.Text = "መልመጃ 5";
            form_1.toolStripMenuItem51.Text = "መልመጃ 6";
            form_1.toolStripMenuItem52.Text = "መልመጃ 7";
            form_1.toolStripMenuItem53.Text = "መልመጃ 8";
            form_1.toolStripMenuItem54.Text = "መልመጃ 9";
            form_1.toolStripMenuItem55.Text = "መልመጃ 10";

            form_1.toolStripMenuItem35.Text = "መልመጃ 1";
            form_1.toolStripMenuItem36.Text = "መልመጃ 2";
            form_1.toolStripMenuItem37.Text = "መልመጃ 3";
            form_1.toolStripMenuItem38.Text = "መልመጃ 4";
            form_1.toolStripMenuItem39.Text = "መልመጃ 5";
            form_1.toolStripMenuItem40.Text = "መልመጃ 6";
            form_1.toolStripMenuItem41.Text = "መልመጃ 7";
            form_1.toolStripMenuItem42.Text = "መልመጃ 8";
            form_1.toolStripMenuItem43.Text = "መልመጃ 9";
            form_1.toolStripMenuItem44.Text = "መልመጃ 10";

            form_1.toolStripMenuItem33.Text = "የ  'ሀ'  ቤት";
            form_1.toolStripMenuItem32.Text = "የ  'ለ'  ቤት";
            form_1.toolStripMenuItem31.Text = "የ  'ሐ'  ቤት";
            form_1.toolStripMenuItem30.Text = "የ  'መ'  ቤት";
            form_1.toolStripMenuItem29.Text = "የ  'ሠ'  ቤት";
            form_1.toolStripMenuItem28.Text = "የ  'ረ'  ቤት";
            form_1.toolStripMenuItem27.Text = "የ  'ሰ'  ቤት";
            form_1.toolStripMenuItem26.Text = "የ  'ሸ'  ቤት";
            form_1.toolStripMenuItem74.Text = "የ  'ቀ'  ቤት";
            form_1.yeHaBetToolStripMenuItem.Text = "የ  'በ'  ቤት";
            form_1.yeቨBetToolStripMenuItem.Text = "የ  'ቨ'  ቤት";
            form_1.yeተBetToolStripMenuItem.Text = "የ  'ተ'  ቤት";

            form_1.toolStripMenuItem73.Text = "የ  'ቸ'  ቤት";
            form_1.toolStripMenuItem72.Text = "የ  'ኀ'  ቤት";
            form_1.toolStripMenuItem71.Text = "የ  'ነ'  ቤት";
            form_1.toolStripMenuItem70.Text = "የ  'ኘ'  ቤት";
            form_1.toolStripMenuItem69.Text = "የ  'አ'  ቤት";
            form_1.toolStripMenuItem68.Text = "የ  'ከ'  ቤት";
            form_1.toolStripMenuItem67.Text = "የ  'ኸ'  ቤት";
            form_1.toolStripMenuItem56.Text = "የ  'ወ'  ቤት";
            form_1.toolStripMenuItem45.Text = "የ  'ዐ'  ቤት";
            form_1.toolStripMenuItem34.Text = "የ  'ዘ'  ቤት";
            form_1.yeሀBetToolStripMenuItem.Text = "የ  'ዠ'  ቤት";
            form_1.yeየBetToolStripMenuItem.Text = "የ  'የ  'ቤት";

            form_1.toolStripMenuItem85.Text = "የ  'ደ'  ቤት";
            form_1.toolStripMenuItem84.Text = "የ  'ጀ'  ቤት";
            form_1.toolStripMenuItem83.Text = "የ  'ገ'  ቤት";
            form_1.toolStripMenuItem82.Text = "የ  'ጠ'  ቤት";
            form_1.toolStripMenuItem81.Text = "የ  'ጨ'  ቤት";
            form_1.toolStripMenuItem80.Text = "የ  'ጰ'  ቤት";
            form_1.toolStripMenuItem79.Text = "የ  'ጸ'  ቤት";
            form_1.toolStripMenuItem78.Text = "የ  'ፀ'  ቤት";
            form_1.toolStripMenuItem77.Text = "የ  'ፈ'  ቤት";
            form_1.toolStripMenuItem76.Text = "የ  'ፐ'  ቤት";
        }

        public void changeToEnglishLanguage()
        {
            form_1.menuToolStripMenuItem.Text = "Menu";
            form_1.aboutToolStripMenuItem.Text = "Customize";
            form_1.helpToolStripMenuItem.Text = "Help";
            form_1.toolStripMenuItem1.Text = "About";

            form_1.lessonsToolStripMenuItem.Text = "Lessons";
            form_1.layoutsToolStripMenuItem.Text = "Layout";
            form_1.exitToolStripMenuItem.Text = "Exit";

            if (Form1.layout)
            {
                if (isButton4Clicked && (Form1.custo != null && Form1.custo != ""))
                {
                    form_1.lessonLable.Text = "Custom Lesson";
                }
                if (lesson == 10)
                {
                    form_1.lessonLable.Text = "Custom Lesson";
                }
                else
                {
                    form_1.lessonLable.Text = "Lesson " + (Form1.lessonNum + 1);
                    form_1.Excersice_Label.Text = ", Exercise " + (Form1.exerciseNum + 1);
                }
            }
            else
            {
                form_1.lessonLable.Text = "Numeric";
                form_1.Excersice_Label.Text = ", Exercise" + (Form1.exerciseNum + 1);
            }

            form_1.Error_label.Text = "ERRORS: " + Form1.errors;
            form_1.WPM_label.Text = "WPM: " + Form1.wpm;

            form_1.uSEnglishToolStripMenuItem.Text = "US-English";
            form_1.numericKeypadToolStripMenuItem.Text = "Numeric_Keypad";

            form_1.lesson1ToolStripMenuItem.Text = "(Key) Lesson 1";
            form_1.lesson2ToolStripMenuItem.Text = "(Key) Lesson 2";
            form_1.lesson3ToolStripMenuItem.Text = "(Word) Lesson 3";
            form_1.lesson4ToolStripMenuItem.Text = "(Word) Lesson 4";
            form_1.lesson5ToolStripMenuItem.Text = "(Word) Lesson 5";
            form_1.toolStripMenuItem23.Text = "Amharic 1";
            form_1.toolStripMenuItem25.Text = "Amharic 2";
            form_1.toolStripMenuItem24.Text = "Amharic 3";
            form_1.NumericToolStripMenuItem.Text = "Numeric";

            form_1.exercise1ToolStripMenuItem.Text = "Excercise 1";
            form_1.exercise2ToolStripMenuItem.Text = "Excercise 2";
            form_1.exercise3ToolStripMenuItem.Text = "Excercise 3";
            form_1.exercise4ToolStripMenuItem.Text = "Excercise 4";
            form_1.exercise5ToolStripMenuItem.Text = "Excercise 5";
            form_1.exercise6ToolStripMenuItem.Text = "Excercise 6";
            form_1.exercise7ToolStripMenuItem.Text = "Excercise 7";
            form_1.exercise8ToolStripMenuItem.Text = "Excercise 8";
            form_1.exercise9ToolStripMenuItem.Text = "Excercise 9";
            form_1.exercise10ToolStripMenuItem.Text = "Excercise 10";

            form_1.toolStripMenuItem2.Text = "Excercise 1";
            form_1.toolStripMenuItem3.Text = "Excercise 2";
            form_1.toolStripMenuItem4.Text = "Excercise 3";
            form_1.toolStripMenuItem5.Text = "Excercise 4";
            form_1.toolStripMenuItem6.Text = "Excercise 5";
            form_1.toolStripMenuItem7.Text = "Excercise 6";
            form_1.toolStripMenuItem8.Text = "Excercise 7";
            form_1.toolStripMenuItem9.Text = "Excercise 8";
            form_1.toolStripMenuItem10.Text = "Excercise 9";
            form_1.toolStripMenuItem11.Text = "Excercise 10";

            form_1.toolStripMenuItem13.Text = "Excercise 1";
            form_1.toolStripMenuItem14.Text = "Excercise 2";
            form_1.toolStripMenuItem15.Text = "Excercise 3";
            form_1.toolStripMenuItem16.Text = "Excercise 4";
            form_1.toolStripMenuItem17.Text = "Excercise 5";
            form_1.toolStripMenuItem18.Text = "Excercise 6";
            form_1.toolStripMenuItem19.Text = "Excercise 7";
            form_1.toolStripMenuItem20.Text = "Excercise 8";
            form_1.toolStripMenuItem21.Text = "Excercise 9";
            form_1.toolStripMenuItem22.Text = "Excercise 10";

            form_1.toolStripMenuItem57.Text = "Excercise 1";
            form_1.toolStripMenuItem58.Text = "Excercise 2";
            form_1.toolStripMenuItem59.Text = "Excercise 3";
            form_1.toolStripMenuItem60.Text = "Excercise 4";
            form_1.toolStripMenuItem61.Text = "Excercise 5";
            form_1.toolStripMenuItem62.Text = "Excercise 6";
            form_1.toolStripMenuItem63.Text = "Excercise 7";
            form_1.toolStripMenuItem64.Text = "Excercise 8";
            form_1.toolStripMenuItem65.Text = "Excercise 9";
            form_1.toolStripMenuItem66.Text = "Excercise 10";

            form_1.toolStripMenuItem46.Text = "Excercise 1";
            form_1.toolStripMenuItem47.Text = "Excercise 2";
            form_1.toolStripMenuItem48.Text = "Excercise 3";
            form_1.toolStripMenuItem49.Text = "Excercise 4";
            form_1.toolStripMenuItem50.Text = "Excercise 5";
            form_1.toolStripMenuItem51.Text = "Excercise 6";
            form_1.toolStripMenuItem52.Text = "Excercise 7";
            form_1.toolStripMenuItem53.Text = "Excercise 8";
            form_1.toolStripMenuItem54.Text = "Excercise 9";
            form_1.toolStripMenuItem55.Text = "Excercise 10";

            form_1.toolStripMenuItem35.Text = "Excercise 1";
            form_1.toolStripMenuItem36.Text = "Excercise 2";
            form_1.toolStripMenuItem37.Text = "Excercise 3";
            form_1.toolStripMenuItem38.Text = "Excercise 4";
            form_1.toolStripMenuItem39.Text = "Excercise 5";
            form_1.toolStripMenuItem40.Text = "Excercise 6";
            form_1.toolStripMenuItem41.Text = "Excercise 7";
            form_1.toolStripMenuItem42.Text = "Excercise 8";
            form_1.toolStripMenuItem43.Text = "Excercise 9";
            form_1.toolStripMenuItem44.Text = "Excercise 10";

            form_1.toolStripMenuItem33.Text = "'ሀ'  series";
            form_1.toolStripMenuItem32.Text = "'ለ'  series";
            form_1.toolStripMenuItem31.Text = "'ሐ'  series";
            form_1.toolStripMenuItem30.Text = "'መ'  series";
            form_1.toolStripMenuItem29.Text = "'ሠ'  series";
            form_1.toolStripMenuItem28.Text = "'ረ'  series";
            form_1.toolStripMenuItem27.Text = "'ሰ'  series";
            form_1.toolStripMenuItem26.Text = "'ሸ'  series";
            form_1.toolStripMenuItem74.Text = "'ቀ'  series";
            form_1.yeHaBetToolStripMenuItem.Text = "'በ'  series";
            form_1.yeቨBetToolStripMenuItem.Text = "'ቨ'  series";
            form_1.yeተBetToolStripMenuItem.Text = "'ተ'  series";

            form_1.toolStripMenuItem73.Text = "'ቸ'  series";
            form_1.toolStripMenuItem72.Text = "'ኀ'  series";
            form_1.toolStripMenuItem71.Text = "'ነ'  series";
            form_1.toolStripMenuItem70.Text = "'ኘ'  series";
            form_1.toolStripMenuItem69.Text = "'አ'  series";
            form_1.toolStripMenuItem68.Text = "'ከ'  series";
            form_1.toolStripMenuItem67.Text = "'ኸ'  series";
            form_1.toolStripMenuItem56.Text = "'ወ'  series";
            form_1.toolStripMenuItem45.Text = "'ዐ'  series";
            form_1.toolStripMenuItem34.Text = "'ዘ'  series";
            form_1.yeሀBetToolStripMenuItem.Text = "'ዠ'  series";
            form_1.yeየBetToolStripMenuItem.Text = "'የ  'series";

            form_1.toolStripMenuItem85.Text = "'ደ'  series";
            form_1.toolStripMenuItem84.Text = "'ጀ'  series";
            form_1.toolStripMenuItem83.Text = "'ገ'  series";
            form_1.toolStripMenuItem82.Text = "'ጠ'  series";
            form_1.toolStripMenuItem81.Text = "'ጨ'  series";
            form_1.toolStripMenuItem80.Text = "'ጰ'  series";
            form_1.toolStripMenuItem79.Text = "'ጸ'  series";
            form_1.toolStripMenuItem78.Text = "'ፀ'  series";
            form_1.toolStripMenuItem77.Text = "'ፈ'  series";
            form_1.toolStripMenuItem76.Text = "'ፐ'  series";
        }

        public void changeToTigrignaLanguage()
        {
            form_1.menuToolStripMenuItem.Text = "መውጽኢ";
            form_1.aboutToolStripMenuItem.Text = "ቅንብር";
            form_1.helpToolStripMenuItem.Text = "ሓገዝ";
            form_1.toolStripMenuItem1.Text = "ብዛዕባ";

            form_1.lessonsToolStripMenuItem.Text = "ትምህርትታት";
            form_1.layoutsToolStripMenuItem.Text = "ገጽታዎች";
            form_1.exitToolStripMenuItem.Text = "ዕጾ";

            if (Form1.layout)
            {
                if (isButton4Clicked && (Form1.custo != null && Form1.custo != ""))
                {
                    form_1.lessonLable.Text = "ናይ ውልቀ ምርጫ";
                }
                if (lesson == 10)
                {
                    form_1.lessonLable.Text = "ናይ ውልቀ ምርጫ";
                }
                else
                {
                    form_1.lessonLable.Text = "ትምህርቲ " + (Form1.lessonNum + 1);
                    form_1.Excersice_Label.Text = ", መልመዲ " + (Form1.exerciseNum + 1);
                    
                }
            }
            else
            {
                form_1.lessonLable.Text = "ናይ ቁጽሪ";
                form_1.Excersice_Label.Text = ", መልመዲ " + (Form1.exerciseNum + 1);
            }

            form_1.Error_label.Text = "ስሕተታት: " + Form1.errors;
            form_1.WPM_label.Text = "ፍጥነት: " + Form1.wpm;

            form_1.uSEnglishToolStripMenuItem.Text = "ናይ ፊደል መአዲ";
            form_1.numericKeypadToolStripMenuItem.Text = "ናይ ቁጽሪ መአዲ";

            form_1.lesson1ToolStripMenuItem.Text = "(Key) ትምህርቲ 1";
            form_1.lesson2ToolStripMenuItem.Text = "(Key) ትምህርቲ 2";
            form_1.lesson3ToolStripMenuItem.Text = "(Word) ትምህርቲ 3";
            form_1.lesson4ToolStripMenuItem.Text = "(Word) ትምህርቲ 4";
            form_1.lesson5ToolStripMenuItem.Text = "(Word) ትምህርቲ 5";
            form_1.toolStripMenuItem23.Text = "አማሓርኛ 1";
            form_1.toolStripMenuItem25.Text = "አማሓርኛ 2";
            form_1.toolStripMenuItem24.Text = "አማሓርኛ 3";
            form_1.NumericToolStripMenuItem.Text = "ናይ ቁጽሪ ት/ቲ";

            form_1.exercise1ToolStripMenuItem.Text = "መልመዲ 1";
            form_1.exercise2ToolStripMenuItem.Text = "መልመዲ 2";
            form_1.exercise3ToolStripMenuItem.Text = "መልመዲ 3";
            form_1.exercise4ToolStripMenuItem.Text = "መልመዲ 4";
            form_1.exercise5ToolStripMenuItem.Text = "መልመዲ 5";
            form_1.exercise6ToolStripMenuItem.Text = "መልመዲ 6";
            form_1.exercise7ToolStripMenuItem.Text = "መልመዲ 7";
            form_1.exercise8ToolStripMenuItem.Text = "መልመዲ 8";
            form_1.exercise9ToolStripMenuItem.Text = "መልመዲ 9";
            form_1.exercise10ToolStripMenuItem.Text = "መልመዲ 10";

            form_1.toolStripMenuItem2.Text = "መልመዲ 1";
            form_1.toolStripMenuItem3.Text = "መልመዲ 2";
            form_1.toolStripMenuItem4.Text = "መልመዲ 3";
            form_1.toolStripMenuItem5.Text = "መልመዲ 4";
            form_1.toolStripMenuItem6.Text = "መልመዲ 5";
            form_1.toolStripMenuItem7.Text = "መልመዲ 6";
            form_1.toolStripMenuItem8.Text = "መልመዲ 7";
            form_1.toolStripMenuItem9.Text = "መልመዲ 8";
            form_1.toolStripMenuItem10.Text = "መልመዲ 9";
            form_1.toolStripMenuItem11.Text = "መልመዲ 10";

            form_1.toolStripMenuItem13.Text = "መልመዲ 1";
            form_1.toolStripMenuItem14.Text = "መልመዲ 2";
            form_1.toolStripMenuItem15.Text = "መልመዲ 3";
            form_1.toolStripMenuItem16.Text = "መልመዲ 4";
            form_1.toolStripMenuItem17.Text = "መልመዲ 5";
            form_1.toolStripMenuItem18.Text = "መልመዲ 6";
            form_1.toolStripMenuItem19.Text = "መልመዲ 7";
            form_1.toolStripMenuItem20.Text = "መልመዲ 8";
            form_1.toolStripMenuItem21.Text = "መልመዲ 9";
            form_1.toolStripMenuItem22.Text = "መልመዲ 10";

            form_1.toolStripMenuItem57.Text = "መልመዲ 1";
            form_1.toolStripMenuItem58.Text = "መልመዲ 2";
            form_1.toolStripMenuItem59.Text = "መልመዲ 3";
            form_1.toolStripMenuItem60.Text = "መልመዲ 4";
            form_1.toolStripMenuItem61.Text = "መልመዲ 5";
            form_1.toolStripMenuItem62.Text = "መልመዲ 6";
            form_1.toolStripMenuItem63.Text = "መልመዲ 7";
            form_1.toolStripMenuItem64.Text = "መልመዲ 8";
            form_1.toolStripMenuItem65.Text = "መልመዲ 9";
            form_1.toolStripMenuItem66.Text = "መልመዲ 10";

            form_1.toolStripMenuItem46.Text = "መልመዲ 1";
            form_1.toolStripMenuItem47.Text = "መልመዲ 2";
            form_1.toolStripMenuItem48.Text = "መልመዲ 3";
            form_1.toolStripMenuItem49.Text = "መልመዲ 4";
            form_1.toolStripMenuItem50.Text = "መልመዲ 5";
            form_1.toolStripMenuItem51.Text = "መልመዲ 6";
            form_1.toolStripMenuItem52.Text = "መልመዲ 7";
            form_1.toolStripMenuItem53.Text = "መልመዲ 8";
            form_1.toolStripMenuItem54.Text = "መልመዲ 9";
            form_1.toolStripMenuItem55.Text = "መልመዲ 10";

            form_1.toolStripMenuItem35.Text = "መልመዲ 1";
            form_1.toolStripMenuItem36.Text = "መልመዲ 2";
            form_1.toolStripMenuItem37.Text = "መልመዲ 3";
            form_1.toolStripMenuItem38.Text = "መልመዲ 4";
            form_1.toolStripMenuItem39.Text = "መልመዲ 5";
            form_1.toolStripMenuItem40.Text = "መልመዲ 6";
            form_1.toolStripMenuItem41.Text = "መልመዲ 7";
            form_1.toolStripMenuItem42.Text = "መልመዲ 8";
            form_1.toolStripMenuItem43.Text = "መልመዲ 9";
            form_1.toolStripMenuItem44.Text = "መልመዲ 10";

            form_1.toolStripMenuItem33.Text = "ብ 'ሀ'  ዝጅምሩ";
            form_1.toolStripMenuItem32.Text = "ብ 'ለ'  ዝጅምሩ";
            form_1.toolStripMenuItem31.Text = "ብ 'ሐ'  ዝጅምሩ";
            form_1.toolStripMenuItem30.Text = "ብ 'መ'  ዝጅምሩ";
            form_1.toolStripMenuItem29.Text = "ብ 'ሠ'  ዝጅምሩ";
            form_1.toolStripMenuItem28.Text = "ብ 'ረ'  ዝጅምሩ";
            form_1.toolStripMenuItem27.Text = "ብ 'ሰ'  ዝጅምሩ";
            form_1.toolStripMenuItem26.Text = "ብ 'ሸ'  ዝጅምሩ";
            form_1.toolStripMenuItem74.Text = "ብ 'ቀ'  ዝጅምሩ";
            form_1.yeHaBetToolStripMenuItem.Text = "ብ 'በ'  ዝጅምሩ";
            form_1.yeቨBetToolStripMenuItem.Text = "ብ 'ቨ'  ዝጅምሩ";
            form_1.yeተBetToolStripMenuItem.Text = "ብ 'ተ'  ዝጅምሩ";

            form_1.toolStripMenuItem73.Text = "ብ 'ቸ'  ዝጅምሩ";
            form_1.toolStripMenuItem72.Text = "ብ 'ኀ'  ዝጅምሩ";
            form_1.toolStripMenuItem71.Text = "ብ 'ነ'  ዝጅምሩ";
            form_1.toolStripMenuItem70.Text = "ብ 'ኘ'  ዝጅምሩ";
            form_1.toolStripMenuItem69.Text = "ብ 'አ'  ዝጅምሩ";
            form_1.toolStripMenuItem68.Text = "ብ 'ከ'  ዝጅምሩ";
            form_1.toolStripMenuItem67.Text = "ብ 'ኸ'  ዝጅምሩ";
            form_1.toolStripMenuItem56.Text = "ብ 'ወ'  ዝጅምሩ";
            form_1.toolStripMenuItem45.Text = "ብ 'ዐ'  ዝጅምሩ";
            form_1.toolStripMenuItem34.Text = "ብ 'ዘ'  ዝጅምሩ";
            form_1.yeሀBetToolStripMenuItem.Text = "ብ 'ዠ'  ዝጅምሩ";
            form_1.yeየBetToolStripMenuItem.Text = "ብ 'የ  'ዝጅምሩ";

            form_1.toolStripMenuItem85.Text = "ብ 'ደ'  ዝጅምሩ";
            form_1.toolStripMenuItem84.Text = "ብ 'ጀ'  ዝጅምሩ";
            form_1.toolStripMenuItem83.Text = "ብ 'ገ'  ዝጅምሩ";
            form_1.toolStripMenuItem82.Text = "ብ 'ጠ'  ዝጅምሩ";
            form_1.toolStripMenuItem81.Text = "ብ 'ጨ'  ዝጅምሩ";
            form_1.toolStripMenuItem80.Text = "ብ 'ጰ'  ዝጅምሩ";
            form_1.toolStripMenuItem79.Text = "ብ 'ጸ'  ዝጅምሩ";
            form_1.toolStripMenuItem78.Text = "ብ 'ፀ'  ዝጅምሩ";
            form_1.toolStripMenuItem77.Text = "ብ 'ፈ'  ዝጅምሩ";
            form_1.toolStripMenuItem76.Text = "ብ 'ፐ'  ዝጅምሩ";
        }

        public void englishCostomization()
        {
            this.Text = "Customize";

            groupBox1.Text = "Sound";
            groupBox2.Text = "Layout";
            groupBox3.Text = "Lessons";
            groupBox1.Text = "Language";
            checkBox1.Text = "Play Sound";

            groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "US-English Layout", "Numeric Layout" });

            button4.Text = "Add Custom Text";
            button1.Text = "Ok";
            button3.Text = "Cancel";
        }

        public void amharicCustomization()
        {
            this.Text = "ቅንብር";
            
            groupBox1.Text = "ድምጽ";
            groupBox2.Text = "ገጽታዎች";
            groupBox3.Text = "ትምህርቶች";
            groupBox4.Text = "ቋንቋ";
            checkBox1.Text = "ድምጽ አጫውት";

            groupBox1.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox3.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox4.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button1.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button3.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[]{"የፊደል ገበታ", "የቁጥር ገበታ"});

            button4.Text = "የራስዎን ጽሁፍ ይጨምሩ";
            button1.Text = "እሺ";
            button3.Text = "ይቅር";
        }

        public void oromiffaCustomization() {
            this.Text = "kinibir";

            groupBox1.Text = "dimts";
            groupBox2.Text = "getsitawoch";
            groupBox3.Text = "timihirtoch";
            groupBox4.Text = "quanqua";
            checkBox1.Text = "dimts achawt";

            groupBox1.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox3.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox4.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button1.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button3.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "yefidel gebeta", "yekutir gebeta" });

            button4.Text = "yerasiwon tsihuf yichemiru";
            button1.Text = "eshi";
            button3.Text = "yikir";
        }

        public void tigrinaCustomization()
        {
            this.Text = "ቕንብር";

            groupBox1.Text = "ድምጺ";
            groupBox2.Text = "ገጽታ";
            groupBox3.Text = "ትምህርትታት";
            groupBox4.Text = "ቋንቋ";
            checkBox1.Text = "ድምጺ አጻውት";

            groupBox1.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox3.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox4.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button1.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button3.Font = new System.Drawing.Font("Century Gothic", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "ናይ ፊደል መአዲ", "ናይ ቁጽሪ መአዲ" });

            button4.Text = "ናይ ባዕሎም ጽሑፍ ይወስኹ";
            button1.Text = "እሺ";
            button3.Text = "ይቕረ";

            //here button2 was the 'Apply' button and it's, by now, deleted;
        }

    }       //class
}       //namespace