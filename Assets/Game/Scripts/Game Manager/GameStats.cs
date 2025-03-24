using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] public int initialGamesCount = 5;

    [SerializeField] private List<MiniGame> miniGamesList;

    [System.Serializable]
    public struct MiniGame
    {
        public GameName    name;
        public string      message;
        public Interaction interaction;
        public int         time;

        public override string ToString()
        {
            return name + " - " + message + " - " + interaction + " - " + time;
        }
    }

    public enum GameName
    {
        BABY_CLOPE,
        SAUT_DE_HAIE
    }

    public static string GetSceneName(GameName gameName)
    {
        return gameName switch
        {
            GameName.BABY_CLOPE   => "BabyClope",
            GameName.SAUT_DE_HAIE => "SautDeHaie",
            _                     => null
        };
    }

    public enum Interaction
    {
        TAP,
        MULTI_TAP,
        DRAG,
        RUG
    }

    public static GameStats Instance { private set; get; }

    public int            score     { get; set; }
    public int            remaining { get; set; }
    
    public List<MiniGame> miniGames => miniGamesList;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        remaining = initialGamesCount;
    }
}