/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，敌人属性父类
 * 
 * Description:
 *      具体作用：
 *      1、包含所有敌人的公共属性
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
    public class Ctrl_BaseEnemyProperty : BaseControl
    {
        public bool isDeath = false;                                    //是否死亡
        /* 在Inspector面板中隐藏，声明为public为了方便其他脚本调用 */
        [HideInInspector]
        public int HeroExperience = 0;                                  //杀敌经验值
        [HideInInspector]
        public int MaxHealth = 0;                                       //最大生命值
        [HideInInspector]
        public int ATK = 0;                                             //攻击力
        [HideInInspector]
        public int DEF = 0;                                             //防御力

        public float floCurrentHealth = 0f;                             //当前生命值

        private e_EnemyState _currentState = e_EnemyState.Idle;
        private bool _isSingleAddData = true;                               //单次开关，用于控制怪物死后增加英雄的各种数值
        void OnEnable()
        {
            //判断是否存活
            StartCoroutine("ChekcLifeContinue");
            _isSingleAddData = true;
        }

        void OnDisable()
        {
            //判断是否存活
            StopCoroutine("ChekcLifeContinue");
            _isSingleAddData = false;
        }
        /// <summary>
        /// 当前状态
        /// </summary>
        public e_EnemyState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        /// <summary>
        /// 在子类中运行的方法
        /// </summary>
        public void  RunMethodInChild()
        {
            floCurrentHealth = MaxHealth;
        }

        IEnumerator ChekcLifeContinue()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                if (floCurrentHealth <= MaxHealth * 0.01f)
                {
                    _currentState = e_EnemyState.Death;
                    if (_isSingleAddData)
                    {
                        _isSingleAddData = false;
                        //加经验
                        Ctrl_HeroProperty.Instance.AddExp(HeroExperience);
                        //加杀敌数
                        Ctrl_HeroProperty.Instance.AddKillNumber();
                        //加金币
                        Ctrl_HeroProperty.Instance.AddGold(57);
                    }
                    //置为死亡状态
                    _currentState = e_EnemyState.Death;
                    //回收对象
                    StartCoroutine("RecoverEnemy");
                }
            }
        }

        /// <summary>
        /// 伤害处理
        /// </summary>
        /// <param name="_hurtValue"></param>
        public void OnHurt(int _hurtValue)
        {
            int tmp_IntHurtValue = 0;
            _currentState = e_EnemyState.Hurt;
            tmp_IntHurtValue = Mathf.Abs(_hurtValue);
            if (tmp_IntHurtValue > 0)
            {
                floCurrentHealth -= tmp_IntHurtValue;
            }
            //print("我被攻击了！！！");
        }

        IEnumerator RecoverEnemy()
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
            //重置状态
            floCurrentHealth = MaxHealth;
            _currentState = e_EnemyState.Idle;
            //判断是否BOSS  是的话3秒后返回主城
            if (GetComponent<Ctrl_BossBruce_Animation>() != null)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_3);
                Ctrl_Level2Scene.Instance.ReturnMajorCity();
            }
            //回收本对象
            PoolManager.PoolsArray["Enemies"].RecoverGameObjectToPool(this.gameObject);
        }
    }
}