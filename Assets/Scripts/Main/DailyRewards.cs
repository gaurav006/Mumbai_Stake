using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class WelcomeBonu
{
    public string id;
    public string coin;
    public string game_played;
    public string added_date;
    public string updated_date;

}
[System.Serializable]
public class DailyRewardsOutputs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public string message;
    public int collected_days;
    public List<WelcomeBonu> welcome_bonus;
    public int code;


   
}
[System.Serializable]
public class DailyRewardsDetails
{

}

public class DailyRewards : MonoBehaviour
{

    public DailyRewardsDetails DailyRewardsDetail;
    public DailyRewardsOutputs DailyRewardsOutput;

    private void Awake()
    {
      //  OnDailyRewards();
     
    }

    public void OnDailyRewards()
    {
        string url = Configuration.Url + Configuration.Welcomebonus;
        StartCoroutine(url);
    }

    IEnumerator PostDailyRewards(string Url)
    {
        WWWForm form = new WWWForm();

        form.AddField("user_id", GameController.Instance.CurrentPackage.Id);
        form.AddField("token", GameController.Instance.CurrentPackage.Token);
        UnityWebRequest www = UnityWebRequest.Post(Url, form);
        www.SetRequestHeader("Token", GameController.Instance.CurrentPackage.TokenLogIn);

        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            var responseText = www.downloadHandler.text;
            Debug.Log("Response Place Bet: " + responseText);
            DailyRewardsOutput = new DailyRewardsOutputs();
            DailyRewardsOutput = JsonUtility.FromJson<DailyRewardsOutputs>(responseText);

        }
    }
}
