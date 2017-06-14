using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private Vector3 mousePosition;
	public float moveSpeed = 0.01f;
    public int point;
    
    private gameBrain g;

    // Use this for initialization
    void Start () {
        point = 0;

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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && !g.GameOver) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.y = transform.position.y-0.2f;
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
		}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        point++;
        Debug.Log("Point: "+point);
    }
}
