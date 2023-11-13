using Microsoft.Win32;
using Profile;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

namespace AndroApps
{
    public class APIManagerLevel1 : MonoBehaviour
    {
        public static APIManagerLevel1 Instance;
        public LogInModule logInModule;
        public int number;

        private void Awake()
        {
            Instance = this;
        }
        public void OnClickLogIn()
        {
            number = 0;
            //  logInModule = GetComponent<LogInModule>();
            string password = logInModule.LogInDetail.PasswordInputfield.text;
            string Id = logInModule.LogInDetail.MobileInputfield.text;

            // Debug.Log("url : " + Url + ":ID:" + Id + " : :pass: :" + password + ": :Token ::" + Token);

            InternetCheck.Instance.CheckInternetConnection();
            if (InternetCheck.Instance.IsConnection)
            {
                if ((password == string.Empty && Id == string.Empty) || (password != string.Empty && Id == string.Empty) || (password == string.Empty && Id != string.Empty))
                {
                    logInModule.LogInDetail.Mgs.SetActive(true);
                    logInModule.LogInDetail.Mgs.GetComponent<Text>().text = "Please the filled the detial.";
                    logInModule.LogInDetail.Mgs.GetComponent<Text>().color = Color.red;
                    Invoke("OnMgsClear", 4);
                    return;
                }
                else if (password != string.Empty && Id != string.Empty)
                {
                    // if ((password.Length == 5) && (Id.Length == 10))
                    if (Id.Length == 10)
                    {
                        Debug.Log("Count");
                        //StartCoroutine(LogInId(Url, password, Id, Token));
                        StartCoroutine(LogInId(password, Id));
                    }
                    else
                    {
                        logInModule.LogInDetail.Mgs.SetActive(true);
                        logInModule.LogInDetail.Mgs.GetComponent<Text>().text = "Please the filled the complete detial.";
                        logInModule.LogInDetail.Mgs.GetComponent<Text>().color = Color.red;
                        Invoke("OnMgsClear", 4);
                    }
                }
            }
        }

        void OnMgsClear()
        {
            if (number == 0)
            {
                logInModule.LogInDetail.Mgs.SetActive(false);
                logInModule.LogInDetail.Mgs.GetComponent<Text>().text = "";
            }
            else if (number == 1)
            {
                logInModule.SignUpDetail.Mgs.SetActive(false);
                logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "";
            }
            else if (number == 2)
            {
                // OTP info
                OtpManager.Instance.OtpDetail.Mgs.SetActive(false);
                OtpManager.Instance.OtpDetail.Mgs.GetComponent<Text>().text = "";
            }
            else if (number == 3)
            {
                // forgot info
                OtpManager.Instance.ForgotDetial.Mgs.SetActive(false);
                OtpManager.Instance.ForgotDetial.Mgs.GetComponent<Text>().text = "";
            }
            Debug.Log("Mgs clear");
        }

        public IEnumerator LogInId(string Password, string Id)//string Token)
        {
            string Token = GameController.Instance.CurrentPackage.TokenLogIn;
            string Url = Configuration.Url + Configuration.LogIn;

            WWWForm form = new WWWForm();
            form.AddField("mobile", Id);
            form.AddField("password", Password);
            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            www.SetRequestHeader("Token", Token);

            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
                //  Debug.Log("Response LogIn : " + responseText);

                logInModule.LogInOutput = new LogInOutputs();
                logInModule.LogInOutput = JsonUtility.FromJson<LogInOutputs>(responseText.ToString());

                GameController.Instance.CurrentPackage.Name = logInModule.LogInOutput.user_data[0].name;
                GameController.Instance.CurrentPackage.Id = logInModule.LogInOutput.user_data[0].id;

                GameController.Instance.CurrentPackage.Wallet = logInModule.LogInOutput.user_data[0].wallet;
                GameController.Instance.CurrentPackage.Bonus_wallet = logInModule.LogInOutput.user_data[0].bonus_wallet;
                GameController.Instance.CurrentPackage.Token = logInModule.LogInOutput.user_data[0].token;
                GameController.Instance.CurrentPackage.ImgId = logInModule.LogInOutput.user_data[0].profile_pic;
                GameController.Instance.CurrentPackage.Fcm = logInModule.LogInOutput.user_data[0].fcm;
                GameController.Instance.CurrentPackage.App_version = logInModule.LogInOutput.user_data[0].app_version;
                GameController.Instance.OnProfile();

                //Invoke("OnResponseAPICode", 1);
                logInModule.LogInDetail.logIn.StoreLogin();

                PlayerPrefs.SetString("ID", Id);
                PlayerPrefs.SetString("Pass", Password);

                ProfileDetails.Instance.IsProfileImage = true;
                StartCoroutine(ProfileDetails.Instance.PostUserProfile(GameController.Instance.CurrentPackage.Id, GameController.Instance.CurrentPackage.Fcm, GameController.Instance.CurrentPackage.App_version));

            }
            else
            {
                Debug.Log("error" + www.error);
                logInModule.LogInDetail.Mgs.GetComponent<Text>().text = www.error;
                logInModule.LogInDetail.Mgs.GetComponent<Text>().color = Color.red;
                Invoke("OnMgsClear", 2);
            }
            yield return null;

        }

        public void OnClickSignUp()
        {
            Debug.Log("signup click");
            number = 1;
            GameController.Instance.CurrentPackage.Mobile = logInModule.SignUpDetail.MobileInputfield.text;
            GameController.Instance.CurrentPackage.Password = logInModule.SignUpDetail.PasswordInputfield.text;
            GameController.Instance.CurrentPackage.Name = logInModule.SignUpDetail.NameInputfield.text;
            GameController.Instance.CurrentPackage.Referral = logInModule.SignUpDetail.ReferralCodeInputfield.text;

            InternetCheck.Instance.CheckInternetConnection();
            if (InternetCheck.Instance.IsConnection)
            {
                if ((GameController.Instance.CurrentPackage.Password == string.Empty && GameController.Instance.CurrentPackage.Mobile == string.Empty && GameController.Instance.CurrentPackage.Name == string.Empty) ||
                    (GameController.Instance.CurrentPackage.Password != string.Empty && GameController.Instance.CurrentPackage.Mobile == string.Empty && GameController.Instance.CurrentPackage.Name == string.Empty) ||
                    (GameController.Instance.CurrentPackage.Password == string.Empty && GameController.Instance.CurrentPackage.Mobile != string.Empty && GameController.Instance.CurrentPackage.Name == string.Empty) ||
                    (GameController.Instance.CurrentPackage.Password == string.Empty && GameController.Instance.CurrentPackage.Mobile == string.Empty && GameController.Instance.CurrentPackage.Name != string.Empty))
                {
                    logInModule.SignUpDetail.Mgs.SetActive(true);
                    logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "Please the filled the detial.";
                    logInModule.SignUpDetail.Mgs.GetComponent<Text>().color = Color.red;
                    Invoke("OnMgsClear", 4);
                    return;
                }


                else if (GameController.Instance.CurrentPackage.Password != string.Empty && GameController.Instance.CurrentPackage.Mobile != string.Empty && GameController.Instance.CurrentPackage.Name != string.Empty)
                {
                    if ((GameController.Instance.CurrentPackage.Password.Length > 4) && (GameController.Instance.CurrentPackage.Mobile.Length == 10))
                    {
                        //if (logInModule.SignUpDetail._Toggle.isOn)
                        //{
                        Debug.Log("PostUserSendOtp");
                        StartCoroutine(PostUserSendOtp(GameController.Instance.CurrentPackage.Mobile, GameController.Instance.CurrentPackage.Register));
                        //}
                        //else
                        //{
                        //    logInModule.SignUpDetail.Mgs.SetActive(true);
                        //    logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "Please select check box.";
                        //    logInModule.SignUpDetail.Mgs.GetComponent<Text>().color = Color.red;
                        //    Invoke("OnMgsClear", 4);
                        //}
                    }
                    else
                    {

                        if ((GameController.Instance.CurrentPackage.Mobile.Length > 10) || (GameController.Instance.CurrentPackage.Mobile.Length < 10))
                        {
                            logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "Please filled right detail.";
                        }
                        else
                        {
                            if (GameController.Instance.CurrentPackage.Password.Length < 4)
                            {
                                logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "The password does not contain the required minimum 5 characters.";
                            }
                        }
                        logInModule.SignUpDetail.Mgs.SetActive(true);
                        logInModule.SignUpDetail.Mgs.GetComponent<Text>().color = Color.red;
                        Invoke("OnMgsClear", 4);
                    }
                }
                else
                {

                    logInModule.SignUpDetail.Mgs.SetActive(true);
                    logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "Please filled the complete detial.";
                    logInModule.SignUpDetail.Mgs.GetComponent<Text>().color = Color.red;
                    Invoke("OnMgsClear", 4);

                }
            }
        }


        IEnumerator PostSignup(string Name, string mobile, string Password, string Referrel, string otp, string otp_id, string type)
        {
            string Token = GameController.Instance.CurrentPackage.TokenLogIn;
            string Url = Configuration.Url + Configuration.Signup;

            WWWForm form = new WWWForm();
            form.AddField("name", Name);
            form.AddField("mobile", mobile);
            form.AddField("password", Password);
            form.AddField("type", type);
            form.AddField("otp_id", otp_id);
            form.AddField("otp", otp);
            form.AddField("gender", "m");
            // form.AddField("referral_code", Referrel);
            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            www.SetRequestHeader("Token", Token);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
                Debug.Log("Response SignUp : " + responseText);
                logInModule.SignUpOutput = new SignUpOutputs();
                logInModule.SignUpOutput = JsonUtility.FromJson<SignUpOutputs>(responseText.ToString());

                logInModule.SignUpDetail.OtpPanel.SetActive(false);
                logInModule.LogInDetail.LogInPnl.SetActive(true);
                logInModule.SignUpDetail.MobileInputfield.text = logInModule.SignUpDetail.PasswordInputfield.text = logInModule.SignUpDetail.NameInputfield.text = logInModule.SignUpDetail.ReferralCodeInputfield.text = "";
            }
            else
            {
                Debug.Log("Else sign up ");
                logInModule.SignUpDetail.Mgs.SetActive(true);
                logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = www.result.ToString();
                logInModule.SignUpDetail.Mgs.GetComponent<Text>().color = Color.red;
                Invoke("OnMgsClear", 4);
            }
            yield return null;
        }


        public void OnClickOtp()
        {
            number = 2;
            Debug.Log("OTP click");

            //if (OtpManager.Instance.OtpDetail.MobileInputfield.text == )

            if (OtpManager.Instance.OtpDetail.OTPCodeInputfield.text.Length == 4)
            {
                string mobile = OtpManager.Instance.OtpDetail.MobileInputfield.text;
                string otp = OtpManager.Instance.OtpDetail.OTPCodeInputfield.text;
                StartCoroutine(PostSignup(GameController.Instance.CurrentPackage.Name, GameController.Instance.CurrentPackage.Mobile, GameController.Instance.CurrentPackage.Password, GameController.Instance.CurrentPackage.Referral, otp, GameController.Instance.CurrentPackage.Otp_id, GameController.Instance.CurrentPackage.Register));

            }
            else
            {
                OtpManager.Instance.OtpDetail.Mgs.SetActive(true);
                OtpManager.Instance.OtpDetail.Mgs.GetComponent<Text>().text = "Please filled the right detials.";
                OtpManager.Instance.OtpDetail.Mgs.GetComponent<Text>().color = Color.red;
                Invoke("OnMgsClear", 4);
            }

        }

        IEnumerator PostUserSendOtp(string mobile, string type)
        {
            string Token = GameController.Instance.CurrentPackage.TokenLogIn;
            string Url = Configuration.Url + Configuration.Usersendotp;

            WWWForm form = new WWWForm();
            form.AddField("mobile", mobile);
            form.AddField("type", type);

            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            www.SetRequestHeader("Token", Token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
                OtpManager.Instance.OtpOutput = new OtpOutputs();
                OtpManager.Instance.OtpOutput = JsonUtility.FromJson<OtpOutputs>(responseText.ToString());
                GameController.Instance.CurrentPackage.Otp_id = OtpManager.Instance.OtpOutput.otp_id.ToString();
                Debug.Log("Response SignUp : " + responseText);

                if (OtpManager.Instance.OtpOutput.code == 200)
                {
                    logInModule.SignUpDetail.OtpPanel.SetActive(true);
                    logInModule.SignUpDetail.SignUpPnl.SetActive(false);
                }
                else
                {
                    //logInModule.SignUpDetail.SignUpPnl.SetActive(true);                    
                    logInModule.SignUpDetail.Mgs.SetActive(true);
                    logInModule.SignUpDetail.Mgs.GetComponent<Text>().text = "Mobile Already Exist, Please Login";
                    logInModule.SignUpDetail.Mgs.GetComponent<Text>().color = Color.red;
                    Invoke("OnMgsClear", 4);
                }
            }
            yield return null;
        }


        public void OnClickForgot()
        {
            Debug.Log("ForGot");
            number = 3;
            string str = OtpManager.Instance.ForgotDetial.MobileInputfield.text;
            if (str.Length == 10)
                StartCoroutine(PostForGot(OtpManager.Instance.ForgotDetial.MobileInputfield.text));
            else
            {
                OtpManager.Instance.ForgotDetial.Mgs.SetActive(true);
                OtpManager.Instance.ForgotDetial.Mgs.GetComponent<Text>().text = "Please put the right text";
                OtpManager.Instance.ForgotDetial.Mgs.GetComponent<Text>().color = Color.red;
                Invoke("OnMgsClear", 4);
            }
        }

        IEnumerator PostForGot(string mobile)
        {
            string Token = GameController.Instance.CurrentPackage.TokenLogIn;
            string Url = Configuration.Url + Configuration.Forgot;

            WWWForm form = new WWWForm();
            form.AddField("mobile", mobile);

            UnityWebRequest www = UnityWebRequest.Post(Url, form);
            www.SetRequestHeader("Token", Token);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                var responseText = www.downloadHandler.text;
                OtpManager.Instance.ForgotOutput = new ForgotOutputs();
                OtpManager.Instance.ForgotOutput = JsonUtility.FromJson<ForgotOutputs>(responseText.ToString());

                logInModule.LogInDetail.LogInPnl.SetActive(true);
                logInModule.LogInDetail.ForGot.SetActive(false);
                Debug.Log("Response SignUp : " + responseText);
            }
            yield return null;
        }
    }
}