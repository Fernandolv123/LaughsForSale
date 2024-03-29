using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class CustomerObjectReception : MonoBehaviour
{
    public List<CharacterObjectInteraction> objectInteractions;
    public List<ComboObjectInteraction> comboInteractions;


    private CharacterObjectInteraction defaultObjectInteraction;
    private ComboObjectInteraction defaultComboInteraction;

    private Customer customer;
   
    // Start is called before the first frame update
    void Start()
    {
        defaultObjectInteraction.objectTag = "Default";
        defaultObjectInteraction.laughScore = 0;
        defaultObjectInteraction.killFactor = 1;

        defaultComboInteraction.comboTag = "Default";
        defaultComboInteraction.comboCondition = 0;

        customer = GetComponent<Customer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveObject(string objectTag, string comboTag)
    {
        CharacterObjectInteraction coi = SearchObjectInteraction(objectTag);
        ComboObjectInteraction comboi = SearchComboInteraction(comboTag);

        float pointsResult = coi.laughScore;
        if (comboi.comboCondition != 0) {
            if (pointsResult > 0)
            {
                pointsResult *= comboi.comboCondition;
            }
        }

        Debug.Log("Objeto recibido " + coi.objectTag + " risa " + coi.laughScore + " killer " + coi.killFactor);
        Debug.Log("Combo recibido " + comboi.comboTag + " condition " + comboi.comboCondition);

        Debug.Log("Puntos " + pointsResult);

        ChangeFaceCustomer.instance.ChangeFace((int)pointsResult);
        if (pointsResult >= 0)
        {
            MainGameCustomerSays.instance.Say(customer.frases[2]);
        } else
        {
            MainGameCustomerSays.instance.Say(customer.frases[1]);
        }
        //TODO: Sumar puntos. Feedback usuario. Marcharse y dar paso al siguiemte cliente

        if (GetComponent<Boss_Customer>() != null)
        {
            GetComponent<Boss_Customer>().StartCustomerOut(pointsResult);
        }
        else {
            GetComponent<Customer>().StartCustomerOut(pointsResult);
        }
    }

    private CharacterObjectInteraction SearchObjectInteraction(string tag)
    {
        foreach(CharacterObjectInteraction coi in objectInteractions)
        {
            if(coi.objectTag == tag)
            {
                return coi;
            }
        }
        return defaultObjectInteraction;
    }

    private ComboObjectInteraction SearchComboInteraction(string tag)
    {
        foreach(ComboObjectInteraction coi in comboInteractions)
        {
            if(coi.comboTag == tag)
            {
                return coi;
            }
        }
        return defaultComboInteraction;
    }
}

[System.Serializable]
public struct CharacterObjectInteraction
{
    public string objectTag;
    public float laughScore;
    public int killFactor;
}

[System.Serializable]
public struct ComboObjectInteraction
{
    public string comboTag;
    public int comboCondition;
}