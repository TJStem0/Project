using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBattle : MonoBehaviour
{
    public GameObject battlePanel;
    public Sprite opponentSprite;
    public Image opponentImage;
    public GameObject[] blockingObjects;
    public AudioSource music;
    public AudioSource battleMusic;

    public void Start()
    {
        battlePanel.SetActive(true);
        opponentImage.sprite = opponentSprite;
        for (int i = 0; i < blockingObjects.Length; i++)
        {
            blockingObjects[i].SetActive(false);
        }
        this.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        music.Stop();
        battleMusic.Play();
    }
}
