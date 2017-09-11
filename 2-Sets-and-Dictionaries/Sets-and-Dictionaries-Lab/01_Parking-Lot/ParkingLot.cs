namespace _01_Parking_Lot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            HashSet<string> carNumbers = new HashSet<string>();

            while (input != "END")
            {
                // OR
                // string[] args = Regex.Split(input, ", ");
                string[] args = input
                    .Trim()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string direction = args[0];
                string carNumber = args[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (carNumbers.Count() > 0)
            {
                foreach (var carNumber in carNumbers.OrderBy(c => c))
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
