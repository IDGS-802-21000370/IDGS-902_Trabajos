using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tareas.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }

        [BindProperty]
        public double Altura { get; set; }

        public double IMC { get; set; }
        public string Clasificacion { get; set; }
        public string ImagenRecomendacion { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Peso > 0 && Altura > 0)
            {
                IMC = CalcularIMC(Peso, Altura);
                (Clasificacion, ImagenRecomendacion) = ObtenerClasificacionEImagen(IMC);
            }
        }

        private double CalcularIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }

        private (string, string) ObtenerClasificacionEImagen(double imc)
        {
            string clasificacion;
            string imagen;

            switch (imc)
            {
                case < 18:
                    clasificacion = "Peso Bajo";
                    imagen = "images/peso bajo.png";
                    break;
                case < 25:
                    clasificacion = "Peso Normal";
                    imagen = "images/peso normal.png";
                    break;
                case < 27:
                    clasificacion = "Sobrepeso";
                    imagen = "images/sobrepeso.png";
                    break;
                case < 30:
                    clasificacion = "Obesidad grado I";
                    imagen = "images/ob1.png";
                    break;
                case < 40:
                    clasificacion = "Obesidad grado II";
                    imagen = "images/ob2.png";
                    break;
                default:
                    clasificacion = "Obesidad grado III";
                    imagen = "images/ob3.png";
                    break;
            }

            return (clasificacion, imagen);
        }

    }
}
