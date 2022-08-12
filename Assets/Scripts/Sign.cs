using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    public string SignText;
    public float waitTime;
    public AudioSource dialogueSound;
    public AudioSource extraSound = null;

    TextMeshProUGUI boxText;
    GameObject chatBox;
    bool dialogueDone;

    void Start()
    {
        chatBox = GameObject.Find("Chatbox");
        boxText = GameObject.Find("ChatText").GetComponent<TextMeshProUGUI>();
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

            StartCoroutine(Wait());
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
            }

            dialogueDone = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        boxText.text = SignText;

        if (chatBox.activeSelf == false)
        {
            dialogueSound.Play();
            chatBox.SetActive(true);
        }

        if (dialogueDone)
        {
            yield return new WaitForSeconds(3f);

            boxText.text = "";

            if (chatBox.activeSelf == true)
            {
                chatBox.SetActive(false);
            }
        }
    }
}
