namespace Core
{
    public class Player : BaseEntity
    {
        private PlayerMovement m_Movement = new PlayerMovement();
        public override BaseMovement Movement => m_Movement;
        public PlayerMovement PlayerMovement => m_Movement;
        public override EntityKind Kind => EntityKind.Player;

        public override void Dispose()
        {
            base.Dispose();
            m_Movement = null;
        }
    }
}
