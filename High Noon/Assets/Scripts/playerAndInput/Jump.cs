using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
	private float inputValue = 0;
	private Rigidbody2D rb;
	private float lastInputValue = 0;
	[SerializeField]private float maxJumpForce = 5;
	[SerializeField]private byte maxJumps = 2;
	private float currentJumpForce = 0;
	private byte numJumps = 0;


	public float Input
	{
		set{ inputValue = value; }
	}
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}	
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
		//jumpbutton released
		if(inputValue < lastInputValue){

			if(numJumps < maxJumps){
				rb.AddForce(Vector2.up * maxJumpForce * inputValue);
				numJumps++; 
			}
		}




		lastInputValue = inputValue;
	}
}
