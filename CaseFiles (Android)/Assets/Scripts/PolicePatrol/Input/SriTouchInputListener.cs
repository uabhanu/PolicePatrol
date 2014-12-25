using UnityEngine;
using System.Collections;


public class SriTouchInputListener : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TouchInputListener(TouchInfo touchInfo)
    {
        TouchInfo newInfo = touchInfo;
        SendMessage("TouchInput", newInfo);
    }

}
