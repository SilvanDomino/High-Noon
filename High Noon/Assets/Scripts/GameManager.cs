using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public enum GameState
    {
        Countdown,
        Gameplay
    }

    private GameState _currentState;
    public GameState CurrentState
    {
        get { return _currentState;{} }
        
    }

    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        _currentState = GameState.Countdown;
        CountdownSystem.Countdown.OnCountdownDone += AfterCountdown;
    }

    private void AfterCountdown()
    {
        _currentState = GameState.Gameplay;
    }
}
