using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDayObjectFilter : MonoBehaviour
{
    public GameObject[] CustomerPrefabs;
    public GameObject[] testObjectPool;
    private List<GameObject> filteredCustomers = new List<GameObject>();
    private int day;
    void Start()
    {
        foreach (GameObject customer in CustomerPrefabs){
            for(int i = 0; i<customer.GetComponent<CustomerObjectReception>().objectInteractions.Count;i++){
                for(int y = 0; y<customer.GetComponent<CustomerObjectReception>().objectInteractions.Count;y++){
                    if(customer.GetComponent<CustomerObjectReception>().objectInteractions[i].objectTag == testObjectPool[y].GetComponent<ObjectTag>().objectTag
                    && customer.GetComponent<CustomerObjectReception>().objectInteractions[i].laughScore >= 0){
                        Debug.Log(customer.GetComponent<CustomerObjectReception>().objectInteractions[i].laughScore);
                        Debug.Log("ENCONTRADO");
                        Debug.Log(customer.name);
                        if(!filteredCustomers.Contains(customer)){
                            filteredCustomers.Add(customer);
                        }
                    }
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
