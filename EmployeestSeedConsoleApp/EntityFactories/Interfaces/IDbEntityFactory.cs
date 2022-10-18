namespace EmployeestSeedConsoleApp.Interfaces
{
    public interface IDbEntityFactory<Entity>
    {
        Entity CreateEntity();
    }
}
