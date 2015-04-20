using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    
    public bool opening = false;
    public float progress = 0.0f;
    bool once = true;

	// Use this for initialization
	void Start () {
        GameController.door = this;
	}
	
	// Update is called once per frame
	void Update () {
	    if (opening){
            if(once){
                GameController.commandStage = 3;
                GameController.clearScreen();
            }
            progress += Time.deltaTime;
            this.transform.Rotate(0f, Time.deltaTime * 150, 0f);
            if(progress > 2.0f){
                opening = false;
                this.transform.rotation = Quaternion.identity;

            }
        }
	}
}
