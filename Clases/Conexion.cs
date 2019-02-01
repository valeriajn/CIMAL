using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Cimal.Clases
{
   public  class Conexion
    {
        public OleDbConnection Conectar()
        {
            string cadena = "Provider=SQLNCLI11;Data Source=CORTANA\\UPSASQL;Persist Security Info=True;User ID=sa;Initial Catalog=Cimal ;Pwd=123;";
            // string cadena = "Provider=SQLNCLI11;Data Source=SERVER;Persist Security Info=True;User ID=CedimAdmin;Initial Catalog="+Program.DB+";Pwd=Cedim2016;";
            //string cadena = "Provider=SQLNCLI11;Data Source=DESKTOP-O6KUEE9\\CEDIM;Persist Security Info=True;User ID=sa;Initial Catalog=Cimal ;Pwd=123;";
            //string cadena = "Provider=SQLNCLI11;Data Source = 192.168.1.205;Persist Security Info=True;User ID=sa;Initial Catalog=" + Program.DB + ";Pwd=Sismeco2018;";
            OleDbConnection cone = new OleDbConnection(cadena);
            try
            {
                cone.Open();
                return cone;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return cone;
            }
        }
    }
}
