﻿using EmployeestSeedConsoleApp.Interfaces;

namespace EmployeestSeedConsoleApp.EntityFactories
{
    public sealed class TaskFactory : IDbEntityFactory<Task>
    {
        private static int entitiesCounter = 0;

        public Task CreateEntity()
        {
            Task task = new Task();

            task.Id = GenerateId();
            task.Name = GenerateName();
            task.Description = GenerateDescription();
            task.Estimation = GenerateEstimation();
            task.Status = GenerateStatus();
            task.StoryPoints = GenerateStoryPoints();
            task.TeamId = GetRandomTeamId();
            task.UserId = GetRandomUserId();

            return task;
        }

        private int GenerateId()
        {
            return ++entitiesCounter;
        }

        private string GenerateName()
        {
            return "Task name " + Convert.ToString(entitiesCounter);
        }

        private string GenerateDescription()
        {
            return "Description of the \'" + GenerateName() + "\' task";
        }

        private int GenerateEstimation()
        {
            Random random = new Random();

            return random.Next(2, 10);
        }

        private string GenerateStatus()
        {
            string[] status = { "Planned", "In progress", "On review", "Ready for review", "Done", "Closed" };
            Random random = new Random();

            return status[random.Next(status.Length)];
        }

        private int GenerateStoryPoints()
        {
            return GenerateEstimation();
        }

        private int GetRandomTeamId()
        {
            using (var db = new EmployeestDbContext(Program.Configuration))
            {
                List<Team> teams = db.Teams.Select(team => team).ToList();
                Random random = new Random();

                return teams[random.Next(teams.Count)].Id;
            }
        }

        private int GetRandomUserId()
        {
            using (var db = new EmployeestDbContext(Program.Configuration))
            {
                List<User> users = db.Users.Select(user => user).ToList();
                Random random = new Random();

                return users[random.Next(users.Count)].Id;
            }
        }
    }
}

