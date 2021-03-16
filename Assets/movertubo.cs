using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movertubo : MonoBehaviour
{
    float velocidad = 5;
    bool perdiste;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        perdiste = GameObject.FindGameObjectWithTag("Player").GetComponent<Vuela>().perdiste;

        if (!perdiste)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }
    }
}
