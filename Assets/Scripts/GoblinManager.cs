using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private int countGoblins = 8;


    private static List<GameObject> _goblins = new List<GameObject>();

    public float CooldownSpawn = 1.2f;
    private bool flagSpawn = true;

    private void Update()
    {
        if (_goblins.Count < countGoblins)
        {
            if (flagSpawn)
            {
                var goblin = Instantiate(goblinPrefab, spawnPoint.position, Quaternion.identity);
                goblin.GetComponent<GoblinMovement>().SetTarget(target);
                _goblins.Add(goblin);
                StartCoroutine(Fade());
            }
        }
    }

    IEnumerator Fade()
    {
        flagSpawn = false;
        yield return new WaitForSeconds(CooldownSpawn);
        flagSpawn = true;
    }

    public static void RemoveGoblin(GameObject goblin)
    {
        _goblins.Remove(goblin);
    }
}