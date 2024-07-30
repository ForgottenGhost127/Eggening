using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform targetL;
    public Transform targetR;
    public Vector3 offset;
    private float smoothSpeed = 0.125f;
    private GameObject player;

    public float ventanaX = 5f;
    public float ventanaY = 5f;
    private PlayerController pCon;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            
            pCon = player.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("Player not found!");
        }
        target = GameObject.FindGameObjectWithTag("FocoC").transform;
    }


    void FixedUpdate()
    {
        if (target != null)
        {
            if ((transform.position.x > target.position.x + ventanaX) || (transform.position.x < target.position.x - ventanaX))
            {
                if(pCon.moveX > 0)
                {
                    target = targetL;
                }
                else if (pCon.moveX < 0)
                {
                    target = targetR;
                }
                else
                {
                    target = player.transform;
                }
                Vector3 desiredPosition = target.position + new Vector3(offset.x, offset.y, offset.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }

        }
    }
}
