using UnityEngine;
using System.Collections;

public class WardrobeDarkness : MonoBehaviour {

    public bool flashing = false;
    float timeDif = 0.0f;

    bool once = true;

	// Use this for initialization
	void Start () {
	    GameController.wardrobeDarkness = this;
	}
	
	// Update is called once per frame
	void Update () {
	    if(flashing){
            timeDif += Time.deltaTime;
            if(once){
                GameController.commandStage = 2;
                GameController.moreCommands = true;
                GameController.addCommand();
                once = false;
            }
            if(timeDif > 0.2f){
                timeDif = 0.0f;
                Color newColor = new Color(Random.Range(0,3) * 0.25f, Random.Range(0,4) * 0.25f, Random.Range(0,3) * 0.25f);
                this.GetComponent<Renderer>().material.color = newColor;
            }
        }
	}
}
