using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	private Button btn;
	public GameObject pauseMenu;
	public AudioSource audio;

	void Awake(){

		btn = GetComponent<Button> ();
	}
	void Start () {

		btn.onClick.AddListener(() => pauseGame());
	}

	void pauseGame(){
		if (audio.isPlaying) {
			audio.Pause();
		}
		pauseMenu.SetActive (true); //show pause menu
		Time.timeScale = 0f;
		gameObject.SetActive (false);

	}

	void Update(){

		if (Input.GetKeyUp (KeyCode.Escape)) {
			pauseGame();

		}

	}
	void OnApplicationPause(bool pauseStatus) {
		pauseGame ();
	}

}
