using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Freeze : MonoBehaviour {

	public GameObject freezeText;
	public GameObject freezeanim;
	public TowerProperties tower;
	public float count;
	private float currentTime = 0f;
	public bool isFrozen = false;
	private SpawnController spawnController;
	private float tempSpeed = 0f;


	void Awake(){
		spawnController = GetComponentInChildren<SpawnController>();
	}

	public void freeze(){
		freezeanim.SetActive (true);
		freezeText.SetActive (true);
		isFrozen = true;
		spawnController.freeze = true;
		Time.timeScale = 0.5f;
		tower.rotSpeed = 800f;
		//changeSpeed ();
	}

	void changeSpeed(){
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag ("Projectile");
		foreach (GameObject projectile in projectiles) {
			ProjectileProperties projProps = projectile.GetComponent<ProjectileProperties>();
			if(projProps!=null){
				tempSpeed = projProps.movementSpeed;
				projProps.movementSpeed = 3f;
			}

		}

	}

	void RevertSpeed(){
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag ("Projectile");
		foreach (GameObject projectile in projectiles) {
			ProjectileProperties projProps = projectile.GetComponent<ProjectileProperties>();
			if(projProps!=null){
				projProps.movementSpeed = tempSpeed;
			}
			
		}

	}

	void Update()
	{

		if (GetComponent<GameOver> ().gameOver) {
			freezeanim.SetActive (false);
			freezeText.SetActive (false);
		} else {
			if(freezeanim.activeInHierarchy)
			{
				currentTime += Time.deltaTime;
				if(currentTime > (3*count/4)){
				//if(currentTime > 3f){
					Debug.Log("Freeze finished");
					freezeText.SetActive(false);
				///if(currentTime > count)
				
					freezeanim.SetActive(false);
					currentTime = 0f;
					Time.timeScale = 1f;
					tower.rotSpeed = 400f;
					isFrozen = false;
					//spawnController.freeze = false;
					//RevertSpeed();
				}
			}
			
		}

	}

/*	IEnumerator stayFrozen()    
	{   		
		freezeText.SetActive (true);
		
		yield return StartCoroutine (WaitForRealSeconds(2f));
		freezeText.SetActive (false);

		yield return StartCoroutine (WaitForRealSeconds(1f));
		
		freezeanim.SetActive (false);
		Time.timeScale = 1; //unfreezes game
	}
	
	IEnumerator WaitForRealSeconds (float waitTime) {
		float endTime = Time.realtimeSinceStartup+waitTime;
		
		while (Time.realtimeSinceStartup < endTime) {
			yield return null;
		}
	}
	*/
}
