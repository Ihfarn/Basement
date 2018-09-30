using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {


	public GameObject pintubuka;
	public GameObject pintututup;
	// Use this for initialization
	void Start () {
		pintubuka.SetActive (true);
		pintututup.SetActive (false);
		Debug.Log (pintubuka);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {
			pintubuka.SetActive (false);
			pintututup.SetActive (true);
			Destroy (gameObject);
			Debug.Log ("a");
		}
	}
}
