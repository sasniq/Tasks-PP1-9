using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // 1. Конвертер температуры
        Console.WriteLine("1. Конвертер температуры");
        Console.WriteLine(CelsiusToFahrenheit(25));
        Console.WriteLine(FahrenheitToCelsius(77));
        Console.ReadLine();

        // 2. Перевод времени
        Console.WriteLine("2. Перевод времени");
        Console.WriteLine(To24HourFormat("02:30 PM"));
        Console.WriteLine(To12HourFormat("14:30"));
        Console.ReadLine();

        // 3. Калькулятор возраста
        Console.WriteLine("3. Калькулятор возраста");
        Console.WriteLine(CalculateAge(new DateTime(2005, 6, 16)));
        Console.ReadLine();

        // 4. Обратный отсчет
        Console.WriteLine("4. Обратный отсчет");
        Countdown(5);
        Console.ReadLine();

        // 5. Анализ текста
        Console.WriteLine("5. Анализ текста");
        AnalyzeText("Hello world! This is a test. New paragraph.\n\nAnother paragraph.");
        Console.ReadLine();

        // 6. Генератор паролей
        Console.WriteLine("6. Генератор паролей");
        Console.WriteLine(GeneratePassword(12));
        Console.ReadLine();

        // 7. Конвертер валют
        Console.WriteLine("7. Конвертер валют");
        Console.WriteLine(CurrencyConverter(100, 1.2)); // Пример курса: 1 USD = 1.2 EUR
        Console.ReadLine();

        // 8. Обработка данных о погоде
        Console.WriteLine("8. Обработка данных о погоде");
        double[] temperatures = { 15.5, 20.3, 18.0, 22.1, 19.5 };
        ProcessWeatherData(temperatures);
        Console.ReadLine();

        // 9. Простая система управления задачами
        Console.WriteLine("9. Простая система управления задачами");
        TaskManager();
        Console.ReadLine();

        
    }

    // 1. Конвертер температуры
    public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    // 2. Перевод времени
    public static string To24HourFormat(string time12)
    {
        return DateTime.Parse(time12).ToString("HH:mm");
    }

    public static string To12HourFormat(string time24)
    {
        return DateTime.Parse(time24).ToString("hh:mm tt");
    }

    // 3. Калькулятор возраста
    public static string CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int ageYears = today.Year - birthDate.Year;
        int ageMonths = today.Month - birthDate.Month;
        int ageDays = today.Day - birthDate.Day;

        if (ageDays < 0)
        {
            ageDays += DateTime.DaysInMonth(today.Year, today.Month - 1);
            ageMonths--;
        }

        if (ageMonths < 0)
        {
            ageMonths += 12;
            ageYears--;
        }

        return $"Возраст: {ageYears} лет, {ageMonths} месяцев, {ageDays} дней.";
    }

    // 4. Обратный отсчет
    public static void Countdown(int seconds)
    {
        while (seconds >= 0)
        {
            Console.WriteLine(seconds);
            System.Threading.Thread.Sleep(1000);
            seconds--;
        }
    }

    // 5. Анализ текста
    public static void AnalyzeText(string text)
    {
        int wordCount = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int sentenceCount = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int paragraphCount = text.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

        Console.WriteLine($"Слов: {wordCount}, Предложений: {sentenceCount}, Абзацев: {paragraphCount}");
    }

    // 6. Генератор паролей
    public static string GeneratePassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    // 7. Конвертер валют
    public static double CurrencyConverter(double amount, double exchangeRate)
    {
        return amount * exchangeRate;
    }

    // 8. Обработка данных о погоде
    public static void ProcessWeatherData(double[] temperatures)
    {
        double maxTemp = temperatures.Max();
        double minTemp = temperatures.Min();
        double avgTemp = temperatures.Average();

        Console.WriteLine($"Максимальная температура: {maxTemp}");
        Console.WriteLine($"Минимальная температура: {minTemp}");
        Console.WriteLine($"Средняя температура: {avgTemp}");
    }

    // 9. Простая система управления задачами
    public static void TaskManager()
    {
        List<string> tasks = new List<string>();
        while (true)
        {
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Просмотреть задачи");
            Console.WriteLine("4. Выход");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите задачу:");
                    tasks.Add(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Введите номер задачи для удаления:");
                    int taskNumber;
                    if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
                    {
                        tasks.RemoveAt(taskNumber - 1);
                    }
                    else
                    {
                        Console.WriteLine("Неверный номер задачи");
                    }
                    break;
                case "3":
                    Console.WriteLine("Список задач:");
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }
       
    
}
