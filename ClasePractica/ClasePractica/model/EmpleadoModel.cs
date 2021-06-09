using ClasePractica.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePractica.model
{
    public class EmpleadoModel
    {
        private Empleado[] empleados;
        public EmpleadoModel() { }
        public void Add(Empleado e)
        {
            if (empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = e;
                return;
            }
            Empleado[] temp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, temp, empleados.Length);
            temp[temp.Length - 1] = e;

            empleados = temp;
        }

        public int LastEmpleado()
        {
            if (empleados == null)
            {
                return 0;
            }
            else
            {
                return empleados.Length;
            }
            
        }

        public Empleado[] getAll()
        {
            return empleados;
        }
    }
}
