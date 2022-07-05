using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class KeyNextLevel : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public GameObject gaiola_fechada;
    public GameObject gaiola_aberta;
    public GameObject princesa;
    public GameObject princesa_free;
    public bool correto;
    public string lvl_name;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    async void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            if (correto)
            {
                gaiola_fechada.SetActive(false);
                princesa.SetActive(false);
                princesa_free.SetActive(true);
                gaiola_aberta.SetActive(true);
                await Task.Delay(3000); // ok
                GameController.instance.ShowFinally();
            } else {
                GameController.instance.ShowGameOver();
            }

            Destroy(gameObject, 0.3f);
        }
    }
} 
