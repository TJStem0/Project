using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] texts;
    public AudioSource dialogueSound;
    public AudioSource extraSound = null;
    public GameObject arrow;

    /* Optional Battle */
    public bool isBattle;
    public GameObject battleObject;

    TextMeshProUGUI boxText;
    GameObject chatBox;
    bool dialogueDone = true;

    int textNum = 0;

    void Start()
    {
        chatBox = GameObject.Find("Canvas").transform.Find("Chatbox").gameObject;
        boxText = chatBox.transform.Find("ChatText").GetComponent<TextMeshProUGUI>();
        textNum = 0;
        dialogueDone = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && dialogueDone == false)
        {
            textNum++;
            TalkDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogueDone = false;

            if (extraSound != null)
            {
                extraSound.Play();
            }

            TalkDialogue();
            PlayerMove.speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boxText.text = "";

            if (chatBox.activeSelf == true)
            {
                chatBox.SetActive(false);
                arrow.SetActive(false);
            }

            textNum = 0;
            dialogueDone = true;
        }
    }

    void TalkDialogue()
    {
        if (textNum <= texts.Length - 1)
        {
            boxText.text = texts[textNum];
            dialogueSound.Play();

            if (chatBox.activeSelf == false)
            {
                chatBox.SetActive(true);
                arrow.SetActive(true);
            }
        } else
        {
            dialogueDone = true;
        }
        
        if (dialogueDone)
        {
            boxText.text = "";
            PlayerMove.speed = 5.0f;

            if (chatBox.activeSelf == true)
            {
                chatBox.SetActive(false);
            }

            if (isBattle && battleObject != null)
            {
                battleObject.SetActive(true);
            }
        }
    }
}
