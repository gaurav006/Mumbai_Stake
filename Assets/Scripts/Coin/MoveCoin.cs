using AndroApps;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    public GameObject Obj;
    public Transform Parent;
    //private Transform HoldParent;
    public bool IsDemi;


    public void Awake()
    {
        Obj = this.gameObject;
    }


    private void Start()
    {

        if (!IsDemi)
        {
           // Debug.Log("Parent : Go" + Parent + "  :  " + IsDemi);
            Parent = GameModule.Instance.GetActiveGameDetail.Parent;
            Invoke("Let", 0.05f);
            Obj.transform.SetParent(Parent);
        }
        else
        {
           // Debug.Log("Parent : Go" + Parent + "  :  " + IsDemi);
            Obj.transform.SetParent(Parent);
            Invoke("Let", 0.01f);
        }
    }

    void Let()
    {
        Obj.transform.DOLocalMove(new Vector3(Random.Range(-80, 80), Random.Range(-80, 80), 0), 1); // Dragon
    }

   

    void OnCloneDestroy()
    {
        Debug.Log("Destroy");
        Destroy(Obj);
    }

}
