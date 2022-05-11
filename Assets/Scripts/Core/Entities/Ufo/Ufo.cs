namespace Core
{
    public class Ufo : BaseEntity
    {
        private UfoMovement m_Movement = new UfoMovement();
        public override BaseMovement Movement => m_Movement;
        public UfoMovement UfoMovement => m_Movement;
        public override EntityKind Kind => EntityKind.Ufo;

        public override void Dispose()
        {
            base.Dispose();
            m_Movement = null;
        }
    }
}
