using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropertyManager : MonoBehaviour
{
    public GameObject purchasedPropertyBG;
    public GameObject failedPurchaseBG;
    public Text purchasedPropertyText;
    public CoinManager coinManager;
    // Start is called before the first frame update
    void Start()
    {
        coinManager.cashAtHand = PlayerPrefs.GetInt("CurrentCoins");
        coinManager.totalCoins = PlayerPrefs.GetInt("CollectedCoins");
        coinManager.currentCoins = coinManager.totalCoins + coinManager.cashAtHand;
    }
    private void Update()
    {
        coinManager.UpdateCoinDisplay();
    }
    public void ApartmentButton()
    {
        StartCoroutine(SuccessfullyPurchasedProperty());
        purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Apartment Property!";
    }
    public void CondominiumButton()
    {
        if(coinManager.currentCoins >= 4000)
        {
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Condominium Property!";
            coinManager.currentCoins -= 4000;
        }
        else
        {
            StartCoroutine(FailedPurchaseProperty());
        }
    }
    public void LandedButton()
    {
        if (coinManager.currentCoins >= 5500)
        {
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Landed Property!";
            coinManager.currentCoins -= 5500;
        }
        else
        {
            StartCoroutine(FailedPurchaseProperty());
        }
    }
    IEnumerator SuccessfullyPurchasedProperty()
    {
        purchasedPropertyBG.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        purchasedPropertyBG.SetActive(false);
    }
    IEnumerator FailedPurchaseProperty()
    {
        failedPurchaseBG.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        failedPurchaseBG.SetActive(false);
       
    }
}
