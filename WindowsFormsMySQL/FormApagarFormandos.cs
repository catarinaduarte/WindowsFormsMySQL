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
    public partial class FormApagarFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormApagarFormandos()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", data_nascimento = "";
            char genero = ' ';

            if (ligacao.PesquisaFormando(nudID.Value.ToString(),ref nome, ref morada, 
                ref contacto, ref iban, ref genero, ref data_nascimento))
            {
                txtNome.Text = nome;
                txtMorada.Text = morada;
                mtxtContacto.Text = contacto;
                txtIBAN.Text = iban;
                if (genero == 'M')
                {
                    rbMasculino.Checked = true;
                } else if (genero == 'F')
                {
                    rbFeminino.Checked = true;
                } else if (genero == 'O')
                {
                    rbOutro.Checked = true;
                }
                mtxtDatanascimento.Text = data_nascimento;

                Pesquisa.Enabled = false;
                btnEliminar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja eliminar o registo com id " + nudID.Value.ToString(), "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (ligacao.Delete(nudID.Value.ToString()))
                {
                    MessageBox.Show("Registo eliminado!");
                    btnCancelar_Click(sender, e);
                }    
                else
                {
                    MessageBox.Show("Não foi possível eliminar o registo!");
                }
            }
            
        }

        private void FormApagarFormandos_Load(object sender, EventArgs e)
        {
            //groupBox1.Enabled = false;
            txtNome.ReadOnly = true;
            txtMorada.ReadOnly = true;
            mtxtContacto.ReadOnly = true;
            txtIBAN.ReadOnly = true;
            rbMasculino.Enabled = false;
            rbFeminino.Enabled = false;
            rbOutro.Enabled = false;
            mtxtDatanascimento.ReadOnly = true;

            btnEliminar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Pesquisa.Enabled = true;

            btnEliminar.Enabled = false;

            Limpar();
        }

        private void Limpar()
        {
            nudID.Value = 0;
            txtNome.Text = "";
            txtMorada.Text = "";
            mtxtContacto.Clear();
            txtIBAN.Text = "";
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            mtxtDatanascimento.Clear();
        }
    }
}
