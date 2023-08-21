using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobManager : MonoBehaviour
{
    //public int salary;
    //public StartSelection startSelection;
    //public Text coinText;
    public GameObject HaveJobAlreadyPanel;
    public GameObject CongratulationsOnJobPanel;
    public GameObject LivingExpensesPanel; 
    public Text CongratsJobText;
    public Text HaveJobText;
    private bool isPhotographer;
    private bool isZooKeeper;
    private bool isPlumber;

    // Start is called before the first frame update
    void Start()
    {
        LivingExpensesPanel.SetActive(false);
        if (PlayerPrefs.GetInt("JobIndex") == 0)
        {
            isPhotographer = true;
            Debug.Log("ISPT");
        }
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            isZooKeeper = true;
            Debug.Log("IZKT");
        }
        if (PlayerPrefs.GetInt("JobIndex") == 2)
        {
            isPlumber = true;
            Debug.Log("IPT");
        }
    }
    public void MixedFunctions()
    {
        if(PlayerPrefs.GetInt("JobIndex") == 0 || PlayerPrefs.GetInt("JobIndex") == 1 || PlayerPrefs.GetInt("JobIndex") == 2)
        {
            CongratulationsOnJobPanel.SetActive(false);
            CheckJobButton();
            Debug.Log("MIXED1");
        }
        else if (isPhotographer == true || isZooKeeper == true || isPlumber == true)
        {
            HaveJobAlreadyPanel.SetActive(false);
            CheckJobButton2();
            Debug.Log("MIXED2");
        }      
    }
    public void CheckJobButton()
    {
        if (PlayerPrefs.GetInt("JobIndex") == 0)
        {
            
            HaveJobAlreadyPanel.SetActive(true);
            HaveJobText.text = "You already have the Photographer Job!";
            Debug.Log("WAAAAAAAAAAAAA");
        }
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
     
            HaveJobAlreadyPanel.SetActive(true);
            HaveJobText.text = "You already have the ZooKeeper Job!";
            Debug.Log("BBBBBBBBBBBBB");
        }
        if (PlayerPrefs.GetInt("JobIndex") == 2)
        {

            HaveJobAlreadyPanel.SetActive(true);
            HaveJobText.text = "You already have the Plumber Job!";
            Debug.Log("WAHAHAHAH");
        }
    }
    public void CheckJobButton2()
    {
        if (!isPhotographer)
        {
            PlayerPrefs.SetInt("JobIndex", 0);
            isPhotographer = true;
            CongratulationsOnJobPanel.SetActive(true);
            CongratsJobText.text = "You are now a Photographer!";
            Debug.Log("WWWWWWWWWWWWWWWWWWWWWWW");
        }
        else if (!isZooKeeper)
        {
            PlayerPrefs.SetInt("JobIndex", 1);
            isZooKeeper = true;
            CongratulationsOnJobPanel.SetActive(true);
            CongratsJobText.text = "You are now a ZooKeeper!";
            Debug.Log("CCCCCCCCCCCCCCCCCCCCCCCCCCCCCc");
        }
        else if (!isPlumber)
        {
            PlayerPrefs.SetInt("JobIndex", 2);
            isPlumber = true;
            CongratulationsOnJobPanel.SetActive(true);
            CongratsJobText.text = "You are now a Plumber!";
            Debug.Log("PPPPPPPPPPPPPPPPPPP");
        }
    }
    public void ProceedButton()
    {
        CongratulationsOnJobPanel.SetActive(false);
        HaveJobAlreadyPanel.SetActive(false);
    }
}