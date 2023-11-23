using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeHowToMove : MonoBehaviour
{
    public GameObject howToMove;
    public GameObject background;
    private void OnTriggerEnter(Collider other)
    {

        howToMove.SetActive(false);

        background.SetActive(false);

    }

}

