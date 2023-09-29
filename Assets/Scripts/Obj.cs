using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public bool onFire;
    public GameObject Fire;
    private GameObject cursor;
    private CursorManager cursorScript;

    private void Start()
    {
        onFire = false;
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        cursorScript = cursor.GetComponent<CursorManager>();
    }
    public void CatchOnFire()
    {
        if (onFire) return;
        
        onFire = true;
        Instantiate(Fire, transform.parent.transform.position, Quaternion.identity, transform.parent);

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CatchOnFire();
        }
        if (collision.CompareTag("Cursor"))
        {
            PutOutFire();
        }
        
    }

    public void PutOutFire()
    {
        if (!onFire) return;
        onFire = false;
        Destroy(transform.parent.GetChild(1).gameObject);
    }
}
