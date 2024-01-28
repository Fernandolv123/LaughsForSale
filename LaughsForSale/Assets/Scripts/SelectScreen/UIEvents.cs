using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public GameObject panelConfirmacion;
    public void ConfirmButtonOnClick()
    {
        panelConfirmacion.SetActive(false);
        SelectScreenGameManager.instance.LoadNextLevel();
    }

    public void CancelButtonOnClick()
    {
        panelConfirmacion.SetActive(false);
        SelectScreenGameManager.instance.freezeInteraction = false;
        SelectScreenGameManager.instance.blockFreezeInteraction = true;
    }
}
