using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int food, happiness;
    public int foodTickRate, happinessTickRate;
    public DateTime lastTimeFed, lastTimeHappy;

    private void Awake()
    {
        Initialize(100, 100, 3, 1);
    }

    public void Initialize(int food, int happiness,
        int foodTickRate, int happinessTickRate)
    {
        this.lastTimeFed = DateTime.Now;
        this.lastTimeHappy = DateTime.Now;
        this.food = food;
        this.happiness = happiness;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;

        PetUIController.instance.UpdateImages(food, happiness);
    }

    private void Update()
    {
        if(TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            PetUIController.instance.UpdateImages(food, happiness);
        }
    }

    public void ChangeFood(int amount)
    {
        this.food += amount;

        if(amount > 0)
        {
            this.lastTimeFed = DateTime.Now;
        }

        if (this.food < 0)
        {
            PetManager.instance.Die();
        }
        else if (this.food > 100) this.food = 100;
    }

    public void ChangeHappiness(int amount)
    {
        this.happiness += amount;

        if (amount > 0)
        {
            this.lastTimeHappy = DateTime.Now;
        }

        if (this.happiness < 0)
        {
            PetManager.instance.Die();
        }
        else if (this.happiness > 100) this.happiness = 100;
    }

   
}
