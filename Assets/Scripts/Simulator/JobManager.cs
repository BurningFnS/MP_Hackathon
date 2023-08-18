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
    public Text CongratsJobText;
    public Text HaveJobText;
    public Text PhotographerSummaryText;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckJobButton()
    {
        if (PlayerPrefs.GetInt("JobIndex") == 0)
        {
            
            //PhotographerSummaryText.text = "Photographer Closed";
            Debug.Log("WAAAAAAAAAAAAA");

        }
        if (PlayerPrefs.GetInt("JobIndex") == 1)
        {
            //ZooKeeperSummaryText.text = "ZooKeeper Closed";
            Debug.Log("BBBBBBBBBBBBB");
        }
        if (PlayerPrefs.GetInt("JobIndex") == 2)
        {
            //PlumberSummaryText.text = "PlumberClosed";
            Debug.Log("WAHAHAHAH");
        }
    }

}