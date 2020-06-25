using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPointEffect : MonoBehaviour
{
    [System.ComponentModel.ReadOnly(true)]
    [SerializeField] private Transform[] transformParticles;

    private int current = -1;

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
                    var index = (int)Mathf.Repeat(++current, transformParticles.Length);

                    var system = transformParticles[index];

                    var position = hit.point;

                    position.y = 0f;

                    system.transform.position = position;

                    foreach (var particle in system.GetComponentsInChildren<ParticleSystem>())
                    {
                        particle.Play();
                    }
                    
                    break;
                }
            }
        }
    }
}
