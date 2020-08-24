using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTestMove : MonoBehaviour
{
    
    [Space(3)]
    [Header("플레이어 스탯")]
    [Tooltip("플레이어 체력")]
    [Range(0,9999)]public int playerHp = 100;
    [Tooltip("플레이어 이동속도")]
    [Range(0,10)]public float playerSpeed = 1f;
    [Tooltip("플레이어 공격속도")]
    [Range(0,10)]public float playerAttackSpeed = 1.3f;
    [Tooltip("플레이어 대미지")]
    [Range(0,9999)]public float playerDamage = 10f;
    [Space(3)]
    [Header("플레이어 상태")]
    public bool isAttack = false;
    public bool isHit = false;
    public bool isRot = false;

    private Animator anim;
    private float playerRot = 10;
    private float playerH, playerV;

    private void Awake()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    void Update()
    {
        playerH = Input.GetAxis("Horizontal");
        playerV = Input.GetAxis("Vertical");
        //Vector3 moveBeg = new Vector3(playerH, 0, playerV);
        //moveBeg = moveBeg.normalized * playerSpeed;
        if(playerH != 0 || playerV != 0)
        {
            anim.SetBool("isAttack", false);
            if (playerH != 0 && playerV == 0)
            {
                anim.SetFloat("Speed", 1);

            }
            else if (playerH == 0 && playerV != 0)
            {
                anim.SetFloat("Speed", 1);

            }else if (playerH != 0 && playerV != 0)
            {
                anim.SetFloat("Speed", 1);
            }
        }else if(playerH == 0 && playerV == 0)
        {
            anim.SetFloat("Speed", 0);
        }
        PlayerMovement();
        //this.transform.Translate(moveBeg);

        if (Input.GetKey(KeyCode.X) && isAttack == false)
        {
            StartCoroutine(PlayerAttack());
        }
    }
    private void PlayerMovement()
    {
        if (playerV < 0 && playerH < 0 && isRot==false)
        {

            transform.position -= (Vector3.forward * Time.deltaTime * playerSpeed);
            transform.position += (Vector3.left * Time.deltaTime * playerSpeed);
            Quaternion target = Quaternion.Euler(0, 45, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
        }

        else if (playerV < 0 && playerH > 0 && isRot == false)
        {

            transform.position -= (Vector3.forward * Time.deltaTime * playerSpeed);


            transform.position += (Vector3.right * Time.deltaTime * playerSpeed);


            Quaternion target = Quaternion.Euler(0, 315, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
        }

        // 아래, 좌의 경우
        else if (playerV > 0 && playerH < 0 && isRot == false)
        {

            transform.position += (Vector3.forward * Time.deltaTime * playerSpeed);


            transform.position += (Vector3.left * Time.deltaTime * playerSpeed);


            Quaternion target = Quaternion.Euler(0, 135, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
        }

        // 아래, 우의 경우
        else if (playerV > 0 && playerH > 0 && isRot == false)
        {

            transform.position += (Vector3.forward * Time.deltaTime * playerSpeed);


            transform.position += (Vector3.right * Time.deltaTime * playerSpeed);


            Quaternion target = Quaternion.Euler(0, 225, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
        }

        // 한 키만 누를 시
        else
        {
            if (playerV < 0 && isRot == false)
            {

                transform.position -= (Vector3.forward * Time.deltaTime * playerSpeed);

                Quaternion target = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
            }

            if (playerV > 0 && isRot == false)
            {

                transform.position += (Vector3.forward * Time.deltaTime * playerSpeed);

                Quaternion target = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
            }

            if (playerH < 0 && isRot == false)
            {

                transform.position += (Vector3.left * Time.deltaTime * playerSpeed);
                Quaternion target = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
            }

            if (playerH > 0 && isRot == false)
            {

                transform.position += (Vector3.right * Time.deltaTime * playerSpeed);
                Quaternion target = Quaternion.Euler(0, 270, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * playerRot);
            }
        }

    }

    private IEnumerator PlayerAttack()
    {
        isAttack = true;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isAttack", false);
        isAttack = false;
        yield return null;
    }
}
