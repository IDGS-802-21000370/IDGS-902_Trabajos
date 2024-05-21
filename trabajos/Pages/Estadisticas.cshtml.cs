using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tareas.Pages
{
    public class EstadisticasModel : PageModel
    {
        public List<int> Numeros { get; private set; }
        public int Suma { get; private set; }
        public double Promedio { get; private set; }
        public List<int> Moda { get; private set; }
        public double Mediana { get; private set; }

        public void OnGet()
        {
            var calculador = new CalculadorEstadisticas(20, 0, 100);
            Numeros = calculador.Numeros;
            Suma = calculador.Suma;
            Promedio = calculador.Promedio;
            Moda = calculador.Moda;
            Mediana = calculador.Mediana;
        }
    }

    public class CalculadorEstadisticas
    {
        public List<int> Numeros { get; private set; }
        public int Suma { get; private set; }
        public double Promedio { get; private set; }
        public List<int> Moda { get; private set; }
        public double Mediana { get; private set; }

        public CalculadorEstadisticas(int cantidad, int min, int max)
        {
            GenerarNumerosAleatorios(cantidad, min, max);
            CalcularEstadisticas();
        }

        private void GenerarNumerosAleatorios(int cantidad, int min, int max)
        {
            var random = new Random();
            Numeros = Enumerable.Range(0, cantidad).Select(_ => random.Next(min, max)).ToList();
        }

        private void CalcularEstadisticas()
        {
            Suma = Numeros.Sum();
            Promedio = Numeros.Average();
            CalcularModa();
            CalcularMediana();
        }

        private void CalcularModa()
        {
            Moda = Numeros.GroupBy(n => n)
                          .OrderByDescending(g => g.Count())
                          .Where(g => g.Count() == Numeros.GroupBy(n => n).Max(g => g.Count()))
                          .Select(g => g.Key)
                          .ToList();
        }

        private void CalcularMediana()
        {
            Numeros.Sort();
            int n = Numeros.Count;
            Mediana = (n % 2 == 0) ? (Numeros[n / 2 - 1] + Numeros[n / 2]) / 2.0 : Numeros[n / 2];
        }
    }
}
