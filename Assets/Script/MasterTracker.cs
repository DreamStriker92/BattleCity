using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterTracker : MonoBehaviour {

    static MasterTracker instance=null;

    [SerializeField]
    int hunterTankPoints = 100, destroyerTankPoints = 200, assaultTankPoints= 300, assistentTankPoints=400;
    public int hunterTankPointsWorth { get { return hunterTankPoints; } }
    public int destroyerTankPointsWorth { get { return destroyerTankPoints; } }
    public int assaultTankPointsWorth { get { return assaultTankPoints; } }
    public int assistentTankPointsWorth { get { return assistentTankPoints; } }

    public static int hunterTankDestroyed, destroyerTankDestroyed, assaultTankDestroyed, assistentTankDestroyed;
    public static int stageNumber;
    public static int playerLives = 3;
    public static int playerScore = 0;
  
    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}











  