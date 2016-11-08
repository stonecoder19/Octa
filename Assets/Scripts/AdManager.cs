using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	private string adId = "1002713";
	private string rewardZone = "rewardedVideo";
	private string pictureZone = "pictureZone";
	public SaveMe saveMe;

	
	/*void Awake(){ 

		if (Advertisement.isSupported) {
			Advertisement.Initialize(adId,true);
		}


	}
	
	public void ShowAd(){

	//	ShowOptions options = new ShowOptions ();
	//	options.resultCallback = AdCalBackHandler;

		if (Advertisement.IsReady ()) {
			Debug.Log ("Ad Showing");
			Advertisement.Show ();

		} else {
			//do something
		}
	}



/*	void AdCalBackHandler(ShowResult result){

		switch (result) {
		case ShowResult.Finished:
			if(saveMe!=null)
				saveMe.resetGame();
			break;

		}

	}

	public bool isAdActive(){
		return Advertisement.IsReady (zone);

	}*/
}
