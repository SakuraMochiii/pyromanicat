using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NekoController : MonoBehaviour
{
    public GameObject fireObj;
    public float speed; // speed that cat runs at to destination
    private Animator animator;
    private SpriteRenderer sr;
    private Vector3 destination; // cat runs to destination
    private BoxCollider2D col; //note: this collider is a trigger!
    

    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3(0, 0, 0); // center of screen
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        StartCoroutine(RunAndScratch());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator RunAndScratch()
    {
        RandomizeDestination();
        animator.SetBool("running", true);
        while ((destination - transform.position).magnitude > 0.5)
        {
            // if the cat's distance is > 0.5 from destination,
            // move in the direction torwards destination
            Vector3 moveDirection = (destination - transform.position).normalized * speed;
            transform.position += moveDirection * Time.deltaTime;
            sr.flipX = moveDirection.x > 0; // make sure cat is facing left or right!
            yield return null;
        }
        animator.SetBool("running", false);
        animator.SetBool("scratching", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("scratching", false);
        StartCoroutine(RunAndScratch());

    }
    private void RandomizeDestination ()
    {
        // hard coded values of the bounds of the room
        destination = new Vector3(
            Random.Range(-5.5f, 5.5f),
            Random.Range(-4f, 3f),
            0);
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        collision.gameObject.SetActive(false);
    //        Instantiate(fireObj, collision.transform.position, Quaternion.identity);
    //        //Explode();
    //    }
    //}
}
