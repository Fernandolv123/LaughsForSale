using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Square1MouseClickReceiver : MouseClickReceiver {

    public override void MouseLeftClick() {
        Debug.Log("Click izquierdo Square1");
    }
    public override void MouseRightClick()
    {
        Debug.Log("Click derecho Square1");
    }

}
