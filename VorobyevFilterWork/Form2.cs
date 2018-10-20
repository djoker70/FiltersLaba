using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VorobyevFilterWork
{
    public partial class Form2 : Form
    {
        Form1 firstForm = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f)
        {
            InitializeComponent();
            firstForm = f;
            bool[,] kernelOld = firstForm.getKernel();
            if(kernelOld != null)
            {
                if (kernelOld[0, 0])
                    this.checkBox1.Checked = true;
                if (kernelOld[0, 1])
                    this.checkBox2.Checked = true;
                if (kernelOld[0, 2])
                    this.checkBox3.Checked = true;

                if (kernelOld[1, 0])
                    this.checkBox4.Checked = true;
                if (kernelOld[1, 1])
                    this.checkBox5.Checked = true;
                if (kernelOld[1, 2])
                    this.checkBox6.Checked = true;

                if (kernelOld[2, 0])
                    this.checkBox7.Checked = true;
                if (kernelOld[2, 1])
                    this.checkBox8.Checked = true;
                if (kernelOld[2, 2])
                    this.checkBox9.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool[,] newKernel = new bool[3,3];

            if (this.checkBox1.Checked)
                newKernel[0, 0] = true;
            else newKernel[0, 0] = false;
            if (this.checkBox2.Checked)
                newKernel[0, 1] = true;
            else newKernel[0, 1] = false;
            if (this.checkBox3.Checked)
                newKernel[0, 2] = true;
            else newKernel[0, 2] = false;

            if (this.checkBox4.Checked)
                newKernel[1, 0] = true;
            else newKernel[1, 0] = false;
            if (this.checkBox5.Checked)
                newKernel[1, 1] = true;
            else newKernel[1, 1] = false;
            if (this.checkBox6.Checked)
                newKernel[1, 2] = true;
            else newKernel[1, 2] = false;

            if (this.checkBox7.Checked)
                newKernel[2, 0] = true;
            else newKernel[2, 0] = false;
            if (this.checkBox8.Checked)
                newKernel[2, 1] = true;
            else newKernel[2, 1] = false;
            if (this.checkBox9.Checked)
                newKernel[2, 2] = true;
            else newKernel[2, 2] = false;

            firstForm.setKernel(newKernel);
            Form form1 = Application.OpenForms[0];
           
            this.Hide();
            form1.Show();
        }
    }
}
