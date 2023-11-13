using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public static CardData Instance;
    public List<Sprite> Cards;
    public int Firstindex, SecondIndex;
    public int CommanIndex;

    public string str1, str2;
    private void Awake()
    {
        Instance = this;
    }

    public void OnGameDataDetails(int ID, string Card)
    {
       // Debug.Log("Card name " + Card);
        if (ID == 0)
        {
            CardName(Card); str1 = Card;
            Firstindex = CommanIndex;
            MainController.Instance.WinNextStopDetail.sprites[ID] = MainController.Instance.WinNextStopDetail.Cardorigin[0].GetComponent<Image>().sprite = Cards[Firstindex];
            MainController.Instance.WinNextStopDetail.CardAnim[0].SetActive(true);
        }
        else
        {
            CardName(Card); str2 = Card;
            SecondIndex = CommanIndex;
            MainController.Instance.WinNextStopDetail.sprites[ID] = MainController.Instance.WinNextStopDetail.Cardorigin[1].GetComponent<Image>().sprite = Cards[SecondIndex];
            MainController.Instance.WinNextStopDetail.CardAnim[1].SetActive(true);

        }
    }

    public void CardName(string Card)
    {

        switch (Card)
        {
            //RS
            case "RSK":
                {
                    CommanIndex = 0;
                    break;
                }
            case "RSQ":
                {
                    CommanIndex = 1;
                    break;
                }
            case "RSJ":
                {
                    CommanIndex = 2;
                    break;
                }
            case "RSA":
                {
                    CommanIndex = 3;
                    break;
                }
            case "RS2":
                {
                    CommanIndex = 4;
                    break;
                }
            case "RS3":
                {
                    CommanIndex = 5;
                    break;
                }
            case "RS4":
                {
                    CommanIndex = 6;
                    break;
                }
            case "RS5":
                {
                    CommanIndex = 7;
                    break;
                }
            case "RS6":
                {
                    CommanIndex = 8;
                    break;
                }
            case "RS7":
                {
                    CommanIndex = 9;
                    break;
                }
            case "RS8":
                {
                    CommanIndex = 10;
                    break;
                }
            case "RS9":
                {
                    CommanIndex = 11;
                    break;
                }
            case "RS10":
                {
                    CommanIndex = 12;
                    break;
                }
            // RP
            case "RPK":
                {
                    CommanIndex = 13;
                    break;
                }
            case "RPQ":
                {
                    CommanIndex = 14;
                    break;
                }
            case "RPJ":
                {
                    CommanIndex = 15;
                    break;
                }
            case "RPA":
                {
                    CommanIndex = 16;
                    break;
                }
            case "RP2":
                {
                    CommanIndex = 17;
                    break;
                }
            case "RP3":
                {
                    CommanIndex = 18;
                    break;
                }
            case "RP4":
                {
                    CommanIndex = 19;
                    break;
                }
            case "RP5":
                {
                    CommanIndex = 20;
                    break;
                }
            case "RP6":
                {
                    CommanIndex = 21;
                    break;
                }
            case "RP7":
                {
                    CommanIndex = 22;
                    break;
                }
            case "RP8":
                {
                    CommanIndex = 23;
                    break;
                }
            case "RP9":
                {
                    CommanIndex = 24;
                    break;
                }
            case "RP10":
                {
                    CommanIndex = 25;
                    break;
                }
            //BP
            case "BPk":
                {
                    CommanIndex = 26;
                    break;
                }
            case "BPQ":
                {
                    CommanIndex = 27;
                    break;
                }
            case "BPJ":
                {
                    CommanIndex = 28;
                    break;
                }
            case "BPA":
                {
                    CommanIndex = 29;
                    break;
                }
            case "BP2":
                {
                    CommanIndex = 30;
                    break;
                }
            case "BP3":
                {
                    CommanIndex = 31;
                    break;
                }
            case "BP4":
                {
                    CommanIndex = 32;
                    break;
                }
            case "BP5":
                {
                    CommanIndex = 33;
                    break;
                }
            case "BP6":
                {
                    CommanIndex = 34;
                    break;
                }
            case "BP7":
                {
                    CommanIndex = 35;
                    break;
                }
            case "BP8":
                {
                    CommanIndex = 36;
                    break;
                }
            case "BP9":
                {
                    CommanIndex = 37;
                    break;
                }
            case "BP10":
                {
                    CommanIndex = 38;
                    break;
                }
            case "BLK":
                {
                    CommanIndex = 39;
                    break;
                }
            case "BLQ":
                {
                    CommanIndex = 40;
                    break;
                }
            case "BLJ":
                {
                    CommanIndex = 41;
                    break;
                }
            case "BLA":
                {
                    CommanIndex = 42;
                    break;
                }
            case "BL2":
                {
                    CommanIndex = 43;
                    break;
                }
            case "BL3":
                {
                    CommanIndex = 44;
                    break;
                }
            case "BL4":
                {
                    CommanIndex = 45;
                    break;
                }
            case "BL5":
                {
                    CommanIndex = 46;
                    break;
                }
            case "BL6":
                {
                    CommanIndex = 47;
                    break;
                }
            case "BL7":
                {
                    CommanIndex = 48;
                    break;
                }
            case "BL8":
                {
                    CommanIndex = 49;
                    break;
                }
            case "BL9":
                {
                    CommanIndex = 50;
                    break;
                }
            case "BL10":
                {
                    CommanIndex = 51;
                    break;
                }
        }
    }










}
