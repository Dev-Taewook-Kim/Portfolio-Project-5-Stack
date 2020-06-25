using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEffectObject : MonoBehaviour
{
    [Header("[Transforms]")]
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private Transform[] transformParticles;

    [SerializeField] private int current = -1;

    public void Emit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var hits = Physics.RaycastAll(ray, float.MaxValue);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.layer == 8)
                {
                    current = (int)Mathf.Repeat(++current, transformParticles.Length);

                    var position = hit.point;

                    position.y = 0f;

                    transformParticles[current].transform.position = position;

                    foreach (var particle in transformParticles[current].GetComponentsInChildren<ParticleSystem>())
                    {
                        particle.Play();
                    }

                    break;
                }
            }
        }
    }
}
