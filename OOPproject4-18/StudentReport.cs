namespace OOPproject4_18
{
    public class StudentReport
    {
        private Student[] myStudents;

        public StudentReport(Student[] myStudents)
        {
            this.myStudents = myStudents;
        }

        public void PrintAllStudents()
        {
            for(int i = 0; i < Student.GetCount(); i++)
            {
                System.Console.WriteLine(myStudents[i].ToString());
            }

        }
        public void ExcessGpa() // combination report
        {
            System.Console.WriteLine("excess Gpa report");
            for(int i = 0; i < Student.GetCount() - 1; i++)
            {
                for(int j = i + 1; j < Student.GetCount(); j++)
                {
                    double gpa1 = 0.0;
                    double gpa2 = 0.0;

                    gpa1= myStudents[i].GetQualityPoints() / myStudents[i].GetCreditHours();
                    gpa2= myStudents[j].GetQualityPoints() / myStudents[j].GetCreditHours();

                    double avgGpa = (gpa1 + gpa2) / 2;

                    if(avgGpa >= 0)
                    {
                         System.Console.WriteLine(myStudents[i].GetName() + "\t" + myStudents[j].GetName() + "\t" + avgGpa);
                    }
                }
            }
        }

        public void GpaRange()
        {
                Utility myUtility = new Utility(myStudents);
                myUtility.Sort("year");
                System.Console.WriteLine("Gpa range report");


                int min = 0;
                int max = 0;
                string currYear = myStudents[0].GetClassName();
                


            for(int i = 1; i < Student.GetCount(); i++)
            {
               if(myStudents[i].GetClassName() == currYear)
               {

                   double currMinGpa = 0.0;
                   double currMaxGpa = 0.0;
                   double newGpa = 0.0;
                   currMinGpa = myStudents[min].GetQualityPoints() / myStudents[min].GetCreditHours();
                   currMaxGpa = myStudents[max].GetQualityPoints() / myStudents[max].GetCreditHours();
                   newGpa = myStudents[i].GetQualityPoints() / myStudents[i].GetCreditHours();

                   if(newGpa < currMinGpa)
                   {
                       min = i;
                   }
                   if(newGpa > currMaxGpa )
                   {
                       max = i;
                   
                }
                else
                {
                    ProcessBreak(ref currYear, ref min, ref max, i);
                }
               }

                 ProcessBreak(ref currYear, ref min, ref max, 0);
            }
        }
             private void ProcessBreak(ref string currYear, ref int min, ref int max, int i) // processs break
               {
                   double minGpa = 0.0;
                   minGpa = myStudents[min].GetQualityPoints() / myStudents[min].GetCreditHours();

                   double maxGpa = 0.0;
                   maxGpa = myStudents[max].GetQualityPoints() / myStudents[max].GetCreditHours();
                   double range = maxGpa - minGpa;
                   System.Console.WriteLine($"{currYear} range: \t {range}");

                   min = i;
                   max = i;
                   currYear = myStudents[i].GetClassName();
               }

               public void HoursByYear()
               {
                   Utility myUtility = new Utility(myStudents);
                   myUtility.Sort("year");
                   System.Console.WriteLine("Hours by Year Report");

                   int sum = myStudents[0].GetCreditHours();
                   int count = 1;
                   string currYear = myStudents[0].GetClassName();
                   System.Console.WriteLine(myStudents[0].GetName() + " : " + myStudents[0].GetCreditHours());

                   for(int i = 1; i < Student.GetCount(); i++)
                   {
                       if(myStudents[i].GetClassName() == currYear)
                       {
                           sum = sum + myStudents[i].GetCreditHours();
                           count++;
                           System.Console.WriteLine(myStudents[i].GetName() + " : " + myStudents[i].GetCreditHours());
                       }
                       else
                       {
                           ProcessHoursBreak(ref currYear, ref sum, ref count, i);
                           System.Console.WriteLine(myStudents[i].GetName() + " : " + myStudents[i].GetCreditHours());
                       }
                   }

                    ProcessHoursBreak(ref currYear, ref sum, ref count, 0);
               }
        
            private void ProcessHoursBreak(ref string currYear, ref int sum, ref int count, int i )
            {
                double avg = 0.0;
                avg = sum / count;
                System.Console.WriteLine($"{currYear} avg : {avg}");

                sum = myStudents[i].GetCreditHours();
                count = 1;
                currYear = myStudents[i].GetClassName();
            }
    }
}