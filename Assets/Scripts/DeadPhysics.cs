using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPhysics : MonoBehaviour
{
    public Collider MainCollider;
    private Collider[] AllColliders;

    private void Awake()
    {
        MainCollider = GetComponent<Collider>();
        AllColliders = GetComponentsInChildren<Collider>(true);
        doRagdoll(false);
    }

    public void doRagdoll(bool isRagdoll)
    {
        foreach (var col in AllColliders)
        {
            col.enabled = isRagdoll;
            MainCollider.enabled = !isRagdoll;
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            GetComponent<Animator>().enabled = !isRagdoll;
        }
    }

    private void OnCollisionEnter(Collision collision) //FOR PLAYER
    {
        if (collision.transform.name == "Cube")
        {
            Player.speed = 0f;
            doRagdoll(true);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(stopTheGame());
        }
    }

    IEnumerator stopTheGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }

}
