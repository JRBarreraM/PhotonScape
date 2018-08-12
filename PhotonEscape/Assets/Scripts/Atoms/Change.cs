using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour {
	public SpriteRenderer render;
	private int RandColor;
	private int RandSize;
	public float maxSpeed;
	public float minSpeed;

	private float _speed;
	private GameObject BlackHole;

	void Start () {
		render = GetComponent<SpriteRenderer> ();

		RandColor = Random.Range (0, 4);
		RandSize = Random.Range (0, 4);
		_speed = Random.Range (minSpeed, maxSpeed);

		if (RandColor == 0) {
			render.color = new Color (1f, 0f, 1f, 1f); // Set to opaque magenta
		} else if (RandColor == 1) {
			render.color = new Color (0f, 1f, 0f, 1f); // Set to opaque green
		} else if (RandColor == 2) {
			render.color = new Color (0f, 1f, 1f, 1f); // Set to opaque cyan
		} else if (RandColor == 3) {
			render.color = new Color (1f, 0f, 0f, 1f); // Set to opaque red
		}

		if (RandSize == 0) {
			transform.localScale = new Vector3(1f, 1f,1f);
		} else if (RandSize == 1) {
			transform.localScale = new Vector3(1.25f, 1.25f,1f);
		} else if (RandSize == 2) {
			transform.localScale = new Vector3(1.5f, 1.5f,1f);
		} else if (RandSize == 3) {
			transform.localScale = new Vector3(1.75f, 1.75f,1f);
		}
	}
		
	void FixedUpdate(){
		transform.position = new Vector3 (transform.position.x - _speed * Time.deltaTime,transform.position.y,transform.position.z);
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}