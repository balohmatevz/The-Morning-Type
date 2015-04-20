using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameController.CameraAnimator = this.GetComponent<Animator>();
        this.transform.position = new Vector3(-2.479f, 0.574f, 0.162f);
        this.transform.rotation = Quaternion.Euler(0, 57.49049f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenDoor () {
        GameController.door.opening = true;
    }

    public void displayEndMenu(){
        GameController.registerCommand("play again", 100, 100);
        if(!GameController.scoredisplay){
            GameController.scoredisplay = GameObject.Find("Score").GetComponent<Score>();
        }
        Text t = GameController.scoredisplay.GetComponent<Text>();
        t.enabled = false;
        //GameController.scoredisplay.GetComponent<Renderer>().enabled = false;
        GameController.gameState = GameController.STATE_END;
    }
}
