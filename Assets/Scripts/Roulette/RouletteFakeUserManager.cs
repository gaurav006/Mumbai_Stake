using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteFakeUserManager : MonoBehaviour
{
    public static RouletteFakeUserManager Instance;

    //public FakeUsedetails FakeUsedetail;// user fake details add
   // public Transform Parent;
    public List<Transform> TargetPos;

    public Transform UserPosition;
    public List<GameObject> Clone;
    public List<int> Coin;

    [Header("Prefab")]public GameObject PrefabCoin;

    public void Awake()
    {
        Instance = this;
        for (int i = 0; i < TableManager.Instance.TableNumber.Count; i++)
        {
            TargetPos.Add(TableManager.Instance.TableNumber[i].transform);
        }

    }
}
