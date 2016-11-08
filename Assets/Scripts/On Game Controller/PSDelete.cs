using UnityEngine;
using System.Collections;

public class PSDelete : MonoBehaviour {

	public float deleteTime = 0.5f;//delay before deleting the particle system

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, deleteTime);//destroy the particle system after delay
	}
}
