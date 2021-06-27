using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject[] tanks;
    GameObject tank;
    [SerializeField]
    bool isPlayer;
    [SerializeField]
    GameObject hunterTank, destroyerTank, assaultTank, assistentTank;
    enum tankType
    {
        hunterTank, destroyerTank, assaultTank, assistentTank
    };
    private void Start()
    {
        if (isPlayer)
        {
            tanks = new GameObject[1] { hunterTank };
        }
        else
        {
            tanks = new GameObject[4] { hunterTank, destroyerTank, assaultTank, assistentTank };
        }
    }
    public void StartSpawning(){
        if (!isPlayer)
        {
            List<int> tankToSpawn = new List<int>();
            tankToSpawn.Clear();
            if (LevelManager.hunterTanks > 0) tankToSpawn.Add((int)tankType.hunterTank);
            if (LevelManager.destroyerTanks > 0) tankToSpawn.Add((int)tankType.assaultTank);
            if (LevelManager.assaultTanks > 0) tankToSpawn.Add((int)tankType.assaultTank);
            if (LevelManager.assistentTanks > 0) tankToSpawn.Add((int)tankType.assistentTank);
            int tankID = tankToSpawn[Random.Range(0, tankToSpawn.Count)];
            tank = Instantiate(tanks[tankID], transform.position, transform.rotation);
            if (tankID == (int)tankType.hunterTank) LevelManager.hunterTanks--;
            else if (tankID == (int)tankType.destroyerTank) LevelManager.destroyerTanks--;
            else if (tankID == (int)tankType.assaultTank) LevelManager.assaultTanks--;
            else if (tankID == (int)tankType.assistentTank) LevelManager.assistentTanks--;
        }
        else
        {
            tank = Instantiate(tanks[0], transform.position, transform.rotation);
        }
    }
    public void SpawnNewTank()
    {
        if (tank != null) tank.SetActive(true);
    }
}