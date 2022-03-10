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
    public partial class FormAutenticacao : Form
    {
        DBConnect ligacao = new DBConnect();
        public FormAutenticacao()
        {
            InitializeComponent();
        }

        private void FormAutenticacao_Load(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPW.Text = "";
            ControlBox = false;
            AcceptButton = btnLogin;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtUser.Text == "Login" && txtPW.Text == "1234")
            if (ligacao.ValidateUser(txtUser.Text, txtPW.Text, ref Geral.id_user))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Erro na autenticação!");
            }
        }
    }
}
