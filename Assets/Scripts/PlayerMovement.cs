using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rigidbody2D;
    //private Vector2 change;
    private Vector3 change;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //change = Vector2.zero;
        change = Vector3.zero;
        //change.x = Input.GetAxis("Horizontal");
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        rigidbody2D.MovePosition(
            //new Vector2 + transform.position + change*speed * Time.deltaTime
            transform.position + change*speed * Time.deltaTime
        );

    }

}
