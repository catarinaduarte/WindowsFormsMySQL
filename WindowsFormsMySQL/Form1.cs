using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMySQL
{
    public partial class Form1 : Form
    {
        DBConnect ligacao = new DBConnect();
        FormInserirFormandos frmInserirFormandos = new FormInserirFormandos();
        FormApagarFormandos frmApagarFormandos = new FormApagarFormandos();
        FormApagarNacionalidade frmApagarNacionalidade = new FormApagarNacionalidade();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect ligacao = new DBConnect();
            MessageBox.Show("Nº total de formandos: " + ligacao.Count());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ligacao.Insert();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (frmInserirFormandos.IsDisposed)
            {
                frmInserirFormandos = new FormInserirFormandos();
            }
            frmInserirFormandos.Show();
            frmInserirFormandos.Activate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (frmApagarFormandos.IsDisposed)
            {
                frmApagarFormandos = new FormApagarFormandos();
            }
            frmApagarFormandos.Show();
            frmApagarFormandos.Activate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (frmApagarNacionalidade.IsDisposed)
            {
                frmApagarNacionalidade = new FormApagarNacionalidade();
            }
            frmApagarNacionalidade.Show();
            frmApagarNacionalidade.Activate();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
