using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Customer customer;
    public Customer customer2;
    public List<Customer> listCustomer;
    public int numberOfCustomers;
    public static GameManager instance;
    public bool atendingCustomer;

    void Awake() {
        instance = this;
        numberOfCustomers = 5;
        //Creamos usuarios de prueba
        for (int i = 0; i < numberOfCustomers; i++)
        {
            listCustomer.Add(Instantiate(customer, new Vector3(0,0,0), Quaternion.identity));
            listCustomer.Add(Instantiate(customer2, new Vector3(0, 0, 0), Quaternion.identity));
        }
    }
    // Start is called before the first frame update
    void Start()
    {

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
            //Si hay un cliente siendo atendido, no pasará al siguiente
            return;
        }
        //Pasamos al siguiente cliente si no estamos atendiendo a ninguno
        listCustomer[listCustomer.Count-1].ChangeActive(true);
        //Eliminamos al cliente de la lista
        listCustomer.RemoveAt(listCustomer.Count-1);
        atendingCustomer = true;

    }
}
