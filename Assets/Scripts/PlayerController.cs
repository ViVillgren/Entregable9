using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player controller para que el jugador solo se mueva horizontalmente y verticalmente con unos limites para que no salga de la pantalla.

    private Vector3 initialPos = Vector3.zero;
    public float speed = 5f;
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 8f;
    private float yRange = 5.5f;
    private float minYRange = -3.5F;

    
    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPos;

        //Cada vez que cargue la escena si hay mas de un player se destruiran

        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        else 
        {
            instance = this;
        }
        
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento del player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if (transform.position.y < minYRange)
        {
            transform.position = new Vector3(transform.position.x, minYRange, transform.position.z);
        }
    }
}
