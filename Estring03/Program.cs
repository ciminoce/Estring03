using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Estring03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool error;
            string frase = "";
            string letra = "";
            IngresarFrase(ref frase);
            IngresarLetra(ref letra);
            AnalizarFrase(frase, letra);

            Console.ReadLine();
        }

        private static void AnalizarFrase(string frase, string letra)
        {
            int vecesQueAparece = frase.Count(c => c == letra[0]);
            Console.WriteLine(frase.Contains(letra) ? $"{frase} tiene al menos una letra {letra}": $"{frase} no tiene una letra {letra}");

            if (vecesQueAparece>0)
            {
                Console.WriteLine(vecesQueAparece > 1 ? $"Aparece {vecesQueAparece} veces" : $"Aparece {vecesQueAparece} vez");

                if (vecesQueAparece == 1)
                {
                    Console.WriteLine($"La única {letra} aparece en el lugar nro {frase.IndexOf(letra)}");
                    Console.WriteLine($"La primera {letra} aparece en el lugar nro {frase.IndexOf(letra)}");
                }
                else
                {
                    Console.WriteLine($"La primera {letra} aparece en el lugar nro {frase.IndexOf(letra)}");
                    Console.WriteLine($"La última {letra} aparece en el lugar nro {frase.LastIndexOf(letra)}");

                }

                Console.WriteLine(frase.Replace(letra, "$"));
                RemoverPalabras(frase, letra);
            }
        }

        private static void RemoverPalabras(string frase, string letra)
        {
            var palabras = frase.Split(' ');
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i].Contains(letra))
                {
                    frase=QuitarPalabra(frase, palabras[i]);
                }
            }

            Console.WriteLine(frase.Trim());
        }

        private static string QuitarPalabra(string frase, string palabra)
        {
            int indice = frase.IndexOf(palabra);
            int caracteres = palabra.Length;
            return frase.Remove(indice, caracteres);
        }

        private static void IngresarLetra(ref string letra)
        {
            bool error;
            do
            {
                error = false;
                Console.Write("Ingrese una letra:");
                letra = Console.ReadLine();
                if (!ValidarLetra(letra))
                {
                    Console.WriteLine("Letra no válida");
                    error = true;
                }

            } while (error);
        }

        private static bool ValidarLetra(string letra)
        {
            bool esValido = true;
            if (letra.Length>1)
            {
                esValido= false;
            }else if (!Char.IsLetter(letra[0]))
            {
                esValido= false;
            }

            return esValido;
        }


        private static void IngresarFrase(ref string frase)
        {
            bool error;
            do
            {
                error = false;
                Console.Write("Ingrese una frase:");
                frase = Console.ReadLine();
                if (!ValidarFrase(frase))
                {
                    Console.WriteLine("Frase no válida");
                    error = true;
                }
                
            } while (error);
        }

        private static bool ValidarFrase(string frase)
        {
            return Char.IsLetter(frase[0]) && frase.Any(char.IsSeparator);
        }
    }
}
