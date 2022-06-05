using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        EnemyAI enemy = other.GetComponent<EnemyAI>();

        if (enemy != null) enemy.TakeDamage();

        Destroy(this.gameObject);
    }
}
