using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CloneDetails
{
    public GameObject Prefab;
    public Transform Parent;
    public int Index;
    public List<Sprite> Sprites;
    public List<GameObject> Clone;
    public List<AnimatorController> AnimatorcontrollerClone;
    public AnimationClip[] animationClips;
    // public GameObject Go;
}

public class CloneManager : MonoBehaviour
{
    public CloneDetails CloneDetail;
    public ScrollRect scrollRect;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CloneDetail.Sprites.Count; i++)
        {
            var Go = Instantiate(CloneDetail.Prefab, CloneDetail.Parent);
            Go.name = i.ToString();
            Go.GetComponent<Image>().sprite = CloneDetail.Sprites[i];
            CloneDetail.Clone.Add(Go);
            Go.GetComponent<Mainpanel>().Index = i;
            Go.GetComponent<Animator>().runtimeAnimatorController = CloneDetail.AnimatorcontrollerClone[i] as RuntimeAnimatorController;
            Go.GetComponent<Animation>().clip = CloneDetail.animationClips[i];
            Debug.Log("Add git ");

        }
    }


}
