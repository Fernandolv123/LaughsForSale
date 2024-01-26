using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Customer customer;
    public List<Customer> listCustomer;
    public int numberOfCustomers;
    public static GameManager instance;
    public bool atendingCustomer;

    void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        numberOfCustomers=10;
        for (int i=0;i<numberOfCustomers;i++){
            listCustomer.Add(Instantiate(customer,new Vector3(Random.Range(-10,10),Random.Range(-4,4),0),Quaternion.identity));
        }
        StartCoroutine("NextCustomer");
    }

    // Update is called once per frame
    void Update()
    {
        listCustomer[listCustomer.Count-1].ChangeActive(true);
        if(listCustomer.Count == 0){
            Debug.Log("Vacia");
        }

    }

    IEnumerator NextCustomer(){
        while(true){
            //sacar de la corrutina
            //si alguien lee esto, hola
            atendingCustomer= true;
            Debug.Log(listCustomer[listCustomer.Count-1].ToString());
            Debug.Log(listCustomer.Count);
            listCustomer[listCustomer.Count-1].ChangeActive(true);
            Debug.Log(listCustomer[listCustomer.Count-1].GetActive());
            Debug.Log(atendingCustomer);
            while(atendingCustomer){
                yield return null;
            }
            listCustomer.RemoveAt(numberOfCustomers);
            numberOfCustomers--;
            Debug.Log("Ha pasado un segundo");
            yield return new WaitForSeconds(1f);
        }
        
    }
}
