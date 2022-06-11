using UnityEngine;

public class TermSize : MonoBehaviour {
    
    void Awake()
    {
        TermSize.orthographicSizeAuto();
    }
 
   public static void orthographicSizeAuto () {
       // 縦画面 iPhone6
       float developAspect = 750.0f / 1334.0f;

       // 横画面 iPhone6
       // float developAspect = 1334.0f / 750.0f;
       float deviceAspect = (float)Screen.width / (float)Screen.height;
       float scale = deviceAspect / developAspect;
       Camera mainCamera = Camera.main;
       float deviceSize = mainCamera.orthographicSize;
       float deviceScale = 1.0f / scale;
       if (scale > 1) {
           return;
       }
       mainCamera.orthographicSize = deviceSize * deviceScale;
    }

    public static bool isIPad {
    get {
        return SystemInfo.deviceModel.Contains ("iPad");
    }
    }

    public static bool isIPadDeviceAspect() {
    float deviceAspect = (float)Screen.width / (float)Screen.height; // 2048 / 2732 = 0.74963397
    if (deviceAspect > 0.749f && deviceAspect <= 0.751f) {
        return true;
    }
    return false;
}
}
