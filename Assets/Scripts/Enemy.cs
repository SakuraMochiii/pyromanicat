using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Movement_variables
    public float movespeed;
    #endregion

    #region Targeting_variables
    public Transform obj;
    #endregion

    #region Attack_variables
    public GameObject explosionObj;
    public GameObject fireObj;
    public float explosionRadius;
    #endregion

    #region Physics_components
    Rigidbody2D EnemyRB;
    #endregion

    #region Animation_components
    Animator anim;
    #endregion

    #region Unity_functions

    //runs once on creation
    public void Awake()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //runs once every frame
    private void Update()
    {
        if(obj == null)
        {
            return;
        }
        Move();
    }
    #endregion

    #region Movement_functions
    private void Move()
    {
        Vector2 direction = obj.position - transform.position;

        EnemyRB.velocity = direction.normalized * movespeed;
    }
    #endregion

    #region Attack_functions
    private void Explode()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);

        foreach(RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player"))
            {
                anim.SetBool("Scratch", true);
                Instantiate(explosionObj, obj.position, obj.rotation);
                //destroy obj and instantiate fire?? --> neko will run to next obj, otherwise orig obj still there
                Instantiate(fireObj, hit.transform.position, hit.transform.rotation);
                Destroy(hit.transform.gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Explode();
        }
    }
    #endregion
}
