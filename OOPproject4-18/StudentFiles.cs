using System;
using System.IO;

namespace OOPproject4_18
{
    public class StudentFiles
    {
        private string fileName;

        public StudentFiles(string fileName)
        {
            this.fileName = fileName;
        }

        public Student[] GetAllStudents() // good exam streamReader/writer example
        {

            Student.SetCount(0);
            Student[] myStudents = new Student[50];
            StreamReader inFile = new StreamReader(fileName);
            string line = inFile.ReadLine();

         

            while (line != null)
            {
                string[] temp = line.Split("#");
                myStudents[Student.GetCount()] = new Student(temp[0], int.Parse(temp[1]), int.Parse(temp[2]), temp[3]);
                Student.IncCount();

                line = inFile.ReadLine();
            }
            
            inFile.Close();
            return myStudents;


        }
        public void Save(Student[] myStudents)
        {
            StreamWriter outFile = new StreamWriter(fileName);

            for(int i =0; i< Student.GetCount(); i++)
            {
                outFile.WriteLine(myStudents[i].ToFile());
            }

            outFile.Close();

        }
    }
}