using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields
    [Header("Player Reference")]
    public PlayerController player;

    [Header("UI Components")]
    public Scrollbar scrollbar;

    [Header("Bar Control")]
    public float valorBarra;

    [Header("Height Tracking")]
    public float maxHeightReached;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        InitializeGameManager();
    }

    void Update()
    {
        UpdateMaxHeight();
        CalculateNormalizedHeight();
    }
    #endregion

    #region Public Methods
    public void activeBarra()
    {
        StartCoroutine(controlBarra());
    }

    public void DetenBarra()
    {
        StopAllCoroutines();
    }
    #endregion

    #region Private Methods
    private void InitializeGameManager()
    {
        maxHeightReached = player.transform.position.y;
        valorBarra = 0;
        scrollbar.size = valorBarra;
    }

    private void UpdateMaxHeight()
    {
        if (player.transform.position.y > maxHeightReached)
        {
            maxHeightReached = player.transform.position.y;
        }
    }

    private void CalculateNormalizedHeight()
    {
        float normalizedHeight = (maxHeightReached - player.transform.position.y) / maxHeightReached;
    }

    private IEnumerator controlBarra()
    {
        valorBarra = 0;
        scrollbar.size = valorBarra;

        while (true)
        {
            valorBarra += Time.deltaTime;
            scrollbar.size = valorBarra;

            if (valorBarra > 1)
            {
                break;
            }

            yield return null;
        }
    }
    #endregion

}
