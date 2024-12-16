using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBounce : MonoBehaviour
{
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 2.0f;

    private Vector3 initialPosition;

    private void Start()
    {
        //Armazena a posição inicial do power-up
        initialPosition = transform.position;
    }

    private void Update()
    {
        //Calcula o movimento de bounce usando uma função seno para dar um efeito suave
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + newY, initialPosition.z);
    }
}
