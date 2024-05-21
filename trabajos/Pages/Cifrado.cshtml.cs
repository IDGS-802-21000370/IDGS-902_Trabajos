using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text;

namespace Tareas.Pages
{
    public class cifrado : PageModel
    {
        [BindProperty]
        public string msj { get; set; }
        public string resultado { get; set; }

        // Definir una lista que contenga todas las letras del alfabeto excluyendo la 'W'
        private List<char> alfabeto = new List<char>
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'X', 'Y', 'Z'
        };


        public void OnPost(string action)
        {
            if (!string.IsNullOrEmpty(msj))
            {
                if (action == "encode")
                {
                    resultado = cifradoCesar(msj, 3);
                }
                else if (action == "decode")
                {
                    resultado = cifradoCesar(msj, -3);
                }
            }
        }

        private string cifradoCesar(string input, int numero)
        {
            StringBuilder r = new StringBuilder();

            foreach (char letra in input.ToUpper())
            {

                if (alfabeto.Contains(letra)) // Verifica si el carácter está en la lista del alfabeto
                {
                    int index = (alfabeto.IndexOf(letra) + numero + alfabeto.Count) % alfabeto.Count;
                    r.Append(alfabeto[index]);
                }
                else
                {
                    r.Append(letra);
                }
            }

            return r.ToString();
        }
    }
}
