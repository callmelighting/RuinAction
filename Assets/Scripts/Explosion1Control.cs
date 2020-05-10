using UnityEngine;

public class Explosion1Control : MonoBehaviour
{

    private ParticleSystem effect1;

    void Start()
    {
        effect1 = transform.Find("explosion").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (effect1.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
