using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FINAL.Data.Model;
using MySql.Data.MySqlClient;

namespace FINAL.Data
{
    internal class CConexion
    {
        // Información de conexión a la base de datos
        string connectionString = "Server=localhost;Database=garaje;user=root;Pwd=ennerosvaldo";
        MySqlConnection conex;

        //constructor
        public CConexion()

        {

            conex = new MySqlConnection(connectionString);
        }

        public bool establecerConexion()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }





        //insertar datos 
        
        public void Insertar(modcar usr)
        {
            {
                try
                {
                    string sql = "INSERT INTO carros ( Id, Marca, Modelo, Ano, Propietario, Precio, Fecha_ingreso, Disponible) VALUES (@Id, @Marca, @Modelo, @Ano, @Propietario, @Precio, @Fecha_ingreso,@Disponible)";
                    MySqlCommand cmd = new MySqlCommand(sql, conex);
                    cmd.Parameters.AddWithValue("@Id", usr.Id);
                    cmd.Parameters.AddWithValue("@Marca", usr.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", usr.Modelo);
                    cmd.Parameters.AddWithValue("@Ano", usr.Ano);
                    cmd.Parameters.AddWithValue("@Propietario", usr.Propietario);
                    cmd.Parameters.AddWithValue("@Precio", usr.Precio); //decimal.Parse(txtSaldo.Text)
                    cmd.Parameters.AddWithValue("@Fecha_ingreso", usr.Fecha_ingreso);
                    cmd.Parameters.AddWithValue("@Disponible", usr.Disponible);
                    conex.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception )
                {
                    MessageBox.Show("Error al agregar el vehiculo: " );
                }
                finally
                {
                    conex.Close();
                }

            }
        }
        


        //Para mostrar los datos en la pantalla

        public DataTable LeerTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM carros";
                MySqlCommand cmd = new MySqlCommand(query, conex);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conex.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los vehiculos " + ex.Message);
            }
            finally
            {
                conex.Close();
            }
            return dt;
        }

        //para eliminar vehiculo
        public void EliminarVehiculo(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM carros WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Actualizar(modcar usr)
        {
            try
            {
                string sql = "UPDATE carros SET Id = @Id, Marca = @Marca, Modelo = @Modelo, Ano = @Ano, Propietario = @Propietario, Precio = @Precio, Fecha_ingreso = @Fecha_ingreso, Disponible = @Disponible WHERE id=@id";
                MySqlCommand comando = new MySqlCommand(sql, conex);

                comando.Parameters.AddWithValue("@Id", usr.Id);
                comando.Parameters.AddWithValue("@Marca", usr.Marca);
                comando.Parameters.AddWithValue("@Modelo", usr.Modelo);
                comando.Parameters.AddWithValue("@Ano", usr.Ano);
                comando.Parameters.AddWithValue("@Propietario", usr.Propietario);
                comando.Parameters.AddWithValue("@Precio", usr.Precio);
                comando.Parameters.AddWithValue("@Fecha_ingreso", usr.Fecha_ingreso);
                comando.Parameters.AddWithValue("@Disponible", usr.Disponible);

                MessageBox.Show("vehiculo actualizado");

                conex.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception){}

              MessageBox.Show("error al actualizar ");


            conex.Close();
            }
        }

    }
