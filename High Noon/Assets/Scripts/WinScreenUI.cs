using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    public void UpdateUI(WinData data)
    {
        _text.text = data.name + " Won!";
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
           GameManager.Instance.ReloadScene();
    }
}
