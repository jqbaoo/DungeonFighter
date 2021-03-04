/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，敌人(BOSS)的属性
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
    public class Ctrl_BossBruce_Property : Ctrl_BaseEnemyProperty
    {
        public int intHeroExperience = 20;                              //杀敌经验值
        public int intMaxHealth = 20;                                   //最大生命值
        public int intATK = 2;                                          //攻击力
        public int intDEF = 2;                                          //防御力

        public 
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