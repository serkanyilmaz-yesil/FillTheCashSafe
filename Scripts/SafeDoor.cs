using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SafeDoor : MonoBehaviour
{

    public float time;
    bool close = false;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.SetTweensCapacity(500, 50);

    }

    // Update is called once per frame
    void Update()
    {

        if (!RaycastControl.rayCtrl.finish)
        {
            if (time < 3f)
            {
                time += Time.deltaTime;

                transform.GetChild(0).Rotate(0, 0, 200 * Time.deltaTime);

            }
            else
                transform.DORotate(new Vector3(0, 30, 0), 2).SetEase(Ease.Flash).OnComplete(() => { CamControl.cam.door = true; }); ;

        }
        else
        {
            Invoke("Close", 3f);
            Invoke("CloseTurn", 2f);
            if (time < 5f)
            {
                time += Time.deltaTime;

                transform.GetChild(0).Rotate(0, 0, -200 * Time.deltaTime);

            }

        }


    }

    void CloseTurn()
    {
        transform.DORotate(new Vector3(0, 180, 0), 2).SetEase(Ease.Flash);

    }


    void Close()
    {
        if (!close)
        {
            time = 0;
            close = true;
        }

    }
}
