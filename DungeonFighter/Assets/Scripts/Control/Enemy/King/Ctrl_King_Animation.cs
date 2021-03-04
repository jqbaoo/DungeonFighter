/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，国王的动画系统
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
    public class Ctrl_King_Animation : BaseControl
    {
        public GameObject goMoveUpLabelPrefab;                                          //"飘字"预设
        public GameObject goHurtEffectPrefab;                                           //受伤特效预设

        private Ctrl_BaseEnemyProperty _myProperty;                                     //本身属性脚本
        private Ctrl_HeroProperty _heroProperty;                                        //英雄属性
        private Animator _animator;
        private bool _boolIsSingleTimes = true;                                         //单次开关

        private GameObject goHero;                                                      //英雄            
        private GameObject goUIPlayerInfo;                                              //玩家UI面板
        void OnEnable()
        {
            StartCoroutine("PlayerKingAnimationA");
            StartCoroutine("PlayerKingAnimationB");

            _boolIsSingleTimes = true;
        }
        void Start()
        {
            _myProperty = GetComponent<Ctrl_BaseEnemyProperty>();
            goHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if (goHero != null)
            {
                _heroProperty = goHero.GetComponent<Ctrl_HeroProperty>();
            }
            _animator = GetComponent<Animator>();
            goUIPlayerInfo = GameObject.FindGameObjectWithTag(Tag.UIPlayerInfo);
        }

        void OnDisable()
        {
            StopCoroutine("PlayerKingAnimationA");
            StopCoroutine("PlayerKingAnimationB");

            //把敌人死亡状态恢复为站立状态
            if (_animator != null)
            {
                _animator.SetTrigger("RecoverLife");
            }
        }

        IEnumerator PlayerKingAnimationA()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
                switch (_myProperty.CurrentState)
                {
                    case e_EnemyState.Idle:
                        _animator.SetFloat("MoveSpeed", 0);
                        _animator.SetBool("Attack", false);
                        break;
                    case e_EnemyState.Walking:
                        _animator.SetFloat("MoveSpeed", 1);
                        _animator.SetBool("Attack", false);
                        break;
                    case e_EnemyState.Attack:
                        _animator.SetFloat("MoveSpeed", 0);
                        _animator.SetBool("Attack", true);
                        break;
                    default:
                        break;
                }
            }//while end
        }

        IEnumerator PlayerKingAnimationB()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);          
                switch (_myProperty.CurrentState)
                {
                    case e_EnemyState.Hurt:
                        
                        _animator.SetTrigger("Hurt");
                        yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1DOT5);
                        break;
                    case e_EnemyState.Death:
                        if (_boolIsSingleTimes)
                        {
                            _boolIsSingleTimes = false;
                            _animator.SetTrigger("Dead");
                        }
                        break;
                    default:
                        break;
                }
            }//while end
        }

        /// <summary>
        /// 攻击主角(动画事件)
        /// </summary>
        public void AnimationEvent_AttackHero()
        {
            _heroProperty.DecreaseHealthValues(_myProperty.ATK);
            //"飘字"特效
            StartCoroutine(base.LoadParticalEffectInPool_MoveUpLabel(0.1f, goMoveUpLabelPrefab,
                goHero.transform.position + transform.TransformDirection(new Vector3(0, 10f, 0f)), Quaternion.identity, goHero,_myProperty.ATK, goUIPlayerInfo.transform));
        }

        /// <summary>
        /// 战士受伤动画效果
        /// </summary>
        public IEnumerator AnimationEvent_KingHurt()
        {
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Enemy_Hurt", true, transform.position, transform.rotation, transform, null, 1));
            //yield break;

            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goHurtEffectPrefab, transform.position, Quaternion.identity, null));
            //统计连击
            ComboCountManager.Instance.ResetNumber();
            yield break;
        }

    }//class end
}