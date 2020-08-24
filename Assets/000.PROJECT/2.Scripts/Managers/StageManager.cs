using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour // 선생님은 주로 SceneManager라고 했다는데, 
                                          // SceneManager가 SceneManagement로 unity에서 구현해서 이제 이름이 겹치므로
                                          // StageManager 사용
{
    //스테이지
    public int stage;
    // SoundManager 컴포넌트를 연결 할 변수
    public SoundManager _sMgr;

    // 테스트 변수
    public AudioClip soundClip;
    private float soundTime;

    // Start is called before the first frame update
    void Start()
    {
        //// 아래 두줄은 PlyaManager.cs로 이동
        //GameObject.Find("ExPlainUi").SetActive(false); 
        //GameObject.Find ("SoundCanvas").GetComponent<Canvas> ().enabled = true;

        //SoundManager 게임오브젝의 SoundManager 컴포넌트 연결
        _sMgr = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        //배경사운드 플레이
        _sMgr.PlayBackground(stage);

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > soundTime)
        {
            LightningSound();
            // 3.5초 마다 번개 사운드 연출
            soundTime = Time.time + 3.5f;
        }        
    }

    // 병렬 처리를 위한 코루틴 함수를 호출
    void LightningSound()
    {
        // StartCoroutine으로 Coroutine 함수 호출
        StartCoroutine(this.PlayEffctSound(soundClip));
    }

    // Effect 테스트 사운드를 Coroutine으로 생성
    IEnumerator PlayEffctSound(AudioClip _clip)
    {
        // 공용사운드 함수 호출
        _sMgr.PlayEffct(transform.position, _clip);
        yield return null;
    }
}

// 코루틴함수는 단시간의 반복적인 병렬적 호출에 유용하므로 1시간 간격으로 호출될 시는 쓰지 않는 것이 좋다.
// 여기서처럼 3.5초마다 번개 사운드 출력시에는 좋다.