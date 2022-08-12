using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkedToFarmer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FarmGameplay.talkedToFarmer = true;
        }
    }
}
