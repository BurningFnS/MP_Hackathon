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
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Apartment") == 1)
        {
            ApartmentButton();
            hasApartment = true;
        }
        if (PlayerPrefs.GetInt("Condo") == 1)
        {
            CondominiumButton();
            hasCondominium = true;
        }
        if(PlayerPrefs.GetInt("Landed") == 1)
        {
            LandedButton();
            hasLanded = true;
        }
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
            PlayerPrefs.SetInt("Apartment", 1);
            hasApartment = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Apartment Property!";
        }
        Debug.Log("hasApartment: " + hasApartment);
        Debug.Log(hasProperty);
    }
    public void CondominiumButton()
    {
        Debug.Log(hasApartment +" Have apartment");
        if (!hasCondominium && coinManager.currentCoins >= 4000 && !hasApartment && !hasLanded)
        {
            condominiumSellButton.SetActive(true);
            hasCondominium = true;
            PlayerPrefs.SetInt("Condo", 1);
            hasProperty = true;
            StartCoroutine(SuccessfullyPurchasedProperty());
            purchasedPropertyText.text = "You Have Purchased " + "\n" + "The Condominium Property!";
            coinManager.currentCoins -= 4000;
        }
        else if (hasProperty )
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
        Debug.Log("hasCondominium: " + hasCondominium);
        Debug.Log(hasProperty);
    }
    public void LandedButton()
    {
        if (!hasLanded && coinManager.currentCoins >= 5500 && !hasApartment && !hasCondominium)
        {
            landedSellButton.SetActive(true);
            hasLanded = true;
            PlayerPrefs.SetInt("Landed", 1);
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
        Debug.Log("hasLanded: " + hasLanded);
        Debug.Log(hasProperty);
    }
    public void SellPropertyButton()
    {
        if(hasApartment)
        {
            PlayerPrefs.SetInt("Apartment", 0);
            hasApartment = false;
            hasProperty = false;
            coinManager.currentCoins += 0;
            apartmentSellButton.SetActive(false);
        }
        if(hasCondominium)
        {
            PlayerPrefs.SetInt("Condo", 0);
            hasCondominium = false;
            hasProperty = false;
            coinManager.currentCoins += 3500;
            condominiumSellButton.SetActive(false);
        }
        if(hasLanded)
        {
            PlayerPrefs.SetInt("Landed", 0);
            hasLanded =false;
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

