using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class Leaderboard : MonoBehaviour {
	private Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		//Debug.Log (Social.Active.ToString ());
		PlayGamesPlatform.Activate ();
		btn.onClick.AddListener(() => ShowLeaderBoard());
	}
	
	void ShowLeaderBoard(){
		//Social.ShowLeaderboardUI ();
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			Social.ShowLeaderboardUI();
		});
	

	}
}
