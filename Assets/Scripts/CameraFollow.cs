using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private GameObject player;

    public float ventanaX = 5f;
    public float ventanaY = 5f;
    private PlayerController pCon;

    public float valorOffsetX = 2f;

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
        
        target = GameObject.FindGameObjectWithTag("Player").transform;


    }


    

    void FixedUpdate()
    {
        if (target != null)
        {
            offset = new Vector3(valorOffsetX * pCon.moveX, offset.y, offset.z);

            float limitR = target.position.x + ventanaX + offset.x;
            float limitL = target.position.x - ventanaX + offset.x;
            float limitU = target.position.y + ventanaY + offset.y;
            float limitD = target.position.y - ventanaY + offset.y;

            float posX = transform.position.x;
            float posY = transform.position.y;

            if (posX > limitR || posX < limitL || posY > limitU || posY < limitD)
            {
                Vector3 desiredPosition = target.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }


        }
    }

    //Este Gizmos nos permite visualizar el área de enfoque usando un cubo semitransparente
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector2(ventanaX, ventanaY) * 2);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position - new Vector3 (offset.x, offset.y, offset.z), new Vector2(ventanaX, ventanaY) * 2);
    }
}

