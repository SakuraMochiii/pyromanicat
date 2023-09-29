using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTextureNormal;
    [SerializeField] private Texture2D cursorTextureClick;
    private Vector2 cursorHotspot;
    private bool pouring;
    private Vector2 mousePosition;

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTextureClick.width / 2, cursorTextureClick.height / 2);
        Cursor.SetCursor(cursorTextureNormal, cursorHotspot, CursorMode.Auto);
        pouring = false;
    }
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        if (Input.GetMouseButtonDown(0) && !pouring)
        {
            Cursor.SetCursor(cursorTextureClick, cursorHotspot, CursorMode.Auto);
            pouring = true;
        } else if (Input.GetMouseButtonDown(0) && pouring)
        {
            Cursor.SetCursor(cursorTextureNormal, cursorHotspot, CursorMode.Auto);
            pouring = false;
        }
    }
}
