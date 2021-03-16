using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatubos : MonoBehaviour
{
    public GameObject tubo;
    bool tuboCreado = true;
    bool perdiste;

    // Update is called once per frame
    void Update()
    {
        perdiste = GameObject.FindGameObjectWithTag("Player").GetComponent<Vuela>().perdiste;

        if (!perdiste)
        {
            if (tuboCreado)
            {
                StartCoroutine(CreaTubo());
            }
        }
    }

    IEnumerator CreaTubo()
    {
        tuboCreado = false;
        float y = Random.Range(-1.5f, 4);
        Vector3 posicion = new Vector3(transform.position.x, y, 0);
        Instantiate(tubo, posicion, transform.rotation);
        yield return new WaitForSeconds(2.5f);
        tuboCreado = true;
    }
}

