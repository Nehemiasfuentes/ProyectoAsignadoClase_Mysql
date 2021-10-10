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
    public partial class frmNewMedico : Form
    {
        public frmNewMedico()
        {
            InitializeComponent();


        }

        private void frmNewMedico_Load(object sender, EventArgs e)
        {
            dataGridViewInfo.Columns.Add("nombre", "Nombre");
            dataGridViewInfo.Columns.Add("apellido", "Apellido");
            dataGridViewInfo.Columns.Add("especialidad", "Especialidad");
            dataGridViewInfo.Columns.Add("telefono", "Telefono");
            dataGridViewInfo.Columns.Add("direccionClinica", "Direccion Clinica");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
