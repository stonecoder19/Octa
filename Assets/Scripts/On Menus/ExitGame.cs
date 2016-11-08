using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {		

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			No();
		}
	}

	public void Yes(){
		//Debug.Log ("quit game");
		Application.Quit ();	
	}
	public void No(){
		this.gameObject.SetActive (false);
	}
}
