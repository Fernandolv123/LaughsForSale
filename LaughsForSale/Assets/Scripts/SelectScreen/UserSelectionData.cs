using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSelectionData : MonoBehaviour
{

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UserSelectionData");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public List<string> selectedObjectsTags = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
