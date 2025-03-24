namespace Game.Scripts.Game_Manager
{
    public interface IGame
    {
        public bool IsGameRunning { get; set; }
        public void Win();
        public void Lost();
        public void GameOver();
    }
}