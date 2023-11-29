using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketUIController : MonoBehaviour
{

    public TMP_Text coinText;
    
    private void Start()
    {
        coinText.text = DatabaseManager.instance.GetUserCoins().ToString();
    }

    private void Update()
    {
        coinText.text = DatabaseManager.instance.GetUserCoins().ToString();
    }

    public void PurchaseEgg()
    {
        DatabaseManager.instance.IncEggCount();
    }
}
