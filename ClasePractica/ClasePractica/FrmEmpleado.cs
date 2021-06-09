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
        public List<Empleado> Empleados { get; set; }
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            cmbProfesion.Items.AddRange(Enum.GetValues(typeof(Profesiones))
                                       .Cast<object>()
                                       .ToArray());

            cmbProfesion.SelectedIndex = 0;

            cmbCargo.Items.AddRange(Enum.GetValues(typeof(Cargos))
                                       .Cast<object>()
                                       .ToArray());

            cmbCargo.SelectedIndex = 0;


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {   
                int id = Empleados.Count + 1;
                string nombre = txtNombre.Text;
                string apellido = txtApellidos.Text;
                string cedula = txtCedula.Text;
                string telofono = txtTelefono.Text;
                string correo = txtCorreo.Text;
                ValidateEmpleado(nombre, apellido, cedula, telofono, correo, out decimal salario);
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
                    Salario = salario,
                };

                Empleados.Add(emp);
                dgvEmpleado.DataSource = null;
                dgvEmpleado.DataSource = Empleados;


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mnesaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ValidateEmpleado(string nombre, string apellido, string cedula, string telefono, string correo, out decimal salario)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es requerido!");
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El apellido es requerido!");
            }
            if (string.IsNullOrWhiteSpace(cedula))
            {
                throw new ArgumentException("La cedula es requerido!");
            }
            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El telefono es requerido!");
            }
            if (ValidateTelefono(telefono))
            {
                throw new ArgumentException("El telefono no tiene una estructura valida!");
            }
            if (string.IsNullOrWhiteSpace(correo))
            {
                throw new ArgumentException("El correo es requerido!");
            }
            if (!ValidateCorreo(correo))
            {
                throw new ArgumentException("El correo no tiene una estructura valida!");
            }
            if (!decimal.TryParse(txtSalario.Text, out decimal s))
            {
                throw new ArgumentException($"El valor \"{txtSalario.Text}\" es invalido!");
            }
            salario = s;
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

        private Boolean ValidateTelefono(string telefono)
        {
            return telefono != null && Regex.IsMatch(telefono, "^\\d{7,10}$");
        }


        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (dgvEmpleado == null)
            {
                return;
            }
            List<Empleado> filtro = new List<Empleado>();
            string clave = txtFiltro.Text;
            foreach (Empleado emp in Empleados)
            {
                if ((emp.Id + "").Contains(clave) || emp.Nombre.Contains(clave) || emp.Apellido.Contains(clave) || emp.Cedula.Contains(clave)
                    || emp.Correo.Contains(clave) || emp.Telefono.Contains(clave) || (emp.Salario + "").Contains(clave))
                {
                    filtro.Add(emp);
                }
                if (filtro.Count > 0)
                {
                    dgvEmpleado.DataSource = null;
                    dgvEmpleado.DataSource = filtro;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.Rows.Count == 0)
            {
                return;
            }
            int index = dgvEmpleado.CurrentCell.RowIndex;
            Empleados.RemoveAt(index);

            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = Empleados;
        }
    }
}
