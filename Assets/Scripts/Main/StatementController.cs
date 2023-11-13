using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

[System.Serializable]
public class GameLog
{
    public string game;
    public string reff_id;
    public string bet_id;
    public string user_id;
    public string winning_amount;
    public string added_date;
    public string amount;
    public string user_amount;
    public string is_game;
    public string user_wallet;
    public int bracket_amount;
    public object total;
}
[System.Serializable]
public class StatementOutputs
{
    public List<GameLog> GameLog;
    public string message;
    public int code;
}
[System.Serializable]
public class StatementDetails
{
    public GameObject Prefab;
    public Transform Parent;
    public GameObject go;
    public List<GameObject> statement;
    public bool IsStatement;
}

// Wallethistory
public class StatementController : MonoBehaviour
{
    public StatementDetails statementDetail;
    public StatementOutputs statementOutput;

    private void Start()
    {
        
    }

    public void OnStatement()
    {
        if (statementDetail.IsStatement)
        {
            for (int i = 0; i < statementDetail.statement.Count; i++)
            {
                Destroy(statementDetail.statement[i]);
            }            
        }
        statementDetail.statement.Clear();
        statementDetail.statement = new List<GameObject>();
        string url = Configuration.Url + Configuration.Wallethistory;
        StartCoroutine(PostStatement(url));
    }

    IEnumerator PostStatement(string Url)
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
            Debug.Log("Response wallet history : " + responseText);
           
            statementOutput = new StatementOutputs();
            statementOutput = JsonUtility.FromJson<StatementOutputs>(responseText.ToString());

            MainController.Instance.StatementPanel.SetActive(true);
            for (int i = 0; i < statementOutput.GameLog.Count; i++)
            {
                statementDetail.go = Instantiate(statementDetail.Prefab, statementDetail.Parent);
                statementDetail.statement.Add(statementDetail.go);
                statementDetail.go.name = i.ToString();
                statementDetail.go.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>().text = (1 + i).ToString();
                statementDetail.go.transform.GetChild(1).GetChild(0).transform.GetComponent<Text>().text = statementOutput.GameLog[i].game;
                statementDetail.go.transform.GetChild(2).GetChild(0).transform.GetComponent<Text>().text = statementOutput.GameLog[i].reff_id;
                statementDetail.go.transform.GetChild(3).GetChild(0).transform.GetComponent<Text>().text = statementOutput.GameLog[i].user_wallet;
                statementDetail.go.transform.GetChild(4).GetChild(0).transform.GetComponent<Text>().text = statementOutput.GameLog[i].added_date;
           
            }
            statementDetail.IsStatement = true;
        }
        yield return null;
    }
}