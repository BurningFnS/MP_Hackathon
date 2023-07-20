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
        if (numberOfCoins < 0)
        {
            numberOfCoins = 0;
        }

        coinText.text = "" + numberOfCoins;

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startText);
        }
    }
}
