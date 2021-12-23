using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
 
    public ParticleSystem ParticleEffect => _particle;

    public void PlayParticle() => _particle.Play();

}

