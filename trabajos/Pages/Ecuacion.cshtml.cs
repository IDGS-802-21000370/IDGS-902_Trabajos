using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Tareas.Pages
{
    public class EcuacionModel : PageModel
    {
        [BindProperty]
        public double A { get; set; }

        [BindProperty]
        public double B { get; set; }

        [BindProperty]
        public double X { get; set; }

        [BindProperty]
        public double Y { get; set; }

        [BindProperty]
        public int N { get; set; }

        public double Resultado { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Resultado = CalcularBinomio(A, B, X, Y, N);
            }
        }

        private double CalcularBinomio(double a, double b, double x, double y, int n)
        {
            double suma = 0;
            for (int k = 0; k <= n; k++)
            {
                suma += CoeficienteBinomial(n, k) * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            }
            return suma;
        }

        private double CoeficienteBinomial(int n, int k)
        {
            double coeficiente = 1;
            for (int i = 1; i <= k; i++)
            {
                coeficiente *= (double)(n - i + 1) / i;
            }
            return coeficiente;
        }
    }
}
