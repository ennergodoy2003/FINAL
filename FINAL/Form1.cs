using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FINAL.Data;
using FINAL.Data.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FINAL
{
    public partial class Form1 : Form
    {
        modcar usr = new modcar();
        CConexion cls = new CConexion();
        public Form1()
        {
            InitializeComponent();
        }
        //evento 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                CConexion objetoConexion = new CConexion();
                objetoConexion.establecerConexion();

                MessageBox.Show("conexion exitosa ");
            }
            catch { MessageBox.Show("error de conexion"); }
        }



        //para ingresar un vehiculo


        public void button2_Click(object sender, EventArgs e)
        {

            try
            {
                usr.Id = int.Parse(textId.Text);
                usr.Marca = textMarca.Text;

                usr.Modelo = textModelo.Text;
                usr.Ano = int.Parse(textAno.Text);
                usr.Propietario = textPropietario.Text;
                usr.Precio = int.Parse(textPrecio.Text);
                usr.Fecha_ingreso = dateTimePickerfecha.Value;
                usr.Disponible = checkboxDisponible.Checked;
                cls.Insertar(usr);

                MessageBox.Show("El vehiculo ha sido ingresado exitosamente");

            }

            catch { MessageBox.Show("Error al ingresar vehiculo"); }


        }

        //para leer y hacer que aparezca en la pantalla
        private void cargar_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cls.LeerTodos();
        }


        //PARA ELIMINAR UN VEHICULO
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int IdvehiculoEliminar = int.Parse(textId.Text);


                cls.EliminarVehiculo(IdvehiculoEliminar);

                MessageBox.Show("Vehiculo eliminado");


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al eliminar el vehiculo");
            }
        }

        //para actualizar
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                usr.Id = int.Parse(textId.Text);
                usr.Marca = textMarca.Text;

                usr.Modelo = textModelo.Text;
                usr.Ano = int.Parse(textAno.Text);
                usr.Propietario = textPropietario.Text;
                usr.Precio = int.Parse(textPrecio.Text);
                usr.Fecha_ingreso = dateTimePickerfecha.Value;
                usr.Disponible = checkboxDisponible.Checked;

                cls.Actualizar(usr);



            }
            catch { MessageBox.Show(" hubo erro al actualizar "); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}



    
