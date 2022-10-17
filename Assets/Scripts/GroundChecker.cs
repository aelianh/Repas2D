using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    PlayerMovement player;

    void Awake()
    {
        player = GameObject.Find("mage").GetComponent<PlayerMovement>();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.isGrounded = true;
        player.anim.SetBool("Salto", false);


    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.isGrounded = false;
    }
}
