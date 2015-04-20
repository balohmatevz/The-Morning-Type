using UnityEngine;
using System.Collections;

public class Anvil : MonoBehaviour {

    public int fallingStage = 0;
    public float progress = 0.0f;

	// Use this for initialization
	void Start () {
	    GameController.anvil = this;
	}
	
	// Update is called once per frame
	void Update () {
	    switch(fallingStage){
            case 0: 

            break;
            case 1: 
                this.transform.Translate(0f, -0.001f, 0f);
                if(this.transform.position.y <= 0.718f){
                    fallingStage = 2;
                    GameController.ClockAnimator.SetInteger("ClockState", 4);
                    GameController.moreCommands = false;
                    GameController.commandStage = 1;
                    GameController.clearScreen();
                }
            break;
            case 2: 
                this.transform.Translate(0f, -0.05f, 0f);
                if(transform.position.y < 0.424f){
                    transform.position = new Vector3(transform.position.x, 0.424f, transform.position.z);
                    fallingStage = 3;
                    GameController.CameraAnimator.SetInteger("CameraState", 3);
                }
                GameController.clock.transform.SetParent(this.transform);
                GameController.clock.transform.position = new Vector3(0f, -0.14f, 0f);
                if(GameController.alertBG){
                    Color c = GameController.alertBG.GetComponent<Renderer>().material.color;
                    c.a = Mathf.Max(0f, c.a - (5*Time.deltaTime));
                    GameController.alertBG.GetComponent<Renderer>().material.color = c;
                    if(c.a <= 0.1f){
                        Destroy(GameController.alertBG.gameObject);
                    }
                }
            break;
            case 3:
                if(GameController.clock){
                    Destroy(GameController.clock.gameObject);
                }
                if(GameController.alertBG){
                    Color c = GameController.alertBG.GetComponent<Renderer>().material.color;
                    c.a = Mathf.Max(0f, c.a - (5*Time.deltaTime));
                    GameController.alertBG.GetComponent<Renderer>().material.color = c;
                    if(c.a <= 0.1f){
                        Destroy(GameController.alertBG.gameObject);
                        fallingStage = 4;
                        progress = 0.0f;
                    }
                }
            break;
            case 4:
                progress += Time.deltaTime;
                if(progress > 25.0f){
                    fallingStage = 5;
                    GameController.doorHinge.open = true;
                }
            break;
        }
	}
}
