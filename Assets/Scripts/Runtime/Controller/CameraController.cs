using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    //To Do :: Feature :: Auto Resize Camera Position and Scale
    //Camera Orthographic Size and Position Depends on Difficulty

    private IEnumerator ShakeCameraForSecondsCoroutine(float seconds)
    {
        var dt = 0f;

        var origin = transform.position;

        while (dt <= seconds)
        {
            var positionX = Random.Range(-0.05f, 0.05f);
            var positionY = Random.Range(-0.05f, 0.05f);
            var positionZ = transform.position.z;

            var position = new Vector3(positionX, positionY, positionZ);

            transform.position = position;

            yield return new WaitForEndOfFrame();

            dt += Time.deltaTime;
        }

        transform.position = origin;
    }

    public void ShakeCameraForSeconds(float seconds)
    {
        StopCoroutine(nameof(ShakeCameraForSecondsCoroutine));
        StartCoroutine(ShakeCameraForSecondsCoroutine(seconds));
    }
}
