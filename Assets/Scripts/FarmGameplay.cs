using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGameplay : MonoBehaviour
{
    public GameObject[] farmerVariants;
    public static bool tomatoSoupCollected;
    public static bool talkedToFarmer;
    public GameObject forestBlock;

    void Start()
    {
        tomatoSoupCollected = false;
        talkedToFarmer = false;
    }

    void Update()
    {
        if (tomatoSoupCollected)
        {
            farmerVariants[0].SetActive(false);
            farmerVariants[1].SetActive(true);
        }

        if (talkedToFarmer)
        {
            farmerVariants[1].SetActive(false);
            farmerVariants[2].SetActive(true);
            forestBlock.SetActive(false);
        }
    }
}
