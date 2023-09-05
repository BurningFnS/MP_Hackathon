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
    public bool hasProperty = false;
    public bool hasApartment = false;
    public bool hasLanded = false;
    public bool hasCondominium = false;
    public int condominiumPrice = 3800;
    public int landedPrice = 7200;
    public float sellAmt;
    public float sellPercentage;
    // Start is called before the first frame update
    void Start()
    {
        //Default property is apartment
        PlayerPrefs.SetInt("Apartment", 1);
        // Initialize property ownership based on PlayerPrefs
        if (PlayerPrefs.GetInt("Apartment") == 1)
        {
            apartmentSellButton.SetActive(true);
            hasProperty = true;
            hasApartment = true;
        }
        if (PlayerPrefs.GetInt("Condo") == 1)
        {
            condominiumSellButton.SetActive(true);
            hasProperty = true;
            hasCondominium = true;
        }
        if (PlayerPrefs.GetInt("Landed") == 1)
        {
            landedSellButton.SetActive(true);
            hasProperty = true;
            hasLanded = true;
        }
    }

    // Handle the Apartment purchase button click
    public void ApartmentButton()
    {
        if (hasApartment)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You have already purchased \n this property!";
        }
        else if (hasCondominium || hasLanded)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You already own \n a property!";
        }
        else
        {
            apartmentSellButton.SetActive(true);
            hasProperty = true;
            PlayerPrefs.SetInt("Apartment", 1);
            hasApartment = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Apartment Property!";
        }
        Debug.Log("hasApartment: " + hasApartment);
        Debug.Log(hasProperty);
    }
    // Handle the Condominium purchase button click
    public void CondominiumButton()
    {
        Debug.Log(hasApartment + " Have apartment");
        if (hasCondominium)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You have already purchased \n this property!";
        }
        else if (hasProperty)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You already own \n a property!";
        }
        else if (coinManager.currentCoins < condominiumPrice)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You do not have \n enough  money to purchase \n this property!";
        }
        else
        {
            condominiumSellButton.SetActive(true);
            PlayerPrefs.SetInt("Condo", 1);
            hasProperty = true;
            hasCondominium = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have \n Purchased The \n Condominium Property!";
            coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - condominiumPrice);
        }
        Debug.Log("hasCondominium: " + hasCondominium);
        Debug.Log(hasProperty);
    }
    // Handle the Landed purchase button click
    public void LandedButton()
    {
        if (hasLanded)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You have already purchased \n this property!";
        }
        else if (hasProperty)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You already own \n a property!";
        }
        else if (coinManager.currentCoins < landedPrice)
        {
            StartCoroutine(FailedPurchaseProperty());
            failedPurchaseText.text = "You do not have enough \n money to purchase this property!";
        }
        else
        {
            landedSellButton.SetActive(true);
            hasLanded = true;
            PlayerPrefs.SetInt("Landed", 1);
            hasProperty = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Landed Property!";          
            coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins - landedPrice);
        }
        Debug.Log("hasLanded: " + hasLanded);
        Debug.Log(hasProperty);
    }
    //Handles the sale of property click
    public void SellPropertyButton()
    {
        sellPercentage = 0.8f;
       
        if (hasApartment)
        {
            apartmentSellButton.SetActive(false);
            PlayerPrefs.SetInt("Apartment", 0);
            hasApartment = false;
            coinManager.currentCoins += 0;
        }
        if (hasCondominium)
        {
            condominiumSellButton.SetActive(false);
            sellAmt = sellPercentage * condominiumPrice;
            PlayerPrefs.SetInt("Condo", 0);
            hasCondominium = false;
            coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + Mathf.RoundToInt(sellAmt));
            Debug.Log(sellPercentage);
        }
        if (hasLanded)
        {
            landedSellButton.SetActive(false);
            sellAmt = sellPercentage * landedPrice;
            PlayerPrefs.SetInt("Landed", 0);
            hasLanded = false;
            coinManager.AnimateToAmount(coinManager.currentCoins, coinManager.currentCoins + Mathf.RoundToInt(sellAmt));

        }
        hasProperty = hasApartment || hasCondominium || hasLanded;
        Debug.Log(hasProperty);
    }
    //Coroutine to display purchase of property panel
    IEnumerator SuccessfullyPurchasedProperty()
    {
        purchasedPropertyBG.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        purchasedPropertyBG.SetActive(false);
    }
    //Coroutine to display failure to purchase of property panel
    IEnumerator FailedPurchaseProperty()
    {
        failedPurchaseBG.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        failedPurchaseBG.SetActive(false);

    }
}