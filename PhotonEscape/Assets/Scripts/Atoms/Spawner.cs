using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour {
	public GameObject[] Enemies;
	public Vector3 SpawnValues;
	public float SpawnMostWait;
	public float SpawnLeastWait;
	public int StartWait;
	//public bool stop;
	int RandEnemy;		

	private float SpawnWait;

	// Use this for initialization
	void Start () {
		StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
		SpawnWait = Random.Range (SpawnLeastWait,SpawnMostWait);
	}

	IEnumerator waitSpawner(){
		yield return new WaitForSeconds (StartWait);
		while (true) {
			RandEnemy = Random.Range (0,4);
			Vector3 SpawnPosition = new Vector3(SpawnValues.x,Random.Range(-SpawnValues.y,SpawnValues.y),0);
			Instantiate(Enemies[RandEnemy],SpawnPosition + transform.TransformPoint(0,0,0),gameObject.transform.rotation);
			yield return new WaitForSeconds(SpawnWait);

		}
	}
}
