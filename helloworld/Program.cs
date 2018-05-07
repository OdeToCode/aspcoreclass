using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

#if NET461
            Console.WriteLine("Hello from NET 461");
#else
            Console.WriteLine("Hello from .NET Core!");
#endif

            Console.ReadLine();
        }
    }
}
