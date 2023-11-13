
using System.Collections;
using System.IO;
using UnityEngine;

public class ShareManager : MonoBehaviour
{

    //https://www.youtube.com/watch?v=FQGn31kJsOw
    public void OnShare(int index)
    {
        StartCoroutine(TakeScreenshotAndShare(index));
    }
    private IEnumerator TakeScreenshotAndShare(int index)
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);



        switch (index)
        {
            case 0:
                { //Share on WhatsApp only, if installed(Android only)
                    if (NativeShare.TargetExists("com.whatsapp"))
                        new NativeShare().AddFile(filePath).AddTarget("com.whatsapp").Share();
                    break;
                }
            case 1:
                { //Share on WhatsApp only, if installed(Android only)
                    if (NativeShare.TargetExists("com.facebook.katana"))
                        new NativeShare().AddFile(filePath).AddTarget("com.facebook.katana").Share();
                    //if (NativeShare.TargetExists("com.google.android.apps.messaging"))
                    //    new NativeShare().AddFile(filePath).AddTarget("com.google.android.apps.messaging").Share();
                   
                    break;
                }
            case 2:
                { //Share on WhatsApp only, if installed(Android only)
                    //if (NativeShare.TargetExists("com.twitter.android"))
                    //    new NativeShare().AddFile(filePath).AddTarget("com.twitter.android").Share();
                    if (NativeShare.TargetExists("com.google.android.gm"))
                        new NativeShare().AddFile(filePath).AddTarget("com.google.android.gm").Share();
                    break;
                }
            case 3:
                { //Share on WhatsApp only, if installed(Android only)
                    //if (NativeShare.TargetExists("com.telegram"))
                    //    new NativeShare().AddFile(filePath).AddTarget("com.telegram").Share();
                    if (NativeShare.TargetExists("org.telegram.messenger"))
                        new NativeShare().AddFile(filePath).AddTarget("org.telegram.messenger").Share();
                    break;
                }
        }
    }

    void OnWhatsapp()
    {

    }
}
