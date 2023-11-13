using AndroApps;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int count;
    public Text Timer;
    public GameObject Begins, Wait, Stop;

    void OnEnable()
    {
        //count = 10;
        count = GameController.Instance.CurrentPackage.Time_remaining;
       
        MainController.Instance.BetStop.SetActive(false);
        OnCounter();
    }
    public void OnCounter()
    {
        if (count == 0)
        {
            count = 0;
            Timer.text = "Timer  " + "0:0";
           // GameModule.Instance.OnPlaceBet();
            MainController.Instance.BetStop.SetActive(true);
            
            // message for condition bet place 
            Begins.SetActive(false);
            Stop.SetActive(true);
            Wait.SetActive(false);

            Invoke("waitMessage", 2);//2
            Invoke("OnStopped", 4);//2


        }
        else
        {
            if (count > 0)
            {
                --count; //Debug.Log("Count :: " + count);
            }
            else {
                count++;

            }
            Begins.SetActive(true);
            Stop.SetActive(false);
            Wait.SetActive(false);
            Timer.text = "Timer  " + "0:" + count;
            Invoke("OnCounter", 1);

        }
    }

    void waitMessage()
    {
        Begins.SetActive(false);
        Stop.SetActive(false);
        Wait.SetActive(true);
        Wait.GetComponent<Text>().text = Configuration.waitingforthenextround;
    }
    private void OnStopped()
    {
        // this.gameObject.SetActive(false);
        // count = GameController.Instance.CurrentPackage.Time_remaining;
        GameModule.Instance.OnGetActiveGame();
        count = GameController.Instance.CurrentPackage.Time_remaining;
        MainController.Instance.BetStop.SetActive(false);
       
        OnCounter();
    }
}
