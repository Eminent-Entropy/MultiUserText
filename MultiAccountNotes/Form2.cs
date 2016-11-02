using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MultiAccountNotes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)//on load
        {
            try
            {
                string a = File.ReadAllText("c:\\UserText\\now");//finds what account is logged in

                string MainFolder = "c:\\UserText";//main folder
                string path = Path.Combine(MainFolder, "text");//sub-folder
                string userfile = Path.Combine(path, a);//user's text file

                if (File.Exists(userfile))//users text file exists the it shows it
                {
                    textBox1.Text = File.ReadAllText(userfile);
                }
            }
            catch
            {
                MessageBox.Show("error reading files");
            }
        }

        private void button1_Click(object sender, EventArgs e)//when save is clicked
        {
            try
            {


                string a = File.ReadAllText("c:\\UserText\\now");//gets current user logged in
                string MainFolder = "c:\\UserText";//Main folder
                string path = Path.Combine(MainFolder, "text");//sub-folder
                string userfile = Path.Combine(path, a);//user's text file

                File.WriteAllText(userfile, textBox1.Text);//writes current text to the text file
            }
            catch
            {
                MessageBox.Show("error reading files");
            }
        }

        private void button2_Click(object sender, EventArgs e)//when log out button is clicked
        {
            try
            {
                File.Delete("c:\\UserText\\now");//deletes file with useless information
                this.Close();//closes this form
            }
            catch
            {
                MessageBox.Show("error loging out");
            }
        }
    }   
}
