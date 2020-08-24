using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ILoadingScript : MonoBehaviour
{
    /*이 스크립트는 로딩화면을 보여주며 */
    public Image[] Ruby; //로딩 하면서 보석이 채워지는 효과를 주기위해
    public GameObject roadingImg; //로딩 이미지

    public void LoadScene(string MapName) //다른 스크립트에서 MapName을 받음.
    {
        roadingImg.SetActive(true); //맵 이동이 시작되면 로딩 이미지를 활성화
        StartCoroutine(LodingBar()); //로딩바 채워지는 함수 시작
        AsyncOperation asyNc = SceneManager.LoadSceneAsync(MapName); //비동기씬 전환
        asyNc.allowSceneActivation = false; //화면이 바로 넘어가는 것을 방지
        StartCoroutine(MapLoad(asyNc)); //코루틴을 통해 맵을 로드
    }

    IEnumerator MapLoad(AsyncOperation asyNc)
    {
        //if (!asyNc.isDone) //아직 완료되지 않았다면
        //{
        //    yield return new WaitForSeconds(1.0f);
        //    yield return new WaitForSeconds(1.0f);
        //    yield return new WaitForSeconds(1.0f);
        //    yield return new WaitForSeconds(1.0f);
        //}

        Debug.Log(asyNc.progress); //현재 맵 불러오기가 어느정도 완료되었는지 알려줌 0~0.9까지 표시

        yield return new AsyncOperation(); //비동기 작업이 끝날때까지 대기

        StopCoroutine(LodingBar());
        yield return new WaitForSeconds(1.0f);
        asyNc.allowSceneActivation = true; //다음 맵으로 이동 활성화

        ////0.9로 표시되지만 if문 조건을 0.89이상으로 할경우 if문을 타지 않는다.(이유를 모르겠음....)
        //if (asyNc.progress >= 0.88) //만약 준비가 거의 다 되었다면
        //{
        //    StopCoroutine(LodingBar());
        //    yield return new WaitForSeconds(1.0f);
        //    asyNc.allowSceneActivation = true; //다음 맵으로 이동 활성화
        //}
    }

    IEnumerator LodingBar()
    {
        for (int i = -2; i <= 7; i++) //Ruby이미지를 첫번째 부터 변경시켜줌으로써 점점 채워지는효과를 줌.
        {
            Color aColor = new Color(200f / 255f, 40f / 255f, 40f / 255f); //밝은 보석
            Color bColor = new Color(100f / 255f, 30f / 255f, 30f / 255f); //조금 어두운 보석
            Color cColor = new Color(80f / 255f, 80f / 255f, 80f / 255f); // 어두운 보석

            if (i == -2) //첫번째 루비가 어두워지고
            {
                Ruby[i + 2].color = cColor;
            }
            if (i == -1) //첫번째 루비가 조금 어두워지고 2번째 루비는 어둡게
            {
                Ruby[i + 1].color = bColor;
                Ruby[i + 2].color = cColor;
            }
            if (i == 0) //첫번째 루비가 채워지고 2번째 루비는 조금 어둡게 3번째 루비는 어둡게 만듬
            {
                Ruby[i].color = aColor;
                Ruby[i + 1].color = bColor;
                Ruby[i + 2].color = cColor;
            }
            if (i == 1) //두번째 루비가 채워지고 양옆은 조금어둡게 양끝은 어둡게
            {
                Ruby[i - 1].color = bColor;
                Ruby[i].color = aColor;
                Ruby[i + 1].color = bColor;
                Ruby[i + 2].color = cColor;
            }
            if (i == 2)//세번째 루비가 채워지고 양옆은 조금어둡게 맨양쪽은 어둡게
            {
                Ruby[i - 2].color = cColor;
                Ruby[i - 1].color = bColor;
                Ruby[i].color = aColor;
                Ruby[i + 1].color = bColor;
                Ruby[i + 2].color = cColor;

            }
            if (i == 3) //네번째 루비가 채워지고 양옆은 조금 어둡게 2번째 루비는 어둡게
            {
                Ruby[i - 2].color = cColor;
                Ruby[i - 1].color = bColor;
                Ruby[i].color = aColor;
                Ruby[i + 1].color = bColor;
            }
            if (i == 4) //다섯번째 루비가 채워지고 4번째 루비는 조금 어둡게 3번째 루비는 어둡게 만듬
            {
                Ruby[i - 2].color = cColor;
                Ruby[i - 1].color = bColor;
                Ruby[i].color = aColor;
            }
            if (i == 5) //다섯번째 루비가 조금 어두워지고 4번째는 어둡게
            {
                Ruby[i - 2].color = cColor;
                Ruby[i - 1].color = bColor;
            }
            if (i == 6) //5번째 루비를 어둡게
            {
                Ruby[i - 2].color = cColor;
            }
            yield return new WaitForSeconds(0.8f);
        }
    }
}
