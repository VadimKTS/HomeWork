namespace Lesson13HomeWork
{
    public class MyDelegate
    {
        private int dayCounter = 0;

        public int DayCounter 
        {
            get 
            { return dayCounter; }
            set 
            {
                if (dayCounter == 6)
                {
                    dayCounter = 0;
                }
                else { dayCounter = value; };
            }
        }

        public delegate string DelegateDay();
        public event DelegateDay NotifyWeather;

        public void Show(string a)
        {
            Console.Write($"Сегодня {a}");
            Console.WriteLine(NotifyWeather());
        }

    }
}