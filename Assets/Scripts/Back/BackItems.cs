using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackItems : MonoBehaviour
{
    public int Index;


    public void Init()
 {
        Debug.Log("Back : " + Index);
        BackManager.Instance.Index = Index;
        MainController.Instance.BackDetail.PanelBack.SetActive(true);
    }
}
