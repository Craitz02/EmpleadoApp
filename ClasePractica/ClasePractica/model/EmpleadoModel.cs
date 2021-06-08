using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePractica.model
{
    public class EmpleadoModel
    {
        private FrmEmpleado[] empleados;

        public void Add(FrmEmpleado e)
        {
            if (empleados == null)
            {
                empleados = new FrmEmpleado[1];
                empleados[0] = e;
                return;
            }
            FrmEmpleado[] temp = new FrmEmpleado[empleados.Length + 1];
            Array.Copy(empleados, temp, empleados.Length);
            temp[temp.Length - 1] = e;

            empleados = temp;
        }

        public int LastEmpleado()
        {
            return empleados.Length;
        }
    }
}
