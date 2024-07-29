using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public Scrollbar scrollbar;
    public float valorBarra;

    public float maxHeightReached;

    void Start()
    {
        maxHeightReached = player.transform.position.y;
        valorBarra = 0;
        scrollbar.size = valorBarra;
    }

    void Update()
    {
        if (player.transform.position.y > maxHeightReached)
        {
            maxHeightReached = player.transform.position.y;
        }

        float normalizedHeight = (maxHeightReached - player.transform.position.y) / maxHeightReached;
        
    }

    public void activeBarra()
    {
        StartCoroutine(controlBarra());

    }
    public void DetenBarra()
    {
        StopAllCoroutines();

    }

    IEnumerator controlBarra()
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

}
