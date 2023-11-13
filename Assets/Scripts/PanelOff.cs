using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOff : MonoBehaviour
{
    public GameObject Obj;

    private void OnEnable()
    {
        Invoke("Let", 2);
    }
    void Let()
    {
        Obj.SetActive(false);
    }
}
