using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public LayerMask hitlayerBullet;
    private void OnTriggerEnter(Collider other)
    {
        int layer = (int) Mathf.Log(hitlayerBullet.value, 2);

        if (other.gameObject.layer == layer)
        {
            CharacterHealth otherHealth = other.GetComponent<CharacterHealth>();
            otherHealth.OnUnitDied();
        }
    }
}
