using UnityEngine;
using UnityEngine.UI;


public class PetUIController : MonoBehaviour
{
    public static PetUIController instance;

    public GameObject hatchButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the Scene");

        int numEggs = DatabaseManager.instance.getCurrUser().numEggs;
        if ( numEggs > 0 )
        {
            hatchButton.SetActive(true);
        }
        else if (numEggs == 0)
        {
            hatchButton.SetActive(false);
        }
    }

    public void DecrementEgg()
    {
        DatabaseManager.instance.DecEggCount();
    }

    public void Logout()
    {
        DatabaseManager.instance.Logout();
    }

}
