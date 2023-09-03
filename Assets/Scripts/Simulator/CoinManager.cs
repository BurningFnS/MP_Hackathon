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
    private int interceptedAmount;

    private int currentAmount; // The current displayed money amount


    // Variables for confirmation.
    public GameObject confirmationPanel;
    public Text _MoneyEarned, _Expenditures, _Tips;
    public InsuranceManager insuranceManager;

    public AudioSource soundSource; // Reference to the AudioSource component
    public AudioClip buttonSound;   // The sound clip to play
    private bool soundPlaying;       // Flag to track if sound is currently playing

    private Coroutine currentAnimationCoroutine;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = buttonSound;
    }

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

    public void AnimateToAmount(int beforeAmount, int newAmount)
    {
        // If there's a running animation coroutine, stop it.
        if (currentAnimationCoroutine != null)
        {
            StopCoroutine(currentAnimationCoroutine);
            initialAmount = PlayerPrefs.GetInt("InterceptedAmount");
            targetAmount = newAmount;
            animationStartTime = Time.time;
            Debug.Log("target amount if intercepted: " + targetAmount);
            Debug.Log("initial amount if intercepted: " + initialAmount);
            currentAnimationCoroutine = StartCoroutine(AnimateMoney());
        }
        else
        {
            targetAmount = newAmount;
            initialAmount = beforeAmount;
            animationStartTime = Time.time;
            PlayerPrefs.SetInt("InterceptedAmount", targetAmount);
            currentCoins = newAmount;
            // Start the animation coroutine
            Debug.Log("target amount if not intercepted: " + targetAmount);
            Debug.Log("initial amount if not intercepted: " + initialAmount);
            currentAnimationCoroutine = StartCoroutine(AnimateMoney());
        }


    }

    public void TestAnimateToAmount(int beforeAmount, int change)
    {
        //// If there's a running animation coroutine, stop it.
        //if (currentAnimationCoroutine != null)
        //{
        //    StopCoroutine(currentAnimationCoroutine);
        //    initialAmount = PlayerPrefs.GetInt("InterceptedAmount");
        //    targetAmount = newAmount;
        //    animationStartTime = Time.time;
        //    Debug.Log("target amount if intercepted: " + targetAmount);
        //    Debug.Log("initial amount if intercepted: " + initialAmount);
        //    currentAnimationCoroutine = StartCoroutine(AnimateMoney());
        //}
        //else
        //{
        //    targetAmount = newAmount;
        //    initialAmount = beforeAmount;
        //    animationStartTime = Time.time;
        //    PlayerPrefs.SetInt("InterceptedAmount", targetAmount);
        //    currentCoins = newAmount;
        //    // Start the animation coroutine
        //    Debug.Log("target amount if not intercepted: " + targetAmount);
        //    Debug.Log("initial amount if not intercepted: " + initialAmount);
        //    currentAnimationCoroutine = StartCoroutine(AnimateMoney());
        //}
        targetAmount = beforeAmount + change;
        initialAmount = beforeAmount;
        animationStartTime = Time.time;
        currentCoins = targetAmount;
        currentAnimationCoroutine = StartCoroutine(AnimateMoney());

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

        // Set the currentAnimationCoroutine to null to indicate that it's finished.
        currentAnimationCoroutine = null;
    }

    private void UpdateMoneyText(int amount)
    {
        //currentCoins = amount;
        if(amount >= 1000000)
        {
            double amountInMillions = amount / 1000000.0;
            coinText.text = amountInMillions.ToString("0.##") + "M";
        }
        else if(amount >= 100000)
        {
            coinText.text = "" + (amount / 1000) + "K";
        }
        else
        {
            coinText.text = "" + amount.ToString();
        }
        
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
    public void Confirmation()
    {
        // This function is to open the Continue panel under "ClickedOnCanvas".
        // It contains a portion of the code from the Continue function
        // as it is dumb for users to be allowed to confirm if they can not proceed.
        if (currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if (currentCoins >= 0)
        {
            confirmationPanel.SetActive(true);

            insuranceManager.InsuranceUpdate();

            _MoneyEarned.text = "$" + (PlayerPrefs.GetInt("Salary") * 5);
            Debug.Log("total insurance expenses: " + InsuranceManager.totalInsuranceExpenses);
            _Expenditures.text = "$" + (PlayerPrefs.GetInt("WaterBill") + PlayerPrefs.GetInt("ElectricalBill") + InsuranceManager.totalInsuranceExpenses);
            _Tips.text = "Tips: " + Tips.TipArray[Random.Range(0, Tips.TipArray.Length)];

        }
    }

    public void CloseConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    public void Continue()
    {
        if (currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if (currentCoins >= 0)
        {
            confirmationPanel.SetActive(false);

            PlayerPrefs.SetInt("CurrentCoins", currentCoins);
            PlayerPrefs.SetInt("CurrentAge", currentAge + 5);

            PlayerPrefs.SetFloat("BankOfRashidBalance", bank.bankBalance[0]);
            PlayerPrefs.SetFloat("BankOfJunnieBalance", bank.bankBalance[1]);
            PlayerPrefs.SetFloat("BankOfFooBalance", bank.bankBalance[2]);

            PlayerPrefs.SetFloat("GameInvestmentBalance", investment.investmentBalance[0]);
            PlayerPrefs.SetFloat("BusinessInvestmentBalance", investment.investmentBalance[1]);
            PlayerPrefs.SetFloat("GymInvestmentBalance", investment.investmentBalance[2]);

            //SceneManager.LoadScene("Level");

            PlayButtonSoundAndLoadScene();
        }
    }

    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadRunner", buttonSound.length); // Invoke LoadScene after sound duration
        }
    }

    private void LoadRunner()
    {
        SceneManager.LoadScene("Level");
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
