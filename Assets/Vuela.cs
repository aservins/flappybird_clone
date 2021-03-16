using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vuela : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    int fuerza = 10;
    int tubospasados = 0;
    Text puntos;
    public bool perdiste = false;

    public AudioClip[] sounds;
    AudioSource audioSource;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        puntos = GameObject.FindGameObjectWithTag("Puntos").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!perdiste)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddRelativeForce(Vector2.up * fuerza, ForceMode2D.Impulse);
                audioSource.PlayOneShot(sounds[1]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TuboPasado"))
        {
            tubospasados = tubospasados + 1;
            puntos.text = tubospasados.ToString();
            audioSource.PlayOneShot(sounds[0]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso") || collision.gameObject.CompareTag("Tubo"))
        {
            audioSource.PlayOneShot(sounds[2]);
            perdiste = true;
            menu.SetActive(true);
        }
    }

}
