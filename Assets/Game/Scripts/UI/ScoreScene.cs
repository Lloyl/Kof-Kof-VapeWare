using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScene : MonoBehaviour
{
    [SerializeField] private Image    background;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text scoreText;

    public void ActivateScoreUI(bool win)
    {
        var score = GameStats.Instance.score;
        scoreText.text = $"Score: {score}";
        background.color = win
            ? Constants.WIN_COLOR
            : Constants.LOSE_COLOR;

        resultText.text = win ? "GAGNÉ!" : "PERDU!";
        StartCoroutine(ShowScore());
    }

    private IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        GameManager.Instance.NextGame();
    }
}