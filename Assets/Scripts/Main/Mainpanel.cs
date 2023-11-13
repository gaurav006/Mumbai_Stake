using AndroApps;
using Profile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainpanel : MonoBehaviour
{

    public int Index = 1;
    public void OnMaonPanel()
    {
        //  Debug.Log("OnMaonPanel");
        //if (Index == 13)
        //{
        //    //    MainController.Instance.LogOutPanel.SetActive(false);
        //    //    MainController.Instance.CanvasLogin.SetActive(false);

        //    //    MainController.Instance.CanvasGameplay.SetActive(true);
        //    //    MainController.Instance.Gameplay.SetActive(true);
        //    //    MainController.Instance.CanvasWin.SetActive(true);
        //    //    GameModule.Instance.OnGetActiveGame();
        //    //    //MainController.Instance.TimerScript.SetActive(true);//  time will off not use then socket 
        //}
        //else
        //{
        //    MainController.Instance.ComingSoonPanel.SetActive(true);
        //    Invoke("OnOffPanel", 2);
        //}


        switch (Index)
        {
            case 0: MainController.Instance.MainMenuDetail.GamePlay[0].SetActive(true); break;
            case 1:
            case 2:
                {
                    GameController.Instance.CurrentPackage.BetPlaceIndex = 0;
                    MainController.Instance.ComingSoonPanel.SetActive(true);
                    Invoke("OnOffPanel", 2);
                    break;
                }

            case 3:
                {
                    GameController.Instance.CurrentPackage.BetPlaceIndex = 3;
                    MainController.Instance.LogOutPanel.SetActive(false);
                    MainController.Instance.CanvasLogin.SetActive(false);
                    MainController.Instance.MainMenuDetail.GamePlay[3].SetActive(true);
                    RouletteManager.Instance.RouletteSocket.SetActive(true);
                    ProfileDetails.Instance.RouletteImage.sprite = ProfileDetails.Instance.sSprite;
                    break;
                }
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
                {
                    GameController.Instance.CurrentPackage.BetPlaceIndex = 12;
                    MainController.Instance.ComingSoonPanel.SetActive(true);
                    Invoke("OnOffPanel", 2);
                    break;
                }


            case 13:
                {
                    GameController.Instance.CurrentPackage.BetPlaceIndex = 13;
                    MainController.Instance.LogOutPanel.SetActive(false);
                    MainController.Instance.CanvasLogin.SetActive(false);

                    MainController.Instance.CanvasGameplay.SetActive(true);
                    MainController.Instance.Gameplay.SetActive(true);
                    MainController.Instance.CanvasWin.SetActive(true);
                    GameModule.Instance.OnGetActiveGame();
                    GameModule.Instance.GetActiveGameDetail.thisProfileImage.sprite = ProfileDetails.Instance.sSprite;
                    break;
                }

            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
            case 30:
            case 31:
            case 32:
            case 33:
                {
                    GameController.Instance.CurrentPackage.BetPlaceIndex = 0;
                    MainController.Instance.ComingSoonPanel.SetActive(true);
                    Invoke("OnOffPanel", 2);
                    break;
                }
        }

    }

    void OnOffPanel()
    {
        MainController.Instance.ComingSoonPanel.SetActive(false);
    }


}
