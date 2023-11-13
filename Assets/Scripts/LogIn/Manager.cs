using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace AndroApps
{

    [CreateAssetMenu(fileName = "Manager", menuName = "Andro/Attributes")]
    public class Manager : ScriptableObject
    {

        public string Name;
        public string Id;
        public string Wallet;
        public string Bonus_wallet;
        public string Token;
        public string TokenLogIn;
        public int Time_remaining;
        public string Gameid;
        public string ImgId;
        public string Fcm;
        public string App_version;
        public bool IsInternet;
        public int BetPlaceIndex;

        public string Register = "register";
        public string Password;
        public string Mobile;
        public string Otp_id;
        public string Referral;

    }
}