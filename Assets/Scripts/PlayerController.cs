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
                (enemySpeed/4 + oldGlobalSpeed / 7)/3*Random.Range(-1f,1f),
                enemySpeed/4 + oldGlobalSpeed / 14,
                0f,ForceMode.Impulse);

            target.transform.GetComponent<Rigidbody>().AddForce(
                (enemySpeed/4 + oldGlobalSpeed / 14 )/3*Random.Range(-1f,1f),
                enemySpeed/4 + oldGlobalSpeed / 14 ,
                0f,ForceMode.Impulse);
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4) {

        }
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
                if (transform.position.x > -20) {
                    transform.Translate(Vector3.back * Time.deltaTime * 30f);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                //transform.Rotate(Vector3.up * Time.deltaTime * 130f);
                if (transform.position.x < 20) {
                    transform.Translate(Vector3.forward * Time.deltaTime * 30f);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                Balance.instance.currentGlobalSpeed += 1f;

                //transform.Translate(Vector3.left * Time.deltaTime * 30f);
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                if (Balance.instance.currentGlobalSpeed > 0) {
                    Balance.instance.currentGlobalSpeed /= 1.2f;
                }

                //transform.Translate(Vector3.right * Time.deltaTime * 30f);
            }
        }
         
    }
}
