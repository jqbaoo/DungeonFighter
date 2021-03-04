/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主角移动控制脚本(通过EasyTouch插件)
 * 
 * Description:
 *      具体作用：
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;

namespace Control
{
    public class Ctrl_HeroMovingCtrlByET : BaseControl
    {
#if UNITY_ANDROID || UNITY_IPHONE
        public float floMovingSpeed = 5f;                               //正常移速
        public float floAttackMovingSpeed = 10f;                        //攻击移速                

        private CharacterController _characterController;
        private float _floGravity = 1f;                                 //重力
        #region 事件注册
        void OnEnable()
        {
            EasyJoystick.On_JoystickMove += OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        }

        void OnDestroy()
        {
            EasyJoystick.On_JoystickMove -= OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        }

        void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        }
        #endregion

        void Start()
        {
            _characterController = GetComponent<CharacterController>();

            //StartCoroutine("AttackByMove");
        }
        /// <summary>
        /// 移动攻击
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// 移动摇杆中
        /// </summary>
        /// <param name="move"></param>

        void OnJoystickMove(MovingJoystick move)
        {
            if (move.joystickName != GlobalParameter.JOYSTICK_NAME)
            {
                return;
            }

            //获取摇杆中心偏移的坐标  
            float joyPositionX = move.joystickAxis.x;
            float joyPositionY = move.joystickAxis.y;

            if (joyPositionY != 0 || joyPositionX != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState!=e_HeroActionState.MagicTrickB)
                {
                    transform.LookAt(new Vector3(transform.position.x - joyPositionX, transform.position.y, transform.position.z - joyPositionY));
                }

                Vector3 tmp_Movement = transform.forward * Time.deltaTime * floMovingSpeed;
                //模拟重力
                tmp_Movement.y -= _floGravity;
                //跑动或站立才允许移动
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Idle ||
                    Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Running)
                {
                    _characterController.Move(tmp_Movement);
                    
                    //播放奔跑动画
                    if (UnityHelper.GetInstance().GetSmallTime(0.2f))
                    {
                        Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(e_HeroActionState.Running);
                    }
                }
            }
        }

        /// <summary>
        /// 移动摇杆结束  
        /// </summary>
        /// <param name="move"></param>

        void OnJoystickMoveEnd(MovingJoystick move)
        {
            //停止时，角色恢复idle  
            if (move.joystickName == GlobalParameter.JOYSTICK_NAME)
            {
                if (Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Idle ||
                    Ctrl_HeroAnimationCtrl.Instance.CurrentActionState == e_HeroActionState.Running)
                {
                    Ctrl_HeroAnimationCtrl.Instance.SetCurrentActionState(e_HeroActionState.Idle);
                }
            }
        }

#endif
    }
}