using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public bool audioStarted = false;
	private AudioSource audio;
	public AudioClip lowTempoClip;
	public AudioClip highTempoClip;
	private GameOver gameOver;
	public GameObject pauseMenu;
	public GameObject saveMeMenu;
	public bool justPaused;
	float clipLength;
	private float clipTimer = 0f;
	private bool clipPlaying = false;
	public AudioClip gameClip;
	// Use this for initialization
	void Awake () {
		audio = GetComponent<AudioSource> ();
		gameOver = GetComponent<GameOver> ();
		clipLength = lowTempoClip.length;




	}

	void Start(){
		//audio.clip = lowTempoClip;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (audioStarted) {

			clipTimer+=Time.deltaTime;
			if(clipTimer>=clipLength && !gameOver.gameOver && !pauseMenu.activeInHierarchy &&!clipPlaying){
				audio.loop = true;
				audio.clip = highTempoClip;
				audio.Play();
				clipPlaying = true;

			}


		}*/
	}

	public void startAudio(){
		Debug.Log ("Starting audio");
		audioStarted = true;
		//audio.clip = lowTempoClip;
		audio.clip = gameClip;
		audio.Play ();


	}
}
