namespace EmployeestSeed.EntityFactories.Interfaces
{
    public interface IDbEntityFactory<Entity>
    {
        Entity CreateEntity();
    }
}
