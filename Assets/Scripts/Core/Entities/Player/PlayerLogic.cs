namespace Core
{
    public class PlayerLogic : EntityLogic<Player>
    {
        
        public void CreatePlayer()
        {
            var player = GameHelper.CreatePlayer();
            Register(player);
        }
    }
}
