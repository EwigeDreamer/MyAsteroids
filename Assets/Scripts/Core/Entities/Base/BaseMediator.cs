using System;
using UnityEngine;

namespace Core
{
    public abstract class BaseMediator : IDisposable
    {
        public event Action OnDestroy;
        public  abstract Vector2 Position { get; }
        public  abstract float Rotation { get; }
        protected void CallOnDestroy() => OnDestroy?.Invoke();

        public virtual void Dispose()
        {
            OnDestroy = null;
        }
    }
}