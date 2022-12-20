using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTargetScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out GoblinMovement goblin))
        {
            GoblinManager.RemoveGoblin(goblin.gameObject);
            Destroy(other.gameObject);
        }
    }
}
