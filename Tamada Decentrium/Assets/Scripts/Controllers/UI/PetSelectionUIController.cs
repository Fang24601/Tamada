using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSelectionUIController : MonoBehaviour
{
    public int petSelected;

    private void Awake()
    {
        this.petSelected = -1;
        Debug.Log("Awake");
    }

    public void SetPetSelected(int petSelected)
    {
        this.petSelected = petSelected;
        Debug.Log(this.petSelected.ToString());
    }
}
