using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropertyManager : MonoBehaviour
{
    public GameObject purchasedPropertyBG;
    public Text purchasedPropertyText;
    public CoinManager coinManager;
    // Start is called before the first frame update
    void Start()
    {
        coinManager.cashAtHand = PlayerPrefs.GetInt("CurrentCoins");
        coinManager.totalCoins = PlayerPrefs.GetInt("CollectedCoins");
        coinManager.currentCoins = coinManager.totalCoins + coinManager.cashAtHand;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ApartmentButton()
    {
        purchasedPropertyBG.SetActive(true);
        purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Apartment Property!";

    }
    public void CondominiumButton()
    {

    }
    public void LandedButton()
    {

    }
}
