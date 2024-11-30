namespace Understanding_OOP_With;

internal static class Program
{
    private static void Main()
    {
        var internationalPizzaDay24 = new DateTime(2024, 12 , 4);
        Console.WriteLine($"Year is {internationalPizzaDay24.Year}" );
        Console.WriteLine($"Month is {internationalPizzaDay24.Month}");
        Console.WriteLine($"Day is {internationalPizzaDay24.Day}");
        Console.WriteLine($"Day of the week is {internationalPizzaDay24.DayOfWeek}");

        var internationalPizzaDay25 = internationalPizzaDay24.AddYears(1);
        
        Console.WriteLine($"Year is {internationalPizzaDay25.Year}" );
        Console.WriteLine($"Month is {internationalPizzaDay25.Month}");
        Console.WriteLine($"Day is {internationalPizzaDay25.Day}");
        Console.WriteLine($"Day of the week is {internationalPizzaDay25.DayOfWeek}");
    }
}