using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Literally the same as HealthCollectable but negative health and no disapearing, I'm not at fault if something dies.
public class DamageZone: MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}