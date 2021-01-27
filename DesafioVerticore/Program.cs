using System;

namespace DesafioVerticore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe sua data de Nascimento (dd/mm/aaaa):");

            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now;

            String calculaIdade = Program.CalcularIdade(dateOfBirth, today);

            Console.WriteLine(calculaIdade);
        }

        static string CalcularIdade(DateTime dateOfBirth, DateTime today)
        {

            string numYears = "", numMonths = "", numDays = "";

            if (today < dateOfBirth)
            {
                return "A data de nascimento informada é inválida";
            }

            var yearsAmount = today.Year - dateOfBirth.Year;

            if (today.Month < dateOfBirth.Month || (today.Month ==
            dateOfBirth.Month && today.Day < dateOfBirth.Day))
            {
                yearsAmount--;
            }

            var monthsAmount = CalcularMeses(dateOfBirth, today);

            var daysAmount = CalcularDias(dateOfBirth, today);

            if (yearsAmount > 1)
                numYears = yearsAmount + " anos, ";
            else if (yearsAmount == 1)
                numYears = yearsAmount + " ano, ";

            if (monthsAmount > 1)
                numMonths = monthsAmount + " meses e ";
            else if (monthsAmount == 1)
                numMonths = monthsAmount + " mês e ";

            if (daysAmount > 1)
                numDays = daysAmount + " dias.";
            else if (daysAmount == 1)
                numDays = daysAmount + " dia.";

            return numYears + numMonths + numDays;
        }

        static int CalcularDias(DateTime dateOfBirth, DateTime today)
        {
            int numDays = 0;

            if (today.Month != dateOfBirth.Month && today.Day > dateOfBirth.Day)
            {
                DateTime lastDay = new DateTime(today.Year, today.Month, dateOfBirth.Day);
                numDays = (today - lastDay).Days;
            }

            else if (today.Month != dateOfBirth.Month && today.Day < dateOfBirth.Day)
            {
                DateTime lastDay = new DateTime(today.Year, today.Month - 1, dateOfBirth.Day);
                numDays = (today - lastDay).Days;
            }

            else if (dateOfBirth.Month == today.Month)
            {
                DateTime lastDay = new DateTime(today.Year, today.Month, dateOfBirth.Day);
                numDays = (today - lastDay).Days;
            }

            return numDays;
        }

        static int CalcularMeses(DateTime dateOfBirth, DateTime today)
        {
            int numMonths = 0;

            if (today.Month > dateOfBirth.Month)
            {
                numMonths = today.Month - dateOfBirth.Month;
            }
            else if (today.Month < dateOfBirth.Month)
            {
                if (today.Day > dateOfBirth.Day)
                {
                    numMonths = (12 - dateOfBirth.Month) + (today.Month);
                }

                else if (today.Day < dateOfBirth.Day)
                {
                    numMonths = (12 - dateOfBirth.Month) + (today.Month - 1);
                }
            }
            return numMonths;
        }

    }
}
