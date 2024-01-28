using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameScript : MonoBehaviour {

    public List<Customer> listCustomer;
    public int numberOfCustomers;
    public static MainGameScript instance;
    public bool atendingCustomer;

    public GameObject[] objsSel;
    public Canvas canvas;

    void Awake() {
        instance = this;
        numberOfCustomers = 5;
        //Creamos usuarios de prueba
        for (int i = 0; i < numberOfCustomers; i++)
        {
        }
    }

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
        if (listCustomer.Count == 0)
        {
            //El dia terminaria al estar vacia la lista de clientes
            Debug.Log("Vacia");
            return;
        }
        if (atendingCustomer) {
            //Si hay un cliente siendo atendido, no pasar� al siguiente
            return;
        }
        //Pasamos al siguiente cliente si no estamos atendiendo a ninguno
        listCustomer[listCustomer.Count-1].ChangeActive(true);
        //Eliminamos al cliente de la lista
        listCustomer.RemoveAt(listCustomer.Count-1);
        atendingCustomer = true;

    }
}
