using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{  
    public float speed;
    public GameController gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0) {
            speed = Mathf.Abs(speed);
        }
        this.transform.Translate(Vector3.right * Time.deltaTime * (gm.globalSpeed + speed));
        if (this.transform.position.z < -50) {
            Destroy(gameObject);
        }
    }
}
