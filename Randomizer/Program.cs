using System;

namespace Randomizer {
    class Program {
        static void Main(string[] args) {
            Random rand = new Random();
            
            for (int i = 0; i < 20; i++) {
                int x = rand.Next(0, 5);
                Console.WriteLine(x);
            }
        }
    }
}
