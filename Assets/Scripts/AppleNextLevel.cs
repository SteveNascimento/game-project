using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleNextLevel : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public bool correto;
    public int Score;
    public string lvl_name;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();

            if (correto)
            {
                GameController.instance.ShowWin();
            } else {
                GameController.instance.ShowLost();
            }

            Invoke("NextScene", 2);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(lvl_name);
    }



} 
