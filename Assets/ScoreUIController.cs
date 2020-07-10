using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUIController : MonoBehaviour
{
    public Text speedText;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = Mathf.FloorToInt(Balance.instance.currentGlobalSpeed) + "km/h";
        scoreText.text = Mathf.FloorToInt(Balance.instance.currentScore) + "m";
    }
}
