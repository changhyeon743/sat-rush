
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{

    public GameController gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.rotation.y > 0) {
            this.transform.Translate(Vector3.right * Time.deltaTime * gm.globalSpeed);
        } else if (this.transform.rotation.y == 0) {
            this.transform.Translate(Vector3.back * Time.deltaTime * gm.globalSpeed);
        } else if (this.transform.rotation.y < 0) {
            this.transform.Translate(Vector3.left * Time.deltaTime * gm.globalSpeed);

        }
    }
}
