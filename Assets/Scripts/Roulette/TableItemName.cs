using AndroApps;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableItemName : MonoBehaviour
{
    public GameObject Obj;
    public Transform Parent;

    public GameObject SelectionImage;
    public string Name;
    public int Index;
    public List<GameObject> UserClone_Coin;


    private void Awake()
    {
        Obj = this.gameObject;
        Parent = Obj.transform;
        Name = Obj.name;
        SelectionImage = Obj.transform.GetChild(0).gameObject;
        SelectionImage.SetActive(false);
        Obj.GetComponent<Button>().onClick.AddListener(OnClickNumberButton);// button click 
    }

    public void OnClickNumberButton()
    {
        TableManager.Instance.OnSelectionImage(Index);
        TableManager.Instance.NameEventClick(Name);
        PlaceObjectRandomly();
        BetPlaceManager.Instance.bet = Obj.name;
        BetPlaceManager.Instance.OnPlaceBet();// bet place 
    }
    void PlaceObjectRandomly()
    {
        var go = Instantiate(RouletteManager.Instance.RoulettePrefabCoin, RouletteManager.Instance.FirstPos);
        //firstpos = RouletteManager.Instance.ParentUser;
        go.GetComponent<Image>().sprite = GameModule.Instance.GetActiveGameDetail.CoinSprite;
        go.transform.SetParent(TableManager.Instance.Pos);
        go.GetComponent<RouletteMoveCoin>().Parent = TableManager.Instance.Pos;
        go.transform.DOLocalMove(new Vector3(0, 0, 0), 2);
        RouletteManager.Instance.CloneUser.Add(go);
        // UserClone_Coin.Add(go);
        OnBetNumber(Index);
    }

    public void OnBetNumber(int Index)
    {

        switch (Index)
        {
            case 0: { Debug.Log(" Win + 0"); break; }
            case 1: { Debug.Log(" Win + 1"); break; }
            case 2: { Debug.Log(" Win + 2"); break; }
            case 3: { Debug.Log(" Win + 3"); break; }
            case 4: { Debug.Log(" Win + 4"); break; }
            case 5: { Debug.Log(" Win + 5"); break; }
            case 6: { Debug.Log(" Win + 6"); break; }
            case 7: { Debug.Log(" Win + 7"); break; }
            case 8: { Debug.Log(" Win + 8"); break; }
            case 9: { Debug.Log(" Win + 9"); break; }
            case 10: { Debug.Log(" Win + 10"); break; }
            case 11: { Debug.Log(" Win + 11"); break; }
            case 12: { Debug.Log(" Win + 12"); break; }
            case 13: { Debug.Log(" Win + 13"); break; }
            case 14: { Debug.Log(" Win + 14"); break; }
            case 15: { Debug.Log(" Win + 15"); break; }
            case 16: { Debug.Log(" Win + 16"); break; }
            case 17: { Debug.Log(" Win + 17"); break; }
            case 18: { Debug.Log(" Win + 18"); break; }
            case 19: { Debug.Log(" Win + 19"); break; }
            case 20: { Debug.Log(" Win + 20"); break; }
            case 21: { Debug.Log(" Win + 21"); break; }
            case 22: { Debug.Log(" Win + 22"); break; }
            case 23: { Debug.Log(" Win + 23"); break; }
            case 24: { Debug.Log(" Win + 24"); break; }
            case 25: { Debug.Log(" Win + 25"); break; }
            case 26: { Debug.Log(" Win + 26"); break; }
            case 27: { Debug.Log(" Win + 27"); break; }
            case 28: { Debug.Log(" Win + 28"); break; }
            case 29: { Debug.Log(" Win + 29"); break; }
            case 30: { Debug.Log(" Win + 30"); break; }
            case 31: { Debug.Log(" Win + 31"); break; }
            case 32: { Debug.Log(" Win + 32"); break; }
            case 33: { Debug.Log(" Win + 33"); break; }
            case 34: { Debug.Log(" Win + 34"); break; }
            case 35: { Debug.Log(" Win + 35"); break; }
            case 36: { Debug.Log(" Win + 36"); break; }
            case 37: {// Debug.Log("R_TWELFTH_1ST");
                      RouletteManager.Instance.Is_TWELFTH_1ST = true; break; }
            case 38: { Debug.Log("R_TWELFTH_2ND"); RouletteManager.Instance.IsWELFTH_2ND = true; break; }
            case 39: { Debug.Log("R_TWELFTH_3RD"); RouletteManager.Instance.Is_TWELFTH_3RD = true; break; }
            case 40: { Debug.Log("R_EIGHTEENTH_1ST"); RouletteManager.Instance.IsEightLess = true; break; }
            case 41: { Debug.Log("R_EIGHTEENTH_2ND"); RouletteManager.Instance.IsEightGreter = true; break; }
            case 42: { Debug.Log("R_ODD"); RouletteManager.Instance.IsOdd = true; break; }
            case 43: { Debug.Log("R_EVEN"); RouletteManager.Instance.IsEven = true; break; }
            case 44: { Debug.Log("R_RED"); RouletteManager.Instance.IsRad = true; break; }
            case 45: { Debug.Log("R_BLACK"); RouletteManager.Instance.IsBlack = true; break; }
            case 46: { Debug.Log("R_ROW_1"); RouletteManager.Instance.IsRow1 = true; break; }
            case 47: { Debug.Log("R_ROW_2"); RouletteManager.Instance.IsRow2 = true; break; }
            case 48: { Debug.Log("R_ROW_3"); RouletteManager.Instance.IsRow3 = true; break; }


        }
    }


}
