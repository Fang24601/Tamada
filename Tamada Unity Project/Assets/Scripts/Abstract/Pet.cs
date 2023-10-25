using System;

public class Pet 
{
    public DateTime lastTimeFed, lastTimeHappy;
    public int food, happiness;

    public Pet(DateTime lastTimeFed, DateTime lastTimeHappy, 
        int food, int happiness)
    {
        this.lastTimeFed = lastTimeFed;
        this.lastTimeHappy = lastTimeHappy;
        this.food = food; 
        this.happiness = happiness;
    }
}
