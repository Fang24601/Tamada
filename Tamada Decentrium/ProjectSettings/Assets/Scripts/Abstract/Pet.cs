using JetBrains.Annotations;
using MongoDB.Bson;
using System;
//using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Pet
{

    public string owner { get; set; }
    public DateTime lastTimeFed, lastTimeHappy, lastTimeLove, lastTimeStatus,
        lastTimeGold, lastTimeClean, lastTimePowerful;

    public int food, happiness, love, status, gold, clean, powerful;

    public float lastHourTimer {  get; set; }

    public string name { get; set; }

    public string type { get; set; }
    public ObjectId Id { get; set; }
    public Pet(DateTime lastTimeFed, DateTime lastTimeHappy, DateTime lastTimeLove, DateTime lastTimeStatus,
        DateTime lastTimeGold, DateTime lastTimeClean, DateTime lastTimePowerful,
        int food, int happiness, int love, int status, int gold, int clean, int powerful)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeLove = lastTimeLove;  
        this.lastTimeStatus = lastTimeStatus;
        this.lastTimeGold = lastTimeGold;
        this.lastTimeClean = lastTimeClean;
        this.lastTimePowerful = lastTimePowerful;

        this.food = food;
        this.happiness = happiness;
        this.love = love;
        this.status = status;  
        this.gold = gold;
        this.clean = clean;
        this.powerful = powerful;

        this.owner = "";
    }

    public Pet()
    {
        this.lastTimeFed      = DateTime.Now;
        this.lastTimeHappy    = DateTime.Now;
        this.lastTimeLove     = DateTime.Now;
        this.lastTimeStatus   = DateTime.Now;
        this.lastTimeGold     = DateTime.Now;
        this.lastTimeClean    = DateTime.Now;
        this.lastTimePowerful = DateTime.Now;

        this.food      = 100;
        this.happiness = 100;
        this.love      = 100;
        this.status    = 100;
        this.gold      = 100;
        this.clean     = 100;
        this.powerful  = 100;

        this.owner = "";
        this.name = "";
        this.type = "";
    }

    public Pet(string owner, string petName, string petType)
    {
        this.lastTimeFed = DateTime.Now;
        this.lastTimeHappy = DateTime.Now;
        this.lastTimeLove = DateTime.Now;
        this.lastTimeStatus = DateTime.Now;
        this.lastTimeGold = DateTime.Now;
        this.lastTimeClean = DateTime.Now;
        this.lastTimePowerful = DateTime.Now;

        this.food = 100;
        this.happiness = 100;
        this.love = 100;
        this.status = 100;
        this.gold = 100;
        this.clean = 100;
        this.powerful = 100;

        this.name = petName;
        this.owner = owner;
        this.type = petType;
    }

    public void SetNeeds(NeedsController controller)
    {
        this.lastTimeFed = controller.lastTimeFed;
        this.lastTimeHappy = controller.lastTimeHappy;
        this.lastTimeLove = controller.lastTimeLove;
        this.lastTimeStatus = controller.lastTimeStatus;
        this.lastTimeGold = controller.lastTimeGold;
        this.lastTimeClean = controller.lastTimeClean;
        this.lastTimePowerful = controller.lastTimePowerful;

        this.food = controller.food;
        this.happiness = controller.happiness;
        this.love = controller.love;
        this.status = controller.status;
        this.gold = controller.gold;
        this.clean = controller.clean;
        this.powerful = controller.powerful;
    }


    
}
