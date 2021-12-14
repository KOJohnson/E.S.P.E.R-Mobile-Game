using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotation : MonoBehaviour
{
    public float angle;
    public float secondsToRotate;
    bool startNextRotation = true;
    public bool rotateRight;
    float duration;

    // Start is called before the first frame update
    void Start()
    {
        startRotation();
    }

    private void Update()
    {
        if (startNextRotation && rotateRight)
        {
           //Debug.Log("forward");
            StartCoroutine(Rotate(angle, secondsToRotate));
        }

        else if (startNextRotation && !rotateRight)
        {
            //Debug.Log("back");
            StartCoroutine(Rotate(-angle, secondsToRotate));
        }
    }


    IEnumerator Rotate(float angle, float duration)
    {
        //Debug.Log("rotate start");
        startNextRotation = false;
        Quaternion initialRotation = transform.rotation;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * angle, Vector3.up);
            yield return null;

        }

        startNextRotation = true;
        rotateRight = !rotateRight;
        //Debug.Log("rotate end");
    }

    void startRotation() { 

        if (rotateRight)
        {
            transform.localRotation = Quaternion.AngleAxis(-angle /2, Vector3.up);

        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(angle / 2, Vector3.up);
        }             
    

    }
}
