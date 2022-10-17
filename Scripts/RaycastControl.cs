using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RaycastControl : MonoBehaviour
{
    public static RaycastControl rayCtrl;

    public GameObject dollarBox,dollarPrefab;
    public GameObject selectBox;

    public GameObject box1, box2, box3, box4, box5, box6;


    public float dollarYAxis;
    public Transform[] placedDollar = new Transform[10];
    public int dollarIndex, maxDollar;

    private float boxYAxis = 0.12f;
    private Transform[] box1Placed = new Transform[21];
    private Transform[] box2Placed = new Transform[21];
    private Transform[] box3Placed = new Transform[21];
    private Transform[] box4Placed = new Transform[21];
    private Transform[] box5Placed = new Transform[21];
    private Transform[] box6Placed = new Transform[21];
    private int box1Index, box2Index, box3Index, box4Index, box5Index, box6Index;
    public int box1Max, box2Max, box3Max, box4Max, box5Max, box6Max;
    public GameObject prefabObj;

    private Transform hitPlacedPos;

    public bool play;
    public GameObject sacksObjs, okButton, nextButton;

    [HideInInspector]
    public bool dollarPlaced;

    public bool finish = false;
    public bool countZero = false;
    private AudioSource source;
    private AudioClip bip;

    private void Awake()
    {
        rayCtrl = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TinySauce.OnGameStarted();
        source = GetComponent<AudioSource>();
        bip = Resources.Load<AudioClip>("bip");

        for (int i = 0; i < placedDollar.Length; i++)
        {
            placedDollar[i] = dollarBox.transform.GetChild(1).GetChild(0).GetChild(i);
        }

        BoxSPos();
        play = false;
        sacksObjs.SetActive(false);
        okButton.SetActive(false);
        nextButton.SetActive(false);
        dollarPlaced = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            sacksObjs.SetActive(true);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (Input.GetMouseButton(0))
                {

                    if (!hit.collider.CompareTag("Case") && !hit.collider.CompareTag("Sack"))
                    {
                        hitPlacedPos = hit.collider.gameObject.transform;

                    }



                    if (hit.collider.CompareTag("Dollar") && maxDollar > 0 && prefabObj == null && dollarPlaced)
                    {
                        PlacedDollar();
                        hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                        prefabObj = null;
                    }

                    if (prefabObj !=null)
                    {

                        if (hit.collider.CompareTag("Box1") && box1Max > 0)
                        {
                            if (selectBox.name == hit.collider.gameObject.tag)
                            {
                                PlacedBox1();
                                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;

                            }


                        }
                        if (hit.collider.CompareTag("Box2") && box2Max > 0)
                        {
                            if (selectBox.name == hit.collider.gameObject.tag)
                            {
                                PlacedBox2();
                                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;

                            }

                        }
                        if (hit.collider.CompareTag("Box3") && box3Max > 0)
                        {
                            if (selectBox.name == hit.collider.gameObject.tag)
                            {
                                PlacedBox3();
                                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;

                            }

                        }
                        if (hit.collider.CompareTag("Box4") && box4Max > 0)
                        {
                            if (selectBox.name == hit.collider.gameObject.tag)
                            {
                                PlacedBox4();
                                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;

                            }

                        }
                        if (hit.collider.CompareTag("Box5") && box5Max > 0)
                        {
                            if (selectBox.name == hit.collider.gameObject.tag)
                            {
                                PlacedBox5();
                                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;

                            }

                        }
                        if (hit.collider.CompareTag("Box6") && box6Max > 0)
                        {
                            if (selectBox.name == hit.collider.gameObject.tag)
                            {
                                PlacedBox6();
                                hit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;

                            }

                        }

                    }

                    if (box1Max <= 0 && box2Max <= 0 && box3Max <= 0 && box4Max <= 0 && box5Max <= 0 && box6Max <= 0 && maxDollar == 0)
                    {
                        countZero = true;
                    }



                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (maxDollar <= 0 && hit.collider.CompareTag("Dollar"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }
                    if (box1Max <= 0 && hit.collider.CompareTag("Box1"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }
                    if (box2Max <= 0 && hit.collider.CompareTag("Box2"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }
                    if (box3Max <= 0 && hit.collider.CompareTag("Box3"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }
                    if (box4Max <= 0 && hit.collider.CompareTag("Box4"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }
                    if (box5Max <= 0 && hit.collider.CompareTag("Box5"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }
                    if (box6Max <= 0 && hit.collider.CompareTag("Box6"))
                    {
                        selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                    }

                    if (selectBox != null)
                    {
                        if (prefabObj == null && dollarPlaced && !hit.collider.CompareTag("Dollar"))
                        {
                            selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                        }

                        if (prefabObj != null && hit.collider.CompareTag("Dollar"))
                        {
                            selectBox.transform.DOShakePosition(.5f, .15f, 20, 20);
                        }

                    }

                }


            }

        }

        if (finish)
        {
            sacksObjs.SetActive(false);
            okButton.SetActive(false);
            Invoke("NextDelay", 5f);
            finish = true;
            play = false;

        }


    }

    void NextDelay()
    {
        nextButton.SetActive(true);

    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BoxSPos()
    {
        for (int i = 0; i < box1Placed.Length; i++)
        {
            box1Placed[i] = box1.transform.GetChild(1).GetChild(0).GetChild(i);
        }

        for (int i = 0; i < box2Placed.Length; i++)
        {
            box2Placed[i] = box2.transform.GetChild(1).GetChild(0).GetChild(i);
        }

        for (int i = 0; i < box3Placed.Length; i++)
        {
            box3Placed[i] = box3.transform.GetChild(1).GetChild(0).GetChild(i);
        }

        for (int i = 0; i < box4Placed.Length; i++)
        {
            box4Placed[i] = box4.transform.GetChild(1).GetChild(0).GetChild(i);
        }

        for (int i = 0; i < box5Placed.Length; i++)
        {
            box5Placed[i] = box5.transform.GetChild(1).GetChild(0).GetChild(i);
        }

        for (int i = 0; i < box6Placed.Length; i++)
        {
            box6Placed[i] = box6.transform.GetChild(1).GetChild(0).GetChild(i);
        }

    }

    public void PlacedDollar()
    {
        GameObject clone = Instantiate(dollarPrefab, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                                hitPlacedPos.position.y,
                                                hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        source.PlayOneShot(bip);
        maxDollar--;
        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);


        if (dollarIndex < 9)
        {
            dollarIndex++;

        }
        else
        {
            dollarIndex = 0;
            dollarBox.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            dollarBox.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            dollarBox.transform.GetChild(1).GetChild(0).transform.localPosition.y + dollarYAxis,
            dollarBox.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("DollarYAxisDelay", .5f);
        }

    }

    void DollarYAxisDelay()
    {
        foreach (Transform DollarBox in dollarBox.transform.GetChild(1).GetChild(0))
        {
            DollarBox.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }

    public void PlacedBox1()
    {
        GameObject clone = Instantiate(prefabObj, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                               hitPlacedPos.position.y,
                                               hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        source.PlayOneShot(bip);

        box1Max--;
        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);

        if (box1Index < 20)
        {
            box1Index++;

        }
        else
        {
            box1Index = 0;
            box1.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            box1.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            box1.transform.GetChild(1).GetChild(0).transform.localPosition.y + boxYAxis,
            box1.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("Box1YAxisDelay", 0.5f);

        }

    }
    void Box1YAxisDelay()
    {
        foreach (Transform Box1 in box1.transform.GetChild(1).GetChild(0))
        {
            Box1.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }


    public void PlacedBox2()
    {
        GameObject clone = Instantiate(prefabObj, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                                hitPlacedPos.position.y,
                                                hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        box2Max--;
        source.PlayOneShot(bip);

        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);

        if (box2Index < 20)
        {
            box2Index++;

        }
        else
        {
            box2Index = 0;
            box2.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            box2.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            box2.transform.GetChild(1).GetChild(0).transform.localPosition.y + boxYAxis,
            box2.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("Box2YAxisDelay", 0.5f);

        }

    }
    void Box2YAxisDelay()
    {
        foreach (Transform Box2 in box2.transform.GetChild(1).GetChild(0))
        {
            Box2.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }


    public void PlacedBox3()
    {
        GameObject clone = Instantiate(prefabObj, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                                hitPlacedPos.position.y,
                                                hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        source.PlayOneShot(bip);

        box3Max--;
        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);

        if (box3Index < 20)
        {
            box3Index++;

        }
        else
        {
            box3Index = 0;
            box3.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            box3.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            box3.transform.GetChild(1).GetChild(0).transform.localPosition.y + boxYAxis,
            box3.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("Box3YAxisDelay", 0.5f);

        }

    }
    void Box3YAxisDelay()
    {
        foreach (Transform Box3 in box3.transform.GetChild(1).GetChild(0))
        {
            Box3.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }


    public void PlacedBox4()
    {
        GameObject clone = Instantiate(prefabObj, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                                hitPlacedPos.position.y,
                                                hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        box4Max--;
        source.PlayOneShot(bip);

        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);

        if (box4Index < 20)
        {
            box4Index++;

        }
        else
        {
            box4Index = 0;
            box4.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            box4.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            box4.transform.GetChild(1).GetChild(0).transform.localPosition.y + boxYAxis,
            box4.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("Box4YAxisDelay", 0.5f);

        }

    }
    void Box4YAxisDelay()
    {
        foreach (Transform Box4 in box4.transform.GetChild(1).GetChild(0))
        {
            Box4.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }


    public void PlacedBox5()
    {
        GameObject clone = Instantiate(prefabObj, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                                hitPlacedPos.position.y,
                                                hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        box5Max--;
        source.PlayOneShot(bip);

        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);

        if (box5Index < 20)
        {
            box5Index++;

        }
        else
        {
            box5Index = 0;
            box5.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            box5.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            box5.transform.GetChild(1).GetChild(0).transform.localPosition.y + boxYAxis,
            box5.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("Box5YAxisDelay", 0.5f);

        }

    }
    void Box5YAxisDelay()
    {
        foreach (Transform Box5 in box5.transform.GetChild(1).GetChild(0))
        {
            Box5.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }


    public void PlacedBox6()
    {
        GameObject clone = Instantiate(prefabObj, selectBox.transform.GetChild(1).GetChild(1).transform);
        clone.transform.DOScale(new Vector3(1f, 1f, 1f), .2f).SetEase(Ease.OutElastic);
        clone.transform.position = new Vector3(hitPlacedPos.position.x,
                                                hitPlacedPos.position.y,
                                                hitPlacedPos.position.z);

        clone.transform.eulerAngles = hitPlacedPos.eulerAngles;
        box6Max--;
        source.PlayOneShot(bip);

        GameObject remove = MouseControl.mCtrl.selectSack.transform.GetChild(MouseControl.mCtrl.selectSack.transform.childCount - 1).gameObject;
        Destroy(remove);

        if (box6Index < 20)
        {
            box6Index++;

        }
        else
        {
            box6Index = 0;
            box6.transform.GetChild(1).GetChild(0).transform.localPosition = new Vector3(
            box6.transform.GetChild(1).GetChild(0).transform.localPosition.x,
            box6.transform.GetChild(1).GetChild(0).transform.localPosition.y + boxYAxis,
            box6.transform.GetChild(1).GetChild(0).transform.localPosition.z);
            Invoke("Box6YAxisDelay", 0.5f);
        }

    }
    void Box6YAxisDelay()
    {
        foreach (Transform Box6 in box6.transform.GetChild(1).GetChild(0))
        {
            Box6.transform.GetComponent<BoxCollider>().enabled = true;
        }

    }


}
