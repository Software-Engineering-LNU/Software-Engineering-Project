using EmployeestSeedConsoleApp.Interfaces;
using System.Text;

namespace EmployeestSeedConsoleApp.EntityFactories
{
    public sealed class UserFactory : IDbEntityFactory<User>
    {

        private static int EntitiesCounter = 0;
        private static int PhoneNumberLength = 9;

        public User CreateEntity()
        {
            User user = new User();

            user.Id = GenerateId();
            user.Email = GenerateEmail();
            user.Password = GeneratePassword();
            user.FullName = GenerateFullname();
            user.PhoneNumber = GeneratePhoneNumber();
            user.IsBusinessOwner = GenerateIsBusinessOwner();

            return user;
        }

        private int GenerateId()
        {
            return ++EntitiesCounter;
        }

        private string GenerateEmail()
        {
            return "testEmail" + Convert.ToString(EntitiesCounter) + "@gmail.com";
        }

        private string GeneratePassword()
        {
            return "Password" + Convert.ToString(EntitiesCounter);
        }

        private string GenerateFullname()
        {
            return "Name" + " Surname";
        }

        private string GeneratePhoneNumber()
        {
            string dictionaryString = "0123456789";
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < PhoneNumberLength; i++)
            {
                stringBuilder.Append(dictionaryString[random.Next(dictionaryString.Length)]);
            }

            return "+380" + stringBuilder.ToString();
        }

        private bool GenerateIsBusinessOwner()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 5);

            return randomNumber < 1;
        }
    }
}
