using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {
    [SerializeField]
    Image topCurtain, bottomCurtain, blackCurtain;
    [SerializeField]
    Text stageNumberText, gameOverText;
    

    bool stageStart = false;

    GameObject[] spawnPoints, spawnPlayerPoints;
    void Start()
    {
        stageStart = true;
        spawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        spawnPlayerPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");
        stageNumberText.text = "STAGE " + MasterTracker.stageNumber.ToString();
        StartCoroutine(StartStage());
    }

    public void SpawnEnemy()
{
    if (LevelManager.hunterTanks + LevelManager.destroyerTanks + LevelManager.assaultTanks + LevelManager.assistentTanks > 0)
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Animator anime = spawnPoints[spawnPointIndex].GetComponent<Animator>();
        anime.SetTrigger("Spawning");
    }
    else
        {
        CancelInvoke();
        }
    }

    public void SpawnPlayer()
        {
    if (MasterTracker.playerLives > 0)
    {
        if (!stageStart)
        {
        MasterTracker.playerLives--;
        }
        stageStart = false;
        Animator anime = spawnPlayerPoints[0].GetComponent<Animator>();
        anime.SetTrigger("Spawning");
    }else
    {
        StartCoroutine(GameOver());
    }
        }

    IEnumerator StartStage()
    {
        StartCoroutine(RevealStageNumber());
        yield return new WaitForSeconds(5);
        StartCoroutine(RevealTopStage());
        StartCoroutine(RevealBottomStage());
        yield return null;
        InvokeRepeating("SpawnEnemy", LevelManager.spawnRate, LevelManager.spawnRate);
        SpawnPlayer();
    }
	IEnumerator RevealStageNumber()
    {
        while (blackCurtain.rectTransform.localScale.y > 0)
        {
            blackCurtain.rectTransform.localScale = new Vector3(1, Mathf.Clamp(blackCurtain.rectTransform.localScale.y - Time.deltaTime,0,1), 1);
            yield return null;
        }
    }
    IEnumerator RevealTopStage()
    {
        stageNumberText.enabled = false;
        while (topCurtain.rectTransform.position.y < 1250)
        {
            topCurtain.rectTransform.Translate(new Vector3(0, 500 * Time.deltaTime, 0));
            yield return null;
        }
    }
    IEnumerator RevealBottomStage()
    {
        while (bottomCurtain.rectTransform.position.y > -400)
        {
            bottomCurtain.rectTransform.Translate(new Vector3(0, -500 * Time.deltaTime, 0));
            yield return null;
        }
    }
    public IEnumerator GameOver()
    {
    while (gameOverText.rectTransform.localPosition.y < 0)
        {
        gameOverText.rectTransform.localPosition = new Vector3(gameOverText.rectTransform.localPosition.x, gameOverText.rectTransform.localPosition.y + 120f * Time.deltaTime, gameOverText.rectTransform.localPosition.z);
        yield return null;
        }
    }

    
}

