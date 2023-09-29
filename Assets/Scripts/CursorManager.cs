using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTextureNormal;
    [SerializeField] private Texture2D cursorTextureClick;
    private Vector2 cursorHotspot;
    public bool pouring;
    private Vector2 mousePosition;
    private CircleCollider2D col;
    

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTextureClick.width / 2, cursorTextureClick.height / 2);
        Cursor.SetCursor(cursorTextureNormal, cursorHotspot, CursorMode.Auto);
        pouring = false;
        col = GetComponent<CircleCollider2D>();
        col.enabled = false;
    }
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        if (Input.GetMouseButtonDown(0) && !pouring)
        {
            Cursor.SetCursor(cursorTextureClick, cursorHotspot, CursorMode.Auto);
            pouring = true;
            col.enabled = true;
        } else if (Input.GetMouseButtonDown(0) && pouring)
        {
            Cursor.SetCursor(cursorTextureNormal, cursorHotspot, CursorMode.Auto);
            pouring = false;
            col.enabled = false;
        }
    }


}
