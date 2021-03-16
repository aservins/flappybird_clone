using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creapisos : MonoBehaviour
{
    public GameObject piso;
    bool pisoCreado = true;
    bool perdiste;

    // Update is called once per frame
    void Update() 
    {
        perdiste = GameObject.FindGameObjectWithTag("Player").GetComponent<Vuela>().perdiste;

        if (!perdiste)
        {
            if (pisoCreado)
            {
                StartCoroutine(CreaPiso());
            }
        }
    }
    IEnumerator CreaPiso() {
        pisoCreado = false;
        Instantiate(piso, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);
        pisoCreado = true;
    }
}
