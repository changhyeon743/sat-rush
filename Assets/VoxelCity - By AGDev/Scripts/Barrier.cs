using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public GameObject[] barrier;
    Locomotive locomotive;

	// Use this for initialization
	void Start () {
        locomotive = FindObjectOfType<Locomotive>();
	}
	
	// Update is called once per frame
	void Update () {
        BarrierManager();
	}

    void BarrierManager()
    {
        if (locomotive.sendBarrier1DownSignal)
        {
            barrier[0].GetComponentInChildren<Animator>().Play("BarrierDown");
            barrier[1].GetComponentInChildren<Animator>().Play("BarrierDown");
            locomotive.SetDown1Signal(false);
        }
        else if (locomotive.sendBarrier1UpSignal)
        {
            barrier[0].GetComponentInChildren<Animator>().Play("BarrierUp");
            barrier[1].GetComponentInChildren<Animator>().Play("BarrierUp");
            locomotive.SetUp1Signal(false);
        }

        if (locomotive.sendBarrier2DownSignal)
        {
            barrier[2].GetComponentInChildren<Animator>().Play("BarrierDown");
            barrier[3].GetComponentInChildren<Animator>().Play("BarrierDown");
            locomotive.SetDown2Signal(false);
        }
        else if (locomotive.sendBarrier2UpSignal)
        {
            barrier[2].GetComponentInChildren<Animator>().Play("BarrierUp");
            barrier[3].GetComponentInChildren<Animator>().Play("BarrierUp");
            locomotive.SetUp2Signal(false);
        }

        if (locomotive.sendBarrier3DownSignal)
        {
            barrier[4].GetComponentInChildren<Animator>().Play("BarrierDown");
            barrier[5].GetComponentInChildren<Animator>().Play("BarrierDown");
            locomotive.SetDown3Signal(false);
        }
        else if (locomotive.sendBarrier3UpSignal)
        {
            barrier[4].GetComponentInChildren<Animator>().Play("BarrierUp");
            barrier[5].GetComponentInChildren<Animator>().Play("BarrierUp");
            locomotive.SetUp3Signal(false);
        }
    }
}
