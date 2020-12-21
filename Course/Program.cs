using Course.Entities.Enums;
using System;
using Course.Entities;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do Departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("digite a data do contrato de trabalho : ");
            Console.Write("Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Nivel (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salario Base: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture );


            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);


            Console.Write("Quantos Contratos para esse Trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i<= n; i++)
            {
                Console.WriteLine($"Insira #{i}º Contrato de Trabalho: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor da Hora : ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com Mês e Ano no formato (MM/YYYY): ");
            string montAndYear = Console.ReadLine();
            int month = int.Parse(montAndYear.Substring(0, 2));
            int year = int.Parse(montAndYear.Substring(3));
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Renda Mensal é :"+ montAndYear + ": " + worker.Income(year, month));

        }
    }
}
