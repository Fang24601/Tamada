using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    public ObjectId Id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public int numCoins { get; set; }
    public int numEggs { get; set; }
    public int __v { get; set; }

    public User(string name, string password)
    {
        this.name = name;
        this.password = password;
        this.numCoins = 0;
        this.__v = 0;
    }
}
