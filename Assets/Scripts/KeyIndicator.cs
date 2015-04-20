using UnityEngine;
using System.Collections;

public class KeyIndicator : MonoBehaviour {

	public bool mainMenuDemo = false;
    public float lifespan = 0.0f;
    Animator anim;

	// Use this for initialization
	void Start () {
	    anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(anim.GetBool("MainMenuDemo")){
            lifespan += Time.deltaTime;
            if(lifespan > 10){
                Destroy(this.gameObject);
            }
        }
	}
}
