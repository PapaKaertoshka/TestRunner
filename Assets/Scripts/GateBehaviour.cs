using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject gates;
    private IEnumerator closeGates() {
        yield return new WaitForSeconds(1f);
        gates.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(closeGates());
    }
}
