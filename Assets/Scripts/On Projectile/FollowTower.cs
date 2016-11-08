using UnityEngine;
using System.Collections;

public class FollowTower : MonoBehaviour {
	
	public ProjectileProperties projectile;//properties of projectile
	public GameObject tower;//the gameplay tower

	
	// Update is called once per frame
	void Update () {

		var dir = tower.transform.position - transform.position;//calculates vector between tower and projectile
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+30f;//calculates angle between tower and projectile
		transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1)); //rotates projectile at angle towards tower
		transform.position = Vector2.MoveTowards(transform.position, tower.transform.position, projectile.movementSpeed * Time.deltaTime);
		//causes the projectile to transform towards the position of the tower
	}

	public void setFollowSpeed(float speed){
		projectile.movementSpeed = speed;
		//change the movement speed of the projectile
		
	}
}
