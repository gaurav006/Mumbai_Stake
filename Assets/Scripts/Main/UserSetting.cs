using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using UnityEngine.UI;
using System.Web;
using TMPro;
using UnityEngine.UI;

[System.Serializable]

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class UserSettingOutPuts
{
    public string message;
    public Setting setting;
    public int code;
}


[System.Serializable]
public class Setting
{
    public string id;
    public string first_name;
    public string last_name;
    public string email_id;
    public string mobile;
    public string role;
    public string status;
    public string password;
    public string sw_password;
    public string min_redeem;
    public string referral_amount;
    public string game_referral_percent;
    public string referral_id;
    public string referral_link;
    public string level_1;
    public string level_2;
    public string level_3;
    public string level_4;
    public string level_5;
    public string contact_us;
    public string about_us;
    public string refund_policy;
    public string terms;
    public string privacy_policy;
    public string help_support;
    public string admin_coin;
    public string jackpot_coin;
    public string jackpot_status;
    public string default_otp;
    public string game_for_private;
    public string app_version;
    public string app_url;
    public string logo;
    public string server_key;
    public string sms_url;
    public string joining_amount;
    public string admin_commission;
    public string whats_no;
    public string bonus;
    public string bonus_amount;
    public string payment_gateway;
    public string neokred_client_secret;
    public string neokred_project_id;
    public string upi_id;
    public string symbol;
    public string upi_merchant_id;
    public string upi_secret_key;
    public string razor_api_key;
    public string razor_secret_key;
    public string cashfree_client_id;
    public string cashfree_client_secret;
    public string cashfree_stage;
    public string paytm_mercent_id;
    public string paytm_mercent_key;
    public string payumoney_key;
    public string payumoney_salt;
    public string share_text;
    public string bank_detail_field;
    public string adhar_card_field;
    public string upi_field;
    public string ban_states;
    public string app_message;
    public string robot_teenpatti;
    public string robot_rummy;
    public string extra_spinner;
    public string ander_bahar_random;
    public string dragon_tiger_random;
    public string jackpot_random;
    public string up_down_random;
    public string car_roulette_random;
    public string animal_roulette_random;
    public string color_prediction_random;
    public string color_prediction_1_min_random;
    public string color_prediction_3_min_random;
    public string head_tail_random;
    public string red_black_random;
    public string bacarate_random;
    public string jhandi_munda_random;
    public string roulette_random;
    public string ander_bahar_plus_random;
    public string target_random;
    public string golden_wheel_random;
    public string created_date;
    public string updated_date;
    public string isDeleted;
}

public class UserSetting : MonoBehaviour
{
    public CloneDetailed CloneDetail;

    public UserSettingOutPuts UserSettingOutPut;

    public string str;
    public Text txt1;
    public TextMeshProUGUI txt;


    private void Start()
    {
        //Debug.Log("LOg setting");
        // OnUserSetting();
    }
    public void OnUserSetting()
    {
        string Url = Configuration.Url + Configuration.Usersetting;
        Debug.Log("URL : " + Url);
        StartCoroutine(PostUserSetting(Url));
    }
    IEnumerator PostUserSetting(string Url)
    {
        WWWForm form = new WWWForm();

        form.AddField("user_id", GameController.Instance.CurrentPackage.Id);
        form.AddField("token", GameController.Instance.CurrentPackage.Token);
        UnityWebRequest www = UnityWebRequest.Post(Url, form);
        www.SetRequestHeader("Token", GameController.Instance.CurrentPackage.TokenLogIn);

        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            var responseText = www.downloadHandler.text;
            Debug.Log("Response Place Bet: " + responseText);
            UserSettingOutPut = new UserSettingOutPuts();
            UserSettingOutPut = JsonUtility.FromJson<UserSettingOutPuts>(responseText.ToString());
            // txt.text = UserSettingOutPut.setting.help_support;
            // txt = HttpUtility.HtmlDecode(encodedHTML);
            //txt1.text = "<i> Plz Contact Us</i>";
        }
        yield return null;
    }
}