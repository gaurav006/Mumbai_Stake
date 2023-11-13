using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Bcpg.Sig;

namespace AndroApps_Roulette
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [Serializable]
    public class BotUser
    {
        public string id;
        public string name;
        public string gender;
        public string coin;
        public string avatar;
        public string added_date;
        public string updated_date ;
        public string isDeleted;
    }
    [Serializable]
    public class GameCard
    {
        public string id;
        public string roulette_id;
        public string card;
        public string added_date;
    }
    [Serializable]
    public class GameDatum
    {
        public string id;
        public string room_id;
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
    [Serializable]
    public class  RouletteRoots
    {
        public List<BotUser> bot_user;
        public string message;
        public List<GameDatum> game_data;
        public List<GameCard> game_cards;
        public string online;
        public List<OnlineUser> online_users;
        public int heart_amount;
        public int spade_amount;
        public int diamond_amount;
        public int club_amount;
        public int face_amount;
        public int flag_amount;
        public List<object> last_bet;
        public List<LastWinning> last_winning;
        public int code;
    }



    public class RouletteModule : MonoBehaviour
    {
        public static RouletteModule Instance;
        public RouletteRoots RouletteRoot;


        private void Awake()
        {
            Instance = this;
        }
    }
}
