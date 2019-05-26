 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class BoardMovement : MonoBehaviour {
	Vector3 playerPos;
	Vector3 startPos;
	public Transform End;
	//public Transform Hazard;
	GameObject [] Hazards;
	GameObject [] Blocks;
	public TextMesh playerMessage;
	// Use this for initialization
	AudioSource aud;
	public AudioClip moveClip;
	void Start () {
		playerPos = transform.position;
		startPos = playerPos;
		Hazards = GameObject.FindGameObjectsWithTag("Hazard");
		Blocks = GameObject.FindGameObjectsWithTag ("Block");
		aud = GetComponent<AudioSource>();
		
	}

	// Update is called once per frame
	void Update () {

		Vector3 newPos = playerPos;

		if (Input.GetKeyDown(KeyCode.D)) 

		{
			newPos = playerPos += transform.forward;
			aud.PlayOneShot (moveClip);
		
		}

		if (Input.GetKeyDown(KeyCode.A)) 
		{
			newPos = playerPos -= transform.forward;
			aud.PlayOneShot (moveClip);
		}

		if (Input.GetKeyDown(KeyCode.S)) 
		{
			newPos = playerPos += transform.right;
			aud.PlayOneShot (moveClip);
		}

		if (Input.GetKeyDown(KeyCode.W)) 
		{
			newPos = playerPos -= transform.right;
			aud.PlayOneShot (moveClip);
		}

		//******End*****
		if (playerPos.x == End.position.x &&
		    playerPos.z == End.position.z) 
		{
			newPos = playerPos += transform.up;
			playerMessage.text = "WE LIT!!!";
		}


		//*****BLOCKS/WALLS*****
		bool inABlock = false;

		for (int i = 0; i < Blocks.Length; i++) {

			if (newPos.x == Blocks [i].transform.position.x &&
			    newPos.z == Blocks [i].transform.position.z) {

				inABlock = true;
			}
		}


		if (!inABlock) {
			playerPos = newPos;
		}


		//******HAZARDS********
		//if (playerPos.x == Hazard.position.x &&
		        //playerPos.z == Hazard.position.z)
			for (int i = 0; i < Hazards.Length; i++) {
				if (playerPos.x == Hazards [i].transform.position.x &&
				        playerPos.z == Hazards[i].transform.position.z) 
				{
					//playerPos -= transform.up;
					playerPos = startPos;
				    playerMessage.text = "Try Again";
				}
			}
		    
		transform.position = playerPos;
     }
 }