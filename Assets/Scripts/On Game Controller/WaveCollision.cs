using UnityEngine;
using System.Collections;

public class WaveCollision : MonoBehaviour {

	public GameObject ps;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Projectile") {
			GameObject temp = (Instantiate (ps, col.transform.position, Quaternion.identity) as GameObject);//create ps
			Destroy (temp, 0.8f);//destroy ps after 0.8seconds		
			//Destroy (col.gameObject); //destroys projectile
			col.gameObject.SetActive(false);
		}
	}
}
