/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主角移动控制(通过键盘输入)
 * 
 * Description:
 *      具体作用：
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using Global;
using Kernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    public class Ctrl_HeroMovingCtrlByKey : BaseControl
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        public float flo_MovingSpeed = 5f;
        public float floAttackMovingSpeed = 10f;                        //攻击移速                

        private CharacterController _characterController;
        private float _floGravity = 1f;      

        void Start()
        {
            _characterController = GetComponent<CharacterController>();

            //StartCoroutine("AttackByMove");
        }

        void Update()
        {
            CtrolMoving();
        }

        /// <summary>
        /// 键盘移动
        /// </summary>
        /// <param name="move"></param>

        void CtrolMoving()
        {
            float tmp_Vertical = Input.GetAxis("Vertical");
            float tmp_Horizontal = Input.GetAxis("Horizontal");

            if (tmp_Vertical != 0 || tmp_Horizontal != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState != e_HeroActionState.MagicTrickB)
                {
                    transform.LookAt(new Vector3(transform.position.x - tmp_Horizontal, transform.position.y, transform.position.z - tmp_Vertical));
                }

                Vector3 tmp_Movement = transform.forward * Time.deltaTime * flo_MovingSpeed;
                //模拟重力
                tmp_Movement.y -= _floGravity;
                //跑动或站立才允许移动
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Idle ||
                    Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Running)
                {
                    _characterController.Move(tmp_Movement);
                    //播放奔跑动画
                    if (UnityHelper.GetInstance().GetSmallTime(0.3f))
                    {
                        Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(e_HeroActionState.Running);
                    }
                }
            }
        }

        IEnumerator AttackByMove()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.NormalAttack)
                {
                    Vector3 tmp_VectForward = transform.forward * floAttackMovingSpeed * Time.deltaTime;
                    _characterController.Move(tmp_VectForward);
                }
            }
        }
#endif
    }
}