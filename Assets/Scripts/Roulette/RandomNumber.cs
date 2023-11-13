using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumber : MonoBehaviour
{
    // public GameObject Obj;
    public int CountNumber;
    public int Count;
    public static RandomNumber Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void OnInitRandomNumber()
    {
        switch (Count)
        {
            case 15: { CountNumber = (int)Random.Range(5000, 10000); break; }
            case 14: { CountNumber = (int)Random.Range(10000, 20000); break; }
            case 13: { CountNumber = (int)Random.Range(20000, 30000); break; }
            case 12: { CountNumber = (int)Random.Range(30000, 40000); break; }
            case 11: { CountNumber = (int)Random.Range(50000, 55000); break; }
            case 10: { CountNumber = (int)Random.Range(55000, 58000); break; }
            case 9: { CountNumber = (int)Random.Range(59000, 63000); break; }
            case 8: { CountNumber = (int)Random.Range(64000, 70000); break; }
            case 7: { CountNumber = (int)Random.Range(71000, 75000); break; }
            case 6: { CountNumber = (int)Random.Range(81000, 88000); break; }
            case 5: { CountNumber = (int)Random.Range(90000, 100000); break; }
            case 4: { CountNumber = (int)Random.Range(100001, 115000); break; }
            case 3: { CountNumber = (int)Random.Range(115100, 130000); break; }
            case 2: { CountNumber = (int)Random.Range(131000, 132000); break; }
            case 1:
                {
                    CountNumber = (int)Random.Range(132100, 600000); break;
                }
            //case 15:
            //    {
            //        CountNumber = (int)Random.Range(600000, 900000); break;
            //    }

        }

               // CountNumber = (int)Random.Range(5000, 1000000);
                RouletteManager.Instance.TotalBet.GetComponent<Text>().text = CountNumber.ToString();
        }
    }
