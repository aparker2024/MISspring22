using System;

namespace class_2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your grade"");
            int grade = int.Parse(console.ReadLine());
            string letterGrade;
            if (letterGrade >= 90)
            {
                letterGrade = "A";
            }
            else if (letterGrade >= 80)
            {
                letterGrade = "B";
            }
            else if (letterGrade >= 70)
            {
                letterGrade = "C";
            }
            else
            {
                letterGrade = "NP";
            }

            return letterGrade;
        }
        static void DisplayMessage(string letterGrade)
        {
            if (letterGrade == "A")
            {
                Console.WriteLine("Great job");
            }
            else if (letterGrade == "B")
            {
                Console.WriteLine("Good job");
            }
            else if (letterGrade == "C")
            {
                Console.WriteLine("Nice job"); ;
            }


        }
    }