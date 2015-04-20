using UnityEngine;
using System.Collections;

public class ClockJump : StateMachineBehaviour {

    float progress = 0;
    bool doonce = true;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    progress += Time.deltaTime;
        if(progress > 0.3f){
            GameController.ClockAnimator.SetInteger("ClockState", 3);
            if(doonce){
                GameController.alertBG.progress = 0.0f;
                GameController.alertBG.activeVal = true;
                doonce = false;
            }
        }
	}

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameController.lightClock.enabled = false;
        GameController.lightClock2.enabled = true;
        GameController.commandStage = 0;
        GameController.moreCommands = true;
        GameController.addCommand();
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
