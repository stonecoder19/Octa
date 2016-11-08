using UnityEngine;
using System.Collections;

public class TowerHit : MonoBehaviour {

	public TowerProperties tower;//properties of the tower
	public GameObject ps;//particle system
	public bool hit = false;
	public Freeze powerup_freeze;//slow powerup
	public Wave powerup_wave;//slow powerup
	public OctasUpdate octasUpdate;
	public bool collect = false;
	Animator anim; //reference to animator
	public AudioClip clip;
	private int numHealth;
	public GameObject superShield;
	public GameObject healthBar;
	private Animator healthBarAnim;


	void Awake(){
		anim = GetComponentInParent<Animator> ();
		healthBarAnim = healthBar.GetComponent<Animator> ();
	
	}



	void OnTriggerEnter2D(Collider2D col) //if any collider collides with the tower
	{
		if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Health") {

			//if the projectile collides with the tower then subtract damage from health
			ProjectileProperties projectileProperties = col.gameObject.GetComponent<ProjectileProperties>();
			if(projectileProperties!=null){
				tower.updateHealth(projectileProperties.damage);
			}

			if(col.gameObject.tag == "Projectile"){
				hit = true;
				AudioSource.PlayClipAtPoint(clip,col.gameObject.transform.position);
				anim.SetTrigger("TowerHit"); //play hit animation
				healthBarAnim.enabled = false;
				numHealth = 0;
			}

			if(col.gameObject.tag == "Health"){
				collect = true;
				anim.SetTrigger("Health"); //play health animation

				if(tower.health == 30)
				{
					healthBarAnim.enabled = true;
					numHealth++;
					//Debug.Log("Adding to super shield");
				}else{
					healthBarAnim.enabled = false;
					numHealth = 0;
					//Debug.Log("Start over");
				}

				if(numHealth>=3){
					//Debug.Log("Super shield activated");
					superShield.SetActive(true);
					numHealth =0;
				}

			}

			tower.updateSrite();//change sprite based on damage

			//instantiate(start) the explotion particle system
			GameObject tempPs = (Instantiate(ps,col.transform.position,Quaternion.identity) as GameObject);//create ps
			Destroy(tempPs,0.8f);//destroy ps after 0.8seconds
			//destroy the projectile 
		}

		if(col.gameObject.tag == "Freeze"){
			powerup_freeze.freeze(); //activate freeze power up
		}
		if(col.gameObject.tag == "Wave"){
			powerup_wave.wave();
		}

		if (col.gameObject.tag == "Octa") {
			octasUpdate.updateOctas(1);
		}
		if (col.gameObject.tag != "Projectile" && col.gameObject.tag!="Health")
			Destroy (col.gameObject);
		else
			col.gameObject.SetActive (false);
	}
}
