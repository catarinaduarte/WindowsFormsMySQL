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
    public partial class FormMain : Form
    {
        FormInserirFormandos frmInserirFormandos = new FormInserirFormandos();
        FormApagarFormandos frmApagarFormandos = new FormApagarFormandos();
        FormApagarNacionalidade frmApagarNacionalidade = new FormApagarNacionalidade();
        FormAdicionarNacionalidade frmAdicionarNacionalidade = new FormAdicionarNacionalidade();
        FormAtualizarNacionalidade frmAtualizarNacionalidade = new FormAtualizarNacionalidade();
        FormListarNacionalidade frmListarNacionalidade = new FormListarNacionalidade();
        FormAutenticacao frmAutenticacao = new FormAutenticacao();
        FormListarFormandos frmListarFormandos = new FormListarFormandos();

        public FormMain()
        {
            InitializeComponent();
        }

        private void inseirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAdicionarNacionalidade.IsDisposed)
            {
                frmAdicionarNacionalidade = new FormAdicionarNacionalidade();
            }
            frmAdicionarNacionalidade.MdiParent = this;
            frmAdicionarNacionalidade.StartPosition = FormStartPosition.Manual;
            frmAdicionarNacionalidade.Location = new Point((this.ClientSize.Width - frmAdicionarNacionalidade.Width) / 2,
                (this.ClientSize.Height - frmAdicionarNacionalidade.Height) / 3);
            frmAdicionarNacionalidade.Show();
            frmAdicionarNacionalidade.Activate();

        }

        private void apagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmApagarNacionalidade.IsDisposed)
            {
                frmApagarNacionalidade = new FormApagarNacionalidade();
            }
            frmApagarNacionalidade.MdiParent = this;
            frmApagarNacionalidade.StartPosition = FormStartPosition.Manual;
            frmApagarNacionalidade.Location = new Point((this.ClientSize.Width - frmApagarNacionalidade.Width) / 2,
                (this.ClientSize.Height - frmApagarNacionalidade.Height) / 3);
            frmApagarNacionalidade.Show();
            frmApagarNacionalidade.Activate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "";
            toolStripButton1.Enabled = false;
            frmAutenticacao.ShowDialog();
            toolStripLabel1.Text = "ID user: " + Geral.id_user;
            toolStripButton1.Enabled = true;
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmInserirFormandos.IsDisposed)
            {
                frmInserirFormandos = new FormInserirFormandos();
            }
            frmInserirFormandos.MdiParent = this;
            frmInserirFormandos.StartPosition = FormStartPosition.Manual;
            frmInserirFormandos.Location = new Point((this.ClientSize.Width - frmInserirFormandos.Width) / 2,
                (this.ClientSize.Height - frmInserirFormandos.Height) / 3);
            frmInserirFormandos.Show();
            frmInserirFormandos.Activate();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmApagarFormandos.IsDisposed)
            {
                frmApagarFormandos = new FormApagarFormandos();
            }
            frmApagarFormandos.MdiParent = this;
            frmApagarFormandos.StartPosition = FormStartPosition.Manual;
            frmApagarFormandos.Location = new Point((this.ClientSize.Width - frmApagarFormandos.Width) / 2,
                (this.ClientSize.Height - frmApagarFormandos.Height) / 3);

            frmApagarFormandos.Show();
            frmApagarFormandos.Activate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (frmAtualizarNacionalidade.IsDisposed)
            {
                frmAtualizarNacionalidade = new FormAtualizarNacionalidade();
            }
            frmAtualizarNacionalidade.MdiParent = this;
            frmAtualizarNacionalidade.StartPosition = FormStartPosition.Manual;
            frmAtualizarNacionalidade.Location = new Point((this.ClientSize.Width - frmAtualizarNacionalidade.Width) / 2,
                (this.ClientSize.Height - frmAtualizarNacionalidade.Height) / 3);
            frmAtualizarNacionalidade.Show();
            frmAtualizarNacionalidade.Activate();

        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmListarNacionalidade.IsDisposed)
            {
                frmListarNacionalidade = new FormListarNacionalidade();
            }
            frmListarNacionalidade.MdiParent = this;
            frmListarNacionalidade.StartPosition = FormStartPosition.Manual;
            frmListarNacionalidade.Location = new Point((this.ClientSize.Width - frmListarNacionalidade.Width) / 2,
                (this.ClientSize.Height - frmListarNacionalidade.Height) / 3);
            frmListarNacionalidade.Show();
            frmListarNacionalidade.Activate();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja efetuar logout?\nTodas as janelas serão fechadas.", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                foreach (Form frm in this.MdiChildren)
                {
                    frm.Dispose();
                    frm.Close();
                }

                toolStripLabel1.Text = "";
                toolStripButton1.Enabled = false;
                frmAutenticacao.ShowDialog();
                toolStripLabel1.Text = "ID user: " + Geral.id_user;
                toolStripButton1.Enabled = true;
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmListarFormandos.IsDisposed)
            {
                frmListarFormandos = new FormListarFormandos();
            }
            frmListarFormandos.MdiParent = this;
            frmListarFormandos.StartPosition = FormStartPosition.Manual;
            frmListarFormandos.Location = new Point((this.ClientSize.Width - frmListarFormandos.Width) / 2,
                (this.ClientSize.Height - frmListarFormandos.Height) / 3);
            frmListarFormandos.Show();
            frmListarFormandos.Activate();

        }

        private void nacionalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
