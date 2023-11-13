using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RouletteMoveCoin : MonoBehaviour
{
    public GameObject Obj;
    public Transform Parent;


    public void Awake()
    {
        Obj = this.gameObject;

    }
    public void Start()
    {
        Obj.transform.SetParent(Parent);
       // Obj.transform.DOMove(new Vector3(0, 0, 0), 2);
    }
    public void Let(int time)
    {
        Obj.transform.DOLocalMove(new Vector3(0, 0, 0), time);
    }
}
