using System;
using System.IO;

namespace OOPproject4_18; 

// sort and search before 4-20
// Sort class maybe or 
class Program
{
    static void Main(string[] args)
    {
        StudentFiles myDataHandler = new StudentFiles("student.txt");
        Student[] myStudents = myDataHandler.GetAllStudents();
        StudentReport myReport = new StudentReport(myStudents);
        Utility myUtility = new Utility(myStudents);

        Menu menu = new Menu();
     
     int userInput = 0;
     while(userInput != 3)
     {
         userInput = menu.MainMenu();
         Routem(userInput, myReport, myUtility, myStudents);
     }

    /*   System.Console.WriteLine("after sort--------------------");
        myReport.PrintAllStudents();

        string searchVal = "Maykayla";
        int found = myUtility.Search(searchVal);
      dataHandler.Save(myStudents);


        myReport.ExcessGpa();

    */


    }

    static void Routem(int userInput, StudentReport myReport, Utility myUtility, Student[] myStudents)
    {
        if (userInput == 1)
        {
            SearchStudent(myUtility, myStudents);
        }
        else
        {
            if(userInput == 2)
            {
                ReportRoutem(myReport);
            }
            else
            {
                System.Console.WriteLine("GOODBYE");
            }
        }
    }

    static void ReportRoutem(StudentReport myReport)
    {
        Menu menu = new Menu();

        int userInput = 0;

        while(userInput != 4)
        {
            userInput = menu.ReportMenu();
            if(userInput == 1)
            {
                myReport.GpaRange();
            }
            else
            {
                if(userInput == 2)
                {
                    myReport.HoursByYear();
                }
                else
                {
                    if(userInput == 3)
                    {
                        myReport.ExcessGpa();
                    }
                }
            }
        }
    }

    static void SearchStudent(Utility myUtility, Student[] myStudents)
    {
        myUtility.Sort();
        System.Console.WriteLine("Enter the student you are looking for");
        int found = myUtility.Search(Console.ReadLine());

        if(found != -1)
        {
            System.Console.WriteLine(myStudents[found].ToString());
        }
        else
        {
            System.Console.WriteLine("student not on file");
        }
    }
}
