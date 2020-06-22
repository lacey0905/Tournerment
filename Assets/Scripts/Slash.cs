using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(ShowSlash());
    }

    private void OnDisable()
    {
        
    }

    IEnumerator ShowSlash()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
