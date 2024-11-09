using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    CharacterController cc;
    Animator anim;

    [System.Serializable]

    public class AnimationStrings
    {
        public string forward = "forward";
        public string strafe = "strafe";
        public string sprint = "sprint";
    }
    [SerializeField]
    public AnimationStrings animStrings;
    /*public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 10f;*/
    public float PlayerSpeed;
    //public float PlaySpeed;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        float horizont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float sprint = Input.GetAxis("Sprint");
        transform.Translate(horizont * PlayerSpeed * Time.deltaTime, 0, vertical * PlayerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            PlayerSpeed = 5;
        }
        else
        {
            PlayerSpeed = 1;
        }
    }
    public void AnimateCharacter(float forward, float strafe)
    {
        anim.SetFloat(animStrings.forward, forward);
        anim.SetFloat (animStrings.strafe, strafe);
    }
    public void SprintCharacter(bool isSprinting)
    {
        anim.SetBool(animStrings.sprint, isSprinting);
    }
}
