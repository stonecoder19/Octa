using UnityEngine;
using System.Collections;

public class ProjectileProperties: MonoBehaviour {
	
	public float movementSpeed = 1f;//projectile movement speed
	public int damage = -10;//projectile damage
	private GameOver gameOver;

	// Use this for initialization
	void Awake () {
		gameOver = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameOver>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver.gameOver) {

			Destroy(gameObject); //removes projectile from scene
		}
	}
}
