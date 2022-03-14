using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FollowerController : MonoBehaviour
{
    public GameObject follower;
    public float speed = 1.0f;
    public float rotatiionSpeed = 1.0f;

    XRRayInteractor rayInteractor;

    public void FollowStart(HoverEnterEventArgs args)
    {
        if (rayInteractor == null)
        {
            rayInteractor = args.interactor as XRRayInteractor;

            if (rayInteractor != null)
            {
                StartCoroutine(Follow());
            }
        }
    }

    public void FollowStep()
    {
        StopAllCoroutines();
        rayInteractor = null;
    }

    IEnumerator Follow()
    {
        while (true)
        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                follower.transform.position = Vector3.MoveTowards(follower.transform.position, hit.point, speed * Time.deltaTime);
                Vector3 targetDir = hit.point - follower.transform.position;
                Vector3 rotationAmount = Vector3.RotateTowards(follower.transform.forward, targetDir, rotatiionSpeed * Time.deltaTime, 0.0f);
                follower.transform.rotation = Quaternion.LookRotation(rotationAmount);
            }
            yield return true;
        }
    }
}
