using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTimeout : MonoBehaviour
{
    public float timeout = 5.0f;
    public Transform spawn;

    Coroutine time;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Floor"))
        {
            time = StartCoroutine(Timeout());
        }
    }

    IEnumerator Timeout(){
        yield return new WaitForSeconds(timeout);

        transform.position = spawn.position;
    }

    public void ClearTimeout() {
        if (time != null) StopCoroutine(time);
    }
}
