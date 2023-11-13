using AndroApps;
using Profile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class FakeUsedetails
{
    public Transform UserPosition;
    public List<GameObject> Clone;
    public List<int> Coin;
}

[System.Serializable]
public class CloneDetailed
{
    public GameObject Prefab;
    public Transform Parent;
    public GameObject Go;
    public List<GameObject> ObjList;
    public bool IsClone;
}
public class GameController : MonoBehaviour
{
    public static  GameController Instance;  
    [Header("Scripttable object")] public Manager CurrentPackage;

    void Awake()
    {
        Instance = this;
    }

    public void OnProfile()
    {
        ProfileDetails.Instance.ProfileName.GetComponent<Text>().text = CurrentPackage.Name;
        ProfileDetails.Instance.ProfileID.GetComponent<Text>().text = "ID :"+ CurrentPackage.Id;
        ProfileDetails.Instance.Wallet.GetComponent<Text>().text = CurrentPackage.Wallet;
        ProfileDetails.Instance.RoultteWallet.GetComponent<Text>().text = CurrentPackage.Wallet;
        ProfileDetails.Instance.NameTxt.GetComponent<Text>().text = CurrentPackage.Name;
        ProfileDetails.Instance.RouletteName.GetComponent<Text>().text = CurrentPackage.name;
      
    }
}
