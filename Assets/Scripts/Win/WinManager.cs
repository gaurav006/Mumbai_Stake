using AndroApps_Roulette;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance;
    public List<GameObject> AnimationWin;


    private void Awake()
    {
        Instance = this;
    }

    public void OnInit(int Index)
    {
      //  Debug.Log("Win : " + Index);
        MainController.Instance.CanvasWin.SetActive(true);
        switch (Index)
        {
            case 0:
                {
                    // Dragen
                    AnimationWin[0].SetActive(true);
                    break;
                }
            case 1:
                {
                    // tiger
                    AnimationWin[1].SetActive(true);
                    break;
                }
            case 2:
                {
                    //tie
                     AnimationWin[2].SetActive(true);                   
                   // Debug.Log("TIE Case ");
                    break;
                }

        }
    }

    public void OnInitOff()
    {
        // MainController.Instance.CanvasWin.SetActive(false);
        //   Debug.Log("win end");
        for (int i = 0; i < AnimationWin.Count; i++)
        {
            AnimationWin[i].SetActive(false);
        }

    }



    public void OnRouletteWin()
    {
        int numberToCheck = RouletteManager.Instance.rouletteRotation.Winning;
        TablePoint(RouletteManager.Instance.rouletteRotation.Winning.ToString());

        if (IsEven(numberToCheck))
        {
           // Debug.Log(numberToCheck + " t is even.");
        }
        else
        {
           // Debug.Log(numberToCheck + " t is odd.");
        }
       
        // number greater than case 
        if (numberToCheck > 18)
        {
           // Debug.Log(numberToCheck + " t >18.");
        }
        else
        {
           // Debug.Log(numberToCheck + " t <18.");
        }

        // 12 less than
        if (numberToCheck < 12)
        {
            //Debug.Log(numberToCheck + " t <12.");
        }
        else if (numberToCheck < 24)
        {
            //Debug.Log(numberToCheck + " t <24.");
        }
        else
        {
          //  Debug.Log(numberToCheck + " t <36.");
        }
        for (int i = 0; i < RouletteManager.Instance.Red.Count; i++)
        {
            if (RouletteManager.Instance.Red[i] == numberToCheck)
            {
                //Debug.Log(" red : " + numberToCheck);
            }
            //else
            //{
            //    Debug.Log(" red else : " + numberToCheck);
            //}
            if (RouletteManager.Instance.Black[i] == numberToCheck)
            {
               // Debug.Log(" black : " + numberToCheck);
            }
            //else
            //{
            //    Debug.Log(" black else : ");
            //}

            if (RouletteManager.Instance.OnetoEightteen[i] == numberToCheck)
            {
                //Debug.Log(" one to eightteen : " + numberToCheck);
            }
            if (RouletteManager.Instance.NineteentothritySix[i] == numberToCheck)
            {
               // Debug.Log(" NineteentothritySix : " + numberToCheck);
            }
        }
    }

    public void TablePoint(string Str)
    {

        switch (Str)
        {
            case "0": { Debug.Log(" Win + 0"); break; }
            case "1": { Debug.Log(" Win + 1"); break; }
            case "2": { Debug.Log(" Win + 2"); break; }
            case "3": { Debug.Log(" Win + 3"); break; }
            case "4": { Debug.Log(" Win + 4"); break; }
            case "5": { Debug.Log(" Win + 5"); break; }
            case "6": { Debug.Log(" Win + 6"); break; }
            case "7": { Debug.Log(" Win + 7"); break; }
            case "8": { Debug.Log(" Win + 8"); break; }
            case "9": { Debug.Log(" Win + 9"); break; }
            case "10": { Debug.Log(" Win + 10"); break; }
            case "11": { Debug.Log(" Win + 11"); break; }
            case "12": { Debug.Log(" Win + 12"); break; }
            case "13": { Debug.Log(" Win + 13"); break; }
            case "14": { Debug.Log(" Win + 14"); break; }
            case "15": { Debug.Log(" Win + 15"); break; }
            case "16": { Debug.Log(" Win + 16"); break; }
            case "17": { Debug.Log(" Win + 17"); break; }
            case "18": { Debug.Log(" Win + 18"); break; }
            case "19": { Debug.Log(" Win + 19"); break; }
            case "20": { Debug.Log(" Win + 20"); break; }
            case "21": { Debug.Log(" Win + 21"); break; }
            case "22": { Debug.Log(" Win + 22"); break; }
            case "23": { Debug.Log(" Win + 23"); break; }
            case "24": { Debug.Log(" Win + 24"); break; }
            case "25": { Debug.Log(" Win + 25"); break; }
            case "26": { Debug.Log(" Win + 26"); break; }
            case "27": { Debug.Log(" Win + 27"); break; }
            case "28": { Debug.Log(" Win + 28"); break; }
            case "29": { Debug.Log(" Win + 29"); break; }
            case "30": { Debug.Log(" Win + 30"); break; }
            case "31": { Debug.Log(" Win + 31"); break; }
            case "32": { Debug.Log(" Win + 32"); break; }
            case "33": { Debug.Log(" Win + 33"); break; }
            case "34": { Debug.Log(" Win + 34"); break; }
            case "35": { Debug.Log(" Win + 35"); break; }
            case "36": { Debug.Log(" Win + 36"); break; }
            case "37": { Debug.Log("R_TWELFTH_1ST"); break; }
            case "38": { Debug.Log("R_TWELFTH_2ND"); break; }
            case "39": { Debug.Log("R_TWELFTH_3RD"); break; }
            case "40": { Debug.Log("R_EIGHTEENTH_1ST"); break; }
            case "41": { Debug.Log("R_EIGHTEENTH_2ND"); break; }
            case "42": { Debug.Log("R_ODD"); break; }
            case "43": { Debug.Log("R_EVEN"); break; }
            case "44": { Debug.Log("R_RED"); break; }
            case "45": { Debug.Log("R_BLACK"); break; }
            case "46": { Debug.Log("R_ROW_1"); break; }
            case "47": { Debug.Log("R_ROW_2"); break; }
            case "48": { Debug.Log("R_ROW_3"); break; }





                //case "R_TWELFTH_1ST": {  break; }
                //case "R_TWELFTH_2ND": {  break; }
                //case "R_TWELFTH_3RD": {  break; }
                //case "R_EIGHTEENTH_1ST": {  break; }
                //case "R_EIGHTEENTH_2ND": {  break; }
                //case "R_ODD": {  break; }
                //case "R_EVEN": {  break; }
                //case "R_RED": {  break; }
                //case "R_BLACK": {  break; }
                //case "R_ROW_1": {  break; }
                //case "R_ROW_2": {  break; }
                //case "R_ROW_3": {  break; }         

                //define('R_TWELFTH_1ST', 37);
                //define('R_TWELFTH_2ND', 38);
                //define('R_TWELFTH_3RD', 39);
                //define('R_EIGHTEENTH_1ST', 40);
                //define('R_EIGHTEENTH_2ND', 41);
                //define('R_ODD', 42);
                //define('R_EVEN', 43);
                //define('R_RED', 44);
                //define('R_BLACK', 45);
                //define('R_ROW_1', 46);
                //define('R_ROW_2', 47);
                //define('R_ROW_3', 48); 
        }
    }



    private bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}
