using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// InputHandler. class handles input connects the input to the players and calls player methods. 
/// </summary>
public class InputHandler : MonoBehaviour {
	[SerializeField]private byte playerNumber = 1;
	private MoveHorizontal mhScript;
	private Jump jScript;
	// Use this for initialization
	void Start () {
		mhScript = gameObject.GetComponent<MoveHorizontal>();
		jScript = gameObject.GetComponent<Jump>();	
	}	
	// Update is called once per frame
	void Update () {
			
		float hValue = Input.GetAxis("Horizontal"+playerNumber);
		float vValue = Input.GetAxis("Vertical"+playerNumber);
		//print(playerNumber + " : h : "+hValue+ " : v : "+ vValue);

		//Handle player methods
		mhScript.Input = hValue;
		jScript.Input = vValue;
	}
}
