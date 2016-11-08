using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour {
	private Button btn;
	public StartGame startGame;
	// Use this for initialization

	void Awake(){
		btn = GetComponent<Button> ();
	}
	void Start () {
		btn.onClick.AddListener(() => loadMenu());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadMenu(){
		Time.timeScale = 1f; //unfreeze game
		startGame.loadMenu (); //load menu
		Application.LoadLevel ("GameScene");

	}
}
