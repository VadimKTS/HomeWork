using System.Text.Json;
using System;
using Lesson13HomeWork.Task3;

namespace Lesson13HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------- Task 1 & 2  -------------------------------------

            var exampleDelegate = new MyDelegate();

            exampleDelegate.NotifyWeather += RandomWeather;

            MyDelegate.DelegateDay anonymous = delegate
            {
                exampleDelegate.DayCounter++;
                switch (exampleDelegate.DayCounter)
                {
                    case (int)DayOfTheWeek.Sunday:
                        return "Воскресенье";
                    case (int)DayOfTheWeek.Monday:
                        return "Понедельник";
                    case (int)DayOfTheWeek.Tuesday:
                        return "Вторник";
                    case (int)DayOfTheWeek.Wednesday:
                        return "Среда";
                    case (int)DayOfTheWeek.Thursday:
                        return "Четверг";
                    case (int)DayOfTheWeek.Friday:
                        return "Пятница";
                    case (int)DayOfTheWeek.Saturday:
                        return "Суббота";
                    default: return "";
                }
            };


            for (int i = 0; i < 15; i++)
            {
                exampleDelegate.Show(anonymous());  // результат
            }

            string RandomWeather()
            {
                Random random = new Random();
                int value = random.Next(0, 5);
                Console.Write(" - ");

                switch (value)
                {
                    case (int)WeatherToday.Rain:
                        return "Дождь";
                    case (int)WeatherToday.Sun:
                        return "Солнечно";
                    case (int)WeatherToday.Fog:
                        return "Туман";
                    case (int)WeatherToday.Snow:
                        return "Снег";
                    case (int)WeatherToday.Cloudy:
                        return "Облачно";
                    default: return "";

                }
            }

            //--------------------------------------- Task 3  -------------------------------------

            Console.WriteLine("------------------------------------------------------------------------------");
            
            using (var fs = new FileStream("Lesson13HW.json", FileMode.OpenOrCreate))
            {
                SuperHero person = JsonSerializer.Deserialize<SuperHero>(fs);
                Console.WriteLine($"SquadName: {person?.squadName}  HomeTown: {person?.homeTown}");
                Console.WriteLine($"Formed: {person?.formed}  SecretBase: {person?.secretBase}");
                Console.WriteLine($"Active: {person?.active}  Members Name: {person?.members[0].name}");
                Console.WriteLine($"Members Age: {person?.members[0].age}  Members SecretIdentity: {person?.members[0].secretIdentity}");
                Console.WriteLine($"Members powers: {person?.members[0].powers[0]}, {person?.members[0].powers[1]}, {person?.members[0].powers[2]}"); 
            }








        }
    }
}