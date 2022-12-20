using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private int countGoblinsInWave = 4;
    [SerializeField] private GoblinManager goblinManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Arrow arrow))
        {
            gameObject.active = false;
            goblinManager.SetupGoblinsOnLevel(countGoblinsInWave);
            goblinManager.gameObject.active = true;
            Destroy(arrow.gameObject);
        }
    }

    public void UpgradeLevel(int countGoblins)
    {
        countGoblinsInWave += countGoblins;
    }
}
