using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAI : MonoBehaviour {

	public Transform[] Partolpoints;
	public float speed;
	Transform currentPartolpoint;
	int currentPartolIndex;

	// Use this for initialization
	void Start () {
		currentPartolIndex = 0;
		currentPartolpoint = Partolpoints [currentPartolIndex];
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * Time.deltaTime * speed);
		//Chech to see if we have reached the patrol point
		if (Vector3.Distance (transform.position, currentPartolpoint.position) < .1f) {
			//we have reached the patrol point 
			if (currentPartolIndex + 1 < Partolpoints.Length) {
				currentPartolIndex++;
			} else {
				currentPartolIndex = 0;
			}
			currentPartolpoint = Partolpoints [currentPartolIndex];
		}
	
		Vector3 patrolPointDir = currentPartolpoint.position - transform.position;
		float angle = Mathf.Atan2 (patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;

		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90f);
	}
	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Game Over");
			Destroy (coll.gameObject);
			Debug.Log ("Player Mati");
		}
	}
}
