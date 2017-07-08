using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    private List<Player> _players;

    private void Awake()
    {
        Player.OnPlayerDeath += RemovePlayer;
        
        _players = new List<Player>();
    }
    
    private void Start()
    {
        var playersArray = GameObject.FindObjectsOfType<Player>();
        foreach (var p in playersArray)
        {
            _players.Add(p);
        }
    }

    private void RemovePlayer(Player p)
    {
        if (_players.Contains(p))
            _players.Remove(p);

        if (_players.Count == 1)
            GameManager.Instance.GameWon(_players[0]);
    }
}
