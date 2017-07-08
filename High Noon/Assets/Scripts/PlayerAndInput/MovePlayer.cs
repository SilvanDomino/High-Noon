using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// MoveHorizonral moves the gameobject horizontally and flips the sprite
/// </summary>
public class MovePlayer : MonoBehaviour {

	private float hNormal = 0f;//horizontal normalised movement value
	[SerializeField]private float maxHorizontalSpeed = 8f;//maximum horizontal speed
	[SerializeField]private float jumpForce = 30f;
	[SerializeField]private float maxJumpForce = 8f;
	[SerializeField]private float gravityAccelleration = -30f;
	[SerializeField]private float maxGravity = -8f;
	[SerializeField]private float rayLength = 1f;
	[SerializeField]private byte maxJumps = 2;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private bool flip = false;
	private byte count = 0;

	private byte numJumps = 0;
	private float iv = 0;
	private float vel = 0;
	private float time = 0;
	private bool landed = false;
	private bool start = false;
	private bool dropping = true;
	public void ResetJump()
	{
		if(numJumps < maxJumps-1){
			numJumps++;
			iv = 0;
		}
	}

	public float MoveInput
	{
		set{ hNormal = value; }
	}	
	// Use this for initialization
	void Start () 
	{
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		sr = this.gameObject.GetComponent<SpriteRenderer>();
	}

	public void Jump(float normalisedValue){

		if(!dropping){
			if(iv < maxJumpForce){
				iv = normalisedValue * jumpForce;
				vel = 0;
				time = 0;
				landed = false;
			}
		}
			
	}

	// Update is called once per frame
	void FixedUpdate()
	{			
		time += Time.deltaTime;

		if(!landed)vel = iv + gravityAccelleration * time;
		if(vel < maxGravity)vel = maxGravity;
		if(vel > maxJumpForce)vel = maxJumpForce;


		Vector2 hMove = (Vector2)transform.right * hNormal * maxHorizontalSpeed * Time.deltaTime;
		Vector2 vMove = (Vector2)transform.up * vel * Time.deltaTime;

		Vector2 newPosition = rb.position + hMove + vMove;
		//print("hMove"+hMove+"vMove"+vMove+"new position vector"+newPosition);	
		rb.MovePosition( newPosition );

		int direction = (int)Mathf.Round(hNormal);
		flip = (direction >= 0) ? false : true;
		sr.flipX = flip;
		//if(direction<0)direction=-1;
		//if(direction>=0)direction=1;
		//print(direction);
		//this.gameObject.transform.localScale.x = direction;


		if(vel <= 0)HandleFeetCollision();
		if(vel > 0)HandleHeadCollision();

	}
	private void HandleHeadCollision()
	{
		Debug.DrawRay(rb.position,Vector2.up * rayLength);
		RaycastHit2D hit = Physics2D.Raycast(rb.position,Vector2.up, rayLength);
		Collider2D coll = hit.collider;
		if(coll != null ){
			if(coll.gameObject.tag == "Collidable")
			{
				iv = 0;
				vel = 0;
				dropping = true;

			}
		}
	}
	private void HandleFeetCollision()
	{
		Debug.DrawRay(rb.position,Vector2.down * rayLength);
		RaycastHit2D hit = Physics2D.Raycast(rb.position,Vector2.down, rayLength);
		Collider2D coll = hit.collider;
		if(coll != null ){
			if(coll.gameObject.tag == "Collidable")
			{
				if(vel < 0){	
					
					Lands((Vector2)coll.transform.position + Vector2.up * coll.transform.localScale.y);
				}
				 

			}


		}else if(vel == 0){
			Drops();
		}

	}
	private void Lands(Vector2 position){
		landed = true;
		count=0;	
		vel = 0;
		iv = 0; 
		rb.MovePosition(position);
		numJumps = 0;
		dropping = false;
	}	
	public bool Landed
	{
		get{return landed;}

	}
	private void Drops()
	{
		landed = false;
	}
}
