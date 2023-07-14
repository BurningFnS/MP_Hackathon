using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public Text coinText;
    public GameObject startText;

    public static bool isGameStarted;

    void Start()
    {
        numberOfCoins = 0;
        isGameStarted = false;
    }

    void Update()
    {
        coinText.text = "Coins: " + numberOfCoins;

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startText);
        }
    }
}
