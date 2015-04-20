using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        GameController.scoredisplay = this;
	    text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    text.text = "Score: "+GameController.score;
	}
}
