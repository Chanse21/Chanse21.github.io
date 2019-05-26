using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {
	Rigidbody myRb;
	public float multiplier = 10f;
	int cylindersEaten = 0;
	public int eatThresh = 3;
	public AudioSource eatSource;
	// Use this for initialization
	void Start () {
		myRb = GetComponent<Rigidbody>();
		eatSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		//if the space bar is being newly pressed 
		if (Input.GetKey(KeyCode.UpArrow))
		{
			//add force to our rigidbody
			//in the direction (0,1,0) (up)
			//multiplied times a force amount
			myRb.AddForce(new Vector3(0f,0f,1f) * multiplier);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			myRb.AddForce(new Vector3(0f,0f,-1f) * multiplier);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			//add force to our rigidbody
			//in the direction (0,1,0) (up)
			//multiplied times a force amount
			myRb.AddForce(new Vector3(-1f, 0f, 0f) * multiplier);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			//add force to our rigidbody
			//in the direction (0,1,0) (up)
			//multiplied times a force amount
			myRb.AddForce(new Vector3(1f, 0f, 0f) * multiplier);
		}

	}

	void OnCollisionEnter(Collision col)
	{
		//we compare the transform of the thing that collided with us to the predator
		if (col.gameObject.CompareTag("Prey"))
		{
			//if it is the same, do something

			//add to our count of cylindersEaten
			cylindersEaten++;
			transform.localScale += new Vector3 (1,1,1);
			eatSource.Play ();
			Debug.Log ("Nyum nyum nyum");

			//destroy the prey
			Destroy(col.gameObject);
		}

		//if the tag is Predator
		if (col.gameObject.CompareTag("Predator"))
		{
			//then check if we have eaten enough prey
			if (cylindersEaten < eatThresh) //if we havent...
			{
				//destroy the gameObject that this script is attached to (the player)
				Destroy(gameObject);

			}

		}
	}
}