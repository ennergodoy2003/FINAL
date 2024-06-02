using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FINAL.Data.Model
{
    public class modcar
    {
        //propiedades
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Propietario { get; set; }

        public int Precio { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public bool Disponible { get; set; }

        //constructor vacio
        public modcar() { }

        //constructor parametizado
        public modcar(int Id, string Marca, string Modelo, int Ano, string Propietario, int Precio, DateTime Fecha_ingreso, bool Disponible)
        {
            Id = Id;
            Marca = Marca;
            Ano = Ano;
            Modelo= Modelo;
            Propietario = Propietario;

            Precio = Precio;

            Fecha_ingreso = Fecha_ingreso;
            Disponible = Disponible;
        }

        //se define para que nos devuelva los atributos del automovil
        public override string ToString()
        {
            return $"Id: {Id}, Marca: {Marca}, Modelo: {Modelo}, Ano: {Ano}, Propietario: {Propietario}, Precio: {Precio}, : Fecha_ingreso {Fecha_ingreso}, Disponible: {Disponible} ";
        }
    }
}


