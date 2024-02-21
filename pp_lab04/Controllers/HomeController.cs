using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using pp_lab04.Models;
using System;
using System.Diagnostics;

namespace pp_lab04.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TaskFirst()
        {
            return View();
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        public IActionResult TaskThree()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskFirst(double Num1, double Num2, double Num3, double Num4)
        {
            int countNegatives = (Num1 < 0 ? 1 : 0) + (Num2 < 0 ? 1 : 0) + (Num3 < 0 ? 1 : 0) + (Num4 < 0 ? 1 : 0);
            ViewBag.Result = $"Количество отрицательных чисел: {countNegatives}";
            return View();
        }

        [HttpPost]
        public IActionResult TaskSecond(int Size)
        {
            ViewBag.Size = Size;
            int[,] matrix = new int[Size, Size];

            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    matrix[i, j] = random.Next(100); 
                }
            }

            ViewBag.Matrix = matrix;

            int[] minInColumns = new int[Size];
            for (int j = 0; j < Size; j++)
            {
                int min = matrix[0, j];
                for (int i = 1; i < Size; i++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                minInColumns[j] = min;
            }
            ViewBag.MinInColumns = minInColumns;

            int[] maxInRows = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < Size; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                maxInRows[i] = max;
            }
            ViewBag.MaxInRows = maxInRows;

            return View();
        }


        [HttpPost]
        public IActionResult TaskThree(int Num)
        {

            int[,] matrix = new int[5, 5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = random.Next(100); 
                }
            }

            ViewBag.Matrix = matrix;

            double sum = 0;
            for (int j = 0; j < 5; j++)
            {
                int min = matrix[0, j];
                for (int i = 1; i < 5; i++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                sum += min;
            }

            ViewBag.Average = sum / 5.0;

            return View();
        }

    }
}