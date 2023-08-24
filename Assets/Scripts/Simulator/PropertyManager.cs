using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropertyManager : MonoBehaviour
{
    public GameObject purchasedPropertyBG;
    public GameObject failedPurchaseBG;
    public GameObject apartmentSellButton;
    public GameObject condominiumSellButton;
    public GameObject landedSellButton;
    public Text purchasedPropertyText;
    public Text failedPurchaseText;
    public CoinManager coinManager;
    private bool hasProperty = false;
    private bool hasApartment = false;
    private bool hasLanded = false;
    private bool hasCondominium = false;
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
        if (hasApartment)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You have already purchased \n this property!";
        }
        else if (hasProperty)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You already own \n a property!";
        }
        else
        {
            apartmentSellButton.SetActive(true);
            hasProperty = true;
            hasApartment = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Apartment Property!";
        }
        Debug.Log(hasProperty);
    }
    public void CondominiumButton()
    {
        if (!hasCondominium && coinManager.currentCoins >= 4000)
        {
            condominiumSellButton.SetActive(true);
            hasCondominium = true;
            hasProperty = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Condominium Property!";
            coinManager.currentCoins -= 4000;
        }
        else if (hasProperty)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You already own \n a property!";
        }
        else if (hasCondominium)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You have already purchased \n this property!";
        }
        else
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You do not have enough \n money to purchase this property!";
        }
    }
    public void LandedButton()
    {
        if (!hasLanded && coinManager.currentCoins >= 5500)
        {
            landedSellButton.SetActive(true);
            hasLanded = true;
            hasProperty = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Landed Property!";
            coinManager.currentCoins -= 5500;
        }
        else if (hasProperty)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You already own \n a property!";
        }
        else if (hasLanded)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You have already purchased \n this property!";
        }
        else
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You do not have enough \n money to purchase \n this property!";
        }
    }
    public void SellPropertyButton()
    {
        if(hasApartment)
        {
            hasProperty = false;
            coinManager.currentCoins += 0;
            apartmentSellButton.SetActive(false);
        }
        if(hasCondominium)
        {
            hasProperty = false;
            coinManager.currentCoins += 3500;
            condominiumSellButton.SetActive(false);
        }
        if(hasLanded)
        {
            hasProperty = false;
            coinManager.currentCoins += 5000;
            landedSellButton.SetActive(false);
        }
        Debug.Log(hasProperty);
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

