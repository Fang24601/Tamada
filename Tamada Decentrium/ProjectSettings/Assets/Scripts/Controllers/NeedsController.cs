using System;
using UnityEditor;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public bool isEgg;

    public int food, happiness, love, status, gold, clean, powerful;

    public int foodTickRate, happinessTickRate, loveTickRate,
        statusTickRate, goldTickRate, cleanTickRate, powerfulTickRate;

    public DateTime lastTimeFed, lastTimeHappy, lastTimeLove, lastTimeStatus,
        lastTimeGold, lastTimeClean, lastTimePowerful;

    /*
    private void Awake()
    {
        Initialize(
            100, 100, 100, 100, 100, 100, 100,
            5, 5, 5, 5, 5, 5, 5,
            false
        );
    }
    */

    public void Initialize(
        int food, int happiness, int love, int status, int gold, int clean, int powerful,
        int foodTickRate, int happinessTickRate, int loveTickRate, int statusTickRate,
        int goldTickRate, int cleanTickRate, int powerfulTickRate,
        bool isEgg)
    {

        this.food = food;
        this.happiness = happiness;
        this.love = love;
        this.status = status;
        this.gold = gold; 
        this.clean = clean;
        this.powerful = powerful;

        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.loveTickRate = loveTickRate;
        this.statusTickRate = statusTickRate;
        this.goldTickRate = goldTickRate;
        this.cleanTickRate = cleanTickRate;
        this.powerfulTickRate = powerfulTickRate;

        this.lastTimeFed = DateTime.Now;
        this.lastTimeHappy = DateTime.Now;
        this.lastTimeLove = DateTime.Now;
        this.lastTimeStatus = DateTime.Now;
        this.lastTimeGold = DateTime.Now;
        this.lastTimeClean = DateTime.Now;
        this.lastTimePowerful = DateTime.Now;
        
        this.isEgg = isEgg;

        PetUIController.instance.UpdateImages(food, happiness);
    }

    private void Update()
    {
        if (TimingManager.gameHourTimer < 0)
        {
            if (this.isEgg) return;
            
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeLove(-loveTickRate);
            ChangeStatus(-statusTickRate);
            ChangeGold(-goldTickRate);
            ChangeClean(-cleanTickRate);
            ChangePower(-powerfulTickRate);

            PetUIController.instance.UpdateImages(food, happiness);
        }
    }

    public void StartEggHatching()
    {
        this.isEgg = true;
    }


    public void ChangeFood(int amount)
    {
        this.food += amount;

        if (amount > 0)
        {
            this.lastTimeFed = DateTime.Now;
        }

        if (this.food < 0)
        {
            this.food = 0;
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

    public void ChangeLove(int amount)
    {
        this.love += amount;

        if (amount > 0)
        {
            this.lastTimeLove = DateTime.Now;
        }

        if (this.love < 0)
        {
            PetManager.instance.Die();
        }

        else if (this.love > 100) this.love = 100;
    }

    public void ChangeStatus(int amount)
    {
        this.status += amount;

        if (amount > 0)
        {
            this.lastTimeStatus = DateTime.Now;
        }

        if (this.status < 0)
        {
            PetManager.instance.Die();
        }

        else if (this.status > 100) this.status = 100;
    }

    public void ChangeGold(int amount)
    {
        this.gold += amount;

        if (amount > 0)
        {
            this.lastTimeGold = DateTime.Now;
        }

        if (this.gold < 0)
        {
            PetManager.instance.Die();
        }

        else if (this.gold > 100) this.gold = 100;
    }

    public void ChangeClean(int amount)
    {
        this.clean += amount;

        if (amount > 0)
        {
            this.lastTimeClean = DateTime.Now;
        }

        if (this.clean < 0)
        {
            PetManager.instance.Die();
        }

        else if (this.clean > 100) this.clean = 100;
    }

    public void ChangePower(int amount)
    {
        this.clean += amount;

        if (amount > 0)
        {
            this.lastTimeClean = DateTime.Now;
        }

        if (this.clean < 0)
        {
            PetManager.instance.Die();
        }

        else if (this.clean > 100) this.clean = 100;
    }
}
