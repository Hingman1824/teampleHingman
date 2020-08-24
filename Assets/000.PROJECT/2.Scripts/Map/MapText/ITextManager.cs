using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ITextManager : MonoBehaviour
{
    /* 이 스크립트는 텍스트캔버스를 관리하는 스크립트 입니다.
     *  N Txt는 
    */
    public Text nTxt; //화면 우측 상단 맵 이름 표기
    public Text mTxt; //화면 중앙 맵
    public Text tTxt; //화면 우측 상단 시간 표시

    void Start()
    {
        mTxt = this.GetComponent<Text>(); //이 스크립트를 넣은 텍스트와 연결
        InvokeRepeating("FadeOutTxt", 3f, 0.5f); //FadeOutTxt함수를 3초후 0.5초마다 실행
    }

    void FadeOutTxt()
    {
        Color Acolor = mTxt.color; //컬러 값을 새로 생성하고 기존텍스트의 컬러 값을 대입
        Acolor.a -= 0.15f; //컬러 값의 알파 값을 감소
        mTxt.color = Acolor; //텍스트의 컬러값을 알파값을 감소시킨 컬러값으로 변경
        if (mTxt.color.a <= 0) { Destroy(gameObject); } //텍스트의 알파값이 0이하면 게임오브젝트 제거;
    }
}
