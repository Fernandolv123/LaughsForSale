using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BraisMouseDragNDrop))]
public class BraisDragNDropExample : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        BraisMouseDragNDrop mdnd = GetComponent<BraisMouseDragNDrop>();
        mdnd.ObjectDragEnter.AddListener(Dragged);
        mdnd.ObjectDropped.AddListener(Dropped);
        mdnd.ObjectHovered.AddListener(Hovered);
        mdnd.ObjectHoverExited.AddListener(HoverExited);
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
        if (!BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().selected) {
            if (DropObject.instance.CheckPosition(worldToUISpace(BraisGameManager.instance.canvas, transform.position))) {
                for (int i = 0; i < BraisGameManager.instance.objsSel.Length; i++) {
                    if (BraisGameManager.instance.objsSel[i] == null) {
                        BraisGameManager.instance.objsSel[i] = BraisGameManager.instance.objsDisp[BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().indexDisp];
                        BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().indexSel = i;
                        BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().selected = true;
                        i = BraisGameManager.instance.objsSel.Length;
                        transform.parent = BraisGameManager.instance.canvas.transform.GetChild(1).gameObject.transform.GetChild(BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().indexSel).gameObject.transform;
                        transform.localScale = new Vector2(75, 75);
                    }
                }
            }
        } else {
            if (!DropObject.instance.CheckPosition(worldToUISpace(BraisGameManager.instance.canvas, transform.position))) {
                BraisGameManager.instance.objsSel[BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().indexSel] = null;
                transform.parent = BraisGameManager.instance.canvas.transform.GetChild(0).gameObject.transform.GetChild(BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().indexDisp).gameObject.transform;
                transform.localScale = new Vector2(35, 35);
                BraisGameManager.instance.objSel.GetComponent<BraisMouseDragNDrop>().selected = false;
            }
        }

        transform.localPosition = new Vector3(0,0,-1);
    }

    private void Dragged()
    {
        
    }
    private void Hovered(Vector3 mousePosition)
    {
        
    }

    private void HoverExited()
    {

    }
}
