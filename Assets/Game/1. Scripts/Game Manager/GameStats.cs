using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private int   gameDifficulty = 1;
    [SerializeField] private float miniGamesTimer = 1f;
    [SerializeField] private int   playerLifes    = 4;
    [SerializeField] private int   gameScore;
    [SerializeField] private bool  isMiniGameWinned = true;

    [SerializeField] private List<MiniGame> miniGamesList;

    [System.Serializable]
    public struct MiniGame
    {
        public SceneName   name;
        public string      message;
        public Interaction interaction;
        public bool        landscapeMode;

        public override string ToString()
        {
            return name + " - " + message + " - " + interaction;
        }
    }

    public enum SceneName
    {
        None,
        BabyClope,
        Menu,
        SautDeHaie,
    }

    public enum Interaction
    {
        Tap,
        MultiTap,
        Drag,
        Rug
    }

    public static GameStats Instance { private set; get; }
    public float          timer      { get; set; }
    public bool           Win        { get; set; }
    public int            lifes      { get; set; }
    public int            score      { get; set; }
    public List<MiniGame> miniGames  => miniGamesList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            lifes    = playerLifes;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
    }
}