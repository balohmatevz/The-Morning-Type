using UnityEngine;
using System.Collections;

public class LightClock2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameController.lightClock2 = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if(GameController.lightClock2.enabled){
            GameController.lightClock2.intensity += 12.0f * Time.deltaTime;
            GameController.lightClock2.intensity = Mathf.Min(GameController.lightClock2.intensity, 0.7f);
        }
	}
}
