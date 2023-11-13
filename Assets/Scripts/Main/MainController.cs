using AndroApps;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class BackDetails
{
    public GameObject PanelBack;
    public bool YesNo_Bool;
    public int Count;
    public string Name;
}

[Serializable]
public class AddMoneyDetails
{
    public GameObject PrefabCoin;
    public Transform Parent;
    public GameObject Go;
    public List<GameObject> ListCoin;
}

[Serializable]
public class Bannerdetails
{
    public GameObject BG_Banner;
    public int NumberLess;
    public GameObject Prefab;
    public Transform Parent;

}

[Serializable]
public class WinNextStopDetails
{
    public List<GameObject> Cardorigin;
    public List<GameObject> CardAnim;
    public GameObject StopPanel;
    public GameObject WaitingPanel;
    public GameObject WinPanel;
    public List<Sprite> sprites = new List<Sprite>();
    public Sprite card;
}

[Serializable]
public class MainMenuDetails
{
    public GameObject GameObject;
    public List<GameObject> GamePlay;
}


public class MainController : MonoBehaviour
{
    public static MainController Instance;

    public GameObject CanvasLogin;
    [Header("LogIn")] public GameObject LogOutPanel;
    public GameObject CanvasGameplay;
    public GameObject Gameplay;
    public GameObject CanvasWin;

    public GameObject AddPanel;
    public GameObject AddChipPanel;
    public GameObject StatementPanel;
    public GameObject TimerScript;
    public GameObject BetStop;
    [Header("Win stop Next/ Waiting ")] public WinNextStopDetails WinNextStopDetail;
    public BackDetails BackDetail;
    public AddMoneyDetails AddMoneyDetail;
    public GameObject SettingPanel;
    public GameObject MainPanel;
    public GameObject ComingSoonPanel;
    public string NamePanel;

    [Header("Bannner details")] public Bannerdetails Bannerdetal;
    [Header("Coin")] public List<Sprite> Coin_Sprite;
    [Header("Game Play")] public MainMenuDetails MainMenuDetail;


    private void Awake()
    {
        Instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;// phone display off 
    }

    public void OnMainPanelBack()
    {
        BackDetail.PanelBack.SetActive(true);
        CanvasWin.SetActive(true);
    }

    public void OnAddPanelBack()
    {
        AddPanel.SetActive(false);
        CanvasWin.SetActive(false);

        switch (NamePanel)
        {
            case "Add":
                {
                    Gameplay.SetActive(true);
                    break;
                }
            case "Shop":
                {
                    Gameplay.SetActive(false);
                    break;
                }
        }
    }

    public void namePanel(string name)
    {
        BackDetail.Name = name;
    }

    public void OnAddShopPanel(string name)
    {
        NamePanel = name;

        switch (name)
        {
            case "Add":
                {
                    Debug.Log("Add");
                    AddPanel.SetActive(true);
                    Gameplay.SetActive(false);
                    CanvasWin.SetActive(true);
                    for (int i = 0; i < AddMoneyDetail.ListCoin.Count; i++)
                    {
                        Destroy(AddMoneyDetail.ListCoin[i]);
                    }
                    AddMoneyDetail.ListCoin.Clear();
                    AddMoneyDetail.ListCoin = new List<GameObject>();

                    for (int i = 0; i < 20; i++)
                    {
                        AddMoneyDetail.Go = Instantiate(AddMoneyDetail.PrefabCoin, AddMoneyDetail.Parent);
                        AddMoneyDetail.ListCoin.Add(AddMoneyDetail.Go);
                    }
                    break;
                }

            case "Shop":
                {
                    //  shop for gold coin 
                    CanvasWin.SetActive(true);
                    Gameplay.SetActive(false);

                    for (int i = 0; i < AddMoneyDetail.ListCoin.Count; i++)
                    {
                        Destroy(AddMoneyDetail.ListCoin[i]);
                    }
                    AddMoneyDetail.ListCoin.Clear();
                    AddMoneyDetail.ListCoin = new List<GameObject>();

                    for (int i = 0; i < 20; i++)
                    {
                        AddMoneyDetail.Go = Instantiate(AddMoneyDetail.PrefabCoin, AddMoneyDetail.Parent);
                        AddMoneyDetail.ListCoin.Add(AddMoneyDetail.Go);
                    }
                    AddPanel.SetActive(true);
                    Debug.Log("Shop"); break;
                }
        }
    }
    public void OnBack(int Index)
    {
        BackDetail.PanelBack.SetActive(false);
        string name = BackDetail.Name;
        Debug.Log("bool yes no name " + name);
        if (name == "Yes")
        {
            BackDetail.YesNo_Bool = true;
            TimerScript.GetComponent<Counter>().count = 0;
            TimerScript.SetActive(false);
        }
        else
        {
            BackDetail.YesNo_Bool = false;
        }

        if (BackDetail.YesNo_Bool)
        {
            switch (Index)
            {
                case 0:
                    {
                        Debug.Log("Main panel option");
                        CanvasLogin.SetActive(true);
                        LogOutPanel.SetActive(true);
                        CanvasGameplay.SetActive(false);
                        Gameplay.SetActive(false);
                        CanvasWin.SetActive(false);
                        GameModule.Instance.SocketdDetail.SocketController.SetActive(false);// socket start 
                        WinNextStopDetail.StopPanel.SetActive(false);
                        WinNextStopDetail.WaitingPanel.SetActive(false);

                        break;
                    }
                case 1: { break; }
                case 2: { break; }
                case 3: { break; }
                case 4: { break; }
                case 5: { break; }
                case 6: { break; }
                case 7: { break; }
            }
        }

        else
        {
            switch (Index)
            {
                case 0: { break; }
                case 1: { break; }
                case 2: { break; }
                case 3: { break; }
                case 4: { break; }
                case 5: { break; }
                case 6: { break; }
                case 7: { break; }
            }
        }
    }


}
