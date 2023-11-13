using AndroApps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.ExceptionServices;

public class Coinitem : MonoBehaviour
{

    public int CoinId;
    public Button btn;
    public GameObject ChildCoin;

    public GameObject PrefabCoin;

    private Transform Parent;
    public Transform Parent_T;
    public Transform Parent_D;
    public Transform Parent_Tie;
    public Transform firstpos;



    public void Start()
    {
        // Defualt value calling ...
        GameModule.Instance.GetActiveGameDetail.Coin = 10;
        CoinInside(10);

        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnCoinValue);
        ChildCoin = this.transform.GetChild(0).gameObject;
       

    }
    public void OnCoinValue()
    {
        Debug.Log("Click Coin " + CoinId);
        GameModule.Instance.GetActiveGameDetail.Coin = CoinId;
        CoinInside(CoinId);
        //PlaceObjectRandomly();
    }

    public void CoinInside(int Index)
    {
        switch (Index)
        {
            case 10:
                {
                    GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[0];
                    GameModule.Instance.GetActiveGameDetail.CoinIndex = 0;
                    GameModule.Instance.GetActiveGameDetail.firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[0].transform;
                    firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[0].transform;
                    break;
                }
            case 50:
                {
                    GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[1];
                    GameModule.Instance.GetActiveGameDetail.CoinIndex = 1;
                    GameModule.Instance.GetActiveGameDetail.firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[1].transform;
                    firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[1].transform;
                    break;
                }
            case 100:
                {
                    GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[2];
                    GameModule.Instance.GetActiveGameDetail.CoinIndex = 2;
                    GameModule.Instance.GetActiveGameDetail.firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[2].transform;
                    firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[2].transform;
                    break;
                }
            case 1000:
                {
                    GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[3];
                    GameModule.Instance.GetActiveGameDetail.CoinIndex = 3;
                    GameModule.Instance.GetActiveGameDetail.firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[3].transform;
                    firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[3].transform;
                    break;
                }
            case 5000:
                {
                    GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[4];
                    GameModule.Instance.GetActiveGameDetail.CoinIndex = 4;
                    GameModule.Instance.GetActiveGameDetail.firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[4].transform;
                    firstpos = GameModule.Instance.GetActiveGameDetail.ChildCoin[4].transform;
                    break;
                }

        }
        Coin(GameModule.Instance.GetActiveGameDetail.CoinIndex);

    }

    void Coin(int index)
    {
        for (int i = 0; i < GameModule.Instance.GetActiveGameDetail.ChildCoin.Count; i++)
        {
            GameModule.Instance.GetActiveGameDetail.ChildCoin[i].SetActive(false);
        }
        GameModule.Instance.GetActiveGameDetail.ChildCoin[index].SetActive(true);
    }

    private void PlaceObjectRandomly()
    {
        // set parent
        switch (GameModule.Instance.GetActiveGameDetail.TargetBet)
        {
            case "Dragon":
                {
                    //firstpos = GameModule.Instance.GetActiveGameDetail.CenterProfile;

                    Parent = Parent_D;
                    break;
                }
            case "Tie":
                {
                    Parent = Parent_Tie;
                    break;
                }
            case "Tiger_Bet":
                {
                    Debug.Log("Tiger");
                    Parent = Parent_T;
                    break;
                }
        }

        //var go = Instantiate(PrefabCoin, Parent);
        var go = Instantiate(PrefabCoin, GameModule.Instance.GetActiveGameDetail.Parent);
        go.name = "Coin";
        go.GetComponent<Image>().sprite = GameModule.Instance.GetActiveGameDetail.CoinSprite;
        go.transform.DOLocalMove(new Vector3(Random.Range(-80, 80), Random.Range(-80, 80), 0), 1); // Dragon
    }
}
