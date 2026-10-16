using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject hitParticles;

    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void Damage(float amount)
    {
        Debug.Log(amount + " damage taken");

        Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        Anim.SetTrigger("damage");
    }
}
