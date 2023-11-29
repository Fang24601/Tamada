using System;
using UnityEditor;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    
    public int food, happiness, love, status, gold, clean, powerful;

    public int foodTickRate, happinessTickRate, loveTickRate,
        statusTickRate, goldTickRate, cleanTickRate, powerfulTickRate;

    public DateTime lastTimeFed, lastTimeHappy, lastTimeLove, lastTimeStatus,
        lastTimeGold, lastTimeClean, lastTimePowerful;

    private void Awake()
    {
    }
    public void SetPet(Pet petData)
    {
        this.food = petData.food;
        this.happiness = petData.happiness;
        this.love = petData.love;
        this.status = petData.status;
        this.gold = petData.gold;
        this.clean = petData.clean;
        this.powerful = petData.powerful;

        this.foodTickRate = 3;
        this.happinessTickRate = 3;
        this.loveTickRate = 3;
        this.statusTickRate = 3;
        this.goldTickRate = 3;
        this.cleanTickRate = 3;
        this.powerfulTickRate = 3;

        this.lastTimeFed      = petData.lastTimeFed;
        this.lastTimeHappy    = petData.lastTimeHappy;
        this.lastTimeLove     = petData.lastTimeLove;
        this.lastTimeStatus   = petData.lastTimeStatus;
        this.lastTimeGold     = petData.lastTimeGold;
        this.lastTimeClean    = petData.lastTimeClean;
        this.lastTimePowerful = petData.lastTimePowerful;
    }

    public void Initialize(
        int food, int happiness, int love, int status, int gold, int clean, int powerful,
        int foodTickRate, int happinessTickRate, int loveTickRate, int statusTickRate,
        int goldTickRate, int cleanTickRate, int powerfulTickRate)
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
    }

    private void Update()
    {
        if (TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeLove(-loveTickRate);
            ChangeStatus(-statusTickRate);
            ChangeGold(-goldTickRate);
            ChangeClean(-cleanTickRate);
            ChangePower(-powerfulTickRate);
        }
    }

    public bool IsHappy()
    {
        return (this.food > 75 && this.happiness > 75 &&
                this.love > 75 && this.status > 75 &&
                this.gold > 75 && this.clean > 75 &&
                this.powerful > 75);
    }

    public bool IsSad()
    {
        return (this.food < 25 && this.happiness < 25 &&
                this.love < 25 && this.status < 25 &&
                this.gold < 25 && this.clean < 25 &&
                this.powerful < 25);
    }

    public bool IsDead()
    {
        return (this.food == 0 && this.happiness == 0 &&
                this.love == 0 && this.status == 0 &&
                this.gold == 0 && this.clean == 0 &&
                this.powerful == 0);
    }
    public void ChangeFood(int amount)
    {
        this.food += amount;

        if (amount > 0)
            this.lastTimeFed = DateTime.Now;
        

        if (this.food < 0) this.food = 0;
        else if (this.food > 100) this.food = 100;
    }

    public void ChangeHappiness(int amount)
    {
        Debug.Log("Adding " + amount.ToString() + " To happiness.");
        this.happiness += amount;

        if (amount > 0)
            this.lastTimeHappy = DateTime.Now;

        if (this.happiness < 0) this.happiness = 0;
        else if (this.happiness > 100) this.happiness = 100;
    }

    public void ChangeLove(int amount)
    {
        this.love += amount;

        if (amount > 0)
        {
            this.lastTimeLove = DateTime.Now;
        }

        if (this.love < 0) this.love = 0;
        else if (this.love > 100) this.love = 100;
    }

    public void ChangeStatus(int amount)
    {
        this.status += amount;

        if (amount > 0)
            this.lastTimeStatus = DateTime.Now;

        if (this.status < 0) this.status = 0;
        else if (this.status > 100) this.status = 100;
    }

    public void ChangeGold(int amount)
    {
        this.gold += amount;

        if (amount > 0)
            this.lastTimeGold = DateTime.Now;

        if (this.gold < 0) this.gold = 0;
        else if (this.gold > 100) this.gold = 100;
    }

    public void ChangeClean(int amount)
    {
        this.clean += amount;

        if (amount > 0)
            this.lastTimeClean = DateTime.Now;

        if (this.clean < 0) this.clean = 0;
        else if (this.clean > 100) this.clean = 100;
    }

    public void ChangePower(int amount)
    {
        this.powerful += amount;

        if (amount > 0)
            this.lastTimePowerful = DateTime.Now;

        if (this.powerful < 0) this.powerful = 0;
        else if (this.powerful > 100) this.powerful = 100;
    }
}
