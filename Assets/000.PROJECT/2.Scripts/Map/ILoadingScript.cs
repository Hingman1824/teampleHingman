using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ILoadingScript : MonoBehaviour
{
    public Image[] Ruby; //로딩 하면서 보석이 채워지는 효과를 주기위해
    public GameObject roadingImg; //로딩 이미지

    public void LoadScene(string MapName) //다른 스크립트에서 MapName을 받음.
    {
        roadingImg.SetActive(true); //맵 이동이 시작되면 로딩 이미지를 활성화
        StartCoroutine(MapLoad(MapName)); //코루틴을 통해 맵을 로드
    }

    IEnumerator MapLoad(string MapName)
    {
        AsyncOperation asyNc = SceneManager.LoadSceneAsync(MapName); //
        asyNc.allowSceneActivation = false; //화면이 바로 넘어가는 것을 방지
        
        if (!asyNc.isDone) //아직 완료되지 않았다면
        {
            
            foreach (Image _ruby in Ruby) //Ruby이미지를 첫번째 부터 변경시켜줌으로써 점점 채워지는효과를 줌.
            {
                yield return new WaitForSeconds(0.5f);
                _ruby.color = new Color(255/255, 40/255, 40/255); //컬러 RGB값은 0~1로 표시되므로 255로 나누어서 원하는 컬러값을 표시
            }
            foreach (Image _ruby in Ruby)
            {
                yield return new WaitForSeconds(0.5f);
                _ruby.color = new Color(1, 1, 1);
            }
            //yield return MapLoad(MapName); //함수를 다시불러와서 다시시작.

        }
        //else if(asyNc.isDone)
        //{
        //    foreach (Image _ruby in Ruby) //Ruby이미지를 첫번째 부터 변경시켜줌으로써 점점 채워지는효과를 줌.
        //    {
        //        yield return new WaitForSeconds(0.5f);
        //        _ruby.color = new Color(255 / 255, 40 / 255, 40 / 255); //컬러 RGB값은 0~1로 표시되므로 255로 나누어서 원하는 컬러값을 표시
        //    }
        //    asyNc.allowSceneActivation = true;
        //}

        Debug.Log(asyNc.progress); //현재 맵 불러오기가 어느정도 완료되었는지 알려줌 0~0.9까지 표시

        //0.9로 표시되지만 if문 조건을 0.89이상으로 할경우 if문을 타지 않는다.(이유를 모르겠음....)
        if (asyNc.progress >= 0.88) //만약 준비가 거의 다 되었다면
        {
            foreach (Image _ruby in Ruby) //다시한번 루비의 색깔을 채워준다.
            {
                yield return new WaitForSeconds(0.5f);
                _ruby.color = new Color(255 / 255, 40 / 255, 40 / 255);
            }

            yield return new WaitForSeconds(1.0f);
            asyNc.allowSceneActivation = true; //다음 맵으로 이동 활성화
        }
    }

}
