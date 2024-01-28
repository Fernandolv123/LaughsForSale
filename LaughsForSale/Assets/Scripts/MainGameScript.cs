using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour {

    public GameObject[] objsSel;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < objsSel.Length; i++) {
            Vector3 pos = canvas.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.transform.position;
            GameObject go = Instantiate(objsSel[i], new Vector2(0,0), Quaternion.identity);
            go.transform.parent = canvas.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.transform;
            go.transform.localPosition = new Vector3(0,0,-1);
            go.transform.localScale = new Vector2(75,75);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
