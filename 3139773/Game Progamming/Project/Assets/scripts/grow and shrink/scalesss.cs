using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalesss : MonoBehaviour
{
    public GameObject objectToScale;
    public float duration = 1f;
    public Vector3 minSize;
    public Vector3 maxSize;
    public bool scaleUp = false;
    public Coroutine ScaleCoroutine;

    public bool automatic = false;
    public bool coroutineIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        objectToScale.transform.localScale = minSize;
    }
}

    // Update is called once per frame
//    void Update()
//    {
//        if (automatic)
//        {
//            if (!coroutineIsRunning)
//            {
//                Scale();
//            }
//        }
//        else
//        {
//            if (Input.GetKeyDown(KeyCode.Q) )
//            {
//                Scale();
//            }
//        }
//    }

//    private Scale()
//    {
//        scaleUp = !scaleUp;

//        if (ScaleCoroutine != null)
//            StopCoroutine(ScaleCoroutine);

//        if (scaleUp)
//        {
//            ScaleCoroutine = StartCoroutine(ScaleOverTime(objectToScale, maxSize, duration));
//        }
//        else
//        {
//            ScaleCoroutine = StartCoroutine(ScaleOverTime(objectToScale, minSize, duration));
//        }
//    }

//    private IEnumerator ScaleOverTime(GameObject targetObj, Vector3 toScale, float duration)
//    {
//        float counter = 0;
//        Vector3 startToscale = targetObj.transform.localScale;

//        coroutineIsRunning = true;

//        while(counter < duration)
//        {
//            counter += Time.deltaTime;
//            targetObj.transform.localScale = Vector3.Lerp(startToscale, toScale, counter / duration);

//            if (counter > duration)
//                coroutineIsRunning = false;

//            yield return null;
            

            
//        }
//    }
//}
