using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PetSelectionUIController : MonoBehaviour
{
    public int petSelected;

    private void Awake()
    {
        this.petSelected = -1;
        Debug.Log("Awake");
    }

    public void RandomPet()
    {
        System.Random rd = new System.Random();

        double randNum = rd.NextDouble();
        
        if(randNum <= 0.03)
        {
            Debug.Log(".03");
        }
        else if (randNum <= 0.33)
        {
            Debug.Log(".33");
        }
        else if (randNum <= .64)
        {
            Debug.Log(".64");
        }
        else if (randNum <= 1.0)
        {
            Debug.Log("1.0");
        }
    }
}
