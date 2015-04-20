using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	float timeDif = 0.0f;
	float spawnTickTockTime = 0.6f;
	int progressTickTock = 0;

    string tickTock = "TICK   TOCK   ";

	// Use this for initialization
	void Start () {
        GameController.ClockAnimator = this.GetComponent<Animator>();
        GameController.clock = this;
	}
	
	// Update is called once per frame
	void Update () {
        switch(GameController.gameState){
            case GameController.STATE_MAINMENU:
		        timeDif += Time.deltaTime;
		        if(timeDif > spawnTickTockTime){
			        timeDif -= spawnTickTockTime;
			        string letter = ""+tickTock[progressTickTock];
                    if(letter != " "){
                        Material newMat = Resources.Load("key"+letter, typeof(Material)) as Material;
                        GameObject keyIndicator = Instantiate(Resources.Load("KeyIndicator", typeof(GameObject))) as GameObject;
                        keyIndicator.transform.parent = this.transform;
                        keyIndicator.transform.position = Vector3.zero;
                        keyIndicator.transform.localRotation = Quaternion.Euler(90, 180, 0);
                        keyIndicator.GetComponent<Renderer>().material = newMat;
                        Animator animator = keyIndicator.GetComponent<Animator>();
                        animator.SetBool("MainMenuDemo", true);
                    }

			        progressTickTock += 1;
                    if(progressTickTock >= tickTock.Length){
                        progressTickTock = 0;
                    }
		        }
            break;
            default:
                timeDif = 0.0f;
                progressTickTock = 0;
            break;
        }
	}
}
