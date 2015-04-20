using UnityEngine;
using System.Collections;

public class DoorHinge : MonoBehaviour {

    public bool open = false;
    public float progress = 0.0f;

	// Use this for initialization
	void Start () {
	    GameController.doorHinge = this;
	}
	
	// Update is called once per frame
	void Update () {
	    if(open){
            progress += Time.deltaTime;
            this.transform.Rotate(new Vector3(0f, 1f, 0f), Time.deltaTime * -5f);
            Debug.Log(this.transform.rotation.y +" && "+ Mathf.Deg2Rad * 340f);
            if(progress > 5.0f){
                open = false;
                GameController.wardrobeDarkness.flashing = true;
            }
        }
	}
}
