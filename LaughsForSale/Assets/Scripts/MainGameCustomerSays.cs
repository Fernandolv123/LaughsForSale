using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameCustomerSays : MonoBehaviour
{
    public static MainGameCustomerSays instance;
    //public GameObject textGO;
    public Text text;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Say(string textToSay)
    {
        text.text = textToSay;
    }
}
