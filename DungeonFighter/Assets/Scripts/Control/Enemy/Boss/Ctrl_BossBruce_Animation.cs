/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，敌人(BOSS)动画系统
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
    public class Ctrl_BossBruce_Animation : BaseControl
    {
        /* 音效 */
        public AudioClip ac_NormalAttack;                                               //普攻
        public AudioClip ac_JumpAttack;                                                 //跳跃攻击
        public AudioClip ac_Blare;                                                      //吼叫
        public AudioClip ac_Dead;                                                       //死亡

        public GameObject goMoveUpLabelPrefab;                                          //"飘字"预设
        public GameObject goHurtEffectPrefab;                                           //受伤特效预设
        public GameObject goNormalAttack;
        public GameObject goSkill;

        private Ctrl_BaseEnemyProperty _myProperty;                                     //本身属性脚本
        private Ctrl_HeroProperty _heroProperty;                                        //英雄属性
        private Animator _animator;
        private bool _boolIsSingleTimes = true;                                         //单次开关

        private GameObject goHero;                                                      //英雄            
        private GameObject goUIPlayerInfo;                                              //玩家UI面板

        //void OnEnable()
        //{
        //    StartCoroutine("PlayerWarriorAnimationA");
        //    StartCoroutine("PlayerWarriorAnimationB");

        //    _boolIsSingleTimes = true;
        //}

        void OnEnable()
        {
            GameObject tmp_GoHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if (tmp_GoHero != null)
            {
                _heroProperty = tmp_GoHero.GetComponent<Ctrl_HeroProperty>();
            }
        }
        void Awake()
        {
            _myProperty = GetComponent<Ctrl_BaseEnemyProperty>();

            _animator = GetComponent<Animator>();
        }
        void Start()
        {
            StartCoroutine("PlayerAnimationA");
            StartCoroutine("PlayerAnimationB");

            _boolIsSingleTimes = true;

            _myProperty = GetComponent<Ctrl_BaseEnemyProperty>();
            goHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if (goHero != null)
            {
                _heroProperty = goHero.GetComponent<Ctrl_HeroProperty>();
            }
            goUIPlayerInfo = GameObject.FindGameObjectWithTag(Tag.UIPlayerInfo);
        }

        //void OnDisable()
        //{
        //    StopCoroutine("PlayerWarriorAnimationA");
        //    StopCoroutine("PlayerWarriorAnimationB");

        //    //把敌人死亡状态恢复为站立状态
        //    if (_animator != null)
        //    {
        //        _animator.SetTrigger("RecoverLife");
        //    }
        //}

        IEnumerator PlayerAnimationA()
        {
            yield return new WaitForEndOfFrame();
            //出场先吼一声
            AudioManager.PlayAudioEffectA(ac_Blare);
            _animator.SetTrigger("Blare");
            yield return new WaitForSeconds(ac_Blare.length);

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

        IEnumerator PlayerAnimationB()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
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
        /// 普通攻击(动画事件)
        /// </summary>
        public IEnumerator AnimationEvent_NormalAttack()
        {
            //_heroProperty.DecreaseHealthValues(_myProperty.ATK);

            //攻击音效
            AudioManager.PlayAudioEffectA(ac_NormalAttack);
            //减少血量
            _heroProperty.DecreaseHealthValues(_myProperty.ATK);
            //播放粒子效果
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_MagicB(bruceSkill)", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 5f)), transform.rotation, null, null, 1));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goNormalAttack, transform.position + transform.TransformDirection(new Vector3(0, 0, 5f)), Quaternion.identity, null));
            //飘字特效
            StartCoroutine(base.LoadParticalEffectInPool_MoveUpLabel(0.1f, goMoveUpLabelPrefab,
                goHero.transform.position + transform.TransformDirection(new Vector3(0, 10f, 0f)), Quaternion.identity, goHero, _myProperty.ATK, goUIPlayerInfo.transform));
            yield break;
        }

        /// <summary>
        /// 跳跃攻击(动画事件)
        /// </summary>
        public IEnumerator AnimationEvent_JumpAttack()
        {
            //攻击音效
            AudioManager.PlayAudioEffectA(ac_JumpAttack);
            //减少血量
            _heroProperty.DecreaseHealthValues(_myProperty.ATK * 1.5f);
            //播放粒子效果
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/BossSkill", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 5f)), transform.rotation, transform, null, 1));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goSkill, transform.position + transform.TransformDirection(new Vector3(0, 0, 5f)), Quaternion.identity, null));
            //飘字特效
            StartCoroutine(base.LoadParticalEffectInPool_MoveUpLabel(0.1f, goMoveUpLabelPrefab,
                goHero.transform.position + transform.TransformDirection(new Vector3(0, 10f, 0f)), Quaternion.identity, goHero, (int)(_myProperty.ATK * 1.5f), goUIPlayerInfo.transform));
            yield break;
        }

        /// <summary>
        /// 受伤动画效果
        /// </summary>
        public IEnumerator AnimationEvent_Hurt()
        {
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Enemy_Hurt", true, transform.position, transform.rotation, transform, null, 1));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goHurtEffectPrefab, transform.position, Quaternion.identity, null));
            //统计连击
            ComboCountManager.Instance.ResetNumber();
            yield break;
        }

        /// <summary>
        /// 死亡动画效果
        /// </summary>
        public IEnumerator AnimationEvent_Dead()
        {
            AudioManager.PlayAudioEffectB(ac_Dead);
            yield break;
        }

    }//class end
}