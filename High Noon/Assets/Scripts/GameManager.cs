using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreenObj;
    [SerializeField] private WinScreenUI _winScreen;
    
    public enum GameState
    {
        Countdown,
        Gameplay,
        WinScreen
    }

    private GameState _currentState;
    public GameState CurrentState
    {
        get { return _currentState;{} }
        
    }

    public static GameManager Instance;

    public WinData WinData{ get; private set; }
    
    private void Awake()
    {     
        if (Instance != null)
        {
            //Destroy(this);
            //return;
        }

        Instance = this;
        _currentState = GameState.Countdown;
        CountdownSystem.Countdown.OnCountdownDone += AfterCountdown;
    }

    private void Start()
    {
        _winScreenObj.SetActive(false);
    }
   
    private void AfterCountdown()
    {
        _currentState = GameState.Gameplay;
    }

    public void GameWon(Player p)
    {

        _currentState = GameState.WinScreen;
        _winScreen.UpdateUI(new WinData(p.name, p.ID));
        _winScreenObj.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

public struct WinData
{
    public string name;
    public int nr;

    public WinData(string name, int nr)
    {
        this.name = name;
        this.nr = nr;
    }
}
