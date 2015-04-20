using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddScore : MonoBehaviour {

    float progress = 0.0f;
    Text text;
    RectTransform rt;
    bool init = false;
    public Color clr;
    
    public float startposx;
    public float startposy;
    public string str;

	// Use this for initialization
	void Start () {
	    text = this.GetComponent<Text>();
        rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if(!init){
            rt.position = new Vector2(startposx, startposy);
            text.color = clr;
            init = true;
            text.text = str;
            text.enabled = true;
        }

	    progress += Time.deltaTime;
        //Color c = text.color;
        //c.a = Mathf.Min(1.0f, progress);
        //text.color = c;

        Text scoreText = GameController.scoredisplay.GetComponent<Text>();
        
        float speed = 10.0f;

        rt.position = Vector2.MoveTowards(rt.position, scoreText.rectTransform.position, speed);
        if(Vector2.Distance(rt.position, scoreText.rectTransform.position) < speed){
            Destroy(this.gameObject);
        }

        if(progress > 10.0f){
            Destroy(this.gameObject);
        }
	}
}
