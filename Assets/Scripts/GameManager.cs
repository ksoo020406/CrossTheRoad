using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float startSpawnWait;

    [Header("CreateCar")]
    private float spawnInterval;
    public List<GameObject> carPrefabs = new List<GameObject>();

    [SerializeField] private Transform carSpawnPositionRoot;
    private List<Transform> spawnPositions = new List<Transform>();

    [Header("UI")]
    [SerializeField] private GameObject gameOverUI;

    public int coinCount;
    [SerializeField] private TextMeshProUGUI coinTxt;

    public float timeScore;
    [SerializeField] private TextMeshProUGUI timeScoreTxt;


    private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;

        for (int i = 0; i < carSpawnPositionRoot.childCount; i++)
        {
            spawnPositions.Add(carSpawnPositionRoot.GetChild(i));
        }
    }

    private void Update()
    {
        CoinUpUI();
        TimeScoreUI();
    }

    private void Start()
    {
        StartCoroutine(SpawnCarInWave());

        startSpawnWait = 1.0f;
        spawnInterval = 2.0f;
    }

    // -----Car-----
    // 차를 스폰
    void SpawnCarAtPosition(int posIdx)
    {
        int prefabIdx = Random.Range(0, carPrefabs.Count);
        Instantiate(carPrefabs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity);
    }

    IEnumerator SpawnCarInWave()
    {
        yield return new WaitForSeconds(startSpawnWait);

        while (true)
        {
            int posIdx = Random.Range(0, spawnPositions.Count);

            SpawnCarAtPosition(posIdx);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // -----UI-----
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CoinUpUI()
    {
        coinTxt.text = $"{coinCount}";
    }

    private void TimeScoreUI()
    {
        timeScore = Time.time / 5.0f;

        timeScoreTxt.text = timeScore.ToString("N1");
    }
}
