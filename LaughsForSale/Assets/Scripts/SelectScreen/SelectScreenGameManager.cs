using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectScreenGameManager : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject[] objetos;
    public List<GameObject> objsDisp;
    public GameObject[] objsSel;
    public GameObject objSel;
    public Canvas canvas;
    public GameObject panelConfirmacion;
    public int maxSelectableObjectsCount=6;
    public bool freezeInteraction = false;
    public bool blockFreezeInteraction = false;
    public int lastSelectedObjectsCount = 0;

    public static SelectScreenGameManager instance;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < prefabs.Length; i++) {
            GameObject go = Instantiate(prefabs[i], new Vector2(0,0), Quaternion.identity);
            go.SetActive(false);
            objetos[i] = go;

            //En la pantalla de selección de objetos es necesario desactivar el componente DragNDropExample (TODO: cambiarle el nombre)
            //y dejar funcionando solo el DragNDropSelectScreen
            go.GetComponent<DragNDropExample>().enabled = false;
        }

        objsDisp = new List<GameObject>();
        for (int i=0; i < 9; i++) {
            int rand = Random.Range(0, objetos.Length);
            if (objetos[rand] != null) {
                objsDisp.Add(objetos[rand]);
                objetos[rand] = null;
                /*
                for (int j = 0; j < objsDisp.Count; j++) {
                    if (objsDisp[j] == null) {
                        objsDisp[j] = objetos[rand];
                        objetos[rand] = null;
                    }
                }
                */
            } else {
                i--;
            }
        }

        for (int i=0; i < objsDisp.Count; i++) {
            Vector3 pos = canvas.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.position;
            objsDisp[i].SetActive(true);
            objsDisp[i].GetComponent<DragNDropSelectScreen>().indexDisp = i;
            objsDisp[i].transform.parent = canvas.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform;
            objsDisp[i].transform.localPosition = new Vector3(0,0,-1);
            objsDisp[i].transform.localScale = new Vector2(100, 100);
        }
    }

    private void Update()
    {
        int currentSelectedObjectsCount = GetSelectedObjectsCount();
        if(currentSelectedObjectsCount < lastSelectedObjectsCount)
        {
            blockFreezeInteraction = false;
        }
        if (currentSelectedObjectsCount == maxSelectableObjectsCount && ! blockFreezeInteraction)
        {
            freezeInteraction = true;
            panelConfirmacion.SetActive(true);
        }
        lastSelectedObjectsCount = currentSelectedObjectsCount;
    }

    private int GetSelectedObjectsCount()
    {
        int count = 0;
        for(int i=0; i<objsSel.Length; i++)
        {
            if(objsSel[i] != null)
            {
                count++;
            }
        }
        return count;
    }

    public void LoadNextLevel()
    {
        Debug.Log("Seguinte nivel");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UserSelectionData");
        if(objs.Length == 1)
        {
            UserSelectionData usd = objs[0].GetComponent<UserSelectionData>();
            for(int i=0; i<objsSel.Length; i++)
            {
                usd.selectedObjectsTags.Add(objsSel[i].GetComponent<ObjectTag>().objectTag);
            }
        }

        SceneManager.LoadScene("MainGame");
    }
}
