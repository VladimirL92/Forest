using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Batterfly : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float radius;

    private Vector3 start;
    private Vector3 target;
    private float t;

    private void Start()
    {
        start = transform.position;
        target = start + Random.insideUnitSphere * radius;
    }
    private void Update()
    {
        if (t < 1)
        {
            transform.position = Vector3.Lerp(start, target, t);
            t += Speed * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(target, 0.5f);
    }
}
