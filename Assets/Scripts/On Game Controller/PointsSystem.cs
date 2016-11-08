using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsSystem : MonoBehaviour {
	public GameOver game;//tracks the state of the game	
	public Text pointsText;//text representation of points standing
	public float points;//tracks points
	public float scoreMulti = 1f; //score multiplier
	public GameObject multiText; //mulitplier text
	public PlayGamesManager playGames;
	public GameObject AchievementText;
	private bool activateText = false;
	private float activeTimer = 0f;
	private bool active500 =false;
	private bool active1000 =false;
	private bool active5000 =false;
	private bool active10000 =false;
	private bool active20000 =false;
	private Text achieveText;

	// Use this for initialization


	void Start () {
		points = 0;//start points at zero
		UpdatePoints( );//initialize the points standing
		achieveText = AchievementText.GetComponent<Text> ();	
	

	}
	
	// Update is called once per frame
	void Update () {
		if (!game.gameOver) {//if the game is not yet over

			if(scoreMulti>1f){
				multiText.GetComponent<Text>().text = "x"+scoreMulti; //set the multiplier text
				multiText.SetActive(true); //show the multiplier text
			}else{
				multiText.SetActive(false); //hide the multiplier text

			}

		
			points+=Time.deltaTime*10*scoreMulti; 

			if(points>=500 && points<1000){
				//playGames.recordAchievement(PlayGamesConstants.achievement_500_points);
				if(!active500){
					Debug.Log("500 Achievement");
					activateText = true;
					achieveText.text = "500 Points";
					playGames.recordAchievement(PlayGamesConstants.achievement_500_points);
					active500 = true;
				}

			}

			if(points >=1000 && points<5000){
				//playGames.recordAchievement(PlayGamesConstants.achievement_1000_points);
				if(!active1000){
					achieveText.text = "1000 Points";
					activateText = true;
					active1000 = true;
					playGames.recordAchievement(PlayGamesConstants.achievement_1000_points);
				}
			}

			if(points >=5000 && points<10000){
				//playGames.recordAchievement(PlayGamesConstants.achievement_5000_points);
				if(!active5000){
					achieveText.text = "5000 Points";
					activateText = true;
					active5000 = true;
					playGames.recordAchievement(PlayGamesConstants.achievement_5000_points);
				}

			}

			if(points >= 10000 && points<20000){
				//playGames.recordAchievement(PlayGamesConstants.achievement_10000_points);
				if(!active10000){
					achieveText.text = "10000 Points";
					activateText = true;
					active10000 = true;
					playGames.recordAchievement(PlayGamesConstants.achievement_10000_points);
				}
			}

			if(points >= 20000){
				//playGames.recordAchievement(PlayGamesConstants.achievement_10000_points);
				if(!active20000){
					achieveText.text = "20000 Points";
					activateText = true;
					active20000 = true;
					playGames.recordAchievement(PlayGamesConstants.achievement_20000_points);
				}
			}

			UpdatePoints( );//increment the points

			if(activateText){
				AchievementText.SetActive(true);
				activeTimer+=Time.deltaTime;
				if(activeTimer>=1f){
					AchievementText.SetActive(false);
					activeTimer = 0f;
					activateText = false;
				}
			}

		}
		if (game.gameOver) {
			multiText.SetActive(false);
			AchievementText.SetActive(false);
		}
	}

	void UpdatePoints(){
		int pts = Mathf.RoundToInt (points); //convert score to integer
		pointsText.text = "" + pts.ToString().PadLeft(6,'0'); //adds zeros beside score text
	}

	public void ResetMultiplier(){

		scoreMulti = 1f; //resets multiplier to 1
	}
	
}
