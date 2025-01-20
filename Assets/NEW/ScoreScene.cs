using TMPro;
using UnityEngine;

public class ScoreScene : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text scoreText;
    
    private void Start()
    {
        var score = GameStats.Instance.score;
        scoreText.text = score.ToString();
        
        resultText.text = GameStats.Instance.Win ? "GAGNÉ!" : "PERDU!";
    }
}