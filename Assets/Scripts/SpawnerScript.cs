using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;



public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private int spawnNum;

    [SerializeField]
    private GameObject[] spawnObjs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects(spawnNum);
    }

    void SpawnObjects(int num)
    {
        for(int i = 0; i < num; i++)
        {
            Instantiate(spawnObjs[i%spawnObjs.Length], transform.position, Quaternion.identity);
        }
    }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
