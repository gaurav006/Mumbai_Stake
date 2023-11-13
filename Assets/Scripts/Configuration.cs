using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class Configuration : MonoBehaviour
{

    public const string Url = "https://games.androappstech.in/api/"; //https://games.androappstech.in/api/User/register  https://democlient.androappstech.in/api/User/send_otp

    public const string Signup = "User/register";
    public const string LogIn = "User/login";
    public const string Forgot = "User/forgot_password";
    public const string Plan = "Plan";
    public const string Welcomebonus = "User/welcome_bonus";
   // public const string Welcomebonus = "User/welcome_bonus";
    public const string Wallethistory = "user/wallet_history_all";
    public const string Usersetting = "user/setting";
    public const string Usersendotp = "User/send_otp";


    public const string Begins = "Begins";
    public const string Stops = "Stops";
    public const string waitingforthenextround = "waiting for the next round ";
    public const string term = "Term and Conditions";
    public const string PrivacyPolicy = "Privacy Policy";


    //public const string GetActiveGame = "AnderBahar/get_active_game";
    public const string GetActiveGame = "DragonTiger/get_active_game";

    public const string DragonPlaceBet = "DragonTiger/place_bet";
    public const string RoulettePlaceBet = "Roulette/place_bet";



    public const string CancelBet = "DragonTiger/cancel_bet";

    public const string ProfileImage = "https://games.androappstech.in/data/post/";
    public const string BannerImage = "https://games.androappstech.in/uploads/banner/";
    public const string UserProfile = "/User/profile";
    public const string TokenLoginHeader = "c7d3965d49d4a59b0da80e90646aee77548458b3377ba3c0fb43d5ff91d54ea28833080e3de6ebd4fde36e2fb7175cddaf5d8d018ac1467c3d15db21c11b6909";
}
