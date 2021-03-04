/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，弓箭手属性
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
using Kernal;
using Global;

namespace Control
{
    public class Ctrl_Archer_Property : Ctrl_BaseEnemyProperty
    {
        public int intHeroExperience = 200;                             //杀敌经验值
        public int intMaxHealth = 30;                                   //最大生命值
        public int intATK = 0;                                          //攻击力 实际攻击力在道具上
        public int intDEF = 5;                                          //防御力

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