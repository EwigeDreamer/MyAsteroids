using System;
using UnityEngine;

namespace Core
{
    public abstract class Mediator<T> : BaseMediator where T : BaseEntity
    {
        protected T m_Entity;

        public override Vector2 Position => m_Entity != null ? m_Entity.Movement.Position : default;
        public override float Rotation => m_Entity != null ? m_Entity.Movement.Rotation : default;

        public Mediator(T entity)
        {
            m_Entity = entity;
            entity.OnDestroy += CallOnDestroy;
        }
        public override void Dispose()
        {
            base.Dispose();
            m_Entity = null;
        }
    }
}