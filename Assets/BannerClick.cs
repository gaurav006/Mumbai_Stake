using Profile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerClick : MonoBehaviour
{

    public int Count;
    private void Start()
    {
        if (Count == 0)
        {
            Init();
        }
    }

    public void Init()
    {
        // Debug.Log("Log");
        ProfileDetails.Instance.TouchBool = true;
        ProfileDetails.Instance.IncreaseIndex();
        ProfileDetails.Instance.TouchBool = false;

    }
}
