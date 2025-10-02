using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var job1 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Tech Corp",
            _startYear = 2020,
            _endYear = 2023
        };

        var job2 = new Job
        {
            _jobTitle = "Web Developer",
            _company = "Web Solutions",
            _startYear = 2018,
            _endYear = 2020
        };

        var myResume = new Resume
        {
            _name = "John Doe"
        };
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}

public class Job
{
    public string _jobTitle { get; set; }
    public string _company  { get; set; }
    public int    _startYear { get; set; }
    public int    _endYear   { get; set; }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) — {_startYear}–{_endYear}");
    }
}

public class Resume
{
    public string _name { get; set; }
    public List<Job> _jobs { get; } = new List<Job>();

    public void Display()
    {
        Console.WriteLine(_name);
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}