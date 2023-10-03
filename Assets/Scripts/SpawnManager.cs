using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The different types of enemies that should be spawned and their corresponding spawn information.")]
    private EnemySpawnInfo[] m_EnemyTypes;

    [SerializeField]
    [Tooltip("The number of each enemy to be spawned.")]
    private int m_NumEnemy;
    #endregion

    public int fireCount;
    public int totalObjects;

    public int score;

    public float winValue;

    public GameObject secondCat;

    #region Main Updates
    private void Awake()
    {
        totalObjects = 0;
        for (int i = 0; i < m_NumEnemy; i++)
        {
            for (int j = 0; j < m_EnemyTypes.Length; j++)
            {
                var position = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-4f, 3f));
                Instantiate(m_EnemyTypes[j].EnemyPrefab, position, Quaternion.identity);
                totalObjects += 1;
            }
        }
        fireCount = 0;
        winValue = totalObjects * 5f;
        secondCat.SetActive(false);
    }
    #endregion

    private void Update()
    {
        if (score > 0.5f * winValue)
        {
            secondCat.SetActive(true);
        }
    }
}



[System.Serializable]
public struct EnemySpawnInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The enemy prefab to spawn. This is what will be instantiated each time.")]
    private GameObject m_EnemyPrefab;
    #endregion

    #region Accessors and Mutators
    public GameObject EnemyPrefab
    {
        get { return m_EnemyPrefab; }
    }
    #endregion
}