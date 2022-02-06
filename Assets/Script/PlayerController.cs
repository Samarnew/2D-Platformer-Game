using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    public bool isCrouching = false;
    bool Jump = false;
    private void Update()
    {
        HorizontalMovementRun();
        VerticalCrouch();
    }
    void HorizontalMovementRun()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    void VerticalCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            isCrouching = true;
            
        }
       else if (Input.GetKeyUp(KeyCode.LeftControl)) 
        {
            animator.SetBool("Crouch", false);
            isCrouching = false;
        }
    }
    
}
 