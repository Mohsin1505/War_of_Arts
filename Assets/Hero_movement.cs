using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check if the character is walking (if the horizontal input is not zero)
        bool isWalking = Mathf.Abs(horizontalInput) > 0f;
        animator.SetBool("isWalking", isWalking);

        // Move the character horizontally
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Flip the character's sprite based on the direction of movement
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            //transform.eulerAngles = new Vector3(0f, 180, 0f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // Attack animation and damage 
        if (Input.GetMouseButtonDown(0) )
        {
            animator.SetBool("isAttacking", true);

            StartCoroutine(Attacking());
        }
       /* else 
        {
            animator.SetBool("isAttacking", false);
        }*/
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(.3f);
        animator.SetBool("isAttacking", false);
    }
}
