using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public static CamControl cam;

    public Vector3 endPos;
    public Transform lookPos;
    public bool door = false;
    public float lerpSpeed;

    private void Awake()
    {
        cam = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.LookAt(lookPos);
        if (door)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, lerpSpeed * Time.fixedDeltaTime);

            if (!RaycastControl.rayCtrl.finish)
            {
                Invoke("DelayPlay", 2);

            }
        }
    }

    void DelayPlay()
    {
        if (door)
        {
            RaycastControl.rayCtrl.play = true;
        }
    }

}
