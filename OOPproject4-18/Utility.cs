namespace OOPproject4_18
{
    public class Utility
    {
        private Student[] myStudents;

        public Utility(Student[] myStudents)
        {
            this.myStudents = myStudents;
        }
        public void Sort(string sortField = "name")
        {
            for (int i = 0; i < Student.GetCount() - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < Student.GetCount(); j++)
                {
                    if (myStudents[j].CompareTo(myStudents[min], sortField) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(min, i);
                }
            }
        }
        private void Swap(int x, int y)
        {
            Student temp = myStudents[x];
            myStudents[x] = myStudents[y];
            myStudents[y] = temp;
        }

        public int Search(string searchVal)
        {
            int found = -1;
            for (int i = 0; i < Student.GetCount(); i++)
            {
                if(myStudents[i].CompareTo(searchVal) == 0)
                {
                    return i;
                }
            }
            return found;
        }

    }
}