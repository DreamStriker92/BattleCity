using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    [SerializeField]
    int hunterTanksInThisLevel, destroyerTanksInThisLevel, assaultTanksInThisLevel, assistentTanksInThisLevel, stageNumber;
    public static int hunterTanks, destroyerTanks, assaultTanks, assistentTanks;
    [SerializeField]
    float spawnRateInThisLevel=5;      
    public static float spawnRate { get; private set; } 
    GameObject[] spawnPoints, spawnPlayerPoints;
    private void Awake()
    {
    MasterTracker.stageNumber = stageNumber;
    hunterTanks = hunterTanksInThisLevel;
    destroyerTanks = destroyerTanksInThisLevel;
    assaultTanks = assaultTanksInThisLevel;
    assistentTanks = assistentTanksInThisLevel;
    spawnRate = spawnRateInThisLevel; 
    }
}