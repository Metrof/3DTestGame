using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCast : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private float shotDellay = 1.0f;
    private float nextShotTime;

    public void Fireball(Vector3 targetPoint, Vector3 normalize)
    {
        if (nextShotTime <= Time.time)
        {
            nextShotTime = Time.time + shotDellay;
            _fireball = Instantiate(fireballPrefab);
            _fireball.transform.position = transform.position + normalize * 1.5f;
            Vector3 rel = targetPoint - transform.position;
            float angleY = Mathf.Atan2(rel.x, rel.z) * Mathf.Rad2Deg;
            _fireball.transform.Rotate(0, angleY, 0);
        }
    }
}
