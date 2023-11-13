using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class OtpOutputs
{
    public string message;
    public int otp_id;
    public int code;
}
[System.Serializable]
public class OtpDetails
{
    public InputField MobileInputfield;
    public InputField OTPCodeInputfield;
    public GameObject Mgs;
}

[System.Serializable]
public class ForgotOutputs
{
    public string message;
    public int code;
}
[System.Serializable]
public class ForgotDetails
{
    public InputField MobileInputfield;   
    public GameObject Mgs;
}
public class OtpManager : MonoBehaviour
{
    public static OtpManager Instance;
    [Header("OTP Manager")] public OtpOutputs OtpOutput = new OtpOutputs();
    public OtpDetails OtpDetail;
    [Header("Forgot Manager")] public ForgotOutputs ForgotOutput = new ForgotOutputs();
    public ForgotDetails ForgotDetial;

    private void Awake()
    {
        Instance = this;
    }
}
