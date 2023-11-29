using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public TMP_InputField addPetName;
    public NeedsController needs;
    public PetController pet;

    public Pet petData;

    public float petSaveTimer, originalPetSaveTimer;
    public float petMoveTimer, originalPetMoveTimer;
    public Transform[] waypoints;

    public static PetManager instance;

    private Sprite currSprite;
    public Sprite derm;
    public Sprite moko;
    public Sprite orah;
    public Sprite whoman;

    public Animator animator;
    public AnimatorController animContr;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in the Scene");

        this.originalPetMoveTimer = this.petMoveTimer;
        this.originalPetSaveTimer = this.petSaveTimer;
        this.petData = DatabaseManager.instance.GetUserActivePet();
        needs.SetPet(this.petData);
        this.ChooseSprite();
    }

    private void ChooseSprite()
    {
        string spriteName = DatabaseManager.instance.GetUserActivePet().type;
        Debug.Log("Sprite type: " + spriteName);
        if(spriteName == "derm")
        {
            Debug.Log("Selecting Derm");
            this.pet.SetSprite(this.derm);
        }
        else if (spriteName == "moko")
        {
            Debug.Log("Selecting moko");
            this.pet.SetSprite(this.moko);
        }
        else if (spriteName == "orah")
        {
            Debug.Log("Selecting orah");
            this.pet.SetSprite(this.orah);
        }
        else if (spriteName == "whoman")
        {
            Debug.Log("Selecting whoman");
            this.pet.SetSprite(this.whoman);
        }
    }


    private void Update()
    {
        if (this.petMoveTimer > 0.0f)
        {
            this.petMoveTimer -= Time.deltaTime;
        }
        else if (this.petMoveTimer != -1.0f)
        {
            MovePetToRandomWaypoint();
            this.petMoveTimer = this.originalPetMoveTimer;
        }

        if (this.petSaveTimer > 0.0f)
        {
            this.petSaveTimer -= Time.deltaTime;
        }
        else
        {
            this.petData.SetNeeds(this.needs);
            DatabaseManager.instance.UpdateActivePet(this.petData);
            this.petSaveTimer = this.originalPetSaveTimer;
        }

        if (this.needs.IsHappy())
        {
            // Change Sprite to +75 sprite

            this.pet.Happy();
        }
        else if (this.needs.IsSad())
        {
            // Change Sprite to -25 sprite
            this.pet.Sad();
        }
        else
        {
            // Change to default sprite
            this.pet.Neutral();
        }

        if (this.needs.IsDead())
        {
            this.Die();
        }
    }
    

    private void MovePetToRandomWaypoint()
    {
        int randomWaypoint = Random.Range(0, this.waypoints.Length);
        this.pet.Move(this.waypoints[randomWaypoint].position);
    }

    public void Die()
    {
        Debug.Log("Dead");
    }

    public void AddPet()
    {
        if (this.addPetName.text == null || this.addPetName.text == "") return;
        Pet newPet = new Pet(DatabaseManager.instance.getCurrUser().name, this.addPetName.text, "whoman");
        DatabaseManager.instance.InsertDaycarePet(newPet);
    }
}
