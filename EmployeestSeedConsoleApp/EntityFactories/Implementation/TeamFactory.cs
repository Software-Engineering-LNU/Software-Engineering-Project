﻿using EmployeestSeedConsoleApp.Interfaces;

namespace EmployeestSeedConsoleApp.EntityFactories
{
    public sealed class TeamFactory : IDbEntityFactory<Team>
    {
        private static int entitiesCounter = 0;

        public Team CreateEntity()
        {
            Team team = new Team();

            team.Id = GenerateId();
            team.Name = GenerateName();
            team.ProjectId = GetRandomProjectId();

            return team;
        }

        private int GenerateId()
        {
            return ++entitiesCounter;
        }

        private string GenerateName()
        {
            return "Team " + Convert.ToString(entitiesCounter);
        }

        private int GetRandomProjectId()
        {
            using (var db = new EmployeestDbContext(Program.Configuration))
            {
                List<Project> users = db.Projects.Select(project => project).ToList();
                Random random = new Random();

                return users[random.Next(users.Count)].Id;
            }
        }
    }
}
