using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AndroApps
{

    [System.Serializable]
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
    }

    [System.Serializable]
    public class LogInOutputs
    {
        public string message;
        public List<UserDatum> user_data;
        public int code;
    }

    [System.Serializable]
    public class LogInDetails
    {
        public InputField PasswordInputfield;
        public InputField MobileInputfield;
        public GameObject Mgs;
        public LogIn logIn;
        public GameObject LogInPnl;
        public GameObject ForGot;
    }


    [System.Serializable]
    public class SignUpOutputs
    {
        public string message;
        public List<User> user;
        public string token;
        public int code;
    }

    [System.Serializable]
    public class User
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
        public string color_prediction_1_min_room_id;
        public string color_prediction_3_min_room_id;
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
        public string golden_wheel_room_id;
        public string golden_wheel_star;
        public string game_played;
        public string token;
        public string status;
        public string premium;
        public string app_version;
        public string user_category_id;
        public string unique_token;
        public string added_date;
        public string updated_date;
        public string isDeleted;
    }




    [System.Serializable]
    public class SignUpDetails
    {
        public InputField PasswordInputfield;
        public InputField MobileInputfield;
        public InputField NameInputfield;
        public InputField ReferralCodeInputfield;
        public GameObject Mgs;
        public Toggle _Toggle;
        public GameObject OtpPanel;

        public GameObject SignUpPnl;
    }

    public class LogInModule : MonoBehaviour
    {
        public static LogInModule Instance;
        public LogInOutputs LogInOutput;
        public SignUpOutputs SignUpOutput;
        [Header("LogIn")] public LogInDetails LogInDetail;
        [Header("SignUp")] public SignUpDetails SignUpDetail;

        public void Start()
        {
            Instance = this;
        }
    }
}