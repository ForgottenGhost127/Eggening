using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PruebaClase : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float valorBarra;

    // Start is called before the first frame update
    void Start()
    {
        valorBarra = 0;
        scrollbar.size = valorBarra;
    }

    // Update is called once per frame
    void Update()
    {
        
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
