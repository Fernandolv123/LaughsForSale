using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smile_Controller : MonoBehaviour
{
    public Sprite sadSprite;
    public Sprite midSprite;
    public Sprite happySprite;
    private float laughmeter;

    // Start is called before the first frame update
    void Start()
    {
        laughmeter = 50;
    }

    // Update is called once per frame
    void Update()
    {
        switch  (laughmeter){
            case < 30:
                GetComponent<RawImage>().texture = sadSprite.texture;
                break;
            case > 70:
                GetComponent<RawImage>().texture = happySprite.texture;
                break;
            default:
                GetComponent<RawImage>().texture = midSprite.texture;
                break;
        }
    }

    public void OnValueChange(float slider) {
        //Este método debería estar en el GameManager, y se debería acceder mediante instance
        laughmeter = slider;
    }
}
