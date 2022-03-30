using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState _gameState;
    public int score1=0;
    public int score2=0;
    public Score ScoreP1;
    public Score ScoreP2;
    public Sprite p1Shape;
    public Sprite p2Shape;
    public int size;
    public Sprite[] shapes;
    private void Awake()
    {
        Instance = this;
        size = PlayerPrefs.GetInt("n") - 1;
        p1Shape = shapes[PlayerPrefs.GetInt("p1Shape")];
        p2Shape = shapes[PlayerPrefs.GetInt("p2Shape")];
        size = size * size;
        _gameState = GameState.player1;
        UpdateScore();
    }


    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState GetGameState => _gameState;
    public void SwitchPlayer()
    {
        if (_gameState == GameState.player1)
            _gameState = GameState.player2;
        else
            _gameState = GameState.player1;
    }


    public void UpdateScore()
    {
        ScoreP1.sc.text = "Score P1: " + score1;
        ScoreP2.sc.text = "Score P2: " + score2;
        if (score1 > size / 2)
        {
            PlayerPrefs.SetInt("Result", 1);
            SceneManager.LoadScene("End");
        }
        if (score2 > size / 2)
        {
            PlayerPrefs.SetInt("Result", 2);
            SceneManager.LoadScene("End");
        }

        if (score1+score2 == size)
        {
            PlayerPrefs.SetInt("Result", 0);
            SceneManager.LoadScene("End");
        }
    }
    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                SetGameState(GameState.player1);
                break;
            case GameState.player1:
                break;
            case GameState.player2:
                break;
            case GameState.end:
                break;
            default:
                break;
        }

    }

    public enum GameState
    {
        start,
        player1,
        player2,
        end
    }
}
