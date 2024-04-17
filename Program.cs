using System.IO;



namespace File_reading_question
{
    internal class Program
    {

       static  DataClass[] allMyData = new DataClass[100];

        static int counter = 0;
        static void Main(string[] args)
        {
            string path = @"..\..\..\FrenchMF.TXT";





            ReadFile(path);






        }

        static void ReadFile(string path)
        {


            try
            {
                using (StreamReader sr = File.OpenText(path))
                {


                    string inputString = sr.ReadLine();

                    while (inputString != null)
                    {
                        // Console.WriteLine(inputString);




                        string[] fields = inputString.Split(',');

                        if (IsValidDataString(inputString))
                        {

                            DataClass myData = GetDataFromSTring(inputString);
                            allMyData[counter] = myData;

                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Line");
                        }

                        inputString = sr.ReadLine();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///  this method returns true if the string has 5 fields with the final 4 being ints.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        static DataClass GetDataFromSTring(string input)
        {

            string[] fields = input.Split(',');

            DataClass myData = new DataClass(); 

            myData.Name = fields[0];
            myData.field1 = int.Parse(fields[1]);

            myData.field2 = int.Parse(fields[2]);
            myData.field3 = int.Parse(fields[3]);
            myData.field4 = int.Parse(fields[4]);

            return myData;

        }

        /// <summary>
        /// This method assumes the input string has 5 fields, the last 4 are integers .
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        static bool IsValidDataString(string input)
        {
            string[] fields = input.Split(',');
            int num;

            if (fields.Length < 5)
            {
                return false;
            }

            else if (!int.TryParse(fields[1], out num))
            {
                return false;
            }
            else if (!int.TryParse(fields[2], out num))
            {
                return false;
            }
            else if (!int.TryParse(fields[3], out num))
            {
                return false;
            }
            else if (!int.TryParse(fields[4], out num))
            {
                return false;
            }

            return true;
        }

    }
}
