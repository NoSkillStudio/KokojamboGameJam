using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookerAtCursor : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private DecorRocket decorRocket;

    private void Update()
    {
        if (decorRocket.CurrentRocket == RocketType.Rocket)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);
            if (transform.rotation.z < 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else transform.rotation = Quaternion.Euler(0,0,0);
    }
}