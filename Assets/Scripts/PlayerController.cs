using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target) {
        if (target.transform.tag == "Enemy") {
            float oldGlobalSpeed = Balance.instance.currentGlobalSpeed;
            Balance.instance.ResetGlobalSpeed();
            float enemySpeed = Mathf.Abs(target.transform.GetComponent<EnemyController>().speed);
            rigidBody.AddForce(
                (enemySpeed/4 + oldGlobalSpeed / 25)/4*Random.Range(-1f,1f),
                enemySpeed/4 + oldGlobalSpeed / 25,
                0f,ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //정상 주행 조건
        if (transform.position.y < 4) {
            
            //속도 증가
            if (Balance.instance.currentGlobalSpeed < Balance.instance.maxGlobalSpeed) {
                //점점 속도 증가
                Balance.instance.currentGlobalSpeed += Balance.instance.increasePerTimeGlobalSpeed;
            }

            //방향 보정
            if (transform.localEulerAngles.y > 90) {
                transform.Rotate (0,-0.5f, 0);
            } else if (transform.localEulerAngles.y < 90) {
                transform.Rotate ( 0,0.5f,0);
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
                Balance.instance.currentGlobalSpeed += 1f;

                //transform.Translate(Vector3.left * Time.deltaTime * 30f);
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                
                Balance.instance.currentGlobalSpeed -= 5f;

                //transform.Translate(Vector3.right * Time.deltaTime * 30f);
            }
        }
         
    }
}
