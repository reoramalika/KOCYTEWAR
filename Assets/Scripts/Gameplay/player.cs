using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private Vector3 mousePosition;
	public float moveSpeed = 0.01f;
    public int point;

	// Use this for initialization
	void Start () {
        point = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
		}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        point++;
        Debug.Log("Point: "+point);
    }
}
