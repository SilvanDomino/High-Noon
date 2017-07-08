using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// InputHandler. class handles input connects the input to the players and calls player methods. 
/// </summary>
public class InputHandler : MonoBehaviour {
	[SerializeField]private byte playerNumber = 1;
	private MovePlayer mpScript;
//	private Jump jScript;
	private List<string> jumpKeys = new List<string>();

	// Use this for initialization
	void Start () {
		jumpKeys.Add("Fire1");
		jumpKeys.Add("Fire2");

		mpScript = gameObject.GetComponent<MovePlayer>();
		//jScript = gameObject.GetComponent<Jump>();	
	}	
	// Update is called once per frame
	void Update () {
			
		float hValue = Input.GetAxis("Horizontal"+playerNumber);
		float vValue = Input.GetAxis("Vertical"+playerNumber);
		//print(playerNumber + " : h : "+hValue+ " : v : "+ vValue);

		//Handle player methods
		mpScript.MoveInput = hValue;
	
	
		if(Input.GetButton(jumpKeys[playerNumber-1]))	
		{
		//	print("vValue"+ vValue);

			mpScript.Jump();
		}
		if(Input.GetButtonUp(jumpKeys[playerNumber-1])){

			//vValue = 0;
			mpScript.ResetJump();

		}	


	}

}
