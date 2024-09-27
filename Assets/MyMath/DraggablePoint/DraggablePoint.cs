using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePoint : MonoBehaviour
{
    bool isDrag = false;
    public Color color;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = color;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (isDrag)
        {
            //print(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
        
    }

    private void OnMouseDown()
    {
        isDrag = true;
    }

    private void OnMouseUp()
    {
        isDrag = false;
    }
}
