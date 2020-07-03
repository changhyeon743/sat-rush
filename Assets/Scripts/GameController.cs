using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;

    public float respawnTime;
    public float globalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3( mainCamera.transform.position.x,  player.transform.position.y+10,  mainCamera.transform.position.z);
        if (globalSpeed < Balance.instance.maxGlobalSpeed) {
            globalSpeed += Balance.instance.increasePerTimeGlobalSpeed;
        }
        if (respawnTime > Balance.instance.minRespawnTime) {
            respawnTime-=Balance.instance.increasePerTimeRespawnTime;
        }
    }

    private IEnumerator EnemySpawner()
    {
        yield return new WaitForSeconds(respawnTime);

        while(true)
        {   
            yield return new WaitForSeconds(respawnTime);

            //적 생성 조건
            if (globalSpeed > 100) {
                GameObject enemy = SpawnEnemy();
                enemy.transform.position = new Vector3(Random.Range(-17.0f, 17.0f), 2.1f, 500f);
                enemy.transform.eulerAngles = new Vector3(0,90,0);
                enemy.AddComponent<EnemyController>();
                enemy.GetComponent<EnemyController>().gm = this;

                enemy.GetComponent<EnemyController>().speed = Random.Range(-30f,30f);
                enemy.SetActive(true);
            }
            // currentDifficulty = Mathf.Clamp(currentDifficulty+.15f, 1f, 30f);
        }
    }

    private IEnumerator EnemyBuilding()
    {
        yield return new WaitForSeconds(respawnTime);

        while(true)
        {   
            yield return new WaitForSeconds(respawnTime);

            //적 생성 조건
            if (globalSpeed > 100) {
                GameObject enemy = SpawnEnemy();
                enemy.transform.position = new Vector3(Random.Range(-17.0f, 17.0f), 2.1f, 500f);
                enemy.transform.eulerAngles = new Vector3(0,90,0);
                enemy.AddComponent<EnemyController>();
                enemy.GetComponent<EnemyController>().gm = this;

                enemy.GetComponent<EnemyController>().speed = Random.Range(-30f,30f);
                enemy.SetActive(true);
            }
            // currentDifficulty = Mathf.Clamp(currentDifficulty+.15f, 1f, 30f);
        }
    }

    private GameObject SpawnEnemy() {
        string[] cars = {"BusBlue","BusGreen","BusGrey", "BusYellow" ,"Collector", "CompactGreen",
        "CompactGrey", "CompactOrange", "CompactRed", "CompactViolet", "FireTruck", "FormulaOrange", "FormulaRed", "FormulaYellow",
        "HatchbackBlue", "HatchbackGreen", "HatchbackRed", "JeepBlue",
        "JeepGreen", "JeepGrey", "JeepRed", "Limousine", "Tank","Taxi", "TruckBlue", "TruckGrey", "TruckOrange"};
        return GetFromResource("CarPrefabs/"+cars[Random.Range(0,cars.Length)]);
    }

    private GameObject SpawnBuilding() {
        return GetFromResource("BuildingPrefabs/building4");
    }

    private GameObject GetFromResource(string dir) {
        return Instantiate(Resources.Load(dir)) as GameObject;
    }
}
