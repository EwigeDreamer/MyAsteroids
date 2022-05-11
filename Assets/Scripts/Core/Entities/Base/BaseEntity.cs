using System;

namespace Core
{
    public abstract class BaseEntity : IDisposable
    {
        public event Action OnDestroy;
        public abstract BaseMovement Movement { get; }
        public abstract EntityKind Kind { get; }

        public virtual void Update(float delta_time)
        {
            Movement?.Update(delta_time);
        }

        public void Destroy()
        {
            OnDestroy?.Invoke();
        }

        public virtual void Dispose()
        {
            OnDestroy = null;
        }
    }
}
