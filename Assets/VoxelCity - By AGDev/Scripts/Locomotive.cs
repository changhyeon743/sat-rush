using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour {

    public bool sendBarrier1DownSignal = false;
    public bool sendBarrier1UpSignal = false;
    public bool sendBarrier2DownSignal = false;
    public bool sendBarrier2UpSignal = false;
    public bool sendBarrier3DownSignal = false;
    public bool sendBarrier3UpSignal = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "Barrier1Down":
                sendBarrier1DownSignal = true;
                break;
            case "Barrier1Up":
                sendBarrier1UpSignal = true;
                break;
            case "Barrier2Down":
                sendBarrier2DownSignal = true;
                break;
            case "Barrier2Up":
                sendBarrier2UpSignal = true;
                break;
            case "Barrier3Down":
                sendBarrier3DownSignal = true;
                break;
            case "Barrier3Up":
                sendBarrier3UpSignal = true;
                break;
        }
    }

    public void SetDown1Signal(bool value)
    {
        sendBarrier1DownSignal = value;
    }

    public void SetUp1Signal(bool value)
    {
        sendBarrier1UpSignal = value;
    }

    public void SetDown2Signal(bool value)
    {
        sendBarrier2DownSignal = value;
    }

    public void SetUp2Signal(bool value)
    {
        sendBarrier2UpSignal = value;
    }

    public void SetDown3Signal(bool value)
    {
        sendBarrier3DownSignal = value;
    }

    public void SetUp3Signal(bool value)
    {
        sendBarrier3UpSignal = value;
    }
}
