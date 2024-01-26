using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active){
            GetComponent<SpriteRenderer>().enabled = false;
        } else {
            GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Estoy jugando al fornite, soy" + gameObject);
        if(Input.GetKeyDown(KeyCode.W)){
            CustomerOut();
        }
        }
    }
    public void CustomerOut(){
        GameManager.instance.atendingCustomer=false;
        active = false;
        Destroy(gameObject);
    }

    public void ChangeActive(bool change){
        active = change;
    }
    public bool GetActive(){
        return active;
    }
    public string ToString(){
        return "Hola soy" + gameObject;
    }
}