
using ClasePractica.poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClasePractica
{
    public partial class FrmMdi : Form
    {
        private List<Empleado> empleados;
        public FrmMdi()
        {
            InitializeComponent();
            empleados = new List<Empleado>();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmE = new FrmEmpleado();
            frmE.Empleados = empleados;
            frmE.MdiParent = this;
            frmE.Show();
        }
    }
}
