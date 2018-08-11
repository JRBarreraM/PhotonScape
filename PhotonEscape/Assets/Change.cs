using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour {
	public SpriteRenderer render;
	public BoxCollider2D boxCollider;
	private int RandColor;
	private int RandSize;
	private int RandBoxCollider;
	private float _speed;
	public GameObject BlackHole;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		boxCollider = GetComponent<BoxCollider2D>();

		RandColor = Random.Range (0, 4);
		RandSize = Random.Range (0, 4);
		RandBoxCollider = Random.Range (0, 4);
		_speed = Random.Range (1, 5);

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
			boxCollider.size = new Vector2(1f, 1f);
		} else if (RandSize == 1) {
			boxCollider.size = new Vector2(1.5f, 1.5f);
		} else if (RandSize == 2) {
			boxCollider.size = new Vector2(2f, 2f);
		} else if (RandSize == 3) {
			boxCollider.size = new Vector2(2.5f, 2.5f);
		}


		if (RandBoxCollider == 0) {
			boxCollider.size = new Vector3(1f, 1f, 1f);
		} else if (RandBoxCollider == 1) {
			boxCollider.size = new Vector3(1f, 1f, 1f);
		} else if (RandBoxCollider == 2) {
			boxCollider.size = new Vector3(1f, 1f, 1f);
		} else if (RandBoxCollider == 3) {
			boxCollider.size = new Vector3(1f, 1f, 1f);
		}
	}
		
	void FixedUpdate(){
		transform.position = Vector3.MoveTowards(transform.position,BlackHole.transform.position,_speed*Time.deltaTime);
	}

	void OnTrigger2D(Collider2D col) {
		if (col.gameObject.tag =="BlackHole"){
			Destroy(gameObject,2);
		}
	}
}