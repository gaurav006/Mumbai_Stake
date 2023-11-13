using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProfileDragon : MonoBehaviour
{
    public Image ProfileImage;
    public Text Profilename;
    public Text Wallet;
    public Image AvatarFlick;
    public Animator obj;


    private void Awake()
    {
        obj = this.GetComponent<Animator>();
        ProfileImage = this.GetComponent<Image>();
        Profilename = this.transform.GetChild(0).gameObject.GetComponent<Text>();
        Wallet = this.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        AvatarFlick = this.transform.GetChild(2).gameObject.GetComponent<Image>();
    }
}
