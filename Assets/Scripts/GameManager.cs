using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameUI gameUI;

    public GameAudio gameAudio;
    public int scorePlayer1, scorePlayer2;

    public Action onResetGame;

    public int maxScore = 5;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            gameUI.onStartGame += OnStartGame;
        }
    }
    public void OnScoreZoneReached(int id)
    {

        if (id == 1)
        {
            scorePlayer1++;
        }
        else if (id == 2)
        {
            scorePlayer2++;
        }

        gameUI.UpdateScores(scorePlayer1, scorePlayer2);
        gameUI.HighlightScoreText(id);
        CheckWin();
    }

    private void CheckWin()
    {
        int winnerId = scorePlayer1 >= maxScore ? 1 : scorePlayer2 >= maxScore ? 2 : 0;
        if (winnerId != 0)
        {
            Debug.Log("GameManager: Player " + winnerId + " wins!");
            // Implement win logic here (e.g., display win screen, reset game, etc.)
            gameUI.OnGameEnds(winnerId);
            gameAudio.PlayWinSound();
        } else
        {
            onResetGame?.Invoke();
            gameAudio.PlayScoreSound();
            
        }
    }

    private void OnStartGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        gameUI.UpdateScores(scorePlayer1, scorePlayer2);
    }


}
