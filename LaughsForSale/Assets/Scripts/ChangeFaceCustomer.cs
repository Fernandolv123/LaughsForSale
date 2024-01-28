using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFaceCustomer : MonoBehaviour
{
    public static ChangeFaceCustomer instance;
    public int valueExample;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //valueExample = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeFace(valueExample);
    }

    public void ChangeFace(int valueObject) {
        Sprite happySprite = MainGameScript.instance.canvas.transform.GetChild(3).transform.GetChild(MainGameScript.instance.canvas.transform.GetChild(3).transform.childCount - 1).GetComponent<Customer>().reacciones[1];
        if (valueObject > 0) {
            MainGameScript.instance.canvas.transform.GetChild(3).transform.GetChild(MainGameScript.instance.canvas.transform.GetChild(3).transform.childCount - 1).GetComponent<SpriteRenderer>().sprite = happySprite;
        }
    }
}
