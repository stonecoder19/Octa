﻿using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class PlayGamesManager : MonoBehaviour{

	public bool signedin = false;
	public GameObject startMenu;
	// Use this for initialization
	void Start () {
	
		PlayGamesPlatform.Activate ();
		if (startMenu.activeInHierarchy) {
			Debug.Log("Signing in");
			SignIn ();
			if (PlayerPrefs.GetInt ("SignIn") == 0)
				SignIn ();
			else {
				signedin = true;
			}
		}





	}


	
	public void SignIn(){
		Social.localUser.Authenticate((bool success) => {
			if(success){
				signedin = true;
				PlayerPrefs.SetInt("SignIn",1);
			}
		});
	}

	public void ShowLeaderboard(){

		//if (signedin) {
		//Debug.Log ("Showing leaderboard");
		//SignIn();
			//Social.ShowLeaderboardUI();
		Social.localUser.Authenticate((bool success) => {
			if(success){
				Social.ShowLeaderboardUI();
				signedin = true;
				PlayerPrefs.SetInt("SignIn",1);
			}
		});
		//} else {
			
			//Social.ShowLeaderboardUI();

	//	}
	}

	public void ShowAchievementsUI(){
		
		//if (signedin) {
			
		//} else {
			//SignIn();
		Social.localUser.Authenticate((bool success) => {
			if(success){
				Social.ShowAchievementsUI();
				signedin = true;
				PlayerPrefs.SetInt("SignIn",1);
			}
		});

		//	if(signedin){
			//	Social.ShowAchievementsUI();
		//	}
			
		//}
	}

	public void postScoreToLeaderboard(int score){

			//if (signedin) {
				Social.ReportScore (score, PlayGamesConstants.leaderboard_top_score, (bool success) => {
				//handle success or failure
				});
		//}


	}

	public void recordAchievement(string achievement){
			//if (signedin) {
				Social.ReportProgress (achievement, 100.0f, (bool success) => {
				// handle success or failure
				});
			//}


	}
}
