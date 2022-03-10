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
    public partial class FormInserirFormandos : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormInserirFormandos()
        {
            InitializeComponent();
        }

        private void FormInserirFormandos_Load(object sender, EventArgs e)
        {
            nudID.Value = ligacao.DevolveUltimoID();
            ligacao.PreencherComboNacionalidade(ref cmbNacionalidade);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string id_nacionalidade = cmbNacionalidade.SelectedItem.ToString().Substring(
                    cmbNacionalidade.SelectedItem.ToString().LastIndexOf(' ') + 1);

                if (ligacao.Insert(nudID.Value.ToString(), txtNome.Text, txtMorada.Text,
                    mtxtContacto.Text, txtIBAN.Text, genero(), DateTime.Parse(mtxtDatanascimento.Text).ToString("yyyy-MM-dd"), id_nacionalidade) == true)
                {
                    MessageBox.Show("Inseriu com sucesso!");
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Erro na inserção!");
                }
            }
        }

        private void Limpar()
        {
            nudID.Value = ligacao.DevolveUltimoID();
            txtNome.Text = "";
            txtMorada.Text = "";
            mtxtContacto.Clear();
            txtIBAN.Text = "";
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            mtxtDatanascimento.Clear();
            cmbNacionalidade.SelectedIndex = -1;
        }

        private char genero()
        {
            char genero = 'T';
            if (rbFeminino.Checked)
            {
                genero = 'F';
            }
            else if (rbMasculino.Checked)
            {
                genero = 'M';
            }
            else if (rbOutro.Checked)
            {
                genero = 'O';
            }
            return genero;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool VerificarCampos()
        {
            if(nudID.Value < 1)
            {
                MessageBox.Show("Erro no campo ID!");
                nudID.Focus();
                return false;
            }

            txtNome.Text = Geral.TirarEspacos(txtNome.Text);
            if (txtNome.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }

            txtMorada.Text = Geral.TirarEspacos(txtMorada.Text);
            if (txtMorada.Text.Length < 2)
            {
                MessageBox.Show("Erro no campo Morada!");
                txtMorada.Focus();
                return false;
            }

            if (mtxtContacto.Text.Length < 9)
            {
                MessageBox.Show("Erro no campo Contacto!");
                mtxtContacto.Focus();
                return false;
            }

            txtIBAN.Text = Geral.TirarEspacos(txtIBAN.Text);
            if (txtIBAN.Text.Length < 25)
            {
                MessageBox.Show("Erro no campo IBAN!");
                txtIBAN.Focus();
                return false;
            }

            if (genero() == 'T')
            {
                MessageBox.Show("Erro no campo Género!");
                rbFeminino.Focus();
                return false;
            }

            if (mtxtDatanascimento.Text.Length != 10 || (Geral.CheckDate(mtxtDatanascimento.Text)==false))
            {
                MessageBox.Show("Erro no campo Data Nascimento!");
                mtxtDatanascimento.Focus();
                return false;
            }

            if (cmbNacionalidade.SelectedIndex == -1)
            {
                MessageBox.Show("Erro no campo de Nacionalidade!");
                cmbNacionalidade.Focus();
                return false;
            }

            return true;

        }
    }
}
