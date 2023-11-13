using AndroApps;
using AndroApps_Roulette;
using AndroappsRoulette;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;
using DG.Tweening;
using Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteSocket : MonoBehaviour
{
    public static RouletteSocket Instance;
  [Header("Controller details")]  public ControllerDetails ControllerDetail;
    private SocketManager Manager;
    public string Number;
    public Text NumberTxt;
    public int num;

    public int WinNum;
    public bool IsWin;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        var url = "http://" + ControllerDetail.Address + ControllerDetail.Port;
        // Debug.Log("URL+ " + url);

        // Create the Socket.IO manager
        Manager = new SocketManager(new Uri(url));
        var customNamespace = Manager.GetSocket(ControllerDetail.CustomNamespace);


        customNamespace.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnected);
        customNamespace.On(SocketIOEventTypes.Disconnect, OnDisconnected);

        customNamespace.On<string>(ControllerDetail.Counter, OnNumber);
        customNamespace.On<string>(ControllerDetail.Status, onStatus);

        //SetButtons(false, true);

    }

    private void OnConnected(ConnectResponse resp)
    {
        Debug.Log("Connect : " + resp.sid);
        GameModule.Instance.SocketdDetail.LossConnection.SetActive(false);
        MainController.Instance.CanvasWin.SetActive(true);
    }


    // only close case check 
  //  [Header("Buttons")]

    //[SerializeField]
    //private Button _connectButton;

    //[SerializeField]
    //private Button _closeButton;
    //private void SetButtons(bool connect, bool close)
    //{
    //    if (this._connectButton != null)
    //        this._connectButton.interactable = connect;

    //    if (this._closeButton != null)
    //        this._closeButton.interactable = close;
    //}

    public void OnCloseButton()
    {        
        Manager.Close();
    }
    private void OnDisconnected()
    {
        StopAllCoroutines(); // 
        Debug.Log("DisConnect :  stop ");
        //GameModule.Instance.SocketdDetail.LossConnection.SetActive(true);
    }
    public void OnNumber(string number1)
    {
        Number = number1;
        // Debug.Log("number " + number1);
        num = int.Parse(Number);
        RandomNumber.Instance.Count = int.Parse(Number);
        OnBetpostion();
        RandomNumber.Instance.OnInitRandomNumber();

        if (num >= 10)
        {
            NumberTxt.text = Number.ToString();

        }
        else
        {
            NumberTxt.text = "0" + Number.ToString();
        }

        //if ((num == 1) || (num == 15))
        //{
        //    Debug.Log("Num == 01  / 15 ");          
        //}
    }
    public void onStatus(string RouletteRoots)
    {
        //Debug.Log("status");
        RouletteModule.Instance.RouletteRoot = new RouletteRoots();
        RouletteModule.Instance.RouletteRoot = JsonUtility.FromJson<RouletteRoots>(RouletteRoots);
        for (int i = 1; i < RouletteManager.Instance.LastWining.Count; i++)
        {
            RouletteManager.Instance.LastWining[i].text = RouletteModule.Instance.RouletteRoot.last_winning[i].winning;
        }
        GameController.Instance.CurrentPackage.Gameid = RouletteModule.Instance.RouletteRoot.game_data[0].id;

        // GAME ID data
        //// Debug.LogError(" wining " + RouletteManager.Instance.rouletteRotation.Winning);

        if (num == 1)
        {
            Invoke("OnWin", 0.15f);//0.1wait 
            BetPlaceManager.Instance.IsBet = false;

        }
        else
        {
            WinManager.Instance.OnInitOff();// endwin
            WinNum = 1;
            RouletteManager.Instance.WinNumber.SetActive(false);
            BetPlaceManager.Instance.IsBet = true;
        }
    }

    void OnBetpostion()
    {
        // Debug.Log("Betting user");
        if (num > 2)
        {
            for (int i = 0; i < 10; i++)
            {
                StartCoroutine(Let(i));
                StopCoroutine(Let(i));
            }
        }
    }
    IEnumerator Let(int Index)
    {
        yield return new WaitForSeconds(0.01f);
        RouletteFakeUserManager.Instance.UserPosition.GetComponent<RouletteFake_User>().Randemsetposition();
    }
    void OnWin()
    {
        if (WinNum == 1)
        {
            RouletteManager.Instance.rouletteRotation.Winning = int.Parse(RouletteModule.Instance.RouletteRoot.game_data[0].winning);
            WinManager.Instance.OnRouletteWin();

            StartCoroutine(BetStop());
            // StopCoroutine(BetStop());
            WinNum = 5;
            // Debug.LogError("Win");
            RouletteManager.Instance.WinNumber.transform.GetChild(0).gameObject.GetComponent<Text>().text = RouletteManager.Instance.rouletteRotation.Winning.ToString();
        }
        else
        {
            //Debug.LogError("Win Else");
        }
    }
    IEnumerator BetStop()
    {
        // Debug.LogError("Bet Stop");
        MainController.Instance.BetStop.SetActive(true); // panel hold raycast
        NumberTxt.text = "00";

        MainController.Instance.WinNextStopDetail.StopPanel.SetActive(true); // stop animation play
        yield return new WaitForSeconds(1.7f);
        RouletteRotation.Instance.SetRotation();
        RouletteRotation.Instance.OnButtonTesting();
        MainController.Instance.WinNextStopDetail.StopPanel.SetActive(false);
        // yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(3.5f);
        WinManager.Instance.OnInitOff();
        MainController.Instance.WinNextStopDetail.WaitingPanel.SetActive(true); //wait for next betting  
        yield return new WaitForSeconds(1);
        MainController.Instance.WinNextStopDetail.WaitingPanel.SetActive(false);
        MainController.Instance.BetStop.SetActive(false);
        for (int i = 0; i < RouletteManager.Instance.CloneUser.Count; i++)
        {
            RouletteManager.Instance.CloneUser[i].transform.SetParent(RouletteManager.Instance.Return_Position);
            Destroy(RouletteManager.Instance.CloneUser[i], 2.5f);
            RouletteManager.Instance.CloneUser[i].transform.DOLocalMove(new Vector3(0, 0, 0), 2);
        }
        for (int i = 0; i < RouletteManager.Instance.ListFakeCoin.Count; i++)
        {
            RouletteManager.Instance.ListFakeCoin[i].transform.SetParent(RouletteFakeUserManager.Instance.UserPosition);
            RouletteManager.Instance.ListFakeCoin[i].transform.DOLocalMove(new Vector3(0, 0, 0), 2);
            Destroy(RouletteManager.Instance.ListFakeCoin[i], 3);
        }
        yield return new WaitForSeconds(1.25f);
        RouletteManager.Instance.WinNumber.SetActive(true);
        RouletteManager.Instance.Score.GetComponent<Text>().text = RouletteManager.Instance.WinNumber.transform.GetChild(0).gameObject.GetComponent<Text>().text;

        yield return new WaitForSeconds(1);
        string str = RouletteManager.Instance.rouletteRotation.Winning.ToString();
      //  Debug.LogError("Str : " + str);
        TableManager.Instance.UnSelectionImage();
        StartCoroutine(TableManager.Instance.OnWin(str));
        RouletteManager.Instance.WinNumber.SetActive(false);
        StopCoroutine(BetStop());
        OnReturnPosition();
        yield return null;
    }

    void OnReturnPosition()
    {
        Debug.Log("Clear list ");
        RouletteManager.Instance.CloneUser.Clear();
        RouletteManager.Instance.CloneUser = new List<GameObject>();
        RouletteManager.Instance.ListFakeCoin.Clear();
        RouletteManager.Instance.ListFakeCoin = new List<GameObject>();
        //all bool false
        RouletteManager.Instance.AllboolOff();
        // position store was null
        TableManager.Instance.Pos = null;
        StartCoroutine(ProfileDetails.Instance.PostUserProfile(GameController.Instance.CurrentPackage.Id, GameController.Instance.CurrentPackage.Fcm, GameController.Instance.CurrentPackage.App_version));
    }
}


