using System;

namespace OOPproject4_18
{
    public class Student
    {
        private string name;

        private int creditHours;

        private int qualityPoints;

        private string className;

        private static int count;

   
        public Student(string name, int creditHours, int qualityPoints, string className)
        {
            this.name = name;
            this.creditHours = creditHours;
            this.qualityPoints = qualityPoints;
            this.className = className;
        }
      public void SetName(string temp)
        {
            name = temp;
        }
        public string GetName()
        {
            return name;
        }
  
      public void SetCreditHours(int temp)
        {
            creditHours = temp;
        }
        public int GetCreditHours()
        {
            return creditHours;
        }
  
   public void SetClassName(string temp)
        {
            className = temp;
        }
        public string GetClassName()
        {
            return className;
        }
     

        public int GetQualityPoints()
        {
            return qualityPoints;
        }
        public void SetQualityPoints(int temp)
        {
            qualityPoints = temp;
        }

        public static int GetCount()  // method are known as accessor or mutator; getter or setter 
        {
            return count;
        }

        public static void SetCount(int temp)
        {
            count = temp;
        }

        static public void IncCount()
        {
            count++;
        }

        public string ToString()
        {
            return name + "\t" + creditHours + "\t" + qualityPoints + "\t" + className;
        }
            public string ToFile()
        {
            return name + "#" + creditHours + "#" + qualityPoints + "#" + className;
        }
        public int CompareTo(Student student, string sortField) // compare two objects
        {
            if(sortField == "year")
            {

            return this.className.CompareTo(student.GetClassName());
            }
            return this.name.CompareTo(student.GetName());

        }
        public int CompareTo(string student) // compare two names
        {
            return this.name.CompareTo(name);

        }


    }
}