using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Cimal
{
    public class Validar
    {
        /// <summary>
        /// Metodo para saber la cantidad de caracteres
        /// que introdujo el usuario en la cadena 
        /// los parametros May, Min, Num,Otros
        /// devuelven los resultados 
        /// </summary>
        /// <param name="cadena">La cadena que se analiza</param>
        /// <param name="may">Contador de letras Mayusculas</param>
        /// <param name="min">Contador de letras Minusculas</param>
        /// <param name="num">Contador de letras Numeros</param>
        /// <param name="otro">Contador de letras Otros</param>
        public void MValidacion(ref string cadena, ref int may, ref int min, ref int num, ref int otro)
        {

            for (int i = 0; i < cadena.Length; i++)
            {
                if (char.IsLower(cadena[i])) min++;
                else if (char.IsUpper(cadena[i])) may++;
                else if (char.IsNumber(cadena[i])) num++;
                else otro++;
            }
        }

        public void MPermitirNumeros(KeyPressEventArgs e)
        {
            ///Permite numero sin espacios
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        public void MPermitirNumerosDecimales  (KeyPressEventArgs e,TextBox text)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            ///Permite numero sin espacios
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                e.Handled = true;
            }
            text.Text = text.Text.Replace(".", ".");
            text.Select(text.Text.Length, 0);
        }

        // bool contadorEspacio = true;
        public void MPermitirLetras(KeyPressEventArgs e)
        {
            ///Permite Letras
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        public void MRestringirNumerosEspacio(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
        public void MRestringirEspacio(KeyPressEventArgs e)
        {///Permite letras sin espacio
            if (char.IsWhiteSpace(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        public void MPermitirLetrasUnSoloEspacio(KeyPressEventArgs e, TextBox text)
        {
            ///Permite Letras
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;

            }
            text.Text = text.Text.Replace("  ", " ");
            text.Select(text.Text.Length, 0);


        }

        public void MPermiteUnSoloEspacio(TextBox text)
        {///Permite un solo espacio
            ///programar este codigo en el evnto del textbox TextChanged
            text.Text = text.Text.Replace(" ", "");
            text.Select(text.Text.Length, 0);
        }

        public bool validacionEmail(string strEmail)
        {
            int sw = 0;
            for (int i = 0; i < strEmail.Length; i++)
            {
                char c = strEmail[i];
                if (c == '@')
                    sw++;
            }

            if (sw != 1)
            {
                MessageBox.Show("Error de validacion \n No es un ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;

            }
            else
                return false;
        }
    }
    
}
