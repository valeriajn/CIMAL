using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;
using System.Collections;

namespace Cimal.Clases
{
    public class Tablero :Conexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Color { get; set; }
        public string Dimensiones { get; set; }


        public int IDTableroMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDTablero) + 1 from Tablero";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obtiene el sgte Id para registrar
        public bool GuardarTablero()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Tablero (IDTablero,Nombre,Precio,Color,Dimensiones,Estado) values (?,?,?,?,?,1)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@ID", Nombre);
                comm.Parameters.AddWithValue("@ID", Precio);
                comm.Parameters.AddWithValue("@ID", Color);
                comm.Parameters.AddWithValue("@ID", Dimensiones);

                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return false;

            }

        }//Guarda en la Tabla Clientes
        public bool ActualizarTablero()//Actualiza en la Tabla Persona
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Tablero SET Nombre = ?,Precio = ?,Color = ?,Dimensiones = ? where IDTablero = ?";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@Nombre", Nombre);
                comm.Parameters.AddWithValue("@Precio", Precio);
                comm.Parameters.AddWithValue("@Color", Color);
                comm.Parameters.AddWithValue("@Dimensiones", Dimensiones);
                comm.Parameters.AddWithValue("@ID", ID);

                if (comm.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return false;

            }

        }
        public DataTable CargarTableros()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Tablero where Estado = 1";
               
                DataTable dtCargo = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtCargo);
                return dtCargo;
            }
            catch
            {
                return null;
            }
        }
        public DataTable CargarTablerosid(int id)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from Tablero where Estado = 1 and IDTablero = ?" ;
                comm.Parameters.AddWithValue("@ID", id);
                DataTable dtCargo = new DataTable();
                OleDbDataAdapter adap = new OleDbDataAdapter(comm);
                adap.Fill(dtCargo);
                return dtCargo;
            }
            catch
            {
                return null;
            }
        }
    }
}
