using UnityEngine;
using System.Collections;

public class AlertBG : MonoBehaviour {

    public bool activeVal = false;
    public float progress = 0.0f;
    public float delayAB3 = 0.5f;

	// Use this for initialization
	void Start () {
	    GameController.alertBG = this;
        this.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(activeVal){
            delayAB3 -= Time.deltaTime;  
            if(delayAB3 <= 0f){
                this.transform.Rotate(Vector3.up, 1f, Space.Self);
                this.GetComponent<Renderer>().enabled = true;
                progress += 0.5f * Time.deltaTime;
                float scalenum = Mathf.Min(progress, 0.5f);
                this.transform.localScale = new Vector3(scalenum, scalenum, scalenum);  
            }
        }
	}
}
