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
        
        Debug.Log(randNum.ToString());

    }
}
