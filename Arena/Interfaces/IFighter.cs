namespace Arena.Interfaces
{
    public interface IFighter
    {
        int Attack();

        int Block(int damage);

        bool IsDead();
    }
}