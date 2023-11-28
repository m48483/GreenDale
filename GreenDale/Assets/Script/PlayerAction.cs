using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class PlayerAction : MonoBehaviour
{
    public float Speed;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    Rigidbody2D rigid;
    Animator anim;
    Flowchart otherFlowchart;

    public string[] ZoeResponses1;
    public string[] ZoeResponses2;
    public string[] ZoeResponses3;

    public string[] HayulResponses1;
    public string[] HayulResponses2;
    public string[] HayulResponses3;

    public string[] SunHwaResponses1;
    public string[] SunHwaResponses2;
    public string[] SunHwaResponses3;

    public string[] SoYoungSeokResponses1;
    public string[] SoYoungSeokResponses2;
    public string[] SoYoungSeokResponses3;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject otherObject = GameObject.Find("Flowchart");
        otherFlowchart = otherObject.GetComponent<Flowchart>();
    }

    void Update()
    {
        // Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        isHorizonMove = Mathf.Abs(h) > Mathf.Abs(v);

        //string name = otherFlowchart.GetStringVariable("name");

        // Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //Direction
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        // Scan Object
        if (Input.GetMouseButtonDown(0) && scanObject != null)
        {
            //Debug.Log(name);
            //Debug.Log("this is : " + scanObject.name);
            otherFlowchart.SetStringVariable("name", scanObject.name);
        }

        string n = otherFlowchart.GetStringVariable("name");
        if (n == "store-Zoe")
        {
            ShowRandomZoeResponse();
        }
        else if (n == "citizen-hayul")
        {
            ShowRandomHayulResponse();
        }
        else if (n == "SoYoungSeok")
        {
            ShowRandomSoYoungSeokResponse();
        }
        else if (n == "VillageHead")
        {
            ShowRandomVillageHeadResponse();
        }

    }

    void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.9f, new Color(0, 1, 0));
        RaycastHit2D ratHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("object"));

        if (ratHit.collider != null)
        {
            scanObject = ratHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
    private void ShowRandomZoeResponse()
    {
        // 랜덤한 인덱스 선택
        int randomIndex = Random.Range(0, ZoeResponses1.Length);
        int Zoeheart = otherFlowchart.GetIntegerVariable("ZoeHeart");
        // int ZoeRandom = Random.Range(0, 2);
        // otherFlowchart.SetIntegerVariable("ZoeRandom", ZoeRandom);
        // 선택한 대답 출력
        if (Zoeheart <= 10)
        {
            otherFlowchart.SetStringVariable("sayy", ZoeResponses1[randomIndex]);
        }
        else if (Zoeheart > 10 && Zoeheart <= 40)
        {
            otherFlowchart.SetStringVariable("sayy", ZoeResponses2[randomIndex]);
        }
        else if (Zoeheart > 40)
        {
            otherFlowchart.SetStringVariable("sayy", ZoeResponses3[randomIndex]);
        }

    }
    private void ShowRandomHayulResponse()
    {
        // 랜덤한 인덱스 선택
        int randomIndex = Random.Range(0, HayulResponses1.Length);
        int Hayulheart = otherFlowchart.GetIntegerVariable("HayulHeart");
        // 선택한 대답 출력
        if (Hayulheart <= 10)
        {
            otherFlowchart.SetStringVariable("sayy", HayulResponses1[randomIndex]);
        }
        else if (Hayulheart > 10 && Hayulheart <= 40)
        {
            otherFlowchart.SetStringVariable("sayy", HayulResponses2[randomIndex]);
        }
        else if (Hayulheart > 40)
        {
            otherFlowchart.SetStringVariable("sayy", HayulResponses3[randomIndex]);
        }
    }
    private void ShowRandomSoYoungSeokResponse()
    {
        // 랜덤한 인덱스 선택
        int randomIndex = Random.Range(0, HayulResponses1.Length);
        int SoYoungSeokheart = otherFlowchart.GetIntegerVariable("SoYoungSeokHeart");
        // 선택한 대답 출력
        if (SoYoungSeokheart <= 10)
        {
            otherFlowchart.SetStringVariable("sayy", SoYoungSeokResponses1[randomIndex]);
        }
        else if (SoYoungSeokheart > 10 && SoYoungSeokheart <= 40)
        {
            otherFlowchart.SetStringVariable("sayy", SoYoungSeokResponses2[randomIndex]);
        }
        else if (SoYoungSeokheart > 40)
        {
            otherFlowchart.SetStringVariable("sayy", SoYoungSeokResponses3[randomIndex]);
        }
    }
    private void ShowRandomVillageHeadResponse()
    {
        // 랜덤한 인덱스 선택
        int randomIndex = Random.Range(0, HayulResponses1.Length);
        int VillageHeadheart = otherFlowchart.GetIntegerVariable("VillageHeadHeart");
        // 선택한 대답 출력
        if (VillageHeadheart <= 10)
        {
            otherFlowchart.SetStringVariable("sayy", SunHwaResponses1[randomIndex]);
        }
        else if (VillageHeadheart > 10 && VillageHeadheart <= 40)
        {
            otherFlowchart.SetStringVariable("sayy", SunHwaResponses2[randomIndex]);
        }
        else if (VillageHeadheart > 40)
        {
            otherFlowchart.SetStringVariable("sayy", SunHwaResponses3[randomIndex]);
        }
    }

    public void ZoeHeartSet()
    {
        // 랜덤한 인덱스 선택
        int ZoeHeart = otherFlowchart.GetIntegerVariable("ZoeHeart");
        ZoeHeart -= 10;
        otherFlowchart.SetIntegerVariable("ZoeHeart", ZoeHeart);
    }
}
