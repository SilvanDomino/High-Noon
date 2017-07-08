using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private Vector3 magnitude = new Vector3(0, 0.03f, 0);
    private float update = 0.004f;

	public void Shake()
    {
        StartCoroutine("Shaker");
    }

    IEnumerator Shaker()
    {
        gameObject.transform.position += magnitude;
        yield return new WaitForSeconds(update);
        gameObject.transform.position -= magnitude;
    }
}
