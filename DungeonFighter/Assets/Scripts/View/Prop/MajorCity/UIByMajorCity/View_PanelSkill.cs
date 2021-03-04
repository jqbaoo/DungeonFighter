/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 视图层，英雄技能窗体
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
using UnityEngine.UI;

namespace View
{
    public class View_PanelSkill : MonoBehaviour
    {
        //查看的项目
        public Image img_NormalATK;                                               //普攻
        public Image img_MagicA;                                                  //技能A
        public Image img_MagicB;                                                  //技能B
        public Image img_MagicC;                                                  //技能C
        public Image img_MagicD;                                                  //技能D

        //显示文字控件
        public Text txt_SkillName;                                                //技能名称
        public Text txt_SkillDescription;                                         //技能描述

        void Awake()
        {
            RegisterAttack();
        }
        void Start()
        {
            txt_SkillName.text = "普通攻击";
            txt_SkillDescription.text = "普通攻击连招打击，伤害随着等级的提升而提高";            
        }

        #region 注册相关
        /// <summary>
        /// 注册"攻击贴图"
        /// </summary>
        private void RegisterAttack()
        {
            if (img_NormalATK != null)
            {
                EventTriggerListener.Get(img_NormalATK.gameObject).onClick += NormalATK;
            }
            if (img_MagicA != null)
            {
                EventTriggerListener.Get(img_MagicA.gameObject).onClick += MagicA;
            }
            if (img_MagicB != null)
            {
                EventTriggerListener.Get(img_MagicB.gameObject).onClick += MagicB;
            }
            if (img_MagicC != null)
            {
                EventTriggerListener.Get(img_MagicC.gameObject).onClick += MagicC;
            }
            if (img_MagicD != null)
            {
                EventTriggerListener.Get(img_MagicD.gameObject).onClick += MagicD;
            }
        }

        /// <summary>
        /// "普攻"介绍
        /// </summary>
        /// <param name="_go"></param>
        private void NormalATK(GameObject _go)
        {
            if (_go == img_NormalATK.gameObject)
            {
                txt_SkillName.text = "普通攻击";
                txt_SkillDescription.text = "普通攻击连招打击，伤害随着等级的提升而提高";
            }
        }

        /// <summary>
        /// "技能A"介绍
        /// </summary>
        /// <param name="_go"></param>
        private void MagicA(GameObject _go)
        {
            if (_go == img_MagicA.gameObject)
            {
                txt_SkillName.text = "技能A";
                txt_SkillDescription.text = "技能AA";
            }
        }

        /// <summary>
        /// "技能B"介绍
        /// </summary>
        /// <param name="_go"></param>
        private void MagicB(GameObject _go)
        {
            if (_go == img_MagicB.gameObject)
            {
                txt_SkillName.text = "技能BB";
                txt_SkillDescription.text = "技能BB";
            }
        }

        /// <summary>
        /// "技能C"介绍
        /// </summary>
        /// <param name="_go"></param>
        private void MagicC(GameObject _go)
        {
            if (_go == img_MagicC.gameObject)
            {
                txt_SkillName.text = "技能C";
                txt_SkillDescription.text = "技能CC";
            }
        }

        /// <summary>
        /// "技能D"介绍
        /// </summary>
        /// <param name="_go"></param>
        private void MagicD(GameObject _go)
        {
            if (_go == img_MagicD.gameObject)
            {
                txt_SkillName.text = "技能D";
                txt_SkillDescription.text = "技能DD";
            }
        }
        #endregion


    }//class end
}