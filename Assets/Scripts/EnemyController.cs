using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{  
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //주행 중이다.
        this.transform.Translate(Vector3.right * Time.deltaTime * (Balance.instance.currentGlobalSpeed + speed));

        if (this.transform.position.z < -250) {
            Destroy(gameObject);
        }
    }
}