using UnityEngine;
using System.Collections;

public class GamePause : MonoBehaviour {
	public GameObject pauseMenu;
	public bool isPaused;
	
	// Use this for initialization
	void Start () {
		isPaused = false;
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.Escape) && (!isPaused)) {	
			Time.timeScale = 0f;//stop the game
			pauseMenu.SetActive (true);//show the menu
			isPaused = true;//the game is now paused
		} 
		else {
			if (Input.GetKeyUp (KeyCode.Escape) && (isPaused)) {
				Time.timeScale = 1f;//resume the game
				pauseMenu.SetActive (false);//hide the menu
				isPaused = false;//the game is not paused
			}
		}
	}
}
