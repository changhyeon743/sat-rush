
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public float changePosZ = -400f;
    public float plusPosZ = 700f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // //방향 판단 후 돌진
        // if (this.transform.rotation.y > 0) {
        //     this.transform.Translate(Vector3.right * Time.deltaTime * Balance.instance.currentGlobalSpeed);
        // } else if (this.transform.rotation.y == 0) {
        //     this.transform.Translate(Vector3.back * Time.deltaTime * Balance.instance.currentGlobalSpeed);
        // } else if (this.transform.rotation.y < 0) {
        //     this.transform.Translate(Vector3.left * Time.deltaTime * Balance.instance.currentGlobalSpeed);
        // }

        Vector3 newPosition = transform.position;
        newPosition.z = transform.position.z-Balance.instance.currentGlobalSpeed/2 * Time.deltaTime; //Mathf.Repeat(-Time.time * Balance.instance.currentGlobalSpeed, 0.0f);
        
        if (newPosition.z < -400f) {
            newPosition.z = transform.position.z + 700f;
        }
        
        transform.position = newPosition;

        
    }
}
