using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CasePos : MonoBehaviour
{
    public static CasePos Case;

    public Vector3 endPos, startPos;
    public GameObject selectBox;


    private void Awake()
    {
        Case = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DOTween.SetTweensCapacity(500, 50);
        selectBox = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!RaycastControl.rayCtrl.finish)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (Input.GetMouseButtonUp(0) && RaycastControl.rayCtrl.play)
                {
                    if (hit.collider.CompareTag("Case"))
                    {
                        if (selectBox == null)
                        {
                            selectBox = hit.collider.gameObject;
                            RaycastControl.rayCtrl.selectBox = selectBox;
                            startPos = selectBox.transform.position;
                            RaycastControl.rayCtrl.okButton.SetActive(false);

                            OpenBox();
                        }
                    }

                }


            }
        }
    }

    public void OpenBox()
    {
        foreach (Transform Boxs in transform)
        {
            Boxs.GetComponent<BoxCollider>().enabled = false;
        }
        selectBox.transform.DOMove(endPos, 1).OnComplete(() =>
        {
            selectBox.transform.GetChild(0).transform.DORotate(new Vector3(70, 0, 0), .6f);
            selectBox.transform.GetChild(1).transform.DORotate(new Vector3(-60, 0, 0), .6f);
            RaycastControl.rayCtrl.okButton.SetActive(true);
        });

    }

    public void CloseBox()
    {
        RaycastControl.rayCtrl.okButton.SetActive(false);

        selectBox.transform.GetChild(0).transform.DORotate(new Vector3(0, 0, 0), .6f);
        selectBox.transform.GetChild(1).transform.DORotate(new Vector3(0, 0, 0), .6f).OnComplete(() => 
        { 
            selectBox.transform.DOMove(startPos, 1); 
        
        });

        Invoke("SelectBoxReset", 2f);

        if (RaycastControl.rayCtrl.countZero)
        {
            RaycastControl.rayCtrl.finish = true;
        }
    }

    void SelectBoxReset()
    {
        foreach (Transform Boxs in transform)
        {
            Boxs.GetComponent<BoxCollider>().enabled = true;
        }

        selectBox = null;

    }
}
