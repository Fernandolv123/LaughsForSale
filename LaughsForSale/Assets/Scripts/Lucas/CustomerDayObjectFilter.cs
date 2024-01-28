using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDayObjectFilter : MonoBehaviour
{
    public GameObject[] CustomerPrefabs; // Aquí deberán ir TODOS los prefabs de cliente existentes.
    public GameObject[] testObjectPool; // Este campo es auxiliar, deberá ser sustituido por las referencias a los objetos activos del pool.
    public GameObject[] bosses; // Se deben añadir los 4 bosses del juego en orden.
    public int day = 1; // Día actual.

    private List<GameObject> filteredCustomers = new List<GameObject>();
    private readonly int[] clientsDay = {5,6,7,8,10};
    void Start()
    {
        ShuffleArray(CustomerPrefabs);
        FilterDayCustomers(day);
    }

    void Update()
    {
        
    }

    /*Función que recorre y comprueba todos los prefabs existentes y los añade a un nuevo Array el cuál está compuesto por clientes
    con los que siempre es posible por lo menos sacar puntuación neutra para el risometro*/
    //En la función se también se le pasa el parámetro del día para establecer el boss y el número máximo de clientes.
    // PARA ALEATORIZACIÓN TOTAL AÑADIR EL MÉTODO SHUFFLEARRAY() ANTES DE ESTE MÉTODO.
    private void FilterDayCustomers(int day){
        foreach (GameObject customer in CustomerPrefabs){
            for(int i = 0; i<customer.GetComponent<CustomerObjectReception>().objectInteractions.Count;i++){
                for(int y = 0; y<testObjectPool.Length;y++){
                    if(filteredCustomers.Count+1 == clientsDay[day-1]){
                        if(day > 1){
                            filteredCustomers.Add(bosses[day-2]);
                        }
                        return;
                    }
                    if(customer.GetComponent<CustomerObjectReception>().objectInteractions[i].objectTag == testObjectPool[y].GetComponent<ObjectTag>().objectTag
                    && customer.GetComponent<CustomerObjectReception>().objectInteractions[i].laughScore >= 0){
                        if(!filteredCustomers.Contains(customer)){
                            filteredCustomers.Add(customer);
                        }
                    }
                }
            }
            
        }
    }
    
    //Función que aleatoriza un Array de GameObjects, principalmente utilizado para que no se repitan siempre los mismos clientes.
    void ShuffleArray(GameObject[] array)
    {
        System.Random random = new System.Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
