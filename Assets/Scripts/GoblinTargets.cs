using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTargets : MonoBehaviour
{
    [SerializeField] private List<Transform> targetsGoblin;
    [SerializeField] private Transform startTarget;
    [SerializeField] private Transform finalTarget;

    private List<GameObject> _goblins = new List<GameObject>();

    private void Update()
    {
        _goblins = GoblinManager.GetGoblins();

        for(int i = 0; i < _goblins.Count; i++)
        {
            if (!_goblins[i].gameObject.TryGetComponent<GoblinMovement>(out var goblin))
                continue;
            var target = goblin.GetTarget();

            if (finalTarget.position == target.position)
                continue;

            if (Vector3.Distance(goblin.gameObject.transform.position, target.position) < 0.5f)
            {
                Transform randomTarget;
                if (target.position == startTarget.position)
                {
                    randomTarget = targetsGoblin[Random.Range(0, targetsGoblin.Count - 6)];
                    goblin.SetTarget(randomTarget);
                    continue;
                }
                else
                    randomTarget = targetsGoblin[Random.Range(2, targetsGoblin.Count)];
                    

                if (randomTarget.position.z < goblin.transform.position.z)
                    randomTarget = targetsGoblin[Random.Range(6, targetsGoblin.Count)];

                if (Vector3.Distance(finalTarget.position, target.position + Vector3.back) < Vector3.Distance(finalTarget.position, targetsGoblin[targetsGoblin.Count - 1].position))
                {
                    goblin.SetTarget(finalTarget);
                    continue;
                }

                goblin.SetTarget(randomTarget);
            }
        }
    }

}
