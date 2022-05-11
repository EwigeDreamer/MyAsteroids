using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core
{
    public abstract class EntityLogic<T> : BaseEntityLogic where T : BaseEntity
    {
        protected List<T> m_Entities = new List<T>();

        private ReadOnlyCollection<T> m_EntitiesRO = null;
        public ReadOnlyCollection<T> Entities => m_EntitiesRO ?? (m_EntitiesRO = new ReadOnlyCollection<T>(m_Entities));

        public override void Update(float delta_time)
        {
            for (int i = 0; i < m_Entities.Count; ++i)
            {
                m_Entities[i].Update(delta_time);
            }
        }

        public virtual void Register(T entity)
        {
            if (entity == null) return;
            if (m_Entities.Contains(entity)) return;
            m_Entities.Add(entity);
            CallOnRegister(entity);
        }

        public virtual void UnRegister(T entity)
        {
            if (entity == null) return;
            if (!m_Entities.Contains(entity)) return;
            CallOnUnregister(entity);
            m_Entities.Remove(entity);
        }

        public override void Dispose()
        {
            base.Dispose();
            
            foreach (var entity in m_Entities)
            {
                entity.Dispose();
            }

            m_Entities.Clear();
        }
    }
}