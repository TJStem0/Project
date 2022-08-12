using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : MonoBehaviour
{
    public float speed;
    RectTransform rectTransform;
    public ObstacleMove levelMove;
    public GameObject gamePanel;
    public GameObject textObject;
    public float maxY;
    public float minY;
    public AudioSource music;
    public AudioSource battleMusic;

    float defaultSpeed;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        textObject.SetActive(false);
        PlayerMove.speed = 0f;

        defaultSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButton(0))
        {
            if (rectTransform.position.y >= maxY)
            {
            }
            else
            {
                rectTransform.position = new Vector2(rectTransform.position.x, rectTransform.position.y + speed);
                rectTransform.rotation = Quaternion.Euler(0, 0, 135);
            }
        } else
        {
            if (rectTransform.position.y <= minY)
            {
            }
            else
            {
                rectTransform.position = new Vector2(rectTransform.position.x, rectTransform.position.y - speed);
                rectTransform.rotation = Quaternion.Euler(0, 0, 45);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            rectTransform.position = new Vector2(rectTransform.position.x, 450);
            speed = defaultSpeed;
            levelMove.speed = defaultSpeed;
            levelMove.Restart();
            StartCoroutine(WaitText());
        } else if (collision.tag == "MiniGameEnd")
        {
            gamePanel.SetActive(false);
            PlayerMove.speed = 5.0f;
            music.Play();
            battleMusic.Stop();
        }
    }

    IEnumerator WaitText()
    {
        textObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textObject.SetActive(false);
    }
}
