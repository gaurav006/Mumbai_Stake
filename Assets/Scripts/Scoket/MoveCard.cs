using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    public List<GameObject> Cardorigin;
    public List<GameObject> MovementCard;


    private void Start()
    {
        OnMove();
    }
    public void OnMove()
    {
        for (int i = 0;i< Cardorigin.Count; i++)
        {
            MovementCard[i].SetActive(true);
            MovementCard[i].transform.DOLocalMove(new Vector3(Cardorigin[i].transform.localPosition.x, Cardorigin[i].transform.localPosition.y, Cardorigin[i].transform.localPosition.z), 1);
        }
        
    }
}
