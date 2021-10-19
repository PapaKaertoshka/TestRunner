using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    private void OnTriggerEnter(Collider other)
    {
        particles.SetActive(true);
    }
}
