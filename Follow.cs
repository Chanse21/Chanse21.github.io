using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public GameObject Player;
	public float movementSpeed = 4;


	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Player.transform);
		transform.position += transform.forward * movementSpeed * Time.deltaTime;
	}
}
