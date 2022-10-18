﻿using EmployeestSeedConsoleApp.Interfaces;

namespace EmployeestSeedConsoleApp.EntityFactories
{
    public sealed class PositionFactory : IDbEntityFactory<Position>
    {
        private static int EntitiesCounter = 0;

        public Position CreateEntity()
        {
            Position position = new Position();

            position.Id = GenerateId();
            position.Name = GenerateName();

            return position;
        }

        private int GenerateId()
        {
            return ++EntitiesCounter;
        }

        private string GenerateName()
        {
            return "TestName" + Convert.ToString(EntitiesCounter);
        }
    }
}
