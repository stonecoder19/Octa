using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class GameOver : MonoBehaviour {

	public TowerProperties tower;//health controller
	public PointsSystem score;//score controller
	public GameObject shield;//gameplay shield
	public GameObject endAni;//end game particle system
	public GameObject gameOverMenu;//end of game menu
	public GameObject musicBars;
	public GameObject saveMeMenu;

	public bool gameOver = false;//checks if the game is over now
	private bool gameEnded = false;//checks if the game has been over
	public Text finalScore;//used to store the final score for end game screen
	public GameObject highScoreText;
	public GameObject bestScoreText;
	private bool isNewHighScore =false;
	private AudioSource audio;
	private OctasUpdate octasUpdate;
	public int minRetryOctas = 10;
	private int numRetrys = 0;
	private SaveMe saveMe;
	private PlayGamesManager playManager;
	private AudioManager audioManager;


	void Awake(){
		audio = GetComponent<AudioSource> ();
		octasUpdate = GetComponent<OctasUpdate> ();
		playManager = GetComponent<PlayGamesManager> ();
		audioManager = GetComponent<AudioManager> ();
		//saveMe = saveMeMenu.GetComponent<SaveMe> ();
	}
	// Use this for initialization
	void Start () {
		gameOverMenu.SetActive (false);
		bestScoreText.SetActive (false);
	


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!gameEnded){//if the game has not already ended
			if(gameOver){//and the game is now over
				musicBars.SetActive(false);
				if(audio.isPlaying){
					audio.Stop();
				}
				audioManager.audioStarted = false;
				playManager.postScoreToLeaderboard(Mathf.RoundToInt(score.points));
				gameOverMenu.SetActive(true);//display menu
				int prevHighScore = PlayerPrefs.GetInt("HighScore"); //check highscore
				playManager.postScoreToLeaderboard(prevHighScore);
				//Debug.Log(prevHighScore.ToString());
				if(prevHighScore == 0) //if there is no previous highscore
				{
					PlayerPrefs.SetInt("HighScore",Mathf.RoundToInt(score.points));
				}
				if(prevHighScore<score.points && prevHighScore!=0)
				{
					isNewHighScore = true;
				}

				if(isNewHighScore)
				{
					//octasUpdate.updateOctas(10);
					//octasUpdate.saveOctas();
					PlayerPrefs.SetInt("HighScore",Mathf.RoundToInt(score.points)); //set high score
					bestScoreText.SetActive(false);
					highScoreText.SetActive(true); //show highscore text
				}
				else{
					if(prevHighScore==0){
						bestScoreText.SetActive(false);
					}else{
						bestScoreText.SetActive(true);
						highScoreText.SetActive(false); //show highscore text
					}
				}
				
				finalScore.text = "SCORE : " + Mathf.RoundToInt(score.points);//store the final score
				bestScoreText.GetComponent<Text>().text = "BEST : " + Mathf.RoundToInt(prevHighScore);//store the final score
				Instantiate(endAni,tower.transform.position,Quaternion.identity);
				shield.SetActive(false);//hide the shield	
				tower.gameObject.SetActive(false);//hide the tower

				gameEnded = true;//the game has now ended
			}
		}
		if (!gameEnded) {//if the game has not yet ended
			if(tower.health <= 0){//then if the tower health falls below 0
				/*int numOctas = octasUpdate.getNumOctas();
				Debug.Log(numOctas.ToString());
				Debug.Log(minRetryOctas.ToString());
				if(numOctas>=minRetryOctas){
					numRetrys++;
					saveMeMenu.SetActive(true);
					if(numRetrys>=2)
						saveMeMenu.GetComponent<SaveMe>().deactivateVideoButton();
					PlayerPrefs.SetInt("octas",numOctas);
					audio.Pause();
					Time.timeScale = 0f;

					Debug.Log("Retrying");
				}else{
					gameOver=true;//end the game
				}*/
				gameOver = true;
			}
		}
	}
}

