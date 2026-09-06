using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] Monsters;
    private int Percentager;
    private float SpawnFrequency = 0;
    Vector3 SpawnPoint;
    void Start()
    {
        SpawnPoint = new Vector3(19, -3.18f, -0.1f);
        InvokeRepeating("MonsterSpawn", 2, 7 - SpawnFrequency / 10);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game"     ){SpawnFrequency = 1;}
        if(SceneManager.GetActiveScene().name == "Game01"   ){SpawnFrequency = 4;}
        if(SceneManager.GetActiveScene().name == "Game02"   ){SpawnFrequency = 9;}
        if(SceneManager.GetActiveScene().name == "Game03"   ){SpawnFrequency = 16;}
        if(SceneManager.GetActiveScene().name == "Game04"   ){SpawnFrequency = 25;}
    }
    void MonsterSpawn(){
        Percentager = Random.Range(0, 101);
        if(Percentager <= 75){
            Instantiate(Monsters[0], SpawnPoint, Quaternion.identity);
        }
        if(Percentager > 75 && Percentager <= 95){
            Instantiate(Monsters[1], SpawnPoint, Quaternion.identity);
        }
        if(Percentager > 95){
            Instantiate(Monsters[2], SpawnPoint, Quaternion.identity);
        }
    }
}
