using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rigidBody;
    public GameController gm;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target) {
        if (target.transform.tag == "Enemy") {
            float oldGlobalSpeed = gm.globalSpeed;
            gm.globalSpeed = 0f;
            float enemySpeed = Mathf.Abs(target.transform.GetComponent<EnemyController>().speed);
            rigidBody.AddForce((enemySpeed + oldGlobalSpeed / 30)/4*Random.Range(-1f,1f),enemySpeed + oldGlobalSpeed / 20,0f,ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //정상 주행 조건
        if (transform.position.y < 4) {
            
            //방향 보정
            if (transform.localEulerAngles.y > 90) {
                transform.Rotate (0,-1f, 0);
            } else if (transform.localEulerAngles.y < 90) {
                transform.Rotate ( 0,1f,0);
            }


            if (Input.GetKey(KeyCode.LeftArrow)) {
                //transform.Rotate(Vector3.down * Time.deltaTime * 130f);
                transform.Translate(Vector3.back * Time.deltaTime * 30f);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                //transform.Rotate(Vector3.up * Time.deltaTime * 130f);

                transform.Translate(Vector3.forward * Time.deltaTime * 30f);
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(Vector3.left * Time.deltaTime * 30f);
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(Vector3.right * Time.deltaTime * 30f);
            }
        }
         
    }
}
