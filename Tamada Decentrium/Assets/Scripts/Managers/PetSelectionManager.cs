using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetSelectionManager : MonoBehaviour
{
    public static PetSelectionManager instance;

    public TMP_InputField petName;
    public SpriteRenderer petImage;

    public Sprite derm;
    public Sprite moko;
    public Sprite orah;
    public Sprite whoman;

    Pet newPet;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one DatabaseManager in the Scene");
        }
    }

    public void HatchEgg()
    {
        this.newPet = new Pet(DatabaseManager.instance.getCurrUser().name, "", "");
        // SET SPRITE TO RANDOMLY CHOSEN SPRITE

        System.Random rd = new System.Random();

        double randNum = rd.NextDouble();

        if (randNum <= 0.03)
        {
            this.petImage.sprite = whoman;
            this.newPet.type = "whoman";
        }
        else if (randNum <= 0.33)
        {
            this.petImage.sprite = derm;
            this.newPet.type = "derm";
        }
        else if (randNum <= .64)
        {
            this.petImage.sprite = moko;
            this.newPet.type = "moko";
        }
        else if (randNum <= 1.0)
        {
            this.petImage.sprite = orah;
            this.newPet.type = "orah";
        }

    }


    public void Finish()
    {
        this.newPet.name = this.petName.text;
        DatabaseManager.instance.InsertActivePet(this.newPet);
        SceneManager.LoadScene("Main");
    }
}

