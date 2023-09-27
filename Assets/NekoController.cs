using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoController : MonoBehaviour
{
    public float speed; // speed that cat runs at to destination
    private Animator animator;
    private SpriteRenderer sr;
    private Vector3 destination; // cat runs to destination
    private BoxCollider2D collider; //note: this collider is a trigger!
    

    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3(0, 0, 0); // center of screen
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((destination - transform.position).magnitude > 0.5) 
        {
            // if the cat's distance is > 0.5 from destination,
            // move in the direction torwards destination
            Vector3 moveDirection = (destination - transform.position).normalized * speed;
            transform.position += moveDirection * Time.deltaTime;
            animator.SetBool("running", true);
            sr.flipX = moveDirection.x > 0; // make sure cat is facing left or right!
            
        } else
        {
            // if the cat is at the destination
            animator.SetBool("running", false);
            RandomizeDestination(); // make a new destination for the cat!

        }
    }

    private void RandomizeDestination ()
    {
        // hard coded values of the bounds of the room
        destination = new Vector3(
            Random.Range(-5.5f, 5.5f),
            Random.Range(-4f, 3f),
            0);
    }
}
