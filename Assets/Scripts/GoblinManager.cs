using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private Transform target;
    [SerializeField] private int countGoblins = 8;

    private int countGoblinsOnLevel;

    [SerializeField] private GameObject gameSetup;

    private static List<GameObject> _goblins = new List<GameObject>();

    public float CooldownSpawn = 1.2f;
    private bool flagSpawn = true;

    private void Update()
    {
        if (_goblins.Count < countGoblins && countGoblinsOnLevel > 0)
        {
            if (flagSpawn)
            {
                var goblin = Instantiate(goblinPrefab, spawnPoint.position, Quaternion.identity);
                goblin.GetComponent<GoblinMovement>().SetTarget(target);
                _goblins.Add(goblin);
                countGoblinsOnLevel--;
                StartCoroutine(Fade());
            }
        }

        if (countGoblinsOnLevel <= 0 && _goblins.Count == 0)
        {
            gameSetup.GetComponent<GameSetup>().UpgradeLevel(2);
            gameSetup.active = true;
            gameObject.active = false;
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

    public static List<GameObject> GetGoblins()
    {
        return _goblins;
    }

    public void SetupGoblinsOnLevel(int count)
    {
        countGoblinsOnLevel = count;
    }
}