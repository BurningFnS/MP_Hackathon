using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject coinDetector;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(ActivateCoin());
            Destroy(gameObject);
        }
    }

    IEnumerator ActivateCoin()
    {
        coinDetector.SetActive(true);
        yield return new WaitForSeconds(10f);
        coinDetector.SetActive(false);
        Coin.coinMove = false;
    }
}
