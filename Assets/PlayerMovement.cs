using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject controls;
    private ControlsScript controlsScript;  // Reference to Controls script

    void Start()
    {
        if (controls != null)
        {
            // Get the ControlsScript component from the controls GameObject
            controlsScript = controls.GetComponent<ControlsScript>();

            if (controlsScript == null)
            {
                Debug.LogError("ControlsScript not found on the specified GameObject!");
            }
        }
        else
        {
            Debug.LogError("Controls GameObject is not assigned!");
        }
    }

    void Update()
    {
        if (controlsScript != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(controlsScript.Move) * controlsScript.Speed);

            if (Input.GetKeyDown(KeyCode.UpArrow) && controlsScript.isGrounded())
            {
                animator.SetBool("isJump", true);
            }
            else
            {
                animator.SetBool("isJump", false);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                animator.SetBool("isAttack", true);
            }
            else
            {
                animator.SetBool("isAttack", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isDASH", true);
            }
            else
            {
                animator.SetBool("isDASH", false);
            }
        }
    }
}
