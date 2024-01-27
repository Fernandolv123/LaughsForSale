using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Transform clikedOject = ClickedObject();
            if(clikedOject != null) {
                clikedOject.GetComponent<MouseClickReceiver>()?.MouseLeftClick();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Transform clikedOject = ClickedObject();
            if (clikedOject != null)
            {
                clikedOject.GetComponent<MouseClickReceiver>()?.MouseRightClick();
            }
        }

    }

    private Transform ClickedObject() {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 0);
        if (hit.collider != null) {
            worldPosition = hit.point;
            //Debug.Log("Colision con " + worldPosition);
            return hit.collider.transform;
        }

        return null;
    }
}
