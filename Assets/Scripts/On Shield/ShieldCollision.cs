using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour {

	public GameObject ps;
	public int multiHits = 0;
	private TowerHit towerHit;
	public GameObject tower;
	public PointsSystem pointsSystem;
	public int projBlocks = 15; //number of projectiles to block in a row to get multiplier
	public bool blocked = false;
	//public AudioClip hitClip;
	
	void Start () {
		towerHit = tower.GetComponent<TowerHit> (); //refrences tower hit script from tower
	}
	


	void OnTriggerEnter2D(Collider2D col) //if any collider collides with the shield
	{
		GameObject temp = (Instantiate(ps,col.transform.position,Quaternion.identity) as GameObject);//create ps
		Destroy(temp,0.8f);//destroy ps after 0.8seconds

		//if the projectile collides with a shield
		if(col.gameObject.tag == "Projectile"){
			//AudioSource.PlayClipAtPoint(hitClip,col.gameObject.transform.position);
			blocked = true;
			if(towerHit!=null){
				if(towerHit.hit == false){ //checks if tower has been hit
					multiHits++; //increments number of projectiles blocked
				}else{
					pointsSystem.ResetMultiplier(); //resets mutliplier
					multiHits = 0; //resets number of projectiles blocked
					towerHit.hit = false;
				}
			}
			col.gameObject.SetActive(false);
		}
			
			if(multiHits>=projBlocks){ //if the number of projectiles blocked is greater than 15
				if(pointsSystem!=null)
					if(multiHits%15==0) 
						pointsSystem.scoreMulti = multiHits/15*2; //updates multiplier
			}
		if(col.gameObject.tag != "Projectile" && col.gameObject.tag!="Health")
			Destroy(col.gameObject); //destroys projectile

		if (col.gameObject.tag == "Health")
			col.gameObject.SetActive (false);

	}
}
