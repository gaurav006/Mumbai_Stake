using AndroApps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public Slider Slider_OBj;
    [Header("Scripttable object")] public Manager CurrentPackage;

    private void Awake()
    {
        //Slider_OBj.maxValue = 1000;
        Slider_OBj.value = 0;
        CurrentPackage.TokenLogIn = Configuration.TokenLoginHeader;
    }

    void Start()
    {
        LoadScene("Main");       
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation= SceneManager.LoadSceneAsync(sceneName);       
        while (!operation.isDone)
        {
           // Debug.Log("Slider value : " + Slider_OBj.value);          
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalize the progress value
           // Debug.Log("Loading progress: " + (progress * 100) + "%");
            Slider_OBj.value = progress;
           // Debug.Log("progress value : " + progress);
          //  operation.allowSceneActivation = true;
            yield return null;
        }
    }

}
