using System;
using System.ComponentModel.DataAnnotations;

namespace WilsonGomez_P1_AP1.Entidades
{
    public class Productos
    {
        [Key]
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
    }
}