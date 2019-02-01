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
    public class Persona : Conexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nit { get; set; }
        public string CI { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public int IDPersonaMax()
        {
            OleDbConnection conn = Conectar();
            OleDbCommand comm = new OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = "Select COUNT(IDPersona) + 1 from Persona";
            OleDbDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();

                return Convert.ToInt32(reader[0].ToString());
            }
            return -1;
        }//obtiene el sgte Id para registrar
        public bool GuardarCliente()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Cliente (IDCliente) values (?)";
                comm.CommandType = CommandType.Text;
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

        }//Guarda en la Tabla Clientes
        public bool GuardarPersonal()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Personal (IDPersonal) values (?)";
                comm.CommandType = CommandType.Text;
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

        }//Guarda en la Tabla Clientes
        public bool GuardarPersona()//Guarda en la Tabla Persona
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Persona (IDPersona,Nombre,Apellido,Nit,CI,Direccion,Telefono,Correo,Estado) values (?,?,?,?,?,?,?,?,1)";
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@ID", ID);
                comm.Parameters.AddWithValue("@Nombre",Nombre);
                comm.Parameters.AddWithValue("@Apellido", Apellido);
                comm.Parameters.AddWithValue("@Nit", Nit);
                comm.Parameters.AddWithValue("@CI", CI);
                comm.Parameters.AddWithValue("@Direccion", Direccion);
                comm.Parameters.AddWithValue("@Telefono", Telefono);
                comm.Parameters.AddWithValue("@Correo", Correo);
              

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
        public bool ActualizarPersona()//Actualiza en la Tabla Persona
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Persona SET Nombre = ?,Apellido = ?,Nit = ?,CI = ?,Direccion = ?,Telefono = ?, Correo = ? where IDPersona = ?";
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@Nombre", Nombre);
                comm.Parameters.AddWithValue("@Apellido", Apellido);
                comm.Parameters.AddWithValue("@Nit", Nit);
                comm.Parameters.AddWithValue("@CI", CI);
                comm.Parameters.AddWithValue("@Direccion", Direccion);
                comm.Parameters.AddWithValue("@Telefono", Telefono);
                comm.Parameters.AddWithValue("@Correo", Correo);
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
        public DataTable CargarPersonaCliente()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select IDPersona,Nombre,Apellido,Nit,CI,Direccion,Telefono,Correo from Persona T0, Cliente T1 where T0.IDPersona = T1.IDCliente and Estado = 1";
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
        public DataTable CargarPersonaPersonal()
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select IDPersona,Nombre,Apellido,Nit,CI,Direccion,Telefono,Correo from Persona T0, Personal T1 where T0.IDPersona = T1.IDPersonal and Estado = 1";
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
        public DataTable CargarPersonalid(int id)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select IDPersona,Nombre,Apellido,Nit,CI,Direccion,Telefono,Correo,Login,Password from Persona T0, Personal T1,Usuario T2 where T0.IDPersona = T1.IDPersonal and T0.IDPersona =t2.IDUsuario and Estado = 1 and IDPersona = ?";
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
        public DataTable CargarPersonaClienteid(int id)
        {
            try
            {
                OleDbConnection conn = Conectar();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = conn;
                comm.CommandText = "Select IDPersona,Nombre,Apellido,Nit,CI,Direccion,Telefono,Correo,Login,Password from Persona T0, Cliente T1,Usuario T2 where T0.IDPersona = T1.IDCliente and T0.IDPersona =t2.IDUsuario and Estado = 1 and IDPersona = ?";
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
