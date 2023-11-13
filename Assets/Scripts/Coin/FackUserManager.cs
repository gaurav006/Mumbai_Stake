using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FackUserManager : MonoBehaviour
{
    public static FackUserManager Instance;
    public List<int> Coin;
    public List<FakeUsedetails> FakeUsedetail;// user fake details add 
    public List<Transform> TargetPos;
    public GameObject PrefabCoin; 

    public void Awake()
    {
        Instance = this;       
     
    }   
}
