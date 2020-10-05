using System;
using System.ComponentModel.DataAnnotations;

namespace WilsonGomez_P1_AP1.Entidades
{
    public class Ciudades
    {
        [Key]
        public int CiudadID { get; set; }
        public string Nombres { get; set; }
    }
}