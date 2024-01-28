using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour {
    public static MainGameScript instance;


    public List<Customer> customers;
    public List<Customer> listCustomer;
    public int numberOfCustomers;
    
    public bool atendingCustomer;

    public GameObject[] prefabs;
    public List<GameObject> objsSel;
    public Canvas canvas;
    public Slider slide;

    private bool loadSelectedObjectsFlag;
    private bool intentoALaDesesperadaAllowed = false;

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
        objsSel = new List<GameObject>();

        GameObject[] objsSelected = GameObject.FindGameObjectsWithTag("UserSelectionData");
        //Debug.Log($"[MainGameScript] {objsSelected.Length}");
        if (objsSelected.Length == 1)
        {
            LoadSelectedObjects(objsSelected);
        }
        else
        {
            loadSelectedObjectsFlag = true;
        }
        /*
        for (int i=0; i < objsSel.Length; i++) {
            GameObject go = Instantiate(objsSel[i], new Vector2(0,0), Quaternion.identity);
            //El script DragNDropSelectScreen debe apagarse durante el gameplay de tienda y volver a encenderse durante el de seleccion
            go.GetComponent<DragNDropSelectScreen>().enabled = false;
            go.transform.parent = canvas.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.transform;
            go.transform.localPosition = new Vector3(0,0,-1);
            go.transform.localScale = new Vector2(75,75);
        }

        */
    }

    private void LoadSelectedObjects(GameObject[] objs)
    {
        UserSelectionData usd = objs[0].GetComponent<UserSelectionData>();
        for (int i = 0; i < usd.selectedObjectsTags.Count; i++)
        //foreach(string objectTag in usd.selectedObjectsTags)
        {
            string objectTag = usd.selectedObjectsTags[i];
            GameObject foundPrefab = findObjectPrefabWithTag(objectTag);

            Debug.Log($"[MainGameScript] {objectTag}");
            GameObject go = Instantiate(foundPrefab, new Vector2(0, 0), Quaternion.identity);
            objsSel.Add(go);

            //El script DragNDropSelectScreen debe apagarse durante el gameplay de tienda y volver a encenderse durante el de seleccion
            go.GetComponent<DragNDropSelectScreen>().enabled = false;
            go.transform.parent = canvas.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.transform;
            go.transform.localPosition = new Vector3(0, 0, -1);
            go.transform.localScale = new Vector2(75, 75);

            //Tomar referencia de la posición inicial una vez colocado el objeto en su sitio;
            go.GetComponent<DragNDropExample>().SetStartPosition();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(loadSelectedObjectsFlag)
        {
            loadSelectedObjectsFlag = false;
            GameObject[] objsSelected = GameObject.FindGameObjectsWithTag("UserSelectionData");
            //Debug.Log($"[MainGameScript.Update] {objsSelected.Length}");
            if (objsSelected.Length == 1)
            {
                LoadSelectedObjects(objsSelected);
            }
            else
            {
                Debug.Log("[MainGameScript] Fallo catastrófico: no se encuentran los objetos selecionados. Pulse L para un intento de cargarlos");
                intentoALaDesesperadaAllowed = true;
            }
        }

        if (intentoALaDesesperadaAllowed && Input.GetKeyDown(KeyCode.L))
        {
            GameObject[] objsSelected = GameObject.FindGameObjectsWithTag("UserSelectionData");
            LoadSelectedObjects(objsSelected);
            if(objsSel.Count != 0)
            {
                intentoALaDesesperadaAllowed = false;
            }
        }
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UserSelectionData");
        //Debug.Log($"[MainGameScript.Update] {objs.Length}");
        if (listCustomer.Count == 0)
        {
            //El dia terminaria al estar vacia la lista de clientes
            NextDay();
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

    private void NextDay() {
        //Poner en este método el proceso de cambio de día
    }


    private GameObject findObjectPrefabWithTag(string objectTag)
    {
        string prefabTag;
        for(int i=0; i<prefabs.Length; i++)
        {
            prefabTag = prefabs[i].GetComponent<ObjectTag>().objectTag;
            if(prefabTag == objectTag)
            {
                return prefabs[i];
            }
        }
        return null;
    }

    public void CheckSelectedObjectsLoad(GameObject[] objs)
    {
        if (objsSel.Count == 0)
        {
            LoadSelectedObjects(objs);
        }
    }
}
