using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GameController.userScreen = this.GetComponent<Canvas>();
	    GameController.screen = this;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addScore(string text, float startX, float startY, Color c){
        GameObject txt = Instantiate(Resources.Load("AddScore", typeof(GameObject))) as GameObject;
        txt.transform.SetParent(GameController.userScreen.transform);
        txt.GetComponent<Text>().enabled = false;
        AddScore addscore = txt.GetComponent<AddScore>();
        addscore.startposx = startX;
        addscore.startposy = startY;
        addscore.clr = c;
        addscore.str = text;
        //Debug.Log(startX +"; "+ startY);
    }
}
