using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledorDisabled : MonoBehaviour
{
    public GameObject petSelectionUI;
    public GameObject petUI;
    public GameObject marketUI;
    public GameObject minigameUI;
    public GameObject daycareUI;
    public GameObject viewTamadaUI;


    public void ConfirmPet()
    {
        this.petSelectionUI.SetActive(false);
        this.petUI.SetActive(true);
    }

   
}
