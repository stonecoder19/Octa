using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resume : MonoBehaviour {

	// Use this for initialization
	private Button btn;
	public GameObject pauseMenu;
	public GameObject pauseButton;
	public GameObject countdownText;
	public GameObject resumeButton;
	public Freeze frozen;
	private AudioSource gameAudio;

	void Awake(){
		gameAudio = GetComponent<AudioSource> ();
		btn = resumeButton.GetComponent<Button> ();
	}
	void Start () {
		btn.onClick.AddListener(() => resumeGame());
	}

	public void resumeGame(){
	
		pauseMenu.SetActive (false); //hide pause menu
		StartCoroutine (getReady ()); //start countdown timer



	}

	void Update(){
		//check if escape/back button is pressed and check if pause menu is active
		if (Input.GetKeyUp (KeyCode.Escape) &&pauseMenu.activeInHierarchy) {
			resumeGame(); //resume game

		}

	}

	
	IEnumerator getReady()    
	{   
		countdownText.SetActive (true);

		Text count_text = countdownText.GetComponent<Text> ();
		count_text.text = "3";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		
		count_text.text  = "2";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		
		count_text.text = "1";   
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		
		count_text.text = "GO";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		
		countdownText.SetActive (false); //hides countdown text

		pauseButton.SetActive (true);
		if (!frozen.isFrozen)
			Time.timeScale = 1f; //unfreezes game
		else
			Time.timeScale = 0.5f;
		gameAudio.Play ();
	}
	
	IEnumerator WaitForRealSeconds (float waitTime) {
		float endTime = Time.realtimeSinceStartup+waitTime;
		
		while (Time.realtimeSinceStartup < endTime) {
			yield return null;
		}
	}


}
