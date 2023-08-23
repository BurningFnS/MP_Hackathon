using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventManager : MonoBehaviour
{
    public CoinManager coinManager;
    public EventHandler eventHandler;

    public Text robbedText;

    public int amountRobbed;
    public bool randomEventHasHappened;

    public GameObject robbedPanel;
    // Start is called before the first frame update
    void Start()
    {
        randomEventHasHappened = false;
        //if (gameObject.name == "")


    }

    // Update is called once per frame
    void Update()
    {
        if (eventHandler.gettingRobbed)
        {
            GettingRobbedEvent();
        }

    }

    public void ProceedRobbed()
    {
        
        robbedPanel.SetActive(false);
        coinManager.currentCoins = coinManager.currentCoins - amountRobbed;
        coinManager.UpdateCoinDisplay();
    }

    public void GettingRobbedEvent()
    {
        if (eventHandler.randomEventCanHappen == true && randomEventHasHappened == false)
        {
            if (coinManager.currentCoins > 0)
            {
                amountRobbed = Random.Range(0, coinManager.currentCoins);
                robbedText.text = "Amount Lost: " + amountRobbed;
                randomEventHasHappened = true;
            }
            else
            {
                robbedText.text = "Amount Lost: 0";
                randomEventHasHappened = true;
            }

        }
    }
}
