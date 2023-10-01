using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/Obj.cs
    public bool onFire;
    public GameObject Fire;
    private GameObject cursor;
    private CursorManager cursorScript;

    private float surroundFireTimer;
    private int maxSurroundFireTimer;

    private float timeSinceFireStart;

    private SpawnManager spawnManager;

=======
    public bool onFire;
    public GameObject Fire;
    private GameObject cursor;
    private CursorManager cursorScript;

    public UIManager uiManager;

>>>>>>> Stashed changes:Assets/Prefabs/Obj.cs
    private void Start()
    {

        uiManager = FindObjectOfType<UIManager>();
        
        onFire = false;
        cursor = GameObject.FindGameObjectWithTag("Cursor");
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        cursorScript = cursor.GetComponent<CursorManager>();
<<<<<<< Updated upstream:Assets/Scripts/Obj.cs
        maxSurroundFireTimer = 5;
        surroundFireTimer = maxSurroundFireTimer;
        timeSinceFireStart = 0;
    }
    private void Update()
    {
        surroundFireTimer -= Time.deltaTime;
        timeSinceFireStart += Time.deltaTime;
        if (surroundFireTimer < 0 && onFire && timeSinceFireStart > 1)
        {
            surroundFireTimer = maxSurroundFireTimer;
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 0.5f, Vector2.zero);
            foreach(RaycastHit2D hit in hits)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<Obj>().CatchOnFire(); 
                }
            }
        }
    }
=======
    }
>>>>>>> Stashed changes:Assets/Prefabs/Obj.cs
    public void CatchOnFire()
    {
        if (onFire) return;
        spawnManager.fireCount += 1;
        timeSinceFireStart = 0;
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
        
<<<<<<< Updated upstream:Assets/Scripts/Obj.cs
    }


=======
    }

>>>>>>> Stashed changes:Assets/Prefabs/Obj.cs
    public void PutOutFire()
    {
        if (!onFire) return;
        spawnManager.score += 1;
        spawnManager.fireCount -= 1;
        onFire = false;
        Destroy(transform.parent.GetChild(1).gameObject);
        uiManager.OnFireExtinguished();
    }
}
