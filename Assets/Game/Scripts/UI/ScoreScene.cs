using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScene : MonoBehaviour
{
    [SerializeField] private Image    background;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image[]  animations;

    [SerializeField] private Sprite spriteWin;
    [SerializeField] private Sprite spriteLoose;

    public void ActivateScoreUI(bool win)
    {
        var score = GameStats.Instance.score;
        scoreText.text = $"Score: {score}";
        background.color = win
            ? Constants.WIN_COLOR
            : Constants.LOSE_COLOR;

        resultText.text = win ? "GAGNÉ!" : "PERDU!";

        foreach (var image in animations)
        {
            image.sprite = win
                ? spriteWin
                : spriteLoose;
        }

        StartCoroutine(QuitScore());
    }

    private static IEnumerator QuitScore()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.NextGame();
    }
}