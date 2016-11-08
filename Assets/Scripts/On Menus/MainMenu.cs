using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI()
	{
		int buttonWidth = 150;//width of each button
		int buttonHeight = 30;//height of each button
		
		//create button at half width of screen and 3/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (3 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Play")) {
			Application.LoadLevel("GameScene");
		}
		//create button at half width of screen and 4/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (4 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Help")) {
			//Application.LoadLevel("help");
		}
		//create button at half width of screen and 5/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (5 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Settings")) {
			//Application.LoadLevel("Settings");
		}
		//create button at half width of screen and 5/8 along height of screen
		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),
		                          (6 * Screen.height / 8) - (buttonHeight / 2),
		                          buttonWidth, buttonHeight), "Exit")) {
			Application.Quit();
		}
	}
}
