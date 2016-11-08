using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {


	public StartGame startGame;
	public GameObject pauseButton;
	public AdManager admanager;
	public GameObject exitMenu;

	void Start(){
		pauseButton.SetActive (false); //hide pause button
	}

	public void restartGame(){

		//admanager.ShowAd ();
		Application.LoadLevel("GameScene"); //restarts game

	}

	public void Menu(){ //loads game menu
		startGame.loadMenu ();
		Application.LoadLevel ("GameScene");

	}

	public void Update(){
		if (Input.GetKeyUp(KeyCode.Escape)) {
			exitMenu.SetActive(true);

		}

	}

}
