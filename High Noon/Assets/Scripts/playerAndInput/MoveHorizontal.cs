using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// MoveHorizonral moves the gameobject horizontally and flips the sprite
/// </summary>
public class MoveHorizontal : MonoBehaviour {

	private float speedNormal = 0f;
	[SerializeField]private float maxSpeed = 5f;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private bool flip = false;
	public float Input
	{
		set{ speedNormal = value; }
	}	
	// Use this for initialization
	void Start () 
	{
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		sr = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{	

		Vector2 newPosition = rb.position + (Vector2)transform.right * speedNormal * maxSpeed * Time.deltaTime;
		rb.MovePosition( newPosition );

		int direction = (int)Mathf.Round(speedNormal);
		flip = (direction >= 0) ? false : true;
		sr.flipX = flip;

	}

}
