using AndroApps;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackManager : MonoBehaviour
{
    public static BackManager Instance;

    public List<GameObject> BackItems;
    public int Index;
    private void Awake()
    {
        Instance = this;
    }


    public void OnBack()
    {
        MainController.Instance.BackDetail.PanelBack.SetActive(false);

        switch (Index)
        {
            case 0: MainController.Instance.MainMenuDetail.GamePlay[0].SetActive(false); break;
            case 1:
            case 2: { Debug.Log("Back "); break; }
            case 3:
                {
                    RouletteSocket.Instance.OnCloseButton();
                    MainController.Instance.MainMenuDetail.GamePlay[3].SetActive(false);
                    MainController.Instance.CanvasLogin.SetActive(true);
                    MainController.Instance.LogOutPanel.SetActive(true);
                    RouletteManager.Instance.RouletteSocket.SetActive(false);
                    Debug.Log("Back ");
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
            case 12: { Debug.Log("Back "); break; }
            case 13:
                {
                    ScoketController.instance.OnClose();
                    string name = MainController.Instance.BackDetail.Name;
                    Debug.Log("bool yes no name " + name);
                    if (name == "Yes")
                    {
                        MainController.Instance.BackDetail.YesNo_Bool = true;
                        MainController.Instance.TimerScript.GetComponent<Counter>().count = 0;
                        MainController.Instance.TimerScript.SetActive(false);
                    }
                    Debug.Log("Main panel option");
                    ScoketController.instance.ClearCoinClone();
                    MainController.Instance.CanvasLogin.SetActive(true);
                    MainController.Instance.LogOutPanel.SetActive(true);
                    MainController.Instance.CanvasGameplay.SetActive(false);
                    MainController.Instance.Gameplay.SetActive(false);
                    MainController.Instance.CanvasWin.SetActive(false);
                    GameModule.Instance.SocketdDetail.SocketController.SetActive(false);// socket start 
                    MainController.Instance.WinNextStopDetail.StopPanel.SetActive(false);
                    MainController.Instance.WinNextStopDetail.WaitingPanel.SetActive(false);
                    // Debug.Log("Back ");
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
            case 33: { Debug.Log("Back "); break; }
        }

    }
}
