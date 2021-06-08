﻿using ClasePractica.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePractica.poco
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Profesiones Profesion { get; set; }
        public Cargos Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
