namespace Core
{
    public abstract class BaseEntity
    {
        public abstract BaseMovement Movement { get; }

        public virtual void Update(float delta_time)
        {
            Movement?.Update(delta_time);
        }
    }
}
