using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private bool active = false;
    private SpriteRenderer sprite;
    private bool customerReady;
    public Sprite[] reacciones;
    private void Awake()
    {
        StartCoroutine("FadeIn");
        sprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        customerReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active){
            sprite.enabled = false;
        } else {

            sprite.enabled = true;
            //Si el fadeIn no ha termiando, no se pasar� de cliente
            if(Input.GetKey(KeyCode.W) && customerReady)
            {
                StartCustomerOut();
            }
        }
    }
    public void CustomerOut(){
        //Metodo que pasar� de cliente y lo eliminar� de la lista
        active = false;
        GameManager.instance.atendingCustomer=false;
        Destroy(gameObject);
    }

    public void StartCustomerOut()
    {
        StartCoroutine("FadeOut");
        Invoke("CustomerOut", 1f);
    }

    public void ChangeActive(bool change){
        //Este es el m�todo que llamar� el GameManager para dar paso a un Cliente
        active = change;
    }
    public bool GetActive(){
        return active;
    }

    IEnumerator FadeOut()
    {
        //M�todo utilizado para hacer desaparecer a los clientes
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, i);
            yield return null;
        }
    }

    IEnumerator FadeIn()
    {
        //M�todo usado para hacer aparecer a los clientes
        while (!active) {
            yield return null;
        }
        for (float i = 0; i <= 1f; i += Time.deltaTime/2f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, i);
            yield return null;
        }
        customerReady = true;
    }
}