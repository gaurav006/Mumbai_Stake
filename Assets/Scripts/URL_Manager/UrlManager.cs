using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UrlManager : MonoBehaviour
{

    public static UrlManager Instance;

    [Header("Url")] public string UrlBetPlace;
    public GameObject Mgss;

    [Header("Mgs")] public List<GameObject> Mgs;

    private void Awake()
    {
        Instance = this;
    }

    public void OnUrlManagerBet(int index)
    {
        Mgs[index].GetComponent<Text>().text = string.Empty;
        switch (index)
        {
            case 0: { UrlBetPlace = Configuration.Url; break; }
            case 1: { UrlBetPlace = Configuration.Url; break; }
            case 2: { UrlBetPlace = Configuration.Url; break; }
            case 3:
                {
                    UrlBetPlace = Configuration.Url + Configuration.RoulettePlaceBet;
                    Mgs[3].SetActive(true); break;
                }
            case 4: { UrlBetPlace = Configuration.Url; break; }
            case 5: { UrlBetPlace = Configuration.Url; break; }
            case 6: { UrlBetPlace = Configuration.Url; break; }
            case 7: { UrlBetPlace = Configuration.Url; break; }
            case 8: { UrlBetPlace = Configuration.Url; break; }
            case 9: { UrlBetPlace = Configuration.Url; break; }
            case 10: { UrlBetPlace = Configuration.Url; break; }
            case 11: { UrlBetPlace = Configuration.Url; break; }
            case 12: { UrlBetPlace = Configuration.Url; break; }
            case 13: { UrlBetPlace = Configuration.Url + Configuration.DragonPlaceBet;
                    Mgs[13].SetActive(true); break; }
            case 14: { UrlBetPlace = Configuration.Url; break; }
            case 15: { UrlBetPlace = Configuration.Url; break; }
            case 16: { UrlBetPlace = Configuration.Url; break; }
            case 17: { UrlBetPlace = Configuration.Url; break; }
            case 18: { UrlBetPlace = Configuration.Url; break; }
            case 19: { UrlBetPlace = Configuration.Url; break; }
            case 20: { UrlBetPlace = Configuration.Url; break; }
            case 21: { UrlBetPlace = Configuration.Url; break; }
            case 22: { UrlBetPlace = Configuration.Url; break; }
            case 23:
            case 24: { break; }
        }
        Mgss = Mgs[index];
        Invoke("ClearMgs", 2);

        //  Debug.LogError("Url : " + UrlBetPlace);
    }

    void ClearMgs()
    {
       // Debug.Log("ClearMgs");
        for (int i = 0; i < Mgs.Count; i++)
        {
            Mgs[i].GetComponent<Text>().text = string.Empty;
        }
    }
}
