using System;
using System.Collections.Generic;

namespace FitnessTracker
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Activity> Activities { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Activities = new List<Activity>();
        }
    }

    public class Activity
    {
        public DateTime Date { get; set; }
        public int StepsTaken { get; set; }
        public double DistanceTraveled { get; set; }
        public double CaloriesBurned { get; set; }
        public double ExerciseDuration { get; set; }

        public Activity(DateTime date, int stepsTaken, double distanceTraveled, double caloriesBurned, double exerciseDuration)
        {
            Date = date;
            StepsTaken = stepsTaken;
            DistanceTraveled = distanceTraveled;
            CaloriesBurned = caloriesBurned;
            ExerciseDuration = exerciseDuration;
        }
    }

    public class FitnessTracker
    {
        private List<User> users;

        public FitnessTracker()
        {
            users = new List<User>();
        }

        public void CreateUser(string name, string password)
        {
            users.Add(new User(name, password));
        }

        public void AddActivity(string name, DateTime date, int stepsTaken, double distanceTraveled, double caloriesBurned, double exerciseDuration)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    user.Activities.Add(new Activity(date, stepsTaken, distanceTraveled, caloriesBurned, exerciseDuration));
                    return;
                }
            }
        }

        public void ViewProgress(string name)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    Console.WriteLine("Daily Progress:");
                    foreach (var activity in user.Activities)
                    {
                        Console.WriteLine($"Date: {activity.Date}, Steps Taken: {activity.StepsTaken}, Distance Traveled: {activity.DistanceTraveled}, Calories Burned: {activity.CaloriesBurned}, Exercise Duration: {activity.ExerciseDuration}");
                    }

                    Console.WriteLine("Weekly Progress:");
                    // Implement weekly progress calculation

                    Console.WriteLine("Monthly Progress:");
                    // Implement monthly progress calculation
                    return;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fitnessTracker = new FitnessTracker();

            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Add Activity");
            Console.WriteLine("3. View Progress");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();
                    fitnessTracker.CreateUser(name, password);
                    break;
                case "2":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter date (yyyy-MM-dd): ");
                    var date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter steps taken: ");
                    var stepsTaken = int.Parse(Console.ReadLine());
                    Console.Write("Enter distance traveled: ");
                    var distanceTraveled = double.Parse(Console.ReadLine());
                    Console.Write("Enter calories burned: ");
                    var caloriesBurned = double.Parse(Console.ReadLine());
                    Console.Write("Enter exercise duration: ");
                    var exerciseDuration = double.Parse(Console.ReadLine());
                    fitnessTracker.AddActivity(name, date, stepsTaken, distanceTraveled, caloriesBurned, exerciseDuration);
                    break;
                case "3":
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    fitnessTracker.ViewProgress(name);
                    break;
            }
        }
    }
}
