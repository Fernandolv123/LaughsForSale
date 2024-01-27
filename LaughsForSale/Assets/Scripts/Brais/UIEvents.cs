using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public GameObject panelConfirmacion;
    public void ConfirmButtonOnClick()
    {
        panelConfirmacion.SetActive(false);
        BraisGameManager.instance.LoadNextLevel();
    }

    public void CancelButtonOnClick()
    {
        panelConfirmacion.SetActive(false);
        BraisGameManager.instance.freezeInteraction = false;
        BraisGameManager.instance.blockFreezeInteraction = true;
    }
}
