﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float force;
	public Rigidbody2D rb;
	public GameObject center;
	public GameObject BlackHole;
	public Animator anim;

	private float distance;
	private float time;

	void Start () {
	}

	void FixedUpdate() {
		distance = (transform.position.x - center.transform.position.x) * (-1f);
		force = distance * 100f;

		time = Mathf.Clamp(distance/5f,0.8f,2.5f);

		TimeManager.AlterTime (1/time);
	}

	void Update () {
		bool forward = Input.GetKey (KeyCode.RightArrow);
		float actualForce = 0f;

		if (!forward) {
			actualForce = force;
		} 

		if (GameManager.gameStates == GameStates.Menu || GameManager.gameStates == GameStates.Dead){
			transform.position = transform.position;
		}else{
			rb.velocity = new Vector2 (Mathf.Clamp(Input.GetAxis("Horizontal"),0f,1f) * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
			rb.AddForce (Vector2.left * actualForce);
		}
	}

	void LoseGame() {
		if (GameManager.gameStates != GameStates.Dead) {
			anim.Play ("Faded");
		}

		GameManager.gameStates = GameStates.Dead;

		force = 0f;
		speed = 0f;
		transform.position = Vector3.MoveTowards (transform.position,BlackHole.transform.position,Time.deltaTime);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "BlackHole") {
			LoseGame ();
		}
	}
}
