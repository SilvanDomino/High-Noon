using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
	private Rigidbody2D rb;
	[SerializeField]private float maxJumpForce = 100;
	[SerializeField]private byte maxJumps = 2;
	private byte numJumps = 0;

	float vel = 0;
	float iv = 0;
	float acc = -15f;
	float time = 0;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}	
	public void StartJump(float normalisedValue){

		print("start jump norm value "+ normalisedValue);

		if(numJumps < maxJumps){
			numJumps++;
			iv = normalisedValue * maxJumpForce;
			vel = 0;
			time = 0;
		}
	}

	
	// Update is called once per frame
	void FixedUpdate()
	{		
		//jumpbutton released
		//velocity = initialVelocity + accelleration * time
		time += Time.deltaTime;

		vel = iv + acc * time;

		print("vel : "+vel);
		Vector2 newPosition = rb.position + (Vector2)transform.up * 800;
		//print("newPosition " + newPosition );
		rb.MovePosition(newPosition);


	}
	public void Lands(){
		
	}
}
