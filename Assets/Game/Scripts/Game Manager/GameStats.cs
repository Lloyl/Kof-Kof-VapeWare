using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private int playerLife = 3;

    [SerializeField] private List<MiniGame> miniGamesList;

    [System.Serializable]
    public struct MiniGame
    {
        public SceneName   name;
        public string      message;
        public Interaction interaction;

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

    public int            life      { get; set; }
    public int            score     { get; set; }
    public int            remaining { get; set; }
    public List<MiniGame> miniGames => miniGamesList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            life     = playerLife;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
    }
}