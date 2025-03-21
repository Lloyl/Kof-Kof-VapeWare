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
        NONE,
        BABY_CLOPE,
        MENU,
        SAUT_DE_HAIE
    }
    
    public static string GetSceneName(SceneName sceneName)
    {
        return sceneName switch
        {
            SceneName.BABY_CLOPE => "BabyClope",
            SceneName.MENU => "Menu",
            SceneName.SAUT_DE_HAIE => "SautDeHaie",
            _ => "None"
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