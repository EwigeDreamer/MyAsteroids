using System;

namespace Core
{
    public abstract class BaseEntityLogic : IDisposable
    {
        public event Action<BaseEntity> OnRegister;
        public event Action<BaseEntity> OnUnregister;
        public abstract void Update(float delta_time);
        protected void CallOnRegister(BaseEntity entity) => OnRegister?.Invoke(entity);
        protected void CallOnUnregister(BaseEntity entity) => OnUnregister?.Invoke(entity);

        public virtual void Dispose()
        {
            OnRegister = null;
            OnUnregister = null;
        }
    }
}