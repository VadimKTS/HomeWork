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
                Console.WriteLine($"SquadName: {person?.SquadName}  HomeTown: {person?.HomeTown}");
                Console.WriteLine($"Formed: {person?.Formed}  SecretBase: {person?.SecretBase}");
                Console.WriteLine($"Active: {person?.Active}  Members Name: {person?.Members[0].Name}");
                Console.WriteLine($"Members Age: {person?.Members[0].Age}  Members SecretIdentity: {person?.Members[0].SecretIdentity}");
                Console.WriteLine($"Members powers: {person?.Members[0].Powers[0]}, {person?.Members[0].Powers[1]}, {person?.Members[0].Powers[2]}"); 
            }








        }
    }
}