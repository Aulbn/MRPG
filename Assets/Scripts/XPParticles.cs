using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPParticles : MonoBehaviour
{
    public Transform target;
    public float force = 10f;
    [Range(0,1)] public float attractPoint = .5f;

    private ParticleSystem ps;
    private float attractTime;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        attractTime = Time.time + ps.main.startLifetime.constantMin;
    }

    private void LateUpdate()
    {
        //if (ps.main.startLifetime.constantMin - (attractTime - Time.time) < Time.time) return; //Trying to get it to follow the target after a certain point. Too tired right now..

        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
        ps.GetParticles(particles);

        for (int i = 0; i < particles.Length; i++)
        {
            ParticleSystem.Particle p = particles[i];
            Vector3 directionToTarget = (target.position - p.position).normalized;

            Vector3 seekForce = directionToTarget * force * Time.deltaTime;

            p.velocity += seekForce;

            particles[i] = p;
        }

        ps.SetParticles(particles, particles.Length);
    }
}
