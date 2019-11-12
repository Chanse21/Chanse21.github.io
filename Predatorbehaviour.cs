using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predatorbehaviour : MonoBehaviour {
		Rigidbody predRB;
		public Transform prey;
		public float forceAmt;
	    public float distThresh = 3f;
	    public AudioSource eatSource;

		void Start () {
			predRB = GetComponent<Rigidbody>();
		eatSource = GetComponent<AudioSource> ();
		}

		void Update ()
	{
		Vector3 preyDirection = Vector3.Normalize (prey.position - transform.position);

		if (Vector3.Distance (prey.position, transform.position) <= distThresh) {
			predRB.AddForce (preyDirection * forceAmt);
		
		}
	}

	void OnCollisionEnter (Collision col)
	{  
		//we compare the transform of the thing that collided with us to the predator
		if (col.gameObject.CompareTag ("Prey")) {
			eatSource.Play ();
			Destroy (col.gameObject);

		}
	}
}