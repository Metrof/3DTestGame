using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 3.0f;
    public float playerMagnitudeRange = 7.0f;

    private Transform player;

    private FireballCast fireball;

    private void Awake()
    {
        fireball = GetComponent<FireballCast>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private bool _alive = true;

    private void Update()
    {
        if (!_alive) return;
        Vector3 delta = player.position - transform.position;
        if (delta.magnitude <= playerMagnitudeRange) fireball.Fireball(player.position, delta.normalized);
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, obstacleRange, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
