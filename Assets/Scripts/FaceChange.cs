using UnityEngine;
using System.Collections;

public class FaceChange : StateMachineBehaviour {

    int stage = 0;
    float delay = 3.0f;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        delay -= Time.deltaTime;
        switch(stage){
            case 0:
                if(delay <= 0.0f){
                    Material newMat = Resources.Load("ClockFaceTime", typeof(Material)) as Material;
                    animator.gameObject.transform.Find("Face").GetComponent<Renderer>().material = newMat;
                    stage = 1;
                    delay = 1.0f;
                }
            break;
            case 1:
                if(delay <= 0.0f){
                    Material newMat = Resources.Load("ClockFaceHappy", typeof(Material)) as Material;
                    animator.gameObject.transform.Find("Face").GetComponent<Renderer>().material = newMat;
                    stage = 2;
                    delay = 0.5f;
                }
            break;
            case 2:
                if(delay <= 0.0f){
                    Material newMat = Resources.Load("ClockFaceBlink", typeof(Material)) as Material;
                    animator.gameObject.transform.Find("Face").GetComponent<Renderer>().material = newMat;
                    stage = 3;
                    delay = 0.1f;
                }
            break;
            case 3:
                if(delay <= 0.0f){
                    Material newMat = Resources.Load("ClockFaceHappy", typeof(Material)) as Material;
                    animator.gameObject.transform.Find("Face").GetComponent<Renderer>().material = newMat;
                    stage = 4;
                    delay = 0.1f;
                }
            break;
            case 4:
                if(delay <= 0.0f){
                    Material newMat = Resources.Load("ClockFaceBlink", typeof(Material)) as Material;
                    animator.gameObject.transform.Find("Face").GetComponent<Renderer>().material = newMat;
                    stage = 5;
                    delay = 0.1f;
                }
            break;
            case 5:
                if(delay <= 0.0f){
                    Material newMat = Resources.Load("ClockFaceHappy", typeof(Material)) as Material;
                    animator.gameObject.transform.Find("Face").GetComponent<Renderer>().material = newMat;
                    stage = 6;
                    delay = 0.1f;
                }
            break;
            case 6:
                if(delay <= 0.0f){
                    GameController.ClockAnimator.SetInteger("ClockState", 2);
                    GameController.CameraAnimator.SetInteger("CameraState", 2);
                }
            break;
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
