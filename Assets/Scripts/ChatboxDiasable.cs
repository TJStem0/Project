using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatboxDiasable : MonoBehaviour
{
    GameObject chatBox;

    void Start()
    {
        chatBox = GameObject.Find("Chatbox");
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2f);
        chatBox.SetActive(false);
    }
}
