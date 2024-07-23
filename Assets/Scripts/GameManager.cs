using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public Scrollbar jumpScroll;

    public float maxHeightReached;

    void Start()
    {
        maxHeightReached = player.transform.position.y;
    }

    void Update()
    {
        if (player.transform.position.y > maxHeightReached)
        {
            maxHeightReached = player.transform.position.y;
        }

        float normalizedHeight = (maxHeightReached - player.transform.position.y) / maxHeightReached;
        jumpScroll.size = normalizedHeight;
    }

    public void ActivateScrollbar()
    {
        jumpScroll.gameObject.SetActive(true);
        maxHeightReached = player.transform.position.y;
    }

    public void DeactivateScrollbar()
    {
        jumpScroll.gameObject.SetActive(false);
    }
}
