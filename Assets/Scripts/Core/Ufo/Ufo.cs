namespace Core
{
    public class Ufo : BaseEntity
    {
        private UfoMovement m_Movement = new UfoMovement();
        public override BaseMovement Movement => m_Movement;
        public UfoMovement UfoMovement => m_Movement;
    }
}
