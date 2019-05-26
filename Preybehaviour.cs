using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preybehaviour : MonoBehaviour {
		Rigidbody preyRB;
		public Transform pred;
		public float forceAmt;
	    public float distThresh;

		void Start () {
			preyRB = GetComponent<Rigidbody> ();
		}

		void Update () {
		Vector3 predDirection = Vector3.Normalize (transform.position - pred.position);
		preyRB.AddForce (predDirection * forceAmt);

		}

	void OnCollisionEnter(Collision col)
	{
		//we compare the transform of the thing that collided with us to the predator
		if (col.transform == pred){
			//if it is the same, do something
			Debug.Log("you hit me and you are a predator");

		}
	}

}