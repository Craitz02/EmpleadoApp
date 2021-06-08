using ClasePractica.enums;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasePractica.model;
using ClasePractica.poco;

namespace ClasePractica
{
    public partial class FrmEmpleado : Form
    {
        public EmpleadoModel empleadomodel;
        public FrmEmpleado()
        {
            InitializeComponent();
            loadTipoProfesion();
            loadTipoCargo();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = empleadomodel.LastEmpleado() + 1;
                string nombre = txtNombre.Text;
                string apellido = txtApellidos.Text;
                string cedula = txtCedula.Text;
                string telofono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                int indexProfesion = cmbProfesion.SelectedIndex;
                Profesiones profesion = (Profesiones)Enum.GetValues(typeof(Profesiones)).GetValue(indexProfesion);
                int indexCargo = cmbCargo.SelectedIndex;
                Cargos cargo = (Cargos)Enum.GetValues(typeof(Cargos)).GetValue(indexCargo);


                Empleado emp = new Empleado
                {
                    Id = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Cedula = cedula,
                    Telefono = telofono,
                    Correo = correo,
                    Profesion = profesion,
                    Cargo = cargo,
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mnesaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadTipoProfesion()
        {
            cmbProfesion.Items.Add(Enum.GetValues(typeof(Profesiones))
                                       .Cast<object>()
                                       .ToArray());

            cmbProfesion.SelectedIndex = 0;
        }

        public void loadTipoCargo()
        {
            cmbCargo.Items.Add(Enum.GetValues(typeof(Cargos))
                                       .Cast<object>()
                                       .ToArray());

            cmbCargo.SelectedIndex = 0;
        }

        private void ValidateEmpleado(string nombre)
        {

        }

        private Boolean ValidateCorreo(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
