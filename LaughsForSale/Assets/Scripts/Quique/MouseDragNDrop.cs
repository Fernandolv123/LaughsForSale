using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseDragNDrop : MonoBehaviour
{
    public UnityEvent ObjectDragEnter;
    public UnityEvent ObjectDropped;
    public UnityEvent<Vector3> ObjectHovered;
    public UnityEvent ObjectHoverExited;

    private SpriteRenderer spriteRenderer;
    private Bounds boundingBox;

    private bool isDragged = false;
    private bool isHovered = false;
    private Vector3 mouseToObjectOffset;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        boundingBox = GetBoundingBox();
        //Debug.Log("[MouseDragNDrop] " + boundingBox);
    }

    // Update is called once per frame
    void Update()
    {
        if( ! isDragged && Input.GetMouseButtonDown(0))
        {
            if (IsClicked())
            {
                mouseToObjectOffset = transform.position - MouseWorldPosition();
                isDragged = true;
                if (ObjectDragEnter != null)
                {
                    ObjectDragEnter.Invoke();
                }
                if (ObjectHoverExited != null)
                {
                    ObjectHoverExited.Invoke();
                }
            }
        }

        if (!isDragged && IsClicked())
        {
            //Debug.Log("Hover");
            isHovered = true;
            if (ObjectHovered != null)
            {
                ObjectHovered.Invoke(MouseWorldPosition());
            }
        }

        if (isDragged && Input.GetMouseButtonUp(0))
        {
            isDragged = false;
            boundingBox = GetBoundingBox();
            if(ObjectDropped != null)
            {
                ObjectDropped.Invoke();
            }
        }

        if (isHovered && !IsClicked())
        {
            isHovered = false;
            if (ObjectHoverExited != null)
            {
                ObjectHoverExited.Invoke();
            }

        }

        if (isDragged)
        {
            transform.position = MouseWorldPosition() + mouseToObjectOffset;
        }
    }

    private Bounds GetBoundingBox()
    {
        return spriteRenderer.bounds;
    }

    private bool IsClicked()
    { 
        return boundingBox.Contains(MouseWorldPosition());
    }

    private Vector3 MouseWorldPosition()
    {
        Vector3 worldClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Necesario para evitar que caiga fuera por el valor discrepante en Z
        worldClickPosition.z = boundingBox.center.z;
        return worldClickPosition;
    }
}
