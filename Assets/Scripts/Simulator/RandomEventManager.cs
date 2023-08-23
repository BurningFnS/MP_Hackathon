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
        if(eventHandler.randomeEventCanHappen == true && randomEventHasHappened == false)
        {
            amountRobbed = Random.Range(1, coinManager.currentCoins);
            robbedText.text = "Amount Lost: " + amountRobbed;
            randomEventHasHappened = true;
        }
    }

    public void ProceedRobbed()
    {
        
        robbedPanel.SetActive(false);
        coinManager.currentCoins = coinManager.currentCoins - amountRobbed;
        coinManager.UpdateCoinDisplay();
    }
}
