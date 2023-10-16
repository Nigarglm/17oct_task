namespace _17oct_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bakda ne qeder benzin var?");
            double fuel = double.Parse(Console.ReadLine());
            Console.WriteLine("Mashinin bakinin hecmi ne qederdir?");
            double fuelConsomption = double.Parse(Console.ReadLine());
            Console.WriteLine("Mashinin 100km-e ne qeder benzin istifade edir?");
            double tankCapacity = double.Parse(Console.ReadLine()); 

            Car car = new Car( fuel, fuelConsomption, tankCapacity);

            while (true)
            {
                Console.WriteLine("------MENU-----");
                Console.WriteLine("[1] Sur");
                Console.WriteLine("[2] Zapravkaya gir");
                Console.WriteLine("[3] Benzini goster");
                Console.WriteLine("[4] Getdiyimiz yolu goster");

                double choice = double.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Neche km yol getmek isteyirsiniz?");
                        double distance = double.Parse(Console.ReadLine());
                        bool canDrive = car.Drive(distance);
                        if (canDrive)
                        {
                            Console.WriteLine($"Qalan benzin miqdari: {car.ShowFuel}, Getdiyimiz yol: {car.ShowDistance} km");
                        }
                        else
                        {
                            Console.WriteLine("Bu yolu getmek mumkun deyil");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Socar-a xosh geldiniz. Ne qeqder benzin dolduraq?");
                        double fuelAmount = double.Parse(Console.ReadLine());
                        car.Refuel(fuelAmount);
                        break;

                    case 3:
                        car.ShowFuel();
                        break;

                    case 4:
                        car.ShowDistance();
                        break;
                    default:
                        Console.WriteLine("Yalnish sechim");
                        break;
                }
            }
        }
    }

    public class Car:IVehicle
    {
        public double MileAge { get; set; }
        public double Fuel { get; set; }
        public double FuelConsomption { get; set; }
        public double TankCapacity { get; set; }

        public Car(double fuel=20, double tankCapacity=40, double fuelConsumption=10)
        {
            Fuel=fuel;
            TankCapacity = tankCapacity;
            FuelConsomption = fuelConsumption;
            MileAge = 0;
        }

        public bool Drive(double kilometer)
        {
            double fuelNeeded = kilometer * FuelConsomption;
            if (fuelNeeded <= Fuel)
            {
                Fuel -= fuelNeeded;
                MileAge += kilometer;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Refuel(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Sehv daxil etmisiniz");
                return false;
            }
            else { return true; }
        }

        public void ShowFuel()
        {
            Console.WriteLine($"Qalan benzin miqdari: {Fuel}");
        }

        public void ShowDistance()
        {
            Console.WriteLine($"Getdiyiniz yol: {MileAge} km");
        }
    }

    public interface IVehicle: IDrivable, IRefuellable { }
  
    public interface IDrivable { }

    public interface IRefuellable { }
 
    public static class Colored
    {
        public static void Write(string text, ConsoleColor color=ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLine(string text, ConsoleColor color=ConsoleColor.White)
        {
            Console.ForegroundColor=color;
            Console.WriteLine(text);
            Console.ResetColor();
        } 
    }

}