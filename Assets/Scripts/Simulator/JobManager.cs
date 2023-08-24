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
    //public GameObject LivingExpensesPanel; 
    public Text CongratsJobText;
    public Text HaveJobText;
    private bool isPhotographer;
    private bool isZooKeeper;
    private bool isPlumber;

    // Start is called before the first frame update
    void Start()
    {
        //LivingExpensesPanel.SetActive(false);
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
    public void AcquireJob(int jobIndex)
    {
        if (jobIndex == 0 && !isPhotographer)
        {
            CongratulationsOnJobPanel.SetActive(true);
            isPhotographer = true;
            isPlumber = false;
            isZooKeeper = false;
            PlayerPrefs.SetInt("JobIndex", 0);
            PlayerPrefs.SetInt("Salary", 400);
            CongratsJobText.text = "You are now a Photographer!";
            // Display UI messages for Photographer job
        }
        else if (jobIndex == 1 && !isZooKeeper)
        {
            CongratulationsOnJobPanel.SetActive(true);
            isZooKeeper = true;
            isPlumber = false;
            isPhotographer = false;
            PlayerPrefs.SetInt("JobIndex", 1);
            PlayerPrefs.SetInt("Salary", 360);
            CongratsJobText.text = "You are now a ZooKeeper!";
            // Display UI messages for ZooKeeper job
        }
        else if (jobIndex == 2 && !isPlumber)
        {
            CongratulationsOnJobPanel.SetActive(true);
            isPlumber = true;
            isPhotographer = false;
            isZooKeeper = false;
            PlayerPrefs.SetInt("JobIndex", 2);
            PlayerPrefs.SetInt("Salary",  480);
            CongratsJobText.text = "You are now a Plumber!";
            // Display UI messages for Plumber job
        }
        else
        {
            HaveJobAlreadyPanel.SetActive(true);
            HaveJobText.text = "You already have this job!";
        }
        PlayerPrefs.Save(); // Save changes to PlayerPrefs
    }
  
    public void ProceedButton()
    {
        CongratulationsOnJobPanel.SetActive(false);
        HaveJobAlreadyPanel.SetActive(false);
    }
}