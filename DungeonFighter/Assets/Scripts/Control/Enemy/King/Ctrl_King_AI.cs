/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，国王的AI
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
    public class Ctrl_King_AI : BaseControl
    {
        public float floMoveSpeed = 1f;
        public float floRotateSpeed = 1f;                                               //旋转速度
        public float floAttackDistance = 2f;                                            //攻击距离
        public float floCordonDistance = 5f;                                            //警戒距离
        public float floThinkInterval = 1f;                                             //思考间隔时间

        private GameObject _goHero;                                                     //主角
        private Transform _myTransform;                                                 //当前战士(敌人)方位
        private Ctrl_BaseEnemyProperty _myProperty;                                      //属性
        private CharacterController _characterCtrl;

        void OnEnable()
        {
            //开启思考协程
            StartCoroutine("ThinkProcess");
            //开启移动协程
            StartCoroutine("MovingProcess");
        }
        void Start()
        {
            _goHero = GameObject.FindGameObjectWithTag(Tag.Player);
            _myTransform = this.transform;
            _myProperty = GetComponent<Ctrl_BaseEnemyProperty>();
            _characterCtrl = GetComponent<CharacterController>();

            //确定个体差异性参数
            floMoveSpeed = UnityHelper.GetInstance().GetRandomNum(5, 10);
            //floAttackDistance = UnityHelper.GetInstance().GetRandomNum(1, 3);
            floCordonDistance = UnityHelper.GetInstance().GetRandomNum(4, 8);
            floThinkInterval = UnityHelper.GetInstance().GetRandomNum(2, 4);
        }
        void OnDisable()
        {
            //开启思考协程
            StopCoroutine("ThinkProcess");
            //开启移动协程
            StopCoroutine("MovingProcess");
        }
        /// <summary>
        /// "思考"协程
        /// </summary>
        /// <returns></returns>
        IEnumerator ThinkProcess()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);

            while (true)
            {
                yield return new WaitForSeconds(floThinkInterval);
                if (_myProperty && _myProperty.CurrentState != e_EnemyState.Death)
                {
                    //得到主角与当前敌人的距离
                    Vector3 tmp_VecHero = _goHero.transform.position;
                    //判断距离
                    float tmp_Distance = Vector3.Distance(tmp_VecHero, _myTransform.position);
                    //小于攻击距离
                    if (tmp_Distance < floAttackDistance)
                    {
                        //攻击
                        _myProperty.CurrentState = e_EnemyState.Attack;
                    }
                    else if (tmp_Distance >= floAttackDistance && tmp_Distance < floCordonDistance)
                    {
                        //警戒(追击)
                        _myProperty.CurrentState = e_EnemyState.Walking;
                    }
                    else
                    {
                        //状态转为休闲
                        _myProperty.CurrentState = e_EnemyState.Idle;
                    }
                }
            }
        }

        /// <summary>
        /// "移动"处理
        /// </summary>
        /// <returns></returns>
        IEnumerator MovingProcess()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);

            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT02);
                if (_myProperty && _myProperty.CurrentState != e_EnemyState.Death)
                {
                    //面向主角
                    FaceToHero();
                    //移动
                    switch (_myProperty.CurrentState)
                    {
                        case e_EnemyState.Walking:
                            Vector3 tmp_VectForward = Vector3.ClampMagnitude(_goHero.transform.position - _myTransform.position, floMoveSpeed * Time.deltaTime);
                            _characterCtrl.Move(tmp_VectForward);
                            break;
                        //受伤，后退移动
                        case e_EnemyState.Hurt:
                            //Vector3 tmp_VectBack = -transform.forward * floMoveSpeed / 2 * Time.deltaTime;
                            //_characterCtrl.Move(tmp_VectBack);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 面向主角
        /// </summary>
        private void FaceToHero()
        {
            UnityHelper.GetInstance().FaceToGo(_myTransform, _goHero.transform, floRotateSpeed);
        }
    }
}