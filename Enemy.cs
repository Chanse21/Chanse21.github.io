using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	Rigidbody rb;
	Vector3 targetPos;
	public GameObject targetObj;
	public float thrustAmt = 10f;

	void Update () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		
	}

	void FixedUpdate (){
		targetPos = targetObj.transform.position;
		Vector3 direction = Vector3.Normalize(targetPos - transform.position);
    }
	void OnCollisionEnter(Collision colReport){
		if (colReport.gameObject == targetObj) 
		{
			Destroy (colReport.gameObject);

		}
	}
}