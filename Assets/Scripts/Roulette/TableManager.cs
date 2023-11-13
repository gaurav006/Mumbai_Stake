using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    public static TableManager Instance;
    public List<GameObject> TableNumber;
    public Transform Pos;
    private void Awake()
    {
        Instance = this;
    }

    public void OnSelectionImage(int Index)
    {
        for (int i = 0; i < TableNumber.Count; i++)
        {
            TableNumber[i].GetComponent<TableItemName>().SelectionImage.SetActive(false);
            TableNumber[i].transform.GetChild(0).gameObject.SetActive(false);
        }

        TableNumber[Index].GetComponent<TableItemName>().SelectionImage.SetActive(true);
        TableNumber[Index].transform.GetChild(0).gameObject.SetActive(true);
    }

    public void UnSelectionImage()
    {
        for (int i = 0; i < TableNumber.Count; i++)
        {
            TableNumber[i].GetComponent<TableItemName>().SelectionImage.SetActive(false);
            TableNumber[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void NameEventClick(string name)
    {
        //Debug.Log("Name : " + name);
        switch (name)
        {
            case "0": { Pos = TableNumber[0].GetComponent<TableItemName>().Obj.transform; break; }
            case "1": { Pos = TableNumber[1].GetComponent<TableItemName>().Obj.transform; break; }
            case "2": { Pos = TableNumber[2].GetComponent<TableItemName>().Obj.transform; break; }
            case "3": { Pos = TableNumber[3].GetComponent<TableItemName>().Obj.transform; break; }
            case "4": { Pos = TableNumber[4].GetComponent<TableItemName>().Obj.transform; break; }
            case "5": { Pos = TableNumber[5].GetComponent<TableItemName>().Obj.transform; break; }
            case "6": { Pos = TableNumber[6].GetComponent<TableItemName>().Obj.transform; break; }
            case "7": { Pos = TableNumber[7].GetComponent<TableItemName>().Obj.transform; break; }
            case "8": { Pos = TableNumber[8].GetComponent<TableItemName>().Obj.transform; break; }
            case "9": { Pos = TableNumber[9].GetComponent<TableItemName>().Obj.transform; break; }
            case "10": { Pos = TableNumber[10].GetComponent<TableItemName>().Obj.transform; break; }
            case "11": { Pos = TableNumber[11].GetComponent<TableItemName>().Obj.transform; break; }
            case "12": { Pos = TableNumber[12].GetComponent<TableItemName>().Obj.transform; break; }
            case "13": { Pos = TableNumber[13].GetComponent<TableItemName>().Obj.transform; break; }
            case "14": { Pos = TableNumber[14].GetComponent<TableItemName>().Obj.transform; break; }
            case "15": { Pos = TableNumber[15].GetComponent<TableItemName>().Obj.transform; break; }
            case "16": { Pos = TableNumber[16].GetComponent<TableItemName>().Obj.transform; break; }
            case "17": { Pos = TableNumber[17].GetComponent<TableItemName>().Obj.transform; break; }
            case "18": { Pos = TableNumber[18].GetComponent<TableItemName>().Obj.transform; break; }
            case "19": { Pos = TableNumber[19].GetComponent<TableItemName>().Obj.transform; break; }
            case "20": { Pos = TableNumber[20].GetComponent<TableItemName>().Obj.transform; break; }
            case "21": { Pos = TableNumber[21].GetComponent<TableItemName>().Obj.transform; break; }
            case "22": { Pos = TableNumber[22].GetComponent<TableItemName>().Obj.transform; break; }
            case "23": { Pos = TableNumber[23].GetComponent<TableItemName>().Obj.transform; break; }
            case "24": { Pos = TableNumber[24].GetComponent<TableItemName>().Obj.transform; break; }
            case "25": { Pos = TableNumber[25].GetComponent<TableItemName>().Obj.transform; break; }
            case "26": { Pos = TableNumber[26].GetComponent<TableItemName>().Obj.transform; break; }
            case "27": { Pos = TableNumber[27].GetComponent<TableItemName>().Obj.transform; break; }
            case "28": { Pos = TableNumber[28].GetComponent<TableItemName>().Obj.transform; break; }
            case "29": { Pos = TableNumber[29].GetComponent<TableItemName>().Obj.transform; break; }
            case "30": { Pos = TableNumber[30].GetComponent<TableItemName>().Obj.transform; break; }
            case "31": { Pos = TableNumber[31].GetComponent<TableItemName>().Obj.transform; break; }
            case "32": { Pos = TableNumber[32].GetComponent<TableItemName>().Obj.transform; break; }
            case "33": { Pos = TableNumber[33].GetComponent<TableItemName>().Obj.transform; break; }
            case "34": { Pos = TableNumber[34].GetComponent<TableItemName>().Obj.transform; break; }
            case "35": { Pos = TableNumber[35].GetComponent<TableItemName>().Obj.transform; break; }
            case "36": { Pos = TableNumber[36].GetComponent<TableItemName>().Obj.transform; break; }


            case "37": { Pos = TableNumber[37].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_TWELFTH_1ST"); break; }
            case "R_TWELFTH_1ST": { Pos = TableNumber[37].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_TWELFTH_1ST"); break; }
            case "38": { Pos = TableNumber[38].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_TWELFTH_2ND"); break; }
            case "R_TWELFTH_2ND": { Pos = TableNumber[38].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_TWELFTH_2ND"); break; }
            case "39": { Pos = TableNumber[39].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_TWELFTH_3RD"); break; }
            case "R_TWELFTH_3RD": { Pos = TableNumber[39].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_TWELFTH_3RD"); break; }
            case "40": { Pos = TableNumber[40].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_EIGHTEENTH_1ST"); break; }
            case "R_EIGHTEENTH_1ST": { Pos = TableNumber[40].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_EIGHTEENTH_1ST"); break; }
            case "41": { Pos = TableNumber[41].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_EIGHTEENTH_2ND"); break; }
            case "R_EIGHTEENTH_2ND": { Pos = TableNumber[41].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_EIGHTEENTH_2ND"); break; }
            case "42": { Pos = TableNumber[42].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ODD"); break; }
            case "R_ODD": { Pos = TableNumber[42].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ODD"); break; }
            case "43": { Pos = TableNumber[43].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_EVEN"); break; }
            case "R_EVEN": { Pos = TableNumber[43].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_EVEN"); break; }
            case "44": { Pos = TableNumber[44].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_RED"); break; }
            case "R_RED": { Pos = TableNumber[44].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_RED"); break; }
            case "45": { Pos = TableNumber[45].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_BLACK"); break; }
            case "R_BLACK": { Pos = TableNumber[45].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_BLACK"); break; }
            case "46": { Pos = TableNumber[46].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ROW_1"); break; }
            case "R_ROW_1": { Pos = TableNumber[46].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ROW_1"); break; }
            case "47": { Pos = TableNumber[47].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ROW_2"); break; }
            case "R_ROW_2": { Pos = TableNumber[47].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ROW_2"); break; }
            case "48": { Pos = TableNumber[48].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ROW_3"); break; }
            case "R_ROW_3": { Pos = TableNumber[48].GetComponent<TableItemName>().Obj.transform; Debug.Log("R_ROW_3"); break; }
                //case "2 TO 11": { Pos = TableNumber[37].GetComponent<TableItemName>().Obj.transform; break; }
                //case "2 To 12": { Pos = TableNumber[38].GetComponent<TableItemName>().Obj.transform; break; }
                //case "2To13": { Pos = TableNumber[39].GetComponent<TableItemName>().Obj.transform; break; }
                //case "1st12": { Pos = TableNumber[40].GetComponent<TableItemName>().Obj.transform; break; }
                //case "2nd 12": { Pos = TableNumber[41].GetComponent<TableItemName>().Obj.transform; break; }
                //case "3rd 12": { Pos = TableNumber[42].GetComponent<TableItemName>().Obj.transform; break; }
                //case "1to 18": { Pos = TableNumber[43].GetComponent<TableItemName>().Obj.transform; break; }
                //case "even": { Pos = TableNumber[44].GetComponent<TableItemName>().Obj.transform; break; }
                //case "Red": { Pos = TableNumber[45].GetComponent<TableItemName>().Obj.transform; break; }
                //case "black": { Pos = TableNumber[46].GetComponent<TableItemName>().Obj.transform; break; }
                //case "odd": { Pos = TableNumber[47].GetComponent<TableItemName>().Obj.transform; break; }
                //case "19to36": { Pos = TableNumber[48].GetComponent<TableItemName>().Obj.transform; break; }
        }


    }

    public IEnumerator OnWin(string winname)
    {
      //  Debug.LogError(" Error :: " + winname);
        switch (winname)
        {
            case "0":
                {
                    TableNumber[0].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[0].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "1":
                {
                    TableNumber[1].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[1].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "2":
                {
                    TableNumber[2].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[2].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "3":
                {
                    TableNumber[3].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[3].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "4":
                {
                    TableNumber[4].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[4].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "5":
                {
                    TableNumber[5].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[5].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "6":
                {
                    TableNumber[6].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[6].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "7":
                {
                    TableNumber[7].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[7].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "8":
                {
                    TableNumber[8].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[8].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "9":
                {
                    TableNumber[9].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[9].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "10":
                {
                    TableNumber[10].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[10].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "11":
                {
                    TableNumber[11].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[11].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "12":
                {
                    TableNumber[12].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[12].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "13":
                {
                    TableNumber[13].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[13].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "14":
                {
                    TableNumber[14].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[14].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "15":
                {

                    TableNumber[15].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[15].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "16":
                {
                    TableNumber[16].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[16].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "17":
                {
                    TableNumber[17].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[17].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "18":
                {
                    TableNumber[18].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[18].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "19":
                {
                    TableNumber[19].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[19].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "20":
                {
                    TableNumber[20].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[20].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "21":
                {
                    TableNumber[21].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[21].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "22":
                {
                    TableNumber[22].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[22].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "23":
                {
                    TableNumber[23].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[23].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }


            case "24":
                {
                    TableNumber[24].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[24].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "25":
                {
                    TableNumber[25].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[25].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "26":
                {
                    TableNumber[26].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[26].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }


            case "27":
                {
                    TableNumber[27].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[27].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "28":
                {
                    TableNumber[28].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[28].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "29":
                {
                    TableNumber[29].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[29].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "30":
                {
                    TableNumber[30].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[30].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "31":
                {
                    TableNumber[31].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[31].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "32":
                {
                    TableNumber[32].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[32].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

            case "33":
                {
                    TableNumber[33].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[33].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "34":
                {
                    TableNumber[34].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[34].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "35":
                {
                    TableNumber[35].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[35].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }
            case "36":
                {
                    TableNumber[36].transform.GetChild(0).gameObject.SetActive(true);
                    TableNumber[36].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true; break;
                }

        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 37; i++)
        {
            TableNumber[i].transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
            TableNumber[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

