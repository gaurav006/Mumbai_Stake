using AndroApps;
using Profile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDetials : MonoBehaviour
{
    public static SettingDetials Instance;
    public Text Id, Name;
    public Image ProfilePic;
    public Toggle toggle;
    public int valus = -1;
    public AudioListener audioListener;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        valus = PlayerPrefs.GetInt("Audio");
        if (valus == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
        EnableAudio(toggle.isOn);
    }

    public void OnSettingPanel()
    {
        Id.text = GameController.Instance.CurrentPackage.Id;
        Name.text = GameController.Instance.CurrentPackage.Name;
        ProfilePic.sprite = ProfileDetails.Instance.ProfilePic.sprite;
    }

    public void OnSoundStore()
    {
      //  Debug.Log("Onsound : " + toggle.isOn);
        if (toggle.isOn)
        {
            valus = 1;
        }
        else
        {
            valus = 0;
        }
        EnableAudio(toggle.isOn);
        PlayerPrefs.SetInt("Audio", valus);
    }

    private void EnableAudio(bool istrue)
    {
        // Find the AudioListener in the scene and enable it
        audioListener = FindObjectOfType<AudioListener>();
        audioListener.enabled = istrue;
    }
}
