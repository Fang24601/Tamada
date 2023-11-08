using UnityEngine;
using UnityEngine.UI;


public class PetUIController : MonoBehaviour
{
    public Image foodImage, happinessImage;
    public static PetUIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the Scene");
    }



    public void UpdateImages(int food, int happiness)
    {
        this.foodImage.fillAmount = (float)food / 100;
        this.happinessImage.fillAmount = (float)happiness / 100;
        
    }
}
