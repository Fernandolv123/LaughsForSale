using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseDragNDrop))]
public class DragNDropExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MouseDragNDrop mdnd = GetComponent<MouseDragNDrop>();
        mdnd.ObjectDragEnter.AddListener(Dragged);
        mdnd.ObjectDropped.AddListener(Dropped);
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
}
