using AndroApps;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TargetCoin : MonoBehaviour
{
    public string TargetBet;
    public GameObject Obj;
    public Transform Parent;
    public Transform firstpos;
    public int Totalbet;
    public int Bet;
    public Text BetTxt;

    private void Start()
    {
        Obj = this.gameObject; OnAnimatOrstop();
        BetTxt.text = "";
    }

    public void OnTargetBet()
    {
       // Debug.Log("Target");
        BetTxt.transform.gameObject.GetComponent<Animator>().enabled = true; // animation play
        GameModule.Instance.GetActiveGameDetail.TargetBet = TargetBet = Obj.name;
       // Debug.Log("targetget : " + TargetBet);
        PlaceObjectRandomly();
        BetPlaceManager.Instance.OnPlaceBet();// bet place 
    }

    private void PlaceObjectRandomly()
    {
        Bet = GameModule.Instance.GetActiveGameDetail.Coin;
        Totalbet = Totalbet + Bet;
        BetTxt.text = Totalbet.ToString();

       // Debug.Log(" Parent : " + GameModule.Instance.GetActiveGameDetail.TargetBet);
        // set parent
        switch (GameModule.Instance.GetActiveGameDetail.TargetBet)
        {
            case "Dragon":
                {
                    BetPlaceManager.Instance.bet = "0";
                    GameModule.Instance.GetActiveGameDetail.Parent = GameModule.Instance.GetActiveGameDetail.Parents[0];
                    break;
                }
            case "Tie":
                {
                    BetPlaceManager.Instance.bet = "2";
                    GameModule.Instance.GetActiveGameDetail.Parent = GameModule.Instance.GetActiveGameDetail.Parents[1];
                    break;
                }
            case "Tiger_Bet":
                {
                    BetPlaceManager.Instance.bet = "1";
                   // Debug.Log("Tiger");
                    GameModule.Instance.GetActiveGameDetail.Parent = GameModule.Instance.GetActiveGameDetail.Parents[2];
                    break;
                }
        }

        if (GameModule.Instance.GetActiveGameDetail.CoinSprite == null) return;
        else
        {
            var go = Instantiate(GameModule.Instance.GetActiveGameDetail.PrefabCoin, GameModule.Instance.GetActiveGameDetail.firstpos);
            firstpos = GameModule.Instance.GetActiveGameDetail.firstpos;
            GameModule.Instance.GetActiveGameDetail.CloneCoin.Add(go);

            if (firstpos == null) return;
            else if (firstpos != null)
                go.transform.position = firstpos.position;

            go.GetComponent<Image>().sprite = GameModule.Instance.GetActiveGameDetail.CoinSprite;
            // go.transform.DOLocalMove(new Vector3(Random.Range(-80, 80), Random.Range(-80, 80), 0), 1); // Dragon
        }
    }

    public void OnAnimatOrstop()
    {
        BetTxt.transform.gameObject.GetComponent<Animator>().enabled = false;
        BetTxt.text = "";
        Totalbet = 0;
    }
}
