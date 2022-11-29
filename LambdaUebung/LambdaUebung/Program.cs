class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Beispiel 1: Converter");
        LambdaTest
            .ForEach(LambdaTest
            .Converter(new decimal[] { -10, 0, 10, 20, 30 }, value => value + 273.15M), value => Console.WriteLine(value));

        Console.WriteLine("Beispiel 2: Filter");
        LambdaTest
            .ForEach(LambdaTest
            .Filter(LambdaTest
            .Converter(new decimal[] { -10, 0, 10, 20, 30 }, value => value + 273.15M), val => val < 273.15M), value => Console.WriteLine(value));

        Console.WriteLine("Beispiel 3: Division");
        Console.WriteLine(LambdaTest.ArithmeticOperation(2, 0, (x, y) => y == 0 ? 0 : x / y));
        Console.WriteLine(LambdaTest.ArithmeticOperation(2, 0, (x, y) => x / y, message => Console.Error.WriteLine(message)));

        Console.WriteLine("Beispiel 4: Callback Funktion");
        LambdaTest
            .RunCommand(() => 
                        {
                            Console.WriteLine("Hello World."); 
                            Console.WriteLine("Hello World again."); 
                        });

        Console.ReadLine();
    }
}