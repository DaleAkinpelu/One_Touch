using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public ScoreText scoreTextPlayer2, scoreTextPlayer1;
    public GameObject menuObject;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI volumeValueText;

    public System.Action onStartGame;

        public void UpdateScores( int scorePlayer1, int scorePlayer2)
    {
        scoreTextPlayer2.SetScore(scorePlayer1);
        scoreTextPlayer1.SetScore(scorePlayer2);
    }

    public void HighlightScoreText(int id)
    {
        if (id == 1)
        {
            scoreTextPlayer2.Highlight();
        }
        else if (id == 2)
        {
            scoreTextPlayer1.Highlight();
        }
    }

    public void OnStartGameButtonClicked()
    {
        menuObject.SetActive(false);
        onStartGame?.Invoke();
    }

    public void OnGameEnds(int winnerId)
    {
        menuObject.SetActive(true);
        winText.text = $"Player {winnerId} Wins!";
    }

    public void OnVolumeChanged(float value)
    {
        AudioListener.volume = value;
        volumeValueText.text = Mathf.RoundToInt(value * 100).ToString();
    }
    
}
