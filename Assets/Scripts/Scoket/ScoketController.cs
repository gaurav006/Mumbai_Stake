using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;
using DG.Tweening;
using Profile;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace AndroApps
{
    [Serializable]
    public class ControllerDetails
    {
        public string Address;
        public string Port;
        public string CustomNamespace;
        public string Status;
        public string Counter;
        public bool IsConnection;
    }

    public class ScoketController : MonoBehaviour
    {
        public static ScoketController instance;

        [Header("Controller details")] public ControllerDetails ControllerDetail;
        private SocketManager Manager;

        public string Number;
        public Text NumberTxt;
        public int num;
        public int WinNum;
        public bool IsWin;

        [Header("Status details")] public DragonStatusDetails DragonStatusDetail;

        private void Awake()
        {
            instance = this;
            //System.GC.Collect();
        }

         void Start()
        //private void OnEnable()
        {
            var url = "http://" + ControllerDetail.Address + ControllerDetail.Port;
            Debug.Log("URL+ " + url);
            // Create the Socket.IO manager
            Manager = new SocketManager(new Uri(url));
            var customNamespace = Manager.GetSocket(ControllerDetail.CustomNamespace);

            customNamespace.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnected);
            customNamespace.On(SocketIOEventTypes.Disconnect, OnDisconnected);

            customNamespace.On<string>(ControllerDetail.Counter, OnNumber);
            customNamespace.On<string>(ControllerDetail.Status, onStatus);

        }

        private void OnConnected(ConnectResponse resp)
        {
            Debug.Log("Connect : " + resp.sid);
            GameModule.Instance.SocketdDetail.LossConnection.SetActive(false);
            MainController.Instance.CanvasWin.SetActive(true);
            ControllerDetail.IsConnection = true;
        }

        private void OnDisconnected()
        {
            StopAllCoroutines(); // 
            Debug.Log("DisConnect : ");
            //  MainController.Instance.CanvasWin.SetActive(false);
            GameModule.Instance.SocketdDetail.LossConnection.SetActive(true);
            ControllerDetail.IsConnection = false;
        }

        public void OnClose()
        {
            Manager.Close();
        }

        void OnBetpostion()
        {
            //Debug.Log("Betting user");
            if (num > 2)
            {
                for (int i = 0; i < FackUserManager.Instance.FakeUsedetail.Count; i++)
                {
                    FackUserManager.Instance.FakeUsedetail[i].UserPosition.gameObject.GetComponent<UserFake>().Randemsetposition();
                }
            }
        }
        public void OnNumber(string number1)
        {
            Caching.ClearCache();
            Number = number1;
            //  Debug.Log("number " + number1);
            num = int.Parse(Number);
            OnBetpostion();
            if (num >= 10)
            {
                NumberTxt.text = Number.ToString();
            }
            else
            {
                NumberTxt.text = "0" + Number.ToString();
            }
        }

        public void ClearCoinClone()
        {
            //Debug.Log("Clean  coin all fake and user");
            for (int i = 0; i < FackUserManager.Instance.FakeUsedetail.Count; i++)//7 
            {
                //  GC_GrabadeCollector(FackUserManager.Instance.FakeUsedetail[i].Clone);
                for (int j = 0; j < FackUserManager.Instance.FakeUsedetail[i].Clone.Count; j++)
                {
                    FackUserManager.Instance.FakeUsedetail[i].Clone[j].transform.SetParent(FackUserManager.Instance.FakeUsedetail[i].UserPosition);
                    FackUserManager.Instance.FakeUsedetail[i].Clone[j].transform.DOLocalMove(new Vector3(0, 0, 0), 1);//2
                                                                                                                      // GC_GrabadeCollector(FackUserManager.Instance.FakeUsedetail[i].Clone[j]);
                    Destroy(FackUserManager.Instance.FakeUsedetail[i].Clone[j], 1.1f);//2                                                                                      
                }
                FackUserManager.Instance.FakeUsedetail[i].Clone.Clear();
                FackUserManager.Instance.FakeUsedetail[i].Clone = new List<GameObject>();
            }
            for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.CloneCoin.Count; i++)
            {
                Destroy(GameModule.Instance.GetActiveGameDetail.CloneCoin[i]);
            }
            GameModule.Instance.GetActiveGameDetail.CloneCoin.Clear();
        }

        //  [DllImport("MyNativeLibrary")]
        //  private static extern void ProcessObject(IntPtr obj);
        //void GC_GrabadeCollector(GameObject Obj)
        //{

        //    //// Create a managed object
        //    // GameObject myObject = new GameObject("MyObject");
        //   // Obj = new GameObject("Coin");

        //    // Pin the object in memory
        //    GCHandle handle = GCHandle.Alloc(Obj, GCHandleType.Pinned);

        //    // Pass the object to native code
        //   // ProcessObject(handle.AddrOfPinnedObject());

        //    // Release the GCHandle when done
        //    handle.Free();
        //}
        public void onStatus(string dragonStatusDetails)
        {
            // Debug.Log("status");
            //  var json = dragonStatusDetails;

            DragonStatusDetail = new DragonStatusDetails();
            DragonStatusDetail = JsonUtility.FromJson<DragonStatusDetails>(dragonStatusDetails.ToString());

            GameController.Instance.CurrentPackage.Gameid = DragonStatusDetail.game_data[0].id; // GAME ID data
            GameController.Instance.CurrentPackage.Time_remaining = DragonStatusDetail.game_data[0].time_remaining;

            for (int i = 0; i < GameModule.Instance.LastWiningDetail.Listwining.Count; i++)
            {
                Destroy(GameModule.Instance.LastWiningDetail.Listwining[i]);
            }
            onProfile();
            if (num == 1)
            {
                Invoke("OnWin", 0.2f);
                for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.targetCoins.Count; i++)
                {
                    GameModule.Instance.GetActiveGameDetail.targetCoins[i].gameObject.GetComponent<Button>().enabled = false;
                }
                BetPlaceManager.Instance.IsBet = false;
            }
            else
            {
                WinManager.Instance.OnInitOff();// endwin
                WinNum = 1;
                BetPlaceManager.Instance.IsBet = true;
                for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.targetCoins.Count; i++)
                {
                    GameModule.Instance.GetActiveGameDetail.targetCoins[i].gameObject.GetComponent<Button>().enabled = true;
                }
            }
        }

        void OnWin()
        {
            if (WinNum == 1)
            {
                StartCoroutine(BetStop());
                WinNum = 5;
                // Debug.Log("Win");
                // WinManager.Instance.OnInit(int.Parse(DragonStatusDetail.game_data[0].winning));// start win               
            }
        }

        void CardMoveOrigin(bool IstrueOrigin)
        {
            for (int i = 0; i < MainController.Instance.WinNextStopDetail.Cardorigin.Count; i++)
            {
                StartCoroutine(OnCardMoveOrigin(i, IstrueOrigin));
            }
        }


        IEnumerator OnCardMoveOrigin(int index, bool Istrue)
        {
            yield return new WaitForSeconds(0.2f);
            MainController.Instance.WinNextStopDetail.Cardorigin[index].SetActive(Istrue);
        }

        void CardAnimator(bool IstrueOrigin)
        {
            if (IstrueOrigin == true)
            {
                MainController.Instance.WinNextStopDetail.CardAnim[0].GetComponent<Image>().sprite = MainController.Instance.WinNextStopDetail.CardAnim[1].GetComponent<Image>().sprite = MainController.Instance.WinNextStopDetail.card;
            }

            for (int i = 0; i < MainController.Instance.WinNextStopDetail.CardAnim.Count; i++)
            {

                StartCoroutine(OnCardMoveAnim(i, IstrueOrigin));
                //if (i == 1)
                //{
                //    wait = 0.2f;
                //    StartCoroutine(OnCardMoveAnim(i, IstrueOrigin));
                //}
                //else
                //{
                //    wait = 2f;
                //    StartCoroutine(OnCardMoveAnim(i, IstrueOrigin));
                //}
                // wait = 1;

            }
        }
        float wait = 0.5f;
        IEnumerator OnCardMoveAnim(int index, bool Istrue)
        {
            // yield return new WaitForSeconds(0.2f);
            yield return new WaitForSeconds(wait);
            MainController.Instance.WinNextStopDetail.CardAnim[index].SetActive(Istrue);
        }

        public Sprite[] Sprites;
        public float floatValues;
        GCHandle handle;
        IEnumerator BetStop()
        {
            //Debug.Log("Bet Stop");
            MainController.Instance.BetStop.SetActive(true); // panel hold raycast
            NumberTxt.text = "Stop";
            yield return new WaitForSeconds(0.2f);
            MainController.Instance.WinNextStopDetail.StopPanel.SetActive(true); // stop animation play
            yield return new WaitForSeconds(1.7f);
            int cardcount = DragonStatusDetail.game_cards.Count;
            if (cardcount > 0)
            {
                // Debug.Log("card show ");
                CardMoveOrigin(false);
                CardAnimator(true);// anim
                for (int i = 0; i < cardcount; i++)
                {
                    CardData.Instance.OnGameDataDetails(i, DragonStatusDetail.game_cards[i].card);
                }
            }
            MainController.Instance.WinNextStopDetail.StopPanel.SetActive(false);
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 2; i++)
            {
                MainController.Instance.WinNextStopDetail.CardAnim[i].GetComponent<Image>().sprite = MainController.Instance.WinNextStopDetail.sprites[i];
            }
            // yield return new WaitForSeconds(0.2f);
            WinManager.Instance.OnInit(int.Parse(DragonStatusDetail.game_data[0].winning));// start win 
            yield return new WaitForSeconds(2.5f);
            WinManager.Instance.OnInitOff();
            MainController.Instance.WinNextStopDetail.WaitingPanel.SetActive(true); //wait for next betting  
            ClearCoinClone();
            yield return new WaitForSeconds(1);
            MainController.Instance.WinNextStopDetail.WaitingPanel.SetActive(false);
            CardAnimator(false);// anim
            CardMoveOrigin(true); // same card play animator
            MainController.Instance.BetStop.SetActive(false);
            for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.targetCoins.Count; i++)
            {
                GameModule.Instance.GetActiveGameDetail.targetCoins[i].OnAnimatOrstop();
            }
            StartCoroutine(ProfileDetails.Instance.PostUserProfile(GameController.Instance.CurrentPackage.Id, GameController.Instance.CurrentPackage.Fcm, GameController.Instance.CurrentPackage.App_version));
            System.GC.Collect();
            //handle.Free();
        }

        public void OnReset()
        {
            GameModule.Instance.SocketdDetail.OnLieBetDemi.text = "00";
        }

        void onProfile()
        {
            GameModule.Instance.GetActiveGameDetail.WiningAmount.text = "";
            Debug.Log("onProfile");
            //  OnStop();
            // add to new profile 
            for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.Profile.Count; i++)
            {
                // Demi profile call in 
                GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().Profilename.text = DragonStatusDetail.bot_user[i].name.ToString();
                GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().Wallet.color = Color.magenta;
                GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().Wallet.text = "\u20B9 " + DragonStatusDetail.bot_user[i].coin.ToString();
                //  StartCoroutine(GameModule.Instance.DownloadImage(DragonStatusDetail.bot_user[i].avatar, GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().ProfileImage));
                StartCoroutine(GameModule.Instance.DownloadImage(DragonStatusDetail.bot_user[i].avatar, GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().AvatarFlick));
                GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<Animator>().enabled = true;
                // GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<Animator>().Play("Circle");
                //  GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<Animator>().Play();

            }
            // StartCoroutine(GameModule.Instance.DownloadImage(GameController.Instance.CurrentPackage.ImgId, GameModule.Instance.GetActiveGameDetail.thisProfileImage));
            GameModule.Instance.GetActiveGameDetail.thisWallet.text = GameController.Instance.CurrentPackage.Wallet;
            GameModule.Instance.GetActiveGameDetail.thisProfilename.text = GameController.Instance.CurrentPackage.Name;
            GameModule.Instance.count++;

            // clear the wining list 
            GameModule.Instance.LastWiningDetail.Listwining.Clear();
            GameModule.Instance.LastWiningDetail.Listwining = new List<GameObject>();

            //// put the value new sprit 
            for (int i = 0; i < DragonStatusDetail.last_winning.Count; i++)
            {
                //  Debug.Log("Get last wining");
                GameModule.Instance.LastWiningDetail.go = Instantiate(GameModule.Instance.LastWiningDetail.prefabLastWining, GameModule.Instance.LastWiningDetail.parent);

                GameModule.Instance.LastWiningDetail.Listwining.Add(GameModule.Instance.LastWiningDetail.go);
                int str = int.Parse(DragonStatusDetail.last_winning[i].winning);

                GameModule.Instance.LastWiningDetail.go.GetComponent<Image>().sprite = GameModule.Instance.LastWiningDetail.sprite[str];
                GameModule.Instance.LastWiningDetail.go.name = GameModule.Instance.count.ToString();

            }
            GameModule.Instance.SocketdDetail.OnLieBetDemi.text = DragonStatusDetail.online.ToString();// onlinebet demi 
            GameModule.Instance.SocketdDetail.DragonText.text = DragonStatusDetail.dragon_bet.ToString();// onlinebet demi 
            GameModule.Instance.SocketdDetail.TieText.text = DragonStatusDetail.tie_bet.ToString();// onlinebet demi 
            GameModule.Instance.SocketdDetail.TigerText.text = DragonStatusDetail.tiger_bet.ToString();// onlinebet demi 

        }

        void OnStop()
        {
            Debug.Log("Stop Animation");

            for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.Profile.Count; i++)
            {
                GameModule.Instance.GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().AvatarFlick.GetComponent<Animator>().enabled = false;
            }
        }

    }



    [Serializable]
    public class BotUser
    {
        public string id;
        public string name;
        public string gender;
        public string coin;
        public string avatar;
        public string added_date;
        public string updated_date;
        public string isDeleted;
    }

    [Serializable]
    public class GameDatum
    {
        public string id;
        public string room_id;
        public string main_card;
        public string winning;
        public string status;
        public string added_date;
        public int time_remaining;
        public string end_datetime;
        public string updated_date;
    }

    [Serializable]
    public class LastWinning
    {
        public string id;
        public string room_id;
        public string main_card;
        public string winning;
        public string status;
        public string winning_amount;
        public string user_amount;
        public string comission_amount;
        public string total_amount;
        public string admin_profit;
        public string end_datetime;
        public string random;
        public string added_date;
        public string updated_date;
    }

    [Serializable]
    public class GameCard
    {
        public string id;
        public string dragon_tiger_id;
        public string card;
        public string added_date;
    }


    [Serializable]
    public class DragonStatusDetails
    {
        public List<BotUser> bot_user;
        public string message;
        public List<GameDatum> game_data;
        public List<GameCard> game_cards;
        public List<object> online_users;
        public int online;
        public List<object> last_bet;
        public object my_dragon_bet;
        public object my_tiger_bet;
        public object my_tie_bet;
        public int dragon_bet;
        public int tiger_bet;
        public int tie_bet;
        public List<LastWinning> last_winning;
        public int code;

    }

}