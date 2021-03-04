/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，弓箭手的动画系统
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
    public class Ctrl_Archer_Animation : BaseControl
    {
        public GameObject goArrowSpawnPos;                                              //箭的发射位置
        public GameObject goArrowPrefab;                                                //箭的预设
        public GameObject goHurtEffectPrefab;                                           //受伤特效预设

        private Ctrl_BaseEnemyProperty _myProperty;                                     //本身属性脚本
        private Ctrl_HeroProperty _heroProperty;                                        //英雄属性
        private Animator _animator;
        private bool _boolIsSingleTimes = true;                                         //单次开关

        void OnEnable()
        {
            StartCoroutine("PlayerArcherAnimationA");
            StartCoroutine("PlayerArcherAnimationB");

            _boolIsSingleTimes = true;
        }
        void Start()
        {
            _myProperty = GetComponent<Ctrl_BaseEnemyProperty>();
            GameObject tmp_GoHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if (tmp_GoHero != null)
            {
                _heroProperty = tmp_GoHero.GetComponent<Ctrl_HeroProperty>();
            }
            _animator = GetComponent<Animator>();

        }

        void OnDisable()
        {
            StopCoroutine("PlayerArcherAnimationA");
            StopCoroutine("PlayerArcherAnimationB");

            //把敌人死亡状态恢复为站立状态
            if (_animator != null)
            {
                _animator.SetTrigger("RecoverLife");
            }
        }

        IEnumerator PlayerArcherAnimationA()
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

        IEnumerator PlayerArcherAnimationB()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_2);
                switch (_myProperty.CurrentState)
                {
                    case e_EnemyState.Hurt:
                        _animator.SetTrigger("Hurt");
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
        public IEnumerator AnimationEvent_AttackHero()
        {
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "Prefabs/Prop/Archer_Arrow", true, goArrow.transform.position, goArrow.transform.rotation, transform.parent, null, 10));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goArrowPrefab, goArrowSpawnPos.transform.position, goArrowSpawnPos.transform.rotation, null));

            yield break;
        }

        /// <summary>
        /// 受伤动画效果
        /// </summary>
        public IEnumerator AnimationEvent_ArcherHurt()
        {
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Enemy_Hurt", true, transform.position, transform.rotation, transform, null, 1));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goHurtEffectPrefab, transform.position, Quaternion.identity, null));
            yield break;
        }

    }//class end
}


