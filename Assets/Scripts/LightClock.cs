using UnityEngine;
using System.Collections;

public class LightClock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameController.lightClock = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
