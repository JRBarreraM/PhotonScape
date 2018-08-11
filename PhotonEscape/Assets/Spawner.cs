using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour {
	public GameObject[] Enemies;
	public Vector3 SpawnValues;
	public float SpawnWait;
	public float SpawnMostWait;
	public float SpawnLeastWait;
	public int StartWait;
	public bool stop;
	int RandEnemy;
//	SpriteRenderer render;
		

	// Use this for initialization
	void Start () {
		StartCoroutine(waitSpawner());
	//	render = gameObject.GetComponent(SpriteRenderer);
	}
	
	// Update is called once per frame
	void Update () {
		SpawnWait = Random.Range (SpawnLeastWait,SpawnMostWait);
	}

	IEnumerator waitSpawner(){
		yield return new WaitForSeconds (StartWait);
		while (!stop) {
			RandEnemy = Random.Range (0,4);
			Vector3 SpawnPosition = new Vector3(0.9f,Random.Range(-SpawnValues.y,SpawnValues.y),0);
			render.color = new Color(0f, 0f, 0f, 1f); // Set to opaque black
			Instantiate(Enemies[RandEnemy],SpawnPosition + transform.TransformPoint(0,0,0),gameObject.transform.rotation);
			yield return new WaitForSeconds(SpawnWait);

		}
	}
}
