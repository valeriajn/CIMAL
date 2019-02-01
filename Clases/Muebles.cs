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
    public class Muebles : Conexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Image Image { get; set; }

        public int IDMuebleMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDMueble) + 1 from Mueble";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obtiene el sgte Id para registrar
        public bool GuardarMueble(string filefoto)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(filefoto,FileMode.Open,FileAccess.Read, FileShare.ReadWrite);
                ms.SetLength(fs.Length);
                fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
                byte[] arrImg = ms.GetBuffer();
                ms.Flush();
                ms.Close();
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Mueble (IDMueble,Nombre,Descripcion,Image,Estado) values (?,?,?,?,1)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@ID", Nombre);
                comm.Parameters.AddWithValue("@ID", Descripcion);
                comm.Parameters.Add("@Imagen",SqlDbType.VarBinary).Value = arrImg;
                

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
                comm.CommandText = "UPDATE Mueble SET Nombre = ?,Descripcion = ?,Image = ? where IDTablero = ?";
                comm.CommandType = CommandType.Text;
               
                comm.Parameters.AddWithValue("@ID", Nombre);
                comm.Parameters.AddWithValue("@ID", Descripcion);
                comm.Parameters.AddWithValue("@ID", Image);
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
                comm.CommandText = "Select * from Mueble where Estado = 1";

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
                comm.CommandText = "Select * from Mueble where Estado = 1 and IDMueble = ?";
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
