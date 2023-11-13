using AndroApps;
using UnityEngine;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    public int Index_Login;
    public GameObject LogInPanel;
    public static bool IsSignUp = false;
    [Header("Api manager")] public APIManagerLevel1 aPIManagerLevel1;

    private void Awake()
    {
        Invoke("OnInitialized", 1);
    }

    private void OnInitialized()
    {
       // Debug.Log("Login Auto ");
        // PlayerPrefs.DeleteAll();
        Index_Login = PlayerPrefs.GetInt("IsLogIn");
        string IsSignup = PlayerPrefs.GetString("IsSignUp");

        if (IsSignup == string.Empty)
        {
            IsSignUp = true;
            // return;
        }
        else if (IsSignup != string.Empty)
        {
            IsSignUp = bool.Parse(IsSignup);
        }

        // Debug.Log("Index" + Index_Login);
        if (Index_Login == 0)
        {
            if (IsSignUp)
            {
                // Debug.Log("Is sign true");
                LogInModule.Instance.SignUpDetail.SignUpPnl.SetActive(true);
                LogInModule.Instance.LogInDetail.LogInPnl.SetActive(false);
                StoreSignUp("true");
            }
            else
            {
                //Debug.Log("Is sign false");
                LogInModule.Instance.SignUpDetail.SignUpPnl.SetActive(false);
                LogInModule.Instance.LogInDetail.LogInPnl.SetActive(true);
                StoreSignUp("false");
            }
            LogInPanel.SetActive(true);
            MainController.Instance.LogOutPanel.SetActive(false);
        }
        else
        {
            LogInPanel.SetActive(false);
            MainController.Instance.LogOutPanel.SetActive(true);
            StartCoroutine(aPIManagerLevel1.LogInId(PlayerPrefs.GetString("Pass"), PlayerPrefs.GetString("ID")));
        }
    }
    public void StoreLogin()
    {
        Index_Login = 1;
        PlayerPrefs.SetInt("IsLogIn", Index_Login);
        StoreSignUp("false");
        LogInPanel.SetActive(false);
        MainController.Instance.LogOutPanel.SetActive(true);
    }
    public void StoreLogOut()
    {
        Index_Login = 0;
        PlayerPrefs.SetInt("IsLogIn", Index_Login);
    }

    public void StoreSignUp(string Status)
    {
       // Debug.Log("Store Sign up");
        PlayerPrefs.SetString("IsSignUp", Status);
    }

    public void LogOut()
    {
        PlayerPrefs.DeleteAll(); //
        LogInPanel.SetActive(true);
        LogInModule.Instance.LogInDetail.LogInPnl.SetActive(true);
        MainController.Instance.LogOutPanel.SetActive(false);
        MainController.Instance.SettingPanel.SetActive(false);
        Debug.Log("LogOut");
        Index_Login = 0;
    }
}
