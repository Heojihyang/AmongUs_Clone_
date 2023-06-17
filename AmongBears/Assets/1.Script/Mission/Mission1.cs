using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mission1 : MonoBehaviour
{
    public Color red;
    public Image[] images;
    
    Animator anim;
    PlayerCtrl playerCtrl_script;
    MissionCtrl missionCtrl_script;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        missionCtrl_script = FindObjectOfType<MissionCtrl>();
    }

    //미션 시작
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //초기화
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
        }
            //랜덤
            for (int i = 0; i< 4; i++)
        {
            int rand = Random.Range(0, 7);

            images[rand].color = red;
        }
    }

    //엑스버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    //육각형 버튼 누르면 호출
    public void ClickButton()
    {
        Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        if(img.color == Color.white)
        {
            //빨간색으로 변환
            img.color = red;
        }
        else //빨간색이라면
        {
            //하얀색으로 변환
            img.color = Color.white;
        }

        //성공 여부 체크
        int count = 0;
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].color == Color.white)
            {
               count++;
            }           
        }

        if(count == images.Length)
        {
            //성공, 호출 함수와 딜레이 시간
            Invoke("MissionSuccess", 0.2f);
        }
    }

    //미션 성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
        missionCtrl_script.MissionSuccess(GetComponent<CircleCollider2D>());
    }
}
