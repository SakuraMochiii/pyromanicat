using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region Attack_variables
    public GameObject explosionObj;
    public GameObject fireObj;
    public float explosionRadius;
    #endregion

    #region Attack_functions
    private void Explode()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);

        foreach(RaycastHit2D hit in hits)
        {
            if (hit.transform.CompareTag("Player"))
            {
                hit.transform.gameObject.SetActive(false);
                Instantiate(fireObj, hit.transform.position, hit.transform.rotation);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Instantiate(fireObj, collision.transform.position, Quaternion.identity);
            //Explode();
        }
    }
    #endregion
}
