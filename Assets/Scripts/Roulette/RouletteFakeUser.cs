using BestHTTP.SecureProtocol.Org.BouncyCastle.Tls.Crypto;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteFake_User : MonoBehaviour
{
    public Transform Parent;
    public Transform HoldParent;
    public int Coin_Int, Pos, Spritenumber;
    public int Count;

    public GameObject Obj;

    private void Awake()
    {
        DOTween.SetTweensCapacity(1000, 50); // You can adjust these values based on your project's needs
    }
    private void Start()
    {
        Obj = this.gameObject;
        Parent = HoldParent = RouletteFakeUserManager.Instance.UserPosition;
    }

    public void Randemsetposition()
    {
        Coin_Int = Random.Range(1, 10);// random set the value for coin count
      
        Pos = Random.Range(0, 49); //      
        Spritenumber = Random.Range(0, 5);

       // Debug.Log("Randem range");

        for (int i = 0; i < Coin_Int; i++)
        {
            OnClone();
        }

    }

    void OnClone()
    {
        var go = Instantiate(RouletteFakeUserManager.Instance.PrefabCoin, Parent);
        RouletteManager.Instance.ListFakeCoin.Add(go);

        //  go.GetComponent<MoveCoin>().IsDemi = true;
        go.GetComponent<Image>().sprite = MainController.Instance.Coin_Sprite[Spritenumber];
        go.GetComponent<RouletteMoveCoin>().Parent = RouletteFakeUserManager.Instance.TargetPos[Pos];
        // go.transform.DOLocalMove(new Vector3(0, 0, 0), 0.05f);
        go.GetComponent<RouletteMoveCoin>().Let(1);
    }

}

