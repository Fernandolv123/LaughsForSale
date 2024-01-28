using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseDragNDrop))]
public class DragNDropSelectScreen : MonoBehaviour
{

    public int indexDisp;
    public int indexSel;
    public bool selected;
    
    // Start is called before the first frame update
    void Start()
    {
        MouseDragNDrop mdnd = GetComponent<MouseDragNDrop>();
        mdnd.ObjectDropped.AddListener(Dropped);
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos) {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }


    private void Dropped()
    {
        if (!selected) {
            if (DropObject.instance.CheckPosition(worldToUISpace(SelectScreenGameManager.instance.canvas, transform.position))) {
                for (int i = 0; i < SelectScreenGameManager.instance.objsSel.Length; i++) {
                    if (SelectScreenGameManager.instance.objsSel[i] == null) {
                        SelectScreenGameManager.instance.objsSel[i] = SelectScreenGameManager.instance.objsDisp[indexDisp];
                        indexSel = i;
                        selected = true;
                        i = SelectScreenGameManager.instance.objsSel.Length;
                        transform.parent = SelectScreenGameManager.instance.canvas.transform.GetChild(1).gameObject.transform.GetChild(indexSel).gameObject.transform;
                        transform.localScale = new Vector2(150, 150);
                    }
                }
            }
        } else {
            if (!DropObject.instance.CheckPosition(worldToUISpace(SelectScreenGameManager.instance.canvas, transform.position))) {
                SelectScreenGameManager.instance.objsSel[indexSel] = null;
                transform.parent = SelectScreenGameManager.instance.canvas.transform.GetChild(0).gameObject.transform.GetChild(indexDisp).gameObject.transform;
                transform.localScale = new Vector2(100, 100);
                selected = false;
            }
        }

        transform.localPosition = new Vector3(0,0,-1);
    }
}
