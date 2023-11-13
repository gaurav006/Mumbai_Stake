using AndroApps;
using Profile;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class BetPlaces
{
    public string message;
    public int bet_id;
    public string wallet;
    public int code;
}
public class BetPlaceManager : MonoBehaviour
{
    public static BetPlaceManager Instance;

    [Header("bet place")] public BetPlaces BetPlace;

    [Header("Bet Value ")] public string bet;
    [Header("Bet Url")] public string Url;
    [Header("Betis Amount")] public string amount;
    public bool IsBet;

    private void Awake() { Instance = this; }
    private void Start() { }

    public void OnPlaceBet()
    {
        //Debug.LogError("on place");
        if (IsBet)
        {
            Debug.Log("On bet  place  manager ");
            UrlManager.Instance.OnUrlManagerBet(GameController.Instance.CurrentPackage.BetPlaceIndex);
            Url = UrlManager.Instance.UrlBetPlace;
            amount = GameModule.Instance.GetActiveGameDetail.Coin.ToString();
            StartCoroutine(PostPlacebet(amount, Url, bet));
        }
        else
        {
            Debug.Log("Is bet not be ");
        }
    }



    IEnumerator PostPlacebet(string amount, string Url, string bet)
    {
        //Debug.LogError("CurrentPackage.Gameid : " + GameController.Instance.CurrentPackage.Gameid);
        //  string Url = Configuration.Url + Configuration.RoulettePlaceBet;
       // Debug.Log("Roulette Url : " + Url);
        WWWForm form = new WWWForm();
        form.AddField("bet", bet);
        form.AddField("amount", amount);
        form.AddField("user_id", GameController.Instance.CurrentPackage.Id);
        form.AddField("game_id", GameController.Instance.CurrentPackage.Gameid);
        form.AddField("token", GameController.Instance.CurrentPackage.Token);

        UnityWebRequest www = UnityWebRequest.Post(Url, form);
        www.SetRequestHeader("Token", GameController.Instance.CurrentPackage.TokenLogIn);

        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            var responseText = www.downloadHandler.text;
           // Debug.Log("Roulette Response Place Bet: " + responseText);
            BetPlace = new BetPlaces();
            BetPlace = JsonUtility.FromJson<BetPlaces>(responseText.ToString());
            UrlManager.Instance.Mgss.GetComponent<Text>().text = BetPlace.message;
            StartCoroutine(ProfileDetails.Instance.PostUserProfile(GameController.Instance.CurrentPackage.Id, GameController.Instance.CurrentPackage.Fcm, GameController.Instance.CurrentPackage.App_version));
        }
        else
        {
            Debug.Log("error" + www.error);
        }
        yield return null;
    }
}