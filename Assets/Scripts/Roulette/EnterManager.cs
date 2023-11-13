using AndroappsRoulette;
using UnityEngine;

public class EnterManager : MonoBehaviour
{
    private void OnEnable()
    {
        Count = 0;
    }
    public int Count = 0;
    public void OnCollisionEnter(Collision collision)
    {
        ++Count;
      //  Debug.Log("Name Enter : " + collision.gameObject.name);
        if (Count > 3)
        {
            RouletteRotation.Instance.Speed_Ball = 0;
            RouletteRotation.Instance.BallPoint.transform.SetParent(RouletteRotation.Instance.Pos[RouletteRotation.Instance.Winning]);
            RouletteRotation.Instance.BallPoint.transform.localPosition = new Vector3(0, 0, 0);
        }
        //else if (Count == 2)
        //{
        //    RouletteRotation.Instance.SetRotation();
        //}


    }

    private void OnCollisionExit(Collision collision)
    {
       // Debug.Log("Name : " + collision.gameObject.name);

        if (Count > 5)
        {
            RouletteRotation.Instance.IsCheck = false;
        }
    }

    public void AgainStart()
    {
        Count = 0;
        RouletteRotation.Instance.BallPoint.transform.SetParent(RouletteRotation.Instance.ballRotator.transform);
        RouletteRotation.Instance.Speed_Ball = 300;
        RouletteRotation.Instance.speed = 300;
    }
}
