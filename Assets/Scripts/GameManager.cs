using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("CreateCar")]
    float startSpawnWait;

    public float spawnInterval;
    public List<GameObject> carPrefabs = new List<GameObject>();

    [SerializeField] private Transform carSpawnPositionRoot;
    private List<Transform> spawnPositions = new List<Transform>();

    [Header("UI")]
    [SerializeField] private GameObject gameOverUI;


    private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;

        for (int i = 0; i < carSpawnPositionRoot.childCount; i++)
        {
            spawnPositions.Add(carSpawnPositionRoot.GetChild(i));
        }
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

    // 버튼에 연결될 함수 -> public으로!
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
