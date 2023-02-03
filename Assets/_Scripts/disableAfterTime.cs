using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAfterTime : MonoBehaviour
{
    [SerializeField] float time = 3;

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private void OnDisable()
    {
        StopCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
