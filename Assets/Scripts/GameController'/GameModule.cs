using BestHTTP.SecureProtocol.Org.BouncyCastle.Tls.Crypto;
using Profile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace AndroApps

{

    [Serializable]
    public class OnlineUser
    {
        public string id;
        public string name;
        public string user_type;
        public string bank_detail;
        public string adhar_card;
        public string upi;
        public string password;
        public string mobile;
        public string email;
        public string source;
        public string gender;
        public string profile_pic;
        public string referral_code;
        public string referred_by;
        public string wallet;
        public string unutilized_wallet;
        public string winning_wallet;
        public string bonus_wallet;
        public string spin_remaining;
        public string fcm;
        public string table_id;
        public string poker_table_id;
        public string head_tail_room_id;
        public string rummy_table_id;
        public string ander_bahar_room_id;
        public string dragon_tiger_room_id;
        public string jackpot_room_id;
        public string seven_up_room_id;
        public string rummy_pool_table_id;
        public string rummy_deal_table_id;
        public string color_prediction_room_id;
        public string car_roulette_room_id;
        public string animal_roulette_room_id;
        public string ludo_table_id;
        public string red_black_id;
        public string baccarat_id;
        public string jhandi_munda_id;
        public string roulette_id;
        public string rummy_tournament_table_id;
        public string target_room_id;
        public string ander_bahar_plus_room_id;
        public string game_played;
        public string token;
        public string status;
        public string premium;
        public string app_version;
        public string user_category_id;
        public string added_date;
        public string updated_date;
        public string isDeleted;
        public object unique_token;
    }
    [Serializable]
    public class Profile
    {
        public string id;
        public string name;
        public string user_type;
        public string bank_detail;
        public string adhar_card;
        public string upi;
        public string password;
        public string mobile;
        public string email;
        public string source;
        public string gender;
        public string profile_pic;
        public string referral_code;
        public string referred_by;
        public string wallet;
        public string unutilized_wallet;
        public string winning_wallet;
        public string bonus_wallet;
        public string spin_remaining;
        public string fcm;
        public string table_id;
        public string poker_table_id;
        public string head_tail_room_id;
        public string rummy_table_id;
        public string ander_bahar_room_id;
        public string dragon_tiger_room_id;
        public string jackpot_room_id;
        public string seven_up_room_id;
        public string rummy_pool_table_id;
        public string rummy_deal_table_id;
        public string color_prediction_room_id;
        public string car_roulette_room_id;
        public string animal_roulette_room_id;
        public string ludo_table_id;
        public string red_black_id;
        public string baccarat_id;
        public string jhandi_munda_id;
        public string roulette_id;
        public string rummy_tournament_table_id;
        public string target_room_id;
        public string ander_bahar_plus_room_id;
        public string game_played;
        public string token;
        public string status;
        public string premium;
        public string app_version;
        public string user_category_id;
        public string added_date;
        public string updated_date;
        public string isDeleted;
        public object unique_token;
        public object user_category;
    }

    [Serializable]
    public class GetActiveGames
    {
        public List<BotUser> bot_user;
        public string message;
        public List<GameDatum> game_data;
        public List<GameCard> game_cards;
        public List<OnlineUser> online_users;
        public int online;
        public List<object> last_bet;
        public object my_ander_bet;
        public object my_bahar_bet;
        public int ander_bet;
        public int bahar_bet;
        public List<LastWinning> last_winning;
        public List<Profile> profile;
        public int code;
    }
    [Serializable]
    public class GetActiveGameDetails
    {
        public List<GameObject> Profile;


        public Image thisProfileImage;
        public Text thisProfilename;
        public Text thisWallet, WiningAmount;
        public int Coin;
        public List<TargetCoin> targetCoins;
        public string TargetBet;
        public List<Sprite> CoinSprit;

        public List<GameObject> ChildCoin;// = new List<GameObject>();
        public List<Transform> Parents;
        public Transform CenterProfile;


        [Header("hold data ")]
        public int CoinIndex = -1;
        public Sprite CoinSprite;
        public Transform Parent;
        public Transform firstpos;
        public GameObject PrefabCoin;
        public List<GameObject> CloneCoin;


    }

    [Serializable]
    public class LastWiningDetails
    {
        public GameObject prefabLastWining;
        public Transform parent;
        public GameObject go;
        public List<GameObject> Listwining;
        public List<Sprite> sprite;

    }

    [Serializable]
    public class SocketdDetails
    {
        [Header("Socket_Controller")] public GameObject SocketController;
        public Text OnLieBetDemi;
        public Text DragonText;
        public Text TieText;
        public Text TigerText;
        public GameObject LossConnection;
    }

    public class GameModule : MonoBehaviour
    {
        public static GameModule Instance;

        public GetActiveGames getActiveGame;
        public GetActiveGameDetails GetActiveGameDetail;
        [Header("bet place")] public BetPlaces BetPlace;
        [Header("Last Wining")] public LastWiningDetails LastWiningDetail;

        // socket working 
        [Header("Socket Controller Details")] public SocketdDetails SocketdDetail;
        public GameObject MainController;


        public int count;
        private void Awake()
        {
            Instance = this;
            MainController = this.gameObject;
        }
        private void Start() { }

        public void OnGetActiveGame()
        {
            // Debug.Log("On Get Active");
            //  StartCoroutine(PostGetActive()); only use to API 


            SocketdDetail.SocketController.SetActive(true);// socket start 

        }

        IEnumerator PostGetActive()
        {
            string Url = Configuration.Url + Configuration.GetActiveGame;
            WWWForm form = new WWWForm();
            form.AddField("room_id", "1");
            form.AddField("user_id", "20");
            //form.AddField("token", GameController.Instance.CurrentPackage.Token);
            // form.AddField("token", "0cc28fdd22c72846fad41d410f46173c");
            form.AddField("token", "38b85d6ff52321d23793a9a69093ab7f");
            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            //www.SetRequestHeader("Token", Token);
            www.SetRequestHeader("Token", GameController.Instance.CurrentPackage.TokenLogIn);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
                Debug.Log("Response Get active : " + responseText);
                getActiveGame = new GetActiveGames();
                getActiveGame = JsonUtility.FromJson<GetActiveGames>(responseText.ToString());
                GameController.Instance.CurrentPackage.Gameid = getActiveGame.game_data[0].id; // GAME ID data
                GameController.Instance.CurrentPackage.Time_remaining = getActiveGame.game_data[0].time_remaining;
                for (int i = 0; i < LastWiningDetail.Listwining.Count; i++)
                {
                    Destroy(LastWiningDetail.Listwining[i]);
                }
                // onProfile();
                //int Count = MainController.transform.GetChildCount

            }
            else
            {
                //  Debug.Log("error" + www.error);
            }
            yield return null;
        }


        void onProfile()
        {
            // add to new profile 
            for (int i = 0; i < GetActiveGameDetail.Profile.Count; i++)
            {
                GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().Profilename.text = getActiveGame.bot_user[i].name.ToString();
                GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().Wallet.color = Color.magenta;
                GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().Wallet.text = "\u20B9 " + getActiveGame.bot_user[i].coin.ToString();
                StartCoroutine(DownloadImage(getActiveGame.bot_user[i].avatar, GetActiveGameDetail.Profile[i].GetComponent<GameProfileDragon>().ProfileImage));
            }
            StartCoroutine(DownloadImage(GameController.Instance.CurrentPackage.ImgId, GetActiveGameDetail.thisProfileImage));
            GetActiveGameDetail.thisWallet.text = GameController.Instance.CurrentPackage.Wallet;
            GetActiveGameDetail.thisProfilename.text = GameController.Instance.CurrentPackage.Name;
            count++;
            // clear the wining list 
            LastWiningDetail.Listwining.Clear();
            LastWiningDetail.Listwining = new List<GameObject>();
            // put the value new sprit 
            for (int i = 0; i < getActiveGame.last_winning.Count; i++)
            {
                //  Debug.Log("Get last wining");
                LastWiningDetail.go = Instantiate(LastWiningDetail.prefabLastWining, LastWiningDetail.parent);
                LastWiningDetail.Listwining.Add(LastWiningDetail.go);
                int str = int.Parse(getActiveGame.last_winning[i].winning);
                LastWiningDetail.go.GetComponent<Image>().sprite = LastWiningDetail.sprite[str];
                LastWiningDetail.go.name = count.ToString();
            }
        }


        public IEnumerator DownloadImageBanner(string ProfileAvatar, Image img)
        {
            string Url = Configuration.BannerImage;
            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(Url + ProfileAvatar))
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Convert the downloaded data to a texture
                    Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(webRequest);
                    img.sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), Vector2.zero);
                }
                else
                {
                    // Debug.Log("Error: " + webRequest.error);
                }
            }
            yield return null;
        }

        public IEnumerator DownloadImage(string ProfileAvatar, Image img)
        {
            string Url = Configuration.ProfileImage;
            using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(Url + ProfileAvatar))
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Convert the downloaded data to a texture
                    Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(webRequest);                    
                    img.sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), Vector2.zero);
                    // Debug.LogError("Name" + this.transform.GetChild(0).name);                   
                    if (ProfileDetails.Instance.IsProfileImage)
                    {
                        ProfileDetails.Instance.sSprite = img.sprite;
                        ProfileDetails.Instance.IsProfileImage = false;
                        ProfileDetails.Instance.img_Sprite.sprite = ProfileDetails.Instance.sSprite;
                    }
                }
                else
                {
                    Debug.Log("Error: " + webRequest.error);
                }
                yield return null; // check 
            }
        }       

        public void OnCancelBet()
        {
            StartCoroutine(PostCancelBet());
            StopCoroutine(PostCancelBet());
        }

        IEnumerator PostCancelBet()
        {
            string Url = Configuration.Url + Configuration.CancelBet;
            WWWForm form = new WWWForm();
            //form.AddField("bet", "0");
            //form.AddField("amount", "10");
            //form.AddField("user_id", "20");
            //form.AddField("game_id", "843");
            //form.AddField("token", "38b85d6ff52321d23793a9a69093ab7f");
            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            www.SetRequestHeader("Token", GameController.Instance.CurrentPackage.TokenLogIn);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
                Debug.Log("Response: " + responseText);
            }
            else
            {
                Debug.Log("error" + www.error);
            }
            yield return null;
        }
    }
}