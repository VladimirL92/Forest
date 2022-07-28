using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDemonstration : MonoBehaviour
{
    [SerializeField]
    private float speedRotationPLayers = 1;
    private float platformAngle = 0;
    private void Update()
    {
        var count = transform.childCount;

        for (var i = 0; i < count; i++)
        {
            var player = transform.GetChild(i);
            player.Rotate(transform.up, speedRotationPLayers * Time.deltaTime);
        }
        RotatePlatform();
    }

    public void RotatePlatform()
    {
        var ceilAngle = Mathf.Ceil(transform.rotation.eulerAngles.y);
        if (ceilAngle != platformAngle)
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
        Debug.Log(transform.rotation.eulerAngles.y);
    }

    public void Rotate()
    {
        platformAngle += 180;
        if (platformAngle  > 360)
        {
            platformAngle = 0;
        }
    }
}
