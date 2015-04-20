using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public bool die = false;
    float dieProgress = 0.0f;
    Image img;

	// Use this for initialization
	void Start () {
	    img = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(die){
            dieProgress += Time.deltaTime;
            Color c = img.color;
            c.a = Mathf.Max(0.0f, 1.0f - dieProgress);
            img.color = c;
            if(c.a == 0.0f){
                Destroy(this.gameObject);
            }
        }
	}
}
