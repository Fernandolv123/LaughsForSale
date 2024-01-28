using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour {

    public List<Customer> customers;
    public List<Customer> listCustomer;
    public int numberOfCustomers;
    public static MainGameScript instance;
    public bool atendingCustomer;

    public GameObject[] objsSel;
    public Canvas canvas;
    public Slider slide;

    void Awake() {
        instance = this;
        numberOfCustomers = 5;
        //Creamos usuarios de prueba
        for (int i = 0; i < customers.Count; i++) {
            listCustomer.Add(Instantiate(customers[i], new Vector2(0,0), Quaternion.identity));
            listCustomer[i].transform.gameObject.transform.parent = canvas.transform.GetChild(3).gameObject.transform;
            listCustomer[i].transform.gameObject.transform.localPosition = new Vector3(0,0,-1);
            listCustomer[i].transform.gameObject.transform.localScale = new Vector2(159, 139);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < objsSel.Length; i++) {
            GameObject go = Instantiate(objsSel[i], new Vector2(0,0), Quaternion.identity);
            //El script DragNDropSelectScreen debe apagarse durante el gameplay de tienda y volver a encenderse durante el de seleccion
            go.GetComponent<DragNDropSelectScreen>().enabled = false;
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

    public void SetLaughmeter(float points)
    {
        // Este método es el encargado de cambiar los puntos del laughmeter y de coordinarlo
        slide.value += points;
    }
}
