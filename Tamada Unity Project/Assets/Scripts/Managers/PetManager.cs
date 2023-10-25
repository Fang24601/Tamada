using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public NeedsController needs;
    public PetController pet;
    public float petMoveTimer, originalPetMoveTimer;
    public Transform[] waypoints;

    public static PetManager instance;

    private void Awake()
    {
        this.originalPetMoveTimer = this.petMoveTimer;

        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetManager in the Scene");
    }
    private void Update()
    {
        if(this.petMoveTimer > 0.0f)
        {
            this.petMoveTimer -= Time.deltaTime; 
        }
        else
        {
            MovePetToRandomWaypoint();
            this.petMoveTimer = this.originalPetMoveTimer;
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
}
