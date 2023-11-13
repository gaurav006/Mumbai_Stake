using AndroApps;
using AndroappsRoulette;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class RouletteManager : MonoBehaviour
{
    public static RouletteManager Instance;

    public List<GameObject> ChildCoin;
    public Transform Return_Position;
    public Transform FirstPos;
    public GameObject RoulettePrefabCoin;
    public List<GameObject> CloneUser = new List<GameObject>();
    [Header("Scripttable object")] public Manager CurrentPackage;
    public GameObject RouletteSocket;
    public List<GameObject> ListFakeCoin;
    public List<Text> LastWining;
    [Header("RouletteRotation")] public RouletteRotation rouletteRotation;

    public GameObject WinNumber, Score, TotalBet, Winner;
    public List<int> Red, Black;
    public List<int> OnetoEightteen, NineteentothritySix;
    public int green;

    [Header("Bool")] public bool IsEven, IsOdd, IsEightGreter, IsEightLess, IsRad, IsBlack, IsGreen, IsRow1, IsRow2, IsRow3, Is_TWELFTH_1ST, IsWELFTH_2ND, Is_TWELFTH_3RD;

    private void Awake()
    {
        Instance = this;
        WinNumber.SetActive(false);
        AllboolOff();
    }


    public void AllboolOff()
    {
        IsEven = IsOdd = IsEightGreter = IsEightLess = IsRad = IsBlack = IsGreen = IsRow1 = IsRow2 = IsRow3 = Is_TWELFTH_1ST = IsWELFTH_2ND = Is_TWELFTH_3RD = false;
    }

}
