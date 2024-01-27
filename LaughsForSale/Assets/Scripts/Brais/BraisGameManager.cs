using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraisGameManager : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject[] objetos;
    public GameObject[] objsDisp;
    public GameObject[] objsSel;
    public GameObject objSel;
    public Canvas canvas;

    public static BraisGameManager instance;

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
        }

        for (int i=0; i < 9; i++) {
            int rand = Random.Range(0, objetos.Length);
            if (objetos[rand] != null) {
                for (int j = 0; j < objsDisp.Length; j++) {
                    if (objsDisp[j] == null) {
                        objsDisp[j] = objetos[rand];
                        objetos[rand] = null;
                    }
                }
            } else {
                i--;
            }
        }

        for (int i=0; i < 9; i++) {
            Vector3 pos = canvas.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.position;
            objsDisp[i].SetActive(true);
            objsDisp[i].GetComponent<BraisMouseDragNDrop>().indexDisp = i;
            objsDisp[i].transform.parent = canvas.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform;
            objsDisp[i].transform.localPosition = new Vector3(0,0,-1);
            objsDisp[i].transform.localScale = new Vector2(35,35);
        }
    }
}
