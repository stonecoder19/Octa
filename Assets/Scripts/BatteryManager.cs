using UnityEngine;
using System.Collections;
using System;

public class BatteryManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int level = GetBatteryLevel ();
		Debug.Log ("Battery Level " + level + "");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int GetBatteryLevel()
     {
         try {
             string CapacityString = System.IO.File.ReadAllText ("/sys/class/power_supply/battery/capacity");
             return int.Parse (CapacityString);
         } catch (Exception e) {
             Debug.Log ("Failed to read battery power; " + e.Message);
         }
 
         return -1;
     }
}
