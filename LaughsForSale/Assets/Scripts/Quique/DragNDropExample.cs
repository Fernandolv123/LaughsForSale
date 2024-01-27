using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseDragNDrop))]
public class DragNDropExample : MonoBehaviour
{
    public GameObject hoverText;

    private Vector3 canvasCenterOffset;
    // Start is called before the first frame update
    void Start()
    {
        MouseDragNDrop mdnd = GetComponent<MouseDragNDrop>();
        mdnd.ObjectDragEnter.AddListener(Dragged);
        mdnd.ObjectDropped.AddListener(Dropped);
        mdnd.ObjectHovered.AddListener(Hovered);
        mdnd.ObjectHoverExited.AddListener(HoverExited);

        RectTransform rectT = hoverText.GetComponent<RectTransform>();
        float cWidth = rectT.rect.width * rectT.localScale.x * transform.localScale.x;
        float cHeight = rectT.rect.height * rectT.localScale.y * transform.localScale.y;
        canvasCenterOffset = new Vector3(cWidth / 2, cHeight / 2, 0);
    }


    private void Dropped()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log($"[DragNDropExample] Object {gameObject.name} dropped on {transform.position}");
    }

    private void Dragged()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log($"[DragNDropExample] Object {gameObject.name} picked up on {transform.position}");
    }
    private void Hovered(Vector3 mousePosition)
    {
        hoverText.SetActive(true);
        hoverText.transform.position = new Vector3(mousePosition.x, mousePosition.y, hoverText.transform.position.z) + canvasCenterOffset;
    }

    private void HoverExited()
    {
        hoverText.SetActive(false);
    }
}
