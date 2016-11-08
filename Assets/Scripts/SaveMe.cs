using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveMe : MonoBehaviour {

	public Button skipButton;
	public Button octasButton;
	public Button videoButton;
	public Text saveMeText;

	public GameObject countdownText;
	public GameObject pauseButton;
	public GameOver gameOver;
	public Resume resume;
	public Freeze frozen;
	public TowerProperties tower;
	public OctasUpdate octasUpdate;
	private Text octasButtonText;
	//public AdManager adManager;

	// Use this for initialization
	void Start () {
		pauseButton.SetActive (false);
		octasButtonText = octasButton.GetComponentInChildren<Text> ();
		octasButtonText.text = gameOver.minRetryOctas.ToString();
		skipButton.onClick.AddListener(() => skipRetry());
		octasButton.onClick.AddListener(() => spendOctas());
		videoButton.onClick.AddListener(() => showAd());
		//if (!adManager.isAdActive())
		//	deactivateVideoButton ();
	}
	
	void skipRetry(){
		Time.timeScale = 1f;
		gameOver.gameOver = true;
		this.gameObject.SetActive (false);

	}

	void spendOctas(){
		octasUpdate.updateOctas (-gameOver.minRetryOctas);
		octasUpdate.saveOctas ();
		gameOver.minRetryOctas *= 2;
		octasButtonText.text = gameOver.minRetryOctas.ToString ();
		resetGame ();

	}

	void showAd(){
		octasUpdate.saveOctas ();
		//adManager.ShowAd ();
	}

	public void resetGame(){
		tower.health = tower.maxHealth;
		tower.updateSrite ();
		resume.resumeGame ();
		this.gameObject.SetActive (false);

	}

	public void deactivateVideoButton(){
		videoButton.gameObject.SetActive (false);
		Vector3 positon = skipButton.transform.position;
		octasButton.transform.position = new Vector3 (positon.x, octasButton.transform.position.y+10,
		                                             octasButton.transform.position.z);
	}

}
