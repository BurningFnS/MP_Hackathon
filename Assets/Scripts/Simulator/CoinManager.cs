using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    //Variables for all coin related UI and values
    public int endlessRunnerCoins;
    public int currentCoins;
    public int cashAtHand;
    public Text coinText;
    public Text ageText;
    //Variables for age
    public int currentAge;
    public int defaultAge = 25;

    public Bank bank; //Reference to bank script
    
    //Variables for all losing and winning condition
    public GameObject negativeBalancePanel;
    public GameObject losePanel;
    public GameObject retireButton;
    public Text alertText;

    public Image coinImageComponent;
    //Variables for negative and positive coin sprite
    public Sprite negativeCoinSprite;
    public Sprite positiveCoinSprite;
    public InvestmentManager investment; //Reference to the investment script

    //Colours for the negative and positive coin
    public Color redColor;
    public Color blueColor;

    public float animationDuration = 2.0f; // Duration of the animation in seconds

    private int targetAmount; // The target money amount after animation
    private int initialAmount; // The initial money amount at the start of animation
    private float animationStartTime; // The time when the animation started
    //private int interceptedAmount;

    //private int currentAmount; // The current displayed money amount


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
        //Gets and sets the audio clip of the audio source
        soundSource = GetComponent<AudioSource>();
        soundSource.clip = buttonSound;
        PlayerPrefs.SetInt("InterceptedAmount", 0); //Set Intercepted Amount to 0 on start
    }

    void Start()
    {
        //Gets coins collected from endless runner and whatever was left from the previous simulator phase and combine it into currentCoins
        endlessRunnerCoins = PlayerPrefs.GetInt("CollectedCoins");
        cashAtHand = PlayerPrefs.GetInt("CurrentCoins");
        currentAge = PlayerPrefs.GetInt("CurrentAge"); //Gets the current age of the player

        currentCoins = endlessRunnerCoins + cashAtHand;

        // Update coin UI and age UI of player
        UpdateMoneyText(currentCoins);
        ageText.text = "" + currentAge;
        //Show the retire button once they are over the age of 65
        if (currentAge >= 65)
        {
            retireButton.SetActive(true);
        }
    }

    private void Update()
    {
        //Continuously update coin display
        UpdateCoinDisplay();
    }

    public void AnimateToAmount(int beforeAmount, int newAmount)
    {
        // If there's a running animation coroutine, stop it and store the target/updated amount to the new initial amount through PlayerPrefs.
        if (currentAnimationCoroutine != null)
        {
            StopCoroutine(currentAnimationCoroutine);
            initialAmount = PlayerPrefs.GetInt("InterceptedAmount");
            targetAmount = newAmount;
            currentCoins = targetAmount;
            animationStartTime = Time.time;//Get time at the start of coroutine
            Debug.Log("target amount if intercepted: " + targetAmount);
            Debug.Log("initial amount if intercepted: " + initialAmount);
            currentAnimationCoroutine = StartCoroutine(AnimateMoney()); //Then run the coroutine changing the coin UI
        }
        else
        {
            targetAmount = newAmount;
            initialAmount = beforeAmount;
            animationStartTime = Time.time; //Get time at the start of coroutine
            PlayerPrefs.SetInt("InterceptedAmount", targetAmount);
            currentCoins = newAmount;
            // Start the animation coroutine
            Debug.Log("target amount if not intercepted: " + targetAmount);
            Debug.Log("initial amount if not intercepted: " + initialAmount);
            currentAnimationCoroutine = StartCoroutine(AnimateMoney());//Then run the coroutine changing the coin UI
        }


    }

    //public void TestAnimateToAmount(int beforeAmount, int change)
    //{
    //    //// If there's a running animation coroutine, stop it.
    //    //if (currentAnimationCoroutine != null)
    //    //{
    //    //    StopCoroutine(currentAnimationCoroutine);
    //    //    initialAmount = PlayerPrefs.GetInt("InterceptedAmount");
    //    //    targetAmount = newAmount;
    //    //    animationStartTime = Time.time;
    //    //    Debug.Log("target amount if intercepted: " + targetAmount);
    //    //    Debug.Log("initial amount if intercepted: " + initialAmount);
    //    //    currentAnimationCoroutine = StartCoroutine(AnimateMoney());
    //    //}
    //    //else
    //    //{
    //    //    targetAmount = newAmount;
    //    //    initialAmount = beforeAmount;
    //    //    animationStartTime = Time.time;
    //    //    PlayerPrefs.SetInt("InterceptedAmount", targetAmount);
    //    //    currentCoins = newAmount;
    //    //    // Start the animation coroutine
    //    //    Debug.Log("target amount if not intercepted: " + targetAmount);
    //    //    Debug.Log("initial amount if not intercepted: " + initialAmount);
    //    //    currentAnimationCoroutine = StartCoroutine(AnimateMoney());
    //    //}
    //    targetAmount = beforeAmount + change;
    //    initialAmount = beforeAmount;
    //    animationStartTime = Time.time;
    //    currentCoins = targetAmount;
    //    currentAnimationCoroutine = StartCoroutine(AnimateMoney());

    //}

    //Coroutine to animate changes in the coin amount
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

    //Format the coins collected and update the UI
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

    // Update UI display of coins depending on whether they have positive or negative amount of coins
    public void UpdateCoinDisplay()
    {
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
    // Function for opening the confirmation panel
    public void Confirmation()
    {
        // This function is to open the Continue panel under "ClickedOnCanvas".
        // It contains a portion of the code from the Continue function
        // as it is redundant for users to be allowed to confirm if they can not proceed

        //Check if player has negative amount of coins and stop them from proceeding
        if (currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if (currentCoins >= 0)
        {
            confirmationPanel.SetActive(true);
            // Update other UI elements in the confirmation panel
            insuranceManager.InsuranceUpdate();

            _MoneyEarned.text = "$" + (PlayerPrefs.GetInt("Salary") * 5);
            Debug.Log("total insurance expenses: " + InsuranceManager.totalInsuranceExpenses);
            _Expenditures.text = "$" + (PlayerPrefs.GetInt("WaterBill") + PlayerPrefs.GetInt("ElectricalBill") + InsuranceManager.totalInsuranceExpenses);
            _Tips.text = "Tips: " + Tips.TipArray[Random.Range(0, Tips.TipArray.Length)];

        }
    }

    //hide the confirmation panel
    public void CloseConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    // Function to continue the next phase
    public void Continue()
    {
        //Check if player has negative amount of coins and stop them from proceeding
        if (currentCoins < 0)
        {
            alertText.text = "You have negative balance of " + currentCoins;
            negativeBalancePanel.SetActive(true);
        }
        else if (currentCoins >= 0)
        {
            confirmationPanel.SetActive(false);

            // Update player preferences with the new data
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

    // Function to play a button sound and load the game scene only after sound finishes
    public void PlayButtonSoundAndLoadScene()
    {
        if (!soundPlaying)
        {
            soundPlaying = true;
            soundSource.Play();
            Invoke("LoadRunner", buttonSound.length); // Invoke LoadScene after sound duration
        }
    }

    // Function to load the endless runner game scene
    private void LoadRunner()
    {
        SceneManager.LoadScene("Level");
    }

    // Function to proceed in the game despite having a negative amount of coins and lose
    public void Proceed()
    {
        losePanel.SetActive(true);
    }

    //Hide the negative balance panel
    public void Return()
    {
        negativeBalancePanel.SetActive(false);
    }
}
