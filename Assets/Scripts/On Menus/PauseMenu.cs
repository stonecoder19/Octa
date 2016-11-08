using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GamePause gamePause;

	void OnGUI()
	{
		int buttonWidth = 150;//width of each button
		int buttonHeight = 30;//height of each button
		
		//create button at half width of screen and 3/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (3 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Resume")) {
			
			Time.timeScale = 1f;//resume the game
			gamePause.pauseMenu.SetActive (false);//hide the menu
			gamePause.isPaused = false;//the game is not paused
			//Application.LoadLevel("BasicGameScene");
		}
		//create button at half width of screen and 4/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (4 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Settings")) {
			//Application.LoadLevel("SettingsScene");
		}
		//create button at half width of screen and 5/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (5 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Back To Menu")) {
			Time.timeScale = 1f;
			Application.LoadLevel("MainMenuScene");
		}
	}
}
