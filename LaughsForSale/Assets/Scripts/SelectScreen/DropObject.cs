using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{

    public Canvas canvas;
    
    Rect boundingBox;
    public static DropObject instance;

    // Start is called before the first frame update

    void Awake() {
        instance = this;
    }
    
    void Start()
    {
        RectTransform rectTCanvas = canvas.GetComponent<RectTransform>();
        RectTransform rectT = GetComponent<RectTransform>();
        float cWidth = rectT.rect.width * rectT.localScale.x * transform.localScale.x * rectTCanvas.localScale.x; //0.02338634f;
        float cHeight = rectT.rect.height * rectT.localScale.y * transform.localScale.y  * rectTCanvas.localScale.y; // 0.02338634f;

        

        boundingBox = new Rect(transform.position.x - cWidth / 2, transform.position.y -  cHeight / 2, cWidth, cHeight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckPosition(Vector3 position) {
        position.z = -1;
        return boundingBox.Contains(position);
    }
}
