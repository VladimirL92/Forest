using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private int count;
    [SerializeField]
    private Transform spawnObject;
    void Start()
    {
        for (var i = 0; i < count; i++)
        {

            var anim = Instantiate(spawnObject, transform);
            var random2 = Random.insideUnitCircle * radius;
            var random3 = new Vector3(random2.x, transform.position.y, random2.y);
            anim.position = transform.position + random3;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
