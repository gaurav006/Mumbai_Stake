using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class PlanDetail
{
    public string id;
    public string coin;
    public string price;
    public string title;
    public string added_date;
    public string updated_date;
    public string isDeleted;
}
[System.Serializable]
public class PlanOutPuts
{
    public int code;
    public string message;
    public List<PlanDetail> PlanDetails;
}

[System.Serializable]
public class PlanDetails
{
    public GameObject Prefab;
    public Transform Parent;
    public GameObject go;
    public List<GameObject> Planlist;
    public bool IsPlan;
    public List<Sprite> Coin;
}
public class PlanAPI : MonoBehaviour
{

    public PlanOutPuts PlanOutPut;
    public PlanDetails PlanDetail;

    public void OnPlan()
    {
        if (PlanDetail.IsPlan)
        {
            for (int i = 0; i < PlanDetail.Planlist.Count; i++)
            {
                Destroy(PlanDetail.Planlist[i]);
            }
        }
        PlanDetail.Planlist.Clear();
        PlanDetail.Planlist = new List<GameObject>();
        string url = Configuration.Url + Configuration.Plan;
        StartCoroutine(PostPlan(url));
    }


    IEnumerator PostPlan(string Url)
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
            PlanOutPut = new PlanOutPuts();
            PlanOutPut = JsonUtility.FromJson<PlanOutPuts>(responseText.ToString());

            MainController.Instance.AddChipPanel.SetActive(true);
            for (int i = 0; i < PlanOutPut.PlanDetails.Count; i++)
            {
                PlanDetail.go = Instantiate(PlanDetail.Prefab, PlanDetail.Parent);
                PlanDetail.go.name = PlanOutPut.PlanDetails[i].id.ToString();
                PlanDetail.Planlist.Add(PlanDetail.go);
                PlanDetail.go.transform.GetChild(0).GetChild(0).transform.gameObject.GetComponent<Text>().text =  PlanOutPut.PlanDetails[i].title;
                PlanDetail.go.transform.GetChild(1).GetChild(0).transform.gameObject.GetComponent<Text>().text = " \u20B9 "+ PlanOutPut.PlanDetails[i].price;
            }
            PlanDetail.IsPlan = true;
        }
        yield return null;
    }
}
