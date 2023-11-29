using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DaycareUIController : MonoBehaviour
{
    public GameObject buttonParent;
    public GameObject buttonPrefab;
    public GameObject swapButton;

    public List<Pet> petList;

    public string selectedPet;

    void Start()
    {
        this.selectedPet = "none";
        this.petList = DatabaseManager.instance.GetUserPetsInDaycare();

        if (this.petList.Count == 0)
        {
            swapButton.SetActive(false);
        }

        Debug.Log(this.petList.Count + " number of pets in daycare");

        for (int i = 0; i < this.petList.Count; i++)
        {
            GameObject newButton = Instantiate(this.buttonPrefab, this.buttonParent.transform);
            newButton.transform.SetParent(this.buttonParent.transform);
            string petName = this.petList[i].name;
            newButton.GetComponent<Button>().onClick.AddListener(() => this.SelectPet(petName));
            newButton.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = this.petList[i].name;
        }
    }

    private void UpdatePetList()
    {
        foreach (Transform child in this.buttonParent.transform)
        {
            Destroy(child.gameObject);
        }

        this.petList = DatabaseManager.instance.GetUserPetsInDaycare();
        for (int i = 0; i < this.petList.Count; i++)
        {
            GameObject newButton = Instantiate(this.buttonPrefab, this.buttonParent.transform);
            newButton.transform.SetParent(this.buttonParent.transform);
            string petName = this.petList[i].name;
            newButton.GetComponent<Button>().onClick.AddListener(() => this.SelectPet(petName));
            newButton.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = this.petList[i].name;
        }
    }

    public void SelectPet(string petName)
    {
        Debug.Log("Selected Pet: " + petName);
        this.selectedPet = petName;
    }

    public void SwapPet()
    {
        if(this.selectedPet == "none") { return; }

        DatabaseManager.instance.SwapPet(this.petList, this.selectedPet);
        this.UpdatePetList();
        this.selectedPet = "none";
    }

    // Update is called once per frame
    void Update()
    {

    }
}