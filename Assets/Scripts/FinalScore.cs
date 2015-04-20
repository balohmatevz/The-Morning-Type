using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    Text t = this.GetComponent<Text>();
        t.text = "<size=50>Final score: </size>\n<size=100>"+GameController.score+"</size>";
	}
}
