using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;
    
    private ParticleManager ParticleManager { get => particleManager ??= core.GetCoreComponent<ParticleManager>(); }
    private Stats Stats { get => stats ??= core.GetCoreComponent<Stats>(); }

    private ParticleManager particleManager;
    private Stats stats;
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }

        core.StartCoroutine(DisableAfterDelay(0.3f)); // <- Add slight delay!
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        core.transform.parent.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}
