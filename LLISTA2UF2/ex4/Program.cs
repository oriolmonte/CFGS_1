namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entra una hora");
            Console.WriteLine($"{ReadTime()}");

        }
        public static string ReadTime()
        {
            bool result=false;
            string output = "";
            int date;
            int hora=0, min=0, seg = 0;

            while (!result)
            {
                try
                {
                    date = Convert.ToInt32(Console.ReadLine());
                    hora = date / 10000;
                    min = (date % 10000) / 100;
                    seg = date % 100;
                    if (!TimeValid(hora, min, seg)) throw new Exception($"Invalid Input {hora:00}:{min:00}:{seg:00} ");
                    else result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            output = $"Valid timestamp {hora:00}:{min:00}:{seg:00} ";
            return output;
        }
        public static bool TimeValid(int hora, int min, int seg)
        {
            bool result;

            if (hora < 24 && min < 60 && seg < 60)
            {
                result = true;
            }
            else
                result = false;

            return result;
        }

    }
}