using System;

namespace DesafioVerticore
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe sua data de Nascimento (dd/mm/aaaa):");

            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Today;

            String calculaIdade = CalcularIdade(dateOfBirth, today);

            Console.WriteLine(calculaIdade);
        }

        public static string CalcularIdade(DateTime dateOfBirth, DateTime today)
        {
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

            return $"{yearsAmount} ano(s), {monthsAmount} mês(es) e {daysAmount} dia(s).";
        }

        public static int CalcularDias(DateTime dateOfBirth, DateTime today)
        {
            int numDays = 0;

            if (today.Month != dateOfBirth.Month && today.Day > dateOfBirth.Day)
            {
                DateTime lastDay = new DateTime(today.Year, today.Month, dateOfBirth.Day);
                numDays = (today - lastDay).Days;
            }

            else if (today.Month != dateOfBirth.Month && today.Day < dateOfBirth.Day)
            {
                DateTime lastDay = (!(DateTime.IsLeapYear(today.Year)) && today.Month == 3 && dateOfBirth.Day == 29)
                    ? new DateTime(today.Year, today.Month - 1, dateOfBirth.Day - 1)
                    : new DateTime(today.Year, today.Month - 1, dateOfBirth.Day);

                numDays = (today - lastDay).Days;
            }

            else if (dateOfBirth.Month == today.Month)
            {
                DateTime lastDay = new DateTime(today.Year, today.Month, dateOfBirth.Day);
                numDays = (today - lastDay).Days;
            }

            return numDays;
        }

        public static int CalcularMeses(DateTime dateOfBirth, DateTime today)
        {
            int numMonths = 0;

            if (today.Month > dateOfBirth.Month)
            {
                numMonths = today.Month - dateOfBirth.Month;
                if (dateOfBirth.Day > today.Day)
                {
                    numMonths--;
                }
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
