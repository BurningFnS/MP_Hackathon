using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int endlessRunnerCoins;
    public int currentCoins;
    public int cashAtHand;
    public Text coinText;
    public Text ageText;

    public int currentAge;
    public int defaultAge = 25;

    public Bank bank;
    public GameObject negativeBalancePanel;
    public GameObject losePanel;
    public GameObject retireButton;
    public Text alertText;
    public Image coinImageComponent;
    public Sprite negativeCoinSprite;
    public Sprite positiveCoinSprite;
    public InvestmentManager investment;

    public Color redColor;
    public Color blueColor;

    public float animationDuration = 2.0f; // Duration of the animation in seconds

    private int targetAmount; // The target money amount after animation
    private int initialAmount; // The initial money amount at the start of animation
    private float animationStartTime; // The time when the animation started

    private int currentAmount; // The current displayed money amount

    void Start()
    {
        endlessRunnerCoins = PlayerPrefs.GetInt("CollectedCoins");
        cashAtHand = PlayerPrefs.GetInt("CurrentCoins");
        currentAge = PlayerPrefs.GetInt("CurrentAge");

        currentCoins = endlessRunnerCoins + cashAtHand;

        // Optionally, you can update the player's coins display or any other relevant UI elements
        AnimateToAmount(cashAtHand, currentCoins);
        ageText.text = "" + currentAge;
        if (currentAge >= 65)
        {
            retireButton.SetActive(true);
        }
    }

    private void Update()
    {
        UpdateCoinDisplay();
    }

    public void AnimateToAmount(int currentCoins, int newAmount)
    {
        targetAmount = newAmount;
        initialAmount = currentCoins;
        animationStartTime = Time.time;

        // Start the animation coroutine
        StartCoroutine(AnimateMoney());
    }

    private IEnumerator AnimateMoney()
    {
        while (Time.time - animationStartTime < animationDuration)
        {
            float progress = (Time.time - animationStartTime) / animationDuration;
            int animatedAmount = Mathf.RoundToInt(Mathf.Lerp(initialAmount, targetAmount, progress));
            UpdateMoneyText(animatedAmount);
            yield return null;
        }

        // Ensure the final amount is correct
        UpdateMoneyText(targetAmount);
    }

    private void UpdateMoneyText(int amount)
    {
        currentCoins = amount;
        coinText.text = "" + amount.ToString();
    }


    public void UpdateCoinDisplay()
    {
        // Code to update the UI display of the collected coins
        // For example, you could set the text of a UI Text component to show the totalCoins value.
        if (currentCoins < 0)
        {
            coinImageComponent.sprite = negativeCoinSprite;
            coinText.color = redColor;
        }
        else
        {
            coinImageComponent.sprite = positiveCoinSprite;
            coinText.color = blueColor;
        }
        //coinText.text = "" + currentCoins;
    }

    public void Continue()
    {
        if(currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if(currentCoins >= 0)
        {
            PlayerPrefs.SetInt("CurrentCoins", currentCoins);
            PlayerPrefs.SetInt("CurrentAge", currentAge + 5);

            PlayerPrefs.SetFloat("BankOfRashidBalance", bank.bankBalance[0]);
            PlayerPrefs.SetFloat("BankOfJunnieBalance", bank.bankBalance[1]);
            PlayerPrefs.SetFloat("BankOfFooBalance", bank.bankBalance[2]);

            PlayerPrefs.SetFloat("GameInvestmentBalance", investment.investmentBalance[0]);
            PlayerPrefs.SetFloat("BusinessInvestmentBalance", investment.investmentBalance[1]);
            PlayerPrefs.SetFloat("GymInvestmentBalance", investment.investmentBalance[2]);

            SceneManager.LoadScene("Level");
        }
    }
 
    public void Proceed()
    {
        losePanel.SetActive(true);
    }

    public void Return()
    {
        negativeBalancePanel.SetActive(false);
    }
}
