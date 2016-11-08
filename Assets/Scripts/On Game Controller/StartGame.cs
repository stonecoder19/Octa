using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject gameUI;
	public SpawnController spawnController;
	public TowerRotation towerRotation;
	public GameObject tower;
	public GameObject startMenu;
	public GameObject exitMenu;
	public GameObject tutorial;
	public GameObject startButton;
	public GameObject tutorialButton;
	public GameObject exitButton;
	public GameObject tutorialPointer;
	public GameObject musicBars;
	public bool isSarted = false;
	private SceneFadeInOut sceneFadeInOut;
	Button btn,btn2,btn3;
	public static int runTimes = 0; //number of times scene is loaded
	private int firstStart;
	private float counter = 0f;
	public bool returnToMenu = false;
	private AudioSource audio;
	public AudioClip menuClip;
	private AudioManager audioManager;
	private AdManager adManager;
	//public bool retry = false;

	// Use this for initialization

	void Awake(){
		audio = GetComponent<AudioSource> ();
		sceneFadeInOut = GetComponent<SceneFadeInOut> ();
		audioManager = GetComponent<AudioManager> ();
		//adManager = GetComponent<AdManager> ();

	}
	void Start () {
		//Debug.Log (Application.systemLanguage.ToString ());
		isSarted = false;
		runTimes++; //increments number of run times


		if (runTimes>1) { //checks if scene has already been run
			startGame(); //starts the game
		}




		btn = startButton.GetComponent<Button> ();
		btn2 = tutorialButton.GetComponent<Button> (); 
		btn3 = exitButton.GetComponent<Button> (); 
		btn.onClick.AddListener(() => startGame());
		btn2.onClick.AddListener(() => startTutorial());
		btn3.onClick.AddListener(() => exitGame());
		firstStart = PlayerPrefs.GetInt ("firstRun");



	
	}

	void Update()
	{
		if (startMenu.activeInHierarchy) {

			towerRotation.enabled = false;
			tower.transform.rotation = Quaternion.identity;
		}
	
		if (firstStart == 0) {
			if (Delay (1f)) {
			//	tutorialPointer.SetActive (true);
			}
		}
		if(Input.GetKeyUp(KeyCode.Escape) && startMenu.activeInHierarchy &&!returnToMenu){
			exitGame();
		}

		if (returnToMenu || runTimes>0) {
			returnToMenu = false;
		}
	}

	public void startGame(){
		//if (!audio.isPlaying)
		//	audio.Play ();

		if (runTimes%5 == 0) {
			//adManager.ShowAd();
		}



		if (PlayerPrefs.GetInt ("tutFin") == 0) {
			startTutorial();
			return;
		}
		audioManager.startAudio ();
		sceneFadeInOut.sceneStarting = true;
		startMenu.SetActive (false); //hides the start menu
		musicBars.SetActive (true);
		gameUI.SetActive (true); //shows game ui
		towerRotation.enabled = true; //enables player control
		spawnController.enabled = true; //enables projectile spawning	
		isSarted = true;	
		PlayerPrefs.SetInt ("firstRun", 1);
	
	}

	void startTutorial(){
		towerRotation.enabled = true; //enables player control
		sceneFadeInOut.sceneStarting = true;
		startMenu.SetActive (false);
		tutorial.SetActive (true);
	
	}
	
	bool Delay(float time){
		counter += Time.deltaTime;//increment counter
		return counter > time;//return true when the counter has reached the desired time
	}
	void exitGame(){
		exitMenu.SetActive (true);
	}

	public void loadMenu(){
		runTimes = 0; //resets run times

	}




}
