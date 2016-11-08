using UnityEngine;
using System.Collections;

public class TowerRotation : MonoBehaviour {
	
	public TowerProperties tower;//properties of the tower
	private float rot;//+ve or -ve rotation
	public bool touchLeft = false;
	public bool touchRight = false;

	
	// Update is called once per frame
	void FixedUpdate () {

#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//if left arrow key pressed then 
			//rotate anti-clockwise	
			touchRight = false;
			touchLeft = true;
			rot=1f*tower.rotSpeed; 
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//if left arrow key pressed then 
			//rotate clockwise	
			touchLeft = false;
			touchRight = true;
			rot=-1f*tower.rotSpeed;
		}
#else
		if (Input.touchCount == 1) { //check if one finger is one screen
			Touch touch = Input.GetTouch(0); //get the first touch on screen
			if(touch.position.x<Screen.width/2){  //check if touch is on left side of screen
				//rotate anti-clockwise	
				touchRight = false;
				touchLeft = true;
				rot=1f*tower.rotSpeed;
			}

			if(touch.position.x>Screen.width/2){   //check if touch is on right side of screen
				//rotate clockwise	
				touchLeft = false;
				touchRight = true;
				rot-=1f*tower.rotSpeed;
			}
		}
#endif
		transform.Rotate(new Vector3(0,0,rot)*Time.deltaTime);  //rotate tower
		rot = 0;//stop rotation when nothing is pressed
	}
}
