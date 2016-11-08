using UnityEngine;
using System.Collections;

public class TowerProperties: MonoBehaviour {
	
	public float rotSpeed;//speed of tower rotation
	public int health = 30;//default health
	public int maxHealth = 30;//maximum health
	public Color color;
	public Sprite Sprite1;//cracked tower
	public Sprite Sprite2;//more cracked tower
	public Sprite Sprite3;//full tower

	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().color = color; //sets color of sprite

	}

	public void updateHealth(int hp){ //updates player health
		health += hp;
		if (health >= maxHealth) { //checks if health is greater than max health
			health = maxHealth;
		}
	}
	public void updateSrite(){
		switch (health) {
		case 30: GetComponent<SpriteRenderer>().sprite = Sprite1;
			break;
		case 20: GetComponent<SpriteRenderer>().sprite = Sprite2;
			break;
		case 10: GetComponent<SpriteRenderer>().sprite = Sprite3;
			break;
		defualt: break;
		}
	}

}
