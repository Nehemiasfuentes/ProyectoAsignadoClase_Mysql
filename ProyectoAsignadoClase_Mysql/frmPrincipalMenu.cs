using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoAsignadoClase_Mysql
{
    public partial class frmPrincipalMenu : Form
    {
        public frmPrincipalMenu()
        {
            InitializeComponent();
        }

        private void conexionABDtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest frmtest = new frmTest();
            frmtest.MdiParent = this; // diniendo el formulario padre
            frmtest.Show(); //mostrando formulario
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewMedico frmnewmedico = new frmNewMedico();

            frmnewmedico.Show();
        }

        private void frmPrincipalMenu_Load(object sender, EventArgs e)
        {
            frmNewMedico frmnewmedico = new frmNewMedico();

            frmnewmedico.Show();
        }
    }
}
