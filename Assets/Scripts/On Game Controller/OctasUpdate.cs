using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OctasUpdate : MonoBehaviour {

	public Text octasText;
	public GameObject octasAnimImg;
	public GameObject octasAnimText;
	private int numoctas;
	private bool octaAnimActive = false;
	private float octaAnimTimer = 0f;
	private GameOver gameOver;

	void Awake(){
		gameOver = GetComponent<GameOver> ();
	}
	void Start(){
		numoctas = PlayerPrefs.GetInt ("octas");
		//if (numoctas < 0){
			//numoctas = 0;
			//PlayerPrefs.SetInt ("octas", 0);

		octasText.text = numoctas.ToString ();
	}

	void Update(){
		if (octaAnimActive && !gameOver.gameOver) {
			octaAnimTimer+=Time.deltaTime;
			if(octaAnimTimer>=0.4f){
				octasAnimText.SetActive (false);
				octasAnimImg.SetActive (false);
				octaAnimTimer = 0f;
				octaAnimActive = false;
			}

		}

		if (gameOver.gameOver) {
			octasAnimText.SetActive (false);
			octasAnimImg.SetActive (false);
			octaAnimTimer = 0f;
			octaAnimActive = false;
			PlayerPrefs.SetInt("octas",numoctas);
		}




	}

	public void updateOctas(int octas){
		numoctas += octas;
		if (numoctas < 0)
			numoctas = 0;
		octasText.text = numoctas.ToString ();
		octasAnimText.SetActive (true);
		octasText.GetComponent<Animator> ().SetTrigger ("OctaGlow");
		octasAnimImg.SetActive (true);
		octaAnimActive = true;

	}

	public int getNumOctas(){
		return numoctas;
	}

	public void saveOctas(){
		PlayerPrefs.SetInt ("octas", numoctas);
	}
}
