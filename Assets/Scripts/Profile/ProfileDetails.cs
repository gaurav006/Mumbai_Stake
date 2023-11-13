using AndroApps;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.VFX;
//using UnityEngine.UIElements;

namespace Profile
{
    [Serializable]
    public class AppBanner
    {
        public string id;
        public string banner;
        public string createdDate;
        public object updatedDate;
        public string isDeleted;
    }


    [Serializable]
    public class Setting
    {
        public string min_redeem;
        public string referral_amount;
        public string contact_us;
        public string help_support;
        public string game_for_private;
        public string app_version;
        public string joining_amount;
        public string whats_no;
        public string bonus;
        public string payment_gateway;
        public string symbol;
        public string razor_api_key;
        public string cashfree_client_id;
        public string cashfree_stage;
        public string paytm_mercent_id;
        public string payumoney_key;
        public string share_text;
        public string bank_detail_field;
        public string adhar_card_field;
        public string upi_field;
        public string referral_link;
        public string referral_id;
        public string app_message;
        public string upi_merchant_id;
        public string upi_secret_key;
        public string admin_commission;
        public string upi_id;
        public string extra_spinner;
    }

    [Serializable]
    public class UserDatum
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
    public class ProfileAPIs
    {
        public string message;
        public List<UserDatum> user_data;
        public List<object> user_kyc;
        public List<object> user_bank_details;
        public List<string> avatar;
        public Setting setting;
        public List<AppBanner> app_banner;
        public int code;
    }



    public class ProfileDetails : MonoBehaviour
    {
        public static ProfileDetails Instance;

        public GameObject ProfileName;
        public Text ProfileID;
        public GameObject Wallet;
        public GameObject RoultteWallet;
        public Image ProfilePic;
        public Image RouletteImage;
        public Text RouletteName;

        public Text NameTxt;

        public ProfileAPIs ProfileAPI;

        public int Count;
        public int ConstantCount = 0;
        public int MaxCount;

        public List<GameObject> BannerList = new List<GameObject>();

        public bool IsProfileImage;
        public Image img_Sprite;
        public Sprite sSprite;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //OnClickUserProfile();
        }


        public void OnClickUserProfile()
        {
            string id = APIManagerLevel1.Instance.logInModule.LogInOutput.user_data[0].id;
            string fcm = APIManagerLevel1.Instance.logInModule.LogInOutput.user_data[0].fcm;
            Debug.Log("fCM " + fcm);
            string App_Version = APIManagerLevel1.Instance.logInModule.LogInOutput.user_data[0].app_version;
            StartCoroutine(PostUserProfile(id, fcm, App_Version));
        }

        public IEnumerator PostUserProfile(string Id, string Fcm, string App_version)//string Token)
        {
            string TokenLogin = GameController.Instance.CurrentPackage.TokenLogIn;
            string Token = GameController.Instance.CurrentPackage.Token;
            //  Debug.Log("Token : " + Token);

            string Url = Configuration.Url + Configuration.UserProfile;
            WWWForm form = new WWWForm();
            form.AddField("fcm", Fcm);
            form.AddField("app_version", App_version);
            form.AddField("id", Id);
            form.AddField("token", Token);

            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            www.SetRequestHeader("Token", TokenLogin);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
               // Debug.Log("Response LogIn : " + responseText);

                ProfileAPI = new ProfileAPIs();

                ProfileAPI = JsonUtility.FromJson<ProfileAPIs>(responseText.ToString());

                if (IsProfileImage)
                {   //profile_pic
                    StartCoroutine(GameModule.Instance.DownloadImage(ProfileAPI.user_data[0].profile_pic, ProfilePic));
                  //  StartCoroutine(GameModule.Instance.DownloadImage(ProfileAPI.user_data[0].profile_pic, RouletteImage));
                  
                }
                //wallet
                GameModule.Instance.GetActiveGameDetail.thisWallet.text = RoultteWallet.GetComponent<Text>().text = GameController.Instance.CurrentPackage.Wallet = ProfileAPI.user_data[0].wallet;
                SettingDetials.Instance.ProfilePic.sprite = ProfilePic.sprite;
                OnClone();               
            }
            yield return null;

        }
        public void OnClone()
        {
            BannerList.Clear();
            MaxCount = ProfileAPI.app_banner.Count;
            for (int i = 0; i < ProfileAPI.app_banner.Count; i++)
            {
                var go = Instantiate(MainController.Instance.Bannerdetal.Prefab, MainController.Instance.Bannerdetal.Parent);
                go.GetComponent<BannerClick>().Count = i;
                BannerList.Add(go);
                //   Debug.Log("Clone :  " + ProfileAPI.app_banner[i].banner);
                StartCoroutine(GameModule.Instance.DownloadImageBanner(ProfileAPI.app_banner[i].banner, BannerList[i].transform.GetChild(0).GetComponent<Image>()));
            }
            //   CancelInvoke();
            // IncreaseIndex();
        }

        public bool TouchBool;

        public void IncreaseIndex()
        {
            if (TouchBool)
            {
                CancelInvoke();
            }

            if (Count == MaxCount - 1)
            {
                MainController.Instance.Bannerdetal.NumberLess = Count;
                Count = 0;
            }
            else if (Count < MaxCount)
            {
                MainController.Instance.Bannerdetal.NumberLess = Count;
                Count++;
            }

            //  Debug.Log("Inc Else : " + Count);
            OnOffBanner(Count, MainController.Instance.Bannerdetal.NumberLess);

        }

        void OnOffBanner(int index, int numberless)
        {
            MainController.Instance.Bannerdetal.BG_Banner.GetComponent<Image>().sprite = BannerList[numberless].transform.GetChild(0).GetComponent<Image>().sprite;
            for (int i = 0; i < BannerList.Count; i++)
            {
                BannerList[i].SetActive(false);
            }
            BannerList[index].SetActive(true);
            Invoke("IncreaseIndex", 5);
        }

    }
}