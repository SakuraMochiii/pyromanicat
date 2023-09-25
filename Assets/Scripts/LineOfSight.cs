using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //check if coll is interactab le
        if (coll.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>().obj = coll.transform;
            Debug.Log("SEE OBJECT");
        }
    }
}
