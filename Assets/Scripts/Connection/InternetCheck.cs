using UnityEngine;
using UnityEngine.UI;

public class InternetCheck : MonoBehaviour
{
    public static InternetCheck Instance;

    public GameObject net_Obj;
    public GameObject net_BG;

    public bool IsConnection;
    
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        //if (Application.internetReachability == NetworkReachability.NotReachable)
        //{
        //    IsConnection = false;
        //    Debug.Log("Error. Check internet connection!");
        //}

        CheckInternetConnection();
    }

    public void CheckInternetConnection()
    {
        NetworkReachability internetStatus = Application.internetReachability;

        switch (internetStatus)
        {
            case NetworkReachability.NotReachable:
                Debug.Log("No internet connection.");
                // Handle no internet connection
              //  net_Obj.SetActive(true);
                net_BG.SetActive(true);
                net_Obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "No internet connection.";
                IsConnection = false;
                break;

            case NetworkReachability.ReachableViaCarrierDataNetwork:
                Debug.Log("Connected via mobile data.");
                net_Obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Connected via mobile data.";
                IsConnection = true;
                // Handle mobile data connection
               // net_Obj.SetActive(false);
                net_BG.SetActive(false);
                break;

            case NetworkReachability.ReachableViaLocalAreaNetwork:
                Debug.Log("Connected via Wi-Fi or LAN.");
                // Handle Wi-Fi or LAN connection
              //  net_Obj.SetActive(false);
                net_BG.SetActive(false);
                IsConnection = true;
                net_Obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Connected via Wi-Fi or LAN.";
                break;
        }

        Invoke("OnClose", 2);
    }

     void OnClose()
    {
        net_BG.SetActive(false);
    }
    public void TryConnection()
    {
        CheckInternetConnection(); 
    }
}