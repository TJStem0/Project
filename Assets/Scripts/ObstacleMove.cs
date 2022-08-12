using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed;
    public Vector2 startPos;
    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.position = startPos;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }

    public void Restart()
    {
        rect.position = startPos;
    }
}
