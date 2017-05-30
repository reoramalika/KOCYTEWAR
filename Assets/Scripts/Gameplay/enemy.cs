using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float moveSpeed;
    private gameBrain g;
    //private ParticleSystem p;
    //private ParticleSystem.EmissionModule e;

	// Use this for initialization
	void Start () {
        g = new gameBrain();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * moveSpeed);
        //p = transform.GetComponent<ParticleSystem>();
        //e = p.emission;
        //e.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "body")
        {
            if (collision.tag == "Player")
            {
                //e.enabled = true;
                Debug.Log("Touched");
                getGameBrain();
                g.addScore(10);
            }
            Destroy(gameObject);
        }
    }

    void getGameBrain()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            g = gameControllerObject.GetComponent<gameBrain>();
        }
        else
        {
            g = null;
        }

        if (g == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        else
        {
            Debug.Log("'GameController' script found");
        }
    }
}
