namespace App_Atelie.Model
{
    public interface IEntityType<TKey>
    {
        TKey Id { get; set; }
    }
}
