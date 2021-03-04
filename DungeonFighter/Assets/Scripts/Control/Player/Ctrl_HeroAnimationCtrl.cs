/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，主角动画控制
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
using Model;

namespace Control
{
    public class Ctrl_HeroAnimationCtrl : BaseControl
    {
        public static Ctrl_HeroAnimationCtrl Instance;
        //动画剪辑
        public AnimationClip anim_Idle;                                                             //休闲
        public AnimationClip anim_Running;                                                          //跑动
        public AnimationClip anim_NormalAttack1;                                                    //普攻1
        public AnimationClip anim_NormalAttack2;                                                    //普攻2
        public AnimationClip anim_NormalAttack3;                                                    //普攻3
        public AnimationClip anim_MagicTrickA;                                                      //技能A
        public AnimationClip anim_MagicTrickB;                                                      //技能B
        //音频剪辑
        public AudioClip ac_HeroRunning;                                                            //跑步剪辑
        //攻击特效
        public GameObject goHeroNormalParticleEffect1;                                              //普攻1
        public GameObject goHeroNormalParticleEffect2;                                              //普攻2  跳劈
        public GameObject goMagicA;                                                                 //技能A
        public GameObject goMagicB;                                                                 //技能B

        //主角音效剪辑
        public AudioClip ac_BeiJi_DaoJian_1;
        public AudioClip ac_BeiJi_DaoJian_2;
        public AudioClip ac_BeiJi_DaoJian_3;
        public AudioClip ac_SwordHero_MagicA;
        public AudioClip ac_SwordHero_MagicB;
        public AudioClip ac_SwordHero_MagicC;
        public AudioClip ac_SwordHero_MagicD;


        private e_HeroActionState _currentActionState = e_HeroActionState.None;                     //主角的动画状态
        
        private Animation _anim_Handle;
        
        private bool _boolIsSinglePlay = true;                                                      //单次播放
        
        private e_NormalATKComboState _currentATKCombo = e_NormalATKComboState.NormalATK1;          //普攻连招


        public e_HeroActionState CurrentActionState
        {
            get { return _currentActionState; }
        }

        void Awake()
        {
            Instance = this;
        }
        void Start()
        {
            _currentActionState = e_HeroActionState.Idle;
            _anim_Handle = this.GetComponent<Animation>();

            //启动协程，控制动画状态
            StartCoroutine("ControlHeroAnimationState");

            //加快动画速度
            _anim_Handle[anim_NormalAttack1.name].speed = 2.5f;
            _anim_Handle[anim_NormalAttack2.name].speed = 2.5f;
            _anim_Handle[anim_NormalAttack3.name].speed = 2.5f;

            _anim_Handle[anim_MagicTrickA.name].speed = 2.5f;
            _anim_Handle[anim_MagicTrickB.name].speed = 2.5f;

            //主角出现特效
            HeroDisplayParticalEffect();
        }

        /// <summary>
        /// 设置当前动画状态
        /// </summary>
        /// <param name="_actionState"></param>
        public void SetCurrentActionState(e_HeroActionState _actionState)
        {
            this._currentActionState = _actionState;
        }

        /// <summary>
        /// 主角的动画控制
        /// </summary>
        IEnumerator ControlHeroAnimationState()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                switch (_currentActionState)
                {
                    case e_HeroActionState.NormalAttack:
                        //连招处理
                        switch (_currentATKCombo)
                        {
                            case e_NormalATKComboState.NormalATK1:
                                _currentATKCombo = e_NormalATKComboState.NormalATK2;
                                _anim_Handle.CrossFade(anim_NormalAttack1.name);
                                AudioManager.PlayAudioEffectB(ac_BeiJi_DaoJian_1);
                                yield return new WaitForSeconds(anim_NormalAttack1.length / 2.5f);
                                _currentActionState = e_HeroActionState.Idle;

                                break;

                            case e_NormalATKComboState.NormalATK2:
                                _anim_Handle.CrossFade(anim_NormalAttack2.name);
                                _currentATKCombo = e_NormalATKComboState.NormalATK3;
                                AudioManager.PlayAudioEffectB(ac_BeiJi_DaoJian_2);
                                yield return new WaitForSeconds(anim_NormalAttack2.length / 2.5f);
                                _currentActionState = e_HeroActionState.Idle;

                                break;

                            case e_NormalATKComboState.NormalATK3:
                                _anim_Handle.CrossFade(anim_NormalAttack3.name);
                                AudioManager.PlayAudioEffectB(ac_BeiJi_DaoJian_3);
                                yield return new WaitForSeconds(anim_NormalAttack3.length / 2.5f);
                                _currentATKCombo = e_NormalATKComboState.NormalATK1;
                                _currentActionState = e_HeroActionState.Idle;

                                break;

                            default:
                                break;
                        }
                        break;
                    case e_HeroActionState.MagicTrickA:
                        //判断魔法值是否够使用技能
                        if (Model_PlayerKernalDataProxy.GetInstance().GetCurrentMagic() >= 10f)
                        {
                            //扣除相应魔法
                            Model_PlayerKernalDataProxy.GetInstance().DecreaseMagicValues(10f);
                            _anim_Handle.CrossFade(anim_MagicTrickA.name);
                            AudioManager.PlayAudioEffectB(ac_SwordHero_MagicA);
                            yield return new WaitForSeconds(anim_MagicTrickA.length / 2.5f);
                            _currentActionState = e_HeroActionState.Idle;
                        }
                        break;
                    case e_HeroActionState.MagicTrickB:
                        if (Model_PlayerKernalDataProxy.GetInstance().GetCurrentMagic() >= 20f)
                        {
                            //扣除相应魔法
                            Model_PlayerKernalDataProxy.GetInstance().DecreaseMagicValues(20f);
                            _anim_Handle.CrossFade(anim_MagicTrickB.name);
                            AudioManager.PlayAudioEffectB(ac_SwordHero_MagicB);
                            yield return new WaitForSeconds(anim_MagicTrickB.length / 2.5f);
                            _currentActionState = e_HeroActionState.Idle;
                        }
                        break;

                    case e_HeroActionState.None:
                        break;
                    case e_HeroActionState.Idle:
                        _anim_Handle.CrossFade(anim_Idle.name);
                        break;
                    case e_HeroActionState.Running:
                        _anim_Handle.CrossFade(anim_Running.name);
                        
                        //播放音频
                        AudioManager.PlayAudioEffectB(ac_HeroRunning);
                        
                        yield return new WaitForSeconds(ac_HeroRunning.length);
                        break;
                    default:
                        break;
                }//switch end
            }
        }//function end

        /// <summary>
        /// 动画事件_技能A
        /// 在动画事件上使用
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_HeroMagicA()
        {
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_MagicA(bruceSkill)", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 4f)), transform.rotation, null, null, 0));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goMagicA, transform.position + transform.TransformDirection(new Vector3(0, 0, 5f)), Quaternion.identity, null));
            
            yield break;        //相当于return null
        }

        /// <summary>
        /// 动画事件_技能B
        /// 在动画事件上使用
        /// </summary>
        /// <returns></returns>
        public IEnumerator AnimationEvent_HeroMagicB()
        {
            //StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_MagicB(bruceSkill)", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 4f)), transform.rotation, null, null, 0));
            StartCoroutine(base.LoadParticalEffect_UsePool(GlobalParameter.INTERVAL_TIME_0DOT1, goMagicB, transform.position + transform.TransformDirection(new Vector3(0, 0, 5f)), Quaternion.identity, null));
            
            yield break;
        }
        /// <summary>
        /// 普通攻击1粒子特效(左右劈砍)
        /// </summary>
        public IEnumerator AnimationEvent_HeroNormalATK_1()
        {
            StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0, "ParticleProps/Hero_NormalATK2", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 1f)), transform.rotation, transform, null, 1));
            yield break;
        }

        /// <summary>
        /// 普通攻击2粒子特效(从上往下砍)
        /// </summary>
        public IEnumerator AnimationEvent_HeroNormalATK_2()
        {
            StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0, "ParticleProps/Hero_NormalATK3", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 1f)), transform.rotation, transform, null, 1));
            yield break;
        }

        /// <summary>
        /// 主角登场特效
        /// </summary>
        private void HeroDisplayParticalEffect()
        {
            StartCoroutine(base.LoadParticalEffect(GlobalParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_Display", true, transform.position + transform.TransformDirection(new Vector3(0, 0.2f, 0)), transform.rotation, transform, null, 0));            

            GameObject tmp_GoParticleEffect = ResourcesManager.GetInstance().LoadResource("ParticleProps/Hero_Display", true);
            tmp_GoParticleEffect.transform.position = transform.position + transform.TransformDirection(new Vector3(0, 0.2f, 0));
            //设置特效父子关系，为了使特效跟随主角
            tmp_GoParticleEffect.transform.parent = transform;
        }


       
    }
}