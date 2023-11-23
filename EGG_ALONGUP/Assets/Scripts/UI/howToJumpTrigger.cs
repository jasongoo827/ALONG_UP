using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class howToJumpTrigger : MonoBehaviour
{
    public GameObject howToMove;
    public GameObject howToJump;
    public GameObject background;


    private void OnTriggerEnter(Collider other)
    {
        if (!howToJump.activeSelf)
        {
            howToJump.SetActive(true);

            background.SetActive(true);
        }
        else
        {
            howToJump.SetActive(false);
            background.SetActive(false);
        }
    }


}
