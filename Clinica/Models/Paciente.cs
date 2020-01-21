using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Edad { get; set; }
        public string Categoria { get; set; }
    }
}