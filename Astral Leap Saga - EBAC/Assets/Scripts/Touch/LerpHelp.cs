using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelp : MonoBehaviour
{
    public Transform target;

    public float lerpSpeed = 1f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, target.position.x, lerpSpeed * Time.deltaTime);
        transform.position = pos;
    }   
}
