using UnityEngine;
using Valve.VR.InteractionSystem;

public class GoblinMovement : MonoBehaviour
{
    public float Speed = 2f;
    [SerializeField] private Transform target;

    private bool _winFlag = false;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool("RUN", true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_winFlag)
        {
            return;
        }
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
    }

    public Transform GetTarget()
    {
        return target;
    }

    public void SetTarget(Transform positionTarget)
    {
        target = positionTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Arrow arrow))
        {
            GoblinManager.RemoveGoblin(gameObject);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
