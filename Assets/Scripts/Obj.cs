using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public bool onFire;
    public GameObject Fire;

    private void Start()
    {
        onFire = false;
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
    }

    public void PutOutFire()
    {
        if (!onFire) return;
        onFire = false;
        Destroy(transform.GetChild(1));
    }
}
