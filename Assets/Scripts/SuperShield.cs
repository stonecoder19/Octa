using UnityEngine;
using System.Collections;

public class SuperShield : MonoBehaviour {

	private float timer;
	public float timeToDisappear;
	public GameObject ps;
	public GameObject healthBar;
	private Animator healthBarAnim;
	private SpriteRenderer spriteRenderer;
	public float fadeTime = 50f;


	void Awake(){
		healthBarAnim = healthBar.GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//fadeShieldToClear ();
		if (timer >= timeToDisappear) {
			this.gameObject.SetActive (false);
			healthBarAnim.enabled = false;
			timer = 0f;
		}

	}

	void fadeShieldToClear(){

		spriteRenderer.color = Color.Lerp (spriteRenderer.color, Color.clear, fadeTime*Time.deltaTime);

	}


	void OnTriggerEnter2D(Collider2D col) {

		//Debug.Log ("Super Shield hit");

		if (col.gameObject.tag == "Projectile") {
			GameObject temp = (Instantiate (ps, col.transform.position, Quaternion.identity) as GameObject);//create ps
			Destroy (temp, 0.8f);//destroy ps after 0.8seconds

	
	

		
			//Destroy (col.gameObject); //destroys projectile
			col.gameObject.SetActive(false);
		}




	}
}
