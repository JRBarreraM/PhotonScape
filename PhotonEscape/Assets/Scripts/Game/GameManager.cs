using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameStates {Menu,Playing,Dead};

public class GameManager : MonoBehaviour {
	
	public float parallaxSpeed;
	public RawImage background;
	public GameObject menu;
	public GameObject dead;
	public GameObject photon;
	public GameObject spawner;
	//public AudioManager music;
	public Text time;

	private bool usserAction;
	private int timeAlive;
	private int seconds = 1;

	public static GameStates gameStates = GameStates.Menu;

	void Start() {
		menu.SetActive (true);
		dead.SetActive (false);

		//music = GameObject.Find ("AudioManager").GetComponent<AudioManager> ();
	}

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);

		if (gameStates == GameStates.Menu) {
			//music.Play ("Menu");
			menu.SetActive (true);
			dead.SetActive (false);
			spawner.SetActive (false);

			if (usserAction) {
				dead.SetActive (false);
				gameStates = GameStates.Playing;
				menu.SetActive (false);
			}
			Parallax ();
		}

		if (gameStates == GameStates.Playing) {
			Parallax ();
			InvokeRepeating("IncreaseTime",0f,Time.deltaTime);
			//Spawner.stop = false;
			menu.SetActive (false);
			dead.SetActive (false);
			spawner.SetActive (true);

		}

		if (gameStates == GameStates.Dead) {
			Invoke("DeadMenu",0.5f);

			if (usserAction && dead.activeSelf == true) {
				gameStates = GameStates.Menu;
				SceneManager.LoadScene ("MainScene");
			}
		}
	}

	void DeadMenu() {
		dead.SetActive (true);
		spawner.SetActive (false);
		seconds = 0;
		parallaxSpeed = 0f;
	}

	void SetTime(){
		time.text = timeAlive.ToString();
	}

	void IncreaseTime() {
		timeAlive += seconds;
	}

	void Parallax() {
		float speed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + speed,0f,1f,1f);
	}
}