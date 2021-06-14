using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] public Transform m_TargetRoot;
    [SerializeField] public Animator m_Animator;
    [SerializeField] public Transform m_Target;
    [SerializeField] public float m_MoveSpeed;
    [SerializeField] public List<Transform> m_Slots = new List<Transform>();
    [SerializeField] private Transform m_BricksRoot;
    [SerializeField] bool isgrounded;
    public ColorEnum m_CharctorColor;

    private void Start()
    {
        SetCharactorColor();
    }
    [Button]
    private void SetRefs()
    {
        //clear old 
        for (int i = 0; i < m_Slots.Count; i++) Destroy(m_Slots[i].gameObject);
        for (int i = 1; i <= 50; i++)
        {
            Transform localNew = new GameObject(i+"_Slot").transform;
            localNew.parent = m_BricksRoot;
            localNew.eulerAngles = Vector3.zero;
            localNew.localScale = Vector3.one;
            localNew.localPosition = new Vector3(0, i*-0.25f, 0);
            m_Slots.Add(localNew);
        }       
    }
    public Transform GetTopSlot()   
    {
        return m_Slots.Find(x => x.childCount == 0);
    }
    public bool IsFull()
    {
         return m_Slots[m_Slots.Count-1].childCount > 0;
    }
    public int GetHowMany() 
    {
        return m_Slots.FindAll(x => x.childCount != 0).Count;
    }
    [Button]
    public Transform GetTopBlock()
    {
        if(m_Slots[0].childCount == 0) return null;
        return m_Slots.FindLast(x => x.childCount != 0).GetChild(0);
        //Destroy(m_Slots.FindLast(x=> x.childCount !=0).GetChild(0).gameObject);
        //return true;
    }
    [Button]
    void SetCharactorColor()
    {
        switch (m_CharctorColor)
        {
            case ColorEnum.GREEN:
                SetColor(Color.green);
                break;
            case ColorEnum.RED:
                SetColor(Color.red);
                break;
            case ColorEnum.YELLOW:
                SetColor(Color.yellow);
                break;
            default:
                SetColor(Color.white);
                break;
        }
    }
        void SetColor(Color i_Color)
        {
          transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = i_Color;
        }

    public ColorEnum SetPlayreEnum()
    {
        return m_CharctorColor;
    }

    void FixedUpdate()
    {

        if (isgrounded== true)
        {
            Debug.Log("IS_GROUND_TRUEE");
        }

        if (Input.GetMouseButton(0))    
        {
            if (Vector3.Distance(m_Target.position, transform.position) > 0.15f || true)
            {
                transform.LookAt(m_Target);
                m_TargetRoot.position = transform.position;
                transform.Translate((Vector3.forward) * Time.deltaTime * (m_MoveSpeed));
                m_Animator.enabled = true;
            }
            else
            {
                m_Animator.enabled = false;
            }
        }
        else
        {
            m_Animator.enabled = false;
        }
    }
   /* void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Ground_1"|| theCollision.gameObject.name == "Ground_2")
        {
            isgrounded = true;
        }
    }
    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Ground_1" || theCollision.gameObject.name == "Ground_2")
        {
            isgrounded = false;
        }
    }*/
}

