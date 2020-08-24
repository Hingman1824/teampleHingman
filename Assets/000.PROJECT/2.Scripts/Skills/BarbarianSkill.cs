using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BarbarianSkill : PlayerManager
{
    public bool isRend = false;
    public bool isBattleRage = false;
    public bool isFuriousCharge = false;
    public bool isWhirlWind = false;

    private void Awake()
    {        
        myRb = GetComponent<Rigidbody>();
        
        pv = GetComponent<PhotonView>();
        
        pv.ObservedComponents[0] = this;
        
        pv.synchronization = ViewSynchronization.UnreliableOnChange;
        
        anim = gameObject.GetComponentInChildren<Animator>();

        //babaWeapon = GameObject.FindWithTag("BabaWeapon").GetComponent<BoxCollider>();

        if (pv.isMine)
        {
            Camera.main.GetComponent<SmoothFollow>().target = camPivot;
        }
        else
        {            
            myRb.isKinematic = true; 
        }
        currPos = this.transform.position;
        currRot = this.transform.rotation;
    }


    void Update()
    {
        if (pv.isMine)
        {
            pv.RPC("PlayerMovement", PhotonTargets.AllBuffered, null);

            pv.RPC("PlayerMoveAnimation", PhotonTargets.AllBuffered, null);

            pv.RPC("AttackInput", PhotonTargets.AllBuffered, null);

        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, currPos, Time.deltaTime * 3.0f);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currRot, Time.deltaTime * 3.0f);
        }
    }

    [PunRPC]
    public void AttackInput()
    {
        if (Input.GetKey(KeyCode.X) && isRend == false)
        {
            StartCoroutine(Rend());
        }

        if (Input.GetKey(KeyCode.E) && isBattleRage == false)
        {
            StartCoroutine(BattleRage());
        }

        if (Input.GetKey(KeyCode.R) && isFuriousCharge == false)
        {
            StartCoroutine(FuriousCharge());
        }

        if (Input.GetKey(KeyCode.F) && isWhirlWind == false)
        {
            StartCoroutine(WhirlWindOn());
        }
        else if (Input.GetKeyUp(KeyCode.F) && isWhirlWind == true)
        {
            StartCoroutine(WhirlWindOff());
        }
    }

    private IEnumerator Rend()
    {
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.5f);
        //Invoke("PlayerAttackAnimation", 0.5f);
        anim.SetBool("isAttack", false);
    }

    public IEnumerator BattleRage()
    {
        isBattleRage = true;
        anim.SetBool("isSkill1", true);
        yield return new WaitForSeconds(0.5f);
        Invoke("Rend", 0.5f);
        anim.SetBool("isSkill1", false);
        isBattleRage = false;
        yield return null;
    }
    public IEnumerator FuriousCharge()
    {
        isFuriousCharge = true;
        anim.SetBool("isSkill2", true);
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("isSkill2", false);
        isFuriousCharge = false;
        yield return null;
    }
    public IEnumerator WhirlWindOn()
    {
        isWhirlWind = true;
        anim.SetBool("isSkill3", true);
        yield return new WaitForSeconds(2.0f);
        //anim.SetBool("isSkill3", false);
        //isSkill3 = false;
        //yield return null;
    }
    public IEnumerator WhirlWindOff()
    {
        anim.SetBool("isSkill3", false);
        isWhirlWind = false;
        yield return null;
    }


}
