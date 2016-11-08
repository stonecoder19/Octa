using UnityEngine;
using System.Collections;

public class SpawnPowerUps : MonoBehaviour {

	public StartGame start;
	public SpawnController spawn;
	public float powerUpWait = 10f;//time between powerups
	public float gameTime = 0f;
	public float timeSinceStart = 0f;
	public float powerUpDelay = 30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (start.isSarted) {			
			timeSinceStart += Time.deltaTime;
			if(timeSinceStart > powerUpDelay){
				gameTime += Time.deltaTime;
			
				if (gameTime >= powerUpWait) {
					spawn.isPowerUp = true;
					gameTime = 0f;
				}
			}
		}
	}
}
