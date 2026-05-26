using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour
{
    bool isAttacking = false;
    float attackDuration = 1;
    float attackCooldown = 0.5f;
    float nextAttack;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttack)
        {
            StartCoroutine(Attack(attackDuration));
            nextAttack = Time.time + attackCooldown;
        }
    }

    IEnumerator Attack(float duration)
    {
        isAttacking = true;
        //PLAY ANIMATION OF SWING
        yield return new WaitForSeconds(duration);
        isAttacking = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(isAttacking && other.CompareTag("Enemy"))
        {
            //Damage enemy
        }
    }
}
