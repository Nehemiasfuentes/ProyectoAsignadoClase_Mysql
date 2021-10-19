using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoAsignadoClase_Mysql
{
    public partial class frmNewMedico : Form

    {

        private string action = "";

        public frmNewMedico()
        {
            InitializeComponent();


        }

        public void llenarDataGridView()
        {
            Medico medico = new Medico();

            limpiardatagridView();

            dataGridViewInfo.Columns.Add("nombreMedico", "Nombre");
            dataGridViewInfo.Columns.Add("apellidoMedico", "Apellido");
            dataGridViewInfo.Columns.Add("especialidadMedico", "Espcialidad");
            dataGridViewInfo.Columns.Add("telefonoMedico", "Telefono");
            dataGridViewInfo.Columns.Add("DireccionMedico", "Direccion");

            MySqlDataReader dataReader = medico.RegistrosMedicos();

            while (dataReader.Read())
            {
                dataGridViewInfo.Rows.Add(
               dataReader.GetValue(0),
               dataReader.GetValue(1),
               dataReader.GetValue(2),
               dataReader.GetValue(3),
               dataReader.GetValue(4));
            }
        }

        public void vaciarControles()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxEspecialidad.Text = "";
            textBoxTelefono.Text = "";
            textBoxDireccion.Text = "";
        }

        private void limpiardatagridView()
        {
            dataGridViewInfo.Columns.Clear();
            dataGridViewInfo.Rows.Clear();
        }

        private void frmNewMedico_Load(object sender, EventArgs e)
        {
            dataGridViewInfo.Columns.Add("nombre", "Nombre");
            dataGridViewInfo.Columns.Add("apellido", "Apellido");
            dataGridViewInfo.Columns.Add("especialidad", "Especialidad");
            dataGridViewInfo.Columns.Add("telefono", "Telefono");
            dataGridViewInfo.Columns.Add("direccionClinica", "Direccion Clinica");

            llenarDataGridView();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            action = "new";
            if (textBoxNombre.Text == "")
            {
               
                MetroFramework.MetroMessageBox.Show(this, "El campo Nombre esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
            }
            else if (textBoxApellido.Text == "")
            {
          
                MetroFramework.MetroMessageBox.Show(this, "El campo Apellido esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxApellido.Focus();
            }
            else if (textBoxEspecialidad.Text == "")
            {
         
                MetroFramework.MetroMessageBox.Show(this, "El campo Especialidad esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEspecialidad.Focus();
            }
            else if (textBoxTelefono.Text == "")
            {
               
                MetroFramework.MetroMessageBox.Show(this, "El campo Telefono esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTelefono.Focus();
            }
            else if (textBoxDireccion.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "El campo Direccion esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDireccion.Focus();
            }
            else
            {


                Medico medico = new Medico();

                medico.nombre = textBoxNombre.Text;
                medico.apellido = textBoxApellido.Text;
                medico.especialidad = textBoxEspecialidad.Text;
                medico.telefono = textBoxTelefono.Text;
                medico.direccionClinica = textBoxDireccion.Text;

                string mensaje = "¿Estas seguro que deseas guardar los registros?";
                if (MetroFramework.MetroMessageBox.Show(this, mensaje, "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Llamar al metodo Guardar
                    if (medico.RegistrarEditarRegistrosMedicos(action))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Los registros se han almacenado correctamente!", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Los registros no se han almacenado correctamente!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    vaciarControles();
                    llenarDataGridView();

                }

            }
        }

        private void edit_Click(object sender, EventArgs e)
        {

            textBoxNombre.Text = dataGridViewInfo.CurrentRow.Cells[0].Value.ToString();
            textBoxApellido.Text = dataGridViewInfo.CurrentRow.Cells[1].Value.ToString();
            textBoxEspecialidad.Text = dataGridViewInfo.CurrentRow.Cells[2].Value.ToString();
            textBoxTelefono.Text = dataGridViewInfo.CurrentRow.Cells[3].Value.ToString();
            textBoxDireccion.Text = dataGridViewInfo.CurrentRow.Cells[4].Value.ToString();

            action = "edit";

            textBoxNombre.Focus();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Estas seguro que deseas eliminar este medico?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Medico medico = new Medico();
                medico.nombre = (string)dataGridViewInfo.CurrentRow.Cells[0].Value;


                if (medico.EliminarMedico())
                {
                    MetroFramework.MetroMessageBox.Show(this, "El medico se ha eliminado correctamente de la libreta", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    llenarDataGridView();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El medico no se ha eliminado correctamente de la libreta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
            {
            action = "edit";
                if (textBoxNombre.Text == "")
                {

                    MetroFramework.MetroMessageBox.Show(this, "El campo Nombre esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNombre.Focus();
                }
                else if (textBoxApellido.Text == "")
                {

                    MetroFramework.MetroMessageBox.Show(this, "El campo Apellido esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxApellido.Focus();
                }
                else if (textBoxEspecialidad.Text == "")
                {

                    MetroFramework.MetroMessageBox.Show(this, "El campo Especialidad esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxEspecialidad.Focus();
                }
                else if (textBoxTelefono.Text == "")
                {

                    MetroFramework.MetroMessageBox.Show(this, "El campo Telefono esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTelefono.Focus();
                }
                else if (textBoxDireccion.Text == "")
                {

                    MetroFramework.MetroMessageBox.Show(this, "El campo Direccion esta vacio.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxDireccion.Focus();
                }
                else
                {


                    Medico medico = new Medico();

                    //Evaluar la accion a realizar.
                    if (action == "edit")
                    {
                        medico.nombre = textBoxNombre.Text;
                    }

                    medico.nombre = textBoxNombre.Text;
                    medico.apellido = textBoxApellido.Text;
                    medico.especialidad = textBoxEspecialidad.Text;
                    medico.telefono = textBoxTelefono.Text;
                    medico.direccionClinica = textBoxDireccion.Text;

                    string mensaje = "¿Estas seguro que deseas guardar los registros?";
                    if (MetroFramework.MetroMessageBox.Show(this, mensaje, "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Llamar al metodo Guardar
                        if (medico.RegistrarEditarRegistrosMedicos(action))
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Los registros se han almacenado correctamente!", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Los registros no se han almacenado correctamente!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        vaciarControles();
                        llenarDataGridView();

                    }

                }
            }
        }
    }