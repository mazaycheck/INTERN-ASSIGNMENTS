using System;
using System.Text;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string mystr = "Lorem Ipsum is simply dummy text of the" +
                " printing and typesetting industry." +
                " Lorem Ipsum has been the industry's standard" +
                " dummy text ever since the 1500s";
            
            Console.WriteLine(mystr.ToUpper() + "\n");
            var splitstring = mystr.Split(new char[] { ' ', '\'', '.' });
            foreach (var item in splitstring)
            {
                Console.WriteLine(item);
            }

            string joinedstring = String.Join(',', splitstring);

            Console.WriteLine("Split string\n" + joinedstring);
            Console.WriteLine("\n");
            string chisinaustring = mystr.Replace("Lorem Ipsum", "Chisinau");
            Console.WriteLine(chisinaustring  + "\n" );                        
            Console.WriteLine("Hello world".PadLeft(20, '*'));
            Console.WriteLine(@"           A lot of spaces");
            Console.WriteLine(@"           Trimmed lot of spaces".Trim());
            StringBuilder stringBuilder = new StringBuilder();
            int counti = 0;
            foreach (var item in splitstring)
            {
                if (item.Contains('i'))
                {
                    counti++;
                    stringBuilder.AppendLine($"{counti} : {item}");                    
                    stringBuilder.AppendLine(String.Format("{0} : {1}",counti,item));                    

                }
            }
            Console.WriteLine();
            Console.WriteLine($"{counti} words containg letter i : \n" + stringBuilder.ToString());
        }        
    }
}
