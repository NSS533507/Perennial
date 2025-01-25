using UnityEngine;

public class HeroWalkScript : StateMachineBehaviour
{
    private Vector3 previousPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        previousPosition = animator.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 currentPosition = animator.transform.position;
        if (currentPosition != previousPosition)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        previousPosition = currentPosition;
    }
}
