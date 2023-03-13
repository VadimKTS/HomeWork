namespace Lesson13HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------- Task 1 -------------------------------------

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
                    default: return "Воскресенье";
                }
            };


            for (int i = 0; i < 15; i++)
            {
                exampleDelegate.Show(anonymous());
            }

            string RandomWeather()
            {
                Random random = new Random();
                int value = random.Next(0, 5);

                switch (value)
                {
                    case (int)WeatherToday.Rain:
                        return " - Дождь";
                    case (int)WeatherToday.Sun:
                        return " - Солнечно";
                    case (int)WeatherToday.Fog:
                        return " - Туман";
                    case (int)WeatherToday.Snow:
                        return " - Снег";
                    case (int)WeatherToday.Cloudy:
                        return " - Облачно";
                    default: return "";

                }
            }


        }
    }
}