using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSelectionData : MonoBehaviour
{
    public List<string> selectedObjectsTags = new List<string>();

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UserSelectionData");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if(MainGameScript.instance != null)
        {
            MainGameScript.instance.CheckSelectedObjectsLoad(objs);
            Debug.Log("[UserSelectionData] MainGameScript encontrado");
        } else
        {
            Debug.Log("[UserSelectionData] MainGameScript no encontrado");
        }
        DontDestroyOnLoad(this.gameObject);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
