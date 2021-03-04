/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，国王的属性
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
    public class Ctrl_King_Property : Ctrl_BaseEnemyProperty
    {
        public int intHeroExperience = 400;                             //杀敌经验值
        public int intMaxHealth = 50;                                   //最大生命值
        public int intATK = 20;                                          //攻击力
        public int intDEF = 10;                                          //防御力

        void Start()
        {
            base.HeroExperience = intHeroExperience;
            base.MaxHealth = intMaxHealth;
            base.ATK = intATK;
            base.DEF = intDEF;
            base.RunMethodInChild();
        }
    }
}