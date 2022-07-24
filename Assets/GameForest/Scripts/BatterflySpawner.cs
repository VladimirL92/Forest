using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterflySpawner : MonoBehaviour
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private int countAnimals;
    [SerializeField]
    private Transform animal;
    void Start()
    {
        for (var i = 0; i < countAnimals; i++)
        {

            var anim = Instantiate(animal, transform);
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
