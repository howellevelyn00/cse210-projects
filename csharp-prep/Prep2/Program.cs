using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your Grade Percentage?");
        string gradeInput = Console.ReadLine();
        int gradePercentage = int.Parse(gradeInput);
        string letterGrade = "";
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
            if (gradePercentage >= 97)
            {
                letterGrade += "A+";
            }
            else if (gradePercentage <= 93)
            {
                letterGrade += "A-";
            }
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
            if (gradePercentage >= 87)
            {
                letterGrade += "B+";
            }
            else if (gradePercentage <= 83)
            {
                letterGrade += "B-";
            }
            else if (gradePercentage >= 70)
            {
                letterGrade = "C";
                if (gradePercentage >= 77)
                {
                    letterGrade += "C+";
                }
                else if (gradePercentage <= 73)
                {
                    letterGrade += "C-";
                }
            }
            else if (gradePercentage >= 60)
            {
                letterGrade = "D";
                if (gradePercentage >= 67)
                {
                    letterGrade += "D+";
                }
                else if (gradePercentage <= 63)
                {
                    letterGrade += "D-";
                }
            }
            else
            {
                letterGrade = "F";
            }
        }
        Console.WriteLine($"Your letter grade is: {letterGrade}");


    }
}