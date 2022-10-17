using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseControl : MonoBehaviour
{

    public static MouseControl mCtrl;

    public float swipeSpeed, minPosX, maxPosX,mousePosY;
    public GameObject selectSack;


    private void Awake()
    {
        mCtrl = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (Input.GetMouseButton(0) && Input.mousePosition.y < mousePosY)
            {
                transform.Translate(new Vector3(Input.GetAxis("Mouse X"), 0f, 0f) * swipeSpeed * Time.deltaTime);

                if (hit.collider.CompareTag("Sack"))
                {
                    selectSack = hit.collider.gameObject;
                    selectSack.transform.DOScale(1.3f, .2f);
                }

            }
        }

        foreach (Transform Sack in transform)
        {
            if (selectSack != null)
            {
                if (selectSack.transform.name != Sack.transform.name)
                {
                    Sack.transform.DOScale(1f, .2f);
                }

            }
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minPosX, maxPosX);
        transform.position = pos;

        if (selectSack != null )
        {
            if (selectSack.transform.gameObject.name == "sack" )
            {

                RaycastControl.rayCtrl.prefabObj = null;
                RaycastControl.rayCtrl.dollarPlaced = true;
            }
            else
            {

                if (selectSack.transform.childCount > 0)
                {
                    RaycastControl.rayCtrl.prefabObj = selectSack.transform.GetChild(0).transform.gameObject;


                }
                else
                    RaycastControl.rayCtrl.prefabObj = null;

            }

        }

    }
}
