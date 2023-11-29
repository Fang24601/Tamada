using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using UnityEngine.SocialPlatforms;
using System.Data.Common;

public class DatabaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DatabaseManager instance;

    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<User> userCollection;
    private IMongoCollection<Pet> activePetCollection;
    private IMongoCollection<Pet> daycareCollection;
    private IMongoCollection<Pet> cemeteryCollection;

    private User currUser;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    public User getCurrUser()
    {
        return this.currUser;
    }

    private void Start()
    {
        this.InitializeDB();
    }

    
    public void SwapPet(List<Pet> petsInDaycare, string selectedPet)
    {
        Pet newDaycarePet = this.GetUserActivePet();
        this.activePetCollection.FindOneAndDelete(pet => pet.owner == this.currUser.name && pet.name == newDaycarePet.name);


        Pet newActivePet = petsInDaycare.Find(pet => pet.name == selectedPet);
        this.daycareCollection.FindOneAndDelete(pet => pet.owner == this.currUser.name && pet.name == newActivePet.name);

        this.InsertActivePet(newActivePet);
        this.InsertDaycarePet(newDaycarePet);
    }
   
    public void InitializeDB()
    {
        this.client = new MongoClient();
        this.db = this.client.GetDatabase("TamadaDB");

        this.userCollection = this.db.GetCollection<User>("Users");
        this.activePetCollection = this.db.GetCollection<Pet>("ActivePet");
        this.daycareCollection = this.db.GetCollection<Pet>("Daycare");
        this.cemeteryCollection = this.db.GetCollection<Pet>("Cemetery");
    }

    public void DecEggCount()
    {
        this.currUser.numEggs--;
        this.UpdateUser(this.currUser);
    }
    public void IncEggCount()
    {
        if (this.currUser.numCoins >= 500)
        {
            this.currUser.numCoins -= 500;
            this.currUser.numEggs++;
            this.UpdateUser(this.currUser);
        } 
    }
    public void Logout()
    {
        this.currUser = null;
    }

    public bool Create(string username, string password)
    {
        if (password == "") return false;

        List<User> users = this.userCollection.Find(user => user.name == username).ToList();

        if(users.Count > 0)
        {
            return false;
        }
        else 
        {
            User newUser = new User(username, password);
            this.userCollection.InsertOne(newUser);
            return true;
        }
    }

    public bool Login(string username, string password)
    {
        List<User> users = this.userCollection.Find(user => user.name == username && user.password == password).ToList();

        if (users.Count == 0)
        {
            return false;
        }
        else
        {
            this.currUser = users[0];
            return true;
        }
    }
    public void InitializeUser()
    {
        List<Pet> userPets = this.activePetCollection.Find(pet => pet.owner == this.currUser.name).ToList();
    }
    public List<Pet> GetUserPetsInDaycare()
    {
        List<Pet> userPets = this.daycareCollection.Find(pet => pet.owner == this.currUser.name).ToList();
        return userPets;
    }

    public List<Pet> GetUserPetsInCemetery()
    {
        List<Pet> userPets = this.cemeteryCollection.Find(pet => pet.owner == this.currUser.name).ToList();
        return userPets;
    }

    public int GetUserCoins()
    {
        return this.currUser.numCoins;
    }

    public Pet GetUserActivePet()
    {
        List<Pet> userPets = this.activePetCollection.Find(pet => pet.owner == this.currUser.name).ToList();
        if (userPets.Count == 0)
        {
            return null;
        }
        else
        {
            return userPets[0];
        }
    }

    
    public void UpdateUser(User userData)
    {
        this.userCollection.FindOneAndReplace((user) => user.Id == userData.Id, userData);
    }
    public void UpdateActivePet(Pet petData)
    {
        Pet foundPet = this.activePetCollection.FindOneAndReplace(pet => pet.Id == petData.Id, petData);
    }

    public void InsertActivePet(Pet petData)
    {
        
        if (this.GetUserActivePet() == null)
        {
            this.activePetCollection.InsertOne(petData);
        }
        else
        {
            List<Pet> userPets = this.activePetCollection.Find(pet => pet.owner == this.currUser.name).ToList();
            Pet userActivePet = userPets[0];

            this.activePetCollection.FindOneAndDelete(pet => pet.Id == userActivePet.Id);
            this.activePetCollection.InsertOne(petData);
            this.daycareCollection.InsertOne(userActivePet);

        }
    }

    public void InsertCemeteryPet(Pet petData)
    {
        this.cemeteryCollection.InsertOne(petData);
    }

    public void InsertDaycarePet(Pet petData)
    {
        this.daycareCollection.InsertOne(petData);
    }

}
