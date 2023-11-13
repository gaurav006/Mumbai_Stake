using AndroApps;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UserFake : MonoBehaviour
{
    public static UserFake Instance;

    public Transform Parent;
    public Transform HoldParent;
    public int Coin_Int, Pos, Spritenumber;
    public int Count;
    public List<GameObject> ListFakeCoin;
    public GameObject Obj;



    private void Start()
    {
        Instance = this;
        Obj = this.gameObject;
        HoldParent = Parent = FackUserManager.Instance.FakeUsedetail[Count].UserPosition;

    }
    public void Randemsetposition()
    {
        Coin_Int = Random.Range(1, 10);// random set the value for coin count
        Pos = Random.Range(0, 3); //      
        Spritenumber = Random.Range(0, 5);
       // Debug.Log("Randem range");
        for (int i = 0; i < Coin_Int; i++)
        {
            OnClone();
        }
    }
    void OnClone()
    {
        var go = Instantiate(FackUserManager.Instance.PrefabCoin, Parent);
      //  ListFakeCoin.Add(go);
        FackUserManager.Instance.FakeUsedetail[Count].Clone.Add(go);
        go.name = "OnClone";
        // Debug.Log("Parent : Go " + Parent);
        go.GetComponent<MoveCoin>().IsDemi = true;
        go.GetComponent<Image>().sprite = MainController.Instance.Coin_Sprite[Spritenumber];
        go.GetComponent<MoveCoin>().Parent = FackUserManager.Instance.TargetPos[Pos];

    }

}
