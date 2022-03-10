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
    public partial class FormAdicionarNacionalidade : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormAdicionarNacionalidade()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                if (ligacao.InsertNacionalidade(txtAlf2.Text, txtNacionalidade.Text))
                {
                    MessageBox.Show("Inseriu com sucesso!");
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Erro na Inserção!");
                    txtAlf2.Focus();
                }
            }
        }

        void Limpar()
        {
            txtAlf2.Text = "";
            txtNacionalidade.Text = "";
            txtAlf2.Focus();
        }

        bool VerificarCampos()
        {
            txtAlf2.Text = Geral.TirarEspacos(txtAlf2.Text);
            if (txtAlf2.Text.Length != 2)
            {
                MessageBox.Show("Erro no ALF2 (ISO2)!");
                txtAlf2.Focus();
                return false;
            }

            txtNacionalidade.Text = Geral.TirarEspacos(txtNacionalidade.Text);
            if (txtNacionalidade.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo de Nacionalidade!");
                txtNacionalidade.Focus();
                return false;
            }

            return true;
        }

        private void FormAdicionarNacionalidade_Load(object sender, EventArgs e)
        {

        }

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    MouseEventArgs rato = (MouseEventArgs)e;

        //    if (rato.Button == MouseButtons.Left)
        //    {
        //        Limpar();
        //    }
        //    if (rato.Button == MouseButtons.Right)
        //    {
        //        Close();
        //    }

        //}

        private void btnCancelar_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Limpar();
            //}
            //if (e.Button == MouseButtons.Right)
            //{
            //    Close();
            //}

            switch (e.Button)
            {
                case MouseButtons.Left:
                    Limpar();
                    break;
                case MouseButtons.Right:
                    Close();
                    break;
            }

        }
    }
}
