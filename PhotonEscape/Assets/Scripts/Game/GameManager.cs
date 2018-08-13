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
	public GameObject spawner;
	public GameObject light;
	public Text time;

	private bool usserAction;
	private float timeAlive;
	private bool usserQuit;

	public static GameStates gameStates = GameStates.Menu;

	void Start() {
		menu.SetActive (true);
		dead.SetActive (false);

	}

	void Update () {
		usserAction = Input.GetKeyDown (KeyCode.Return);
		usserQuit = Input.GetKeyDown ("q");


		if (gameStates == GameStates.Menu) {
			FindObjectOfType<AudioManager>().Stop ("Death");
			FindObjectOfType<AudioManager>().Play ("Menu");

			menu.SetActive (true);
			dead.SetActive (false);
			spawner.SetActive (false);
			light.SetActive (false);

			if (usserAction) {
				dead.SetActive (false);
				gameStates = GameStates.Playing;
				menu.SetActive (false);
			}

			if (usserQuit) {
				Debug.Log ("Quit!");
				Application.Quit ();
			}

			Parallax ();
		}

		if (gameStates == GameStates.Playing) {
			Parallax ();
			timeAlive += Time.deltaTime;

			light.SetActive (true);
			menu.SetActive (false);
			dead.SetActive (false);
			FindObjectOfType<AudioManager>().Stop ("Menu");
			FindObjectOfType<AudioManager>().Play ("InGame");

			spawner.SetActive (true);

		}

		if (gameStates == GameStates.Dead) {
			Destroy (light);
			Invoke("DeadMenu",0.3f);
			SetTime ();

			if (usserAction && dead.activeSelf == true) {
				gameStates = GameStates.Menu;
				SceneManager.LoadScene ("MainScene");
			}
		}
	}

	void DeadMenu() {
		FindObjectOfType<AudioManager>().Stop ("InGame");
		FindObjectOfType<AudioManager>().Play ("Death");
		dead.SetActive (true);
		spawner.SetActive (false);

		parallaxSpeed = 0f;
	}

	void SetTime(){
		time.text = (Mathf.RoundToInt(timeAlive)).ToString();
	}

	void Parallax() {
		float speed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + speed,0f,1f,1f);
	}
}