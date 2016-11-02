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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)//checks if username and password are correct
        {
            try
            {


                string a = textBox1.Text;//what user type in username box

                string c = a + ".txt";//name of username file for account
                string path1S = "accounts";//sub-folder name

                string MainFolder = "c:\\UserText";//main folder
                string path1 = Path.Combine(MainFolder, path1S);//sub-folder
                path1 = Path.Combine(path1, c);//file

                if (File.Exists(path1) && File.ReadAllText(path1).Contains(textBox2.Text))//if file exists(username is correct) and correct text exists in that file(password correct)
                {
                    Form2 form2 = new Form2();
                    File.WriteAllText("c:\\UserText\\now", textBox1.Text);//tells form2 which account was signed in
                    form2.Show();//starts form2
                }
                else
                {
                    MessageBox.Show("incorect username or password");
                }
            }
            catch
            {
                MessageBox.Show("error reading files");
            }
        }





        private void button2_Click(object sender, EventArgs e)//sets up directory system
        {
            try
            {
                string MainFolder = "c:\\UserText";//main folder
                string path1S = "accounts";//sub-folder name
                string path2S = "text";

                string path1 = Path.Combine(MainFolder, path1S);//sub-folder
                Directory.CreateDirectory(path1);//creates folder

                string path2 = Path.Combine(MainFolder, path2S);//sub-folder
                Directory.CreateDirectory(path2);//creates folder
            }
            catch
            {
                MessageBox.Show("error creating file system");
            }
        }





        public string create1()//creats path(button3_Click)
        {
            string a = textBox3.Text + ".txt";//name of new account file
            string MainFolder = "c:\\UserText";//main folder
            string pathS = "accounts";//sub-folder name

            string path1 = Path.Combine(MainFolder, pathS);//sub-folder
            path1 = Path.Combine(path1, a);//new account file
            return (path1);
        }

        public void create2(string path1)//creates file and writes to it(button3_Click)
        {
            File.WriteAllText(path1, textBox4.Text);//writes password to text file
            MessageBox.Show("account created");
        }


        private void button3_Click(object sender, EventArgs e)//creates account file and writes password to it
        {
            try
            {
                string a = create1();
                create2(a);
            }
            catch
            {
                MessageBox.Show("error creating account");
            }
        }
    }
}
