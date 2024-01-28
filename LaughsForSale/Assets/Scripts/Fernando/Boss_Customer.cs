using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Customer : Customer
{
    private int lives = 2;
    // Start is called before the first frame update
    protected override void Start()
    {
        lives = 2;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void StartCustomerOut(float pointsResult)
    {
        lives--;
        if (lives == 0)
        {
            base.StartCustomerOut(pointsResult);
        }
        else
        {
            MainGameScript.instance.SetLaughmeter(pointsResult);
        }
    }
}
