using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public string nama;

	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Pintu") {
			SceneManager.LoadScene (nama);
			Destroy (coll.gameObject);
			Debug.Log ("Player Mati");
		}
	}

}
