/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，箭的功能处理脚本
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
    public class Ctrl_Arrow : MonoBehaviour
    {        
        public float floArrowSpeed = 1;                                                 //箭的速度
        public int intArrowATK = 40;                                                    //攻击力
        private Ctrl_HeroProperty _heroProperty;                                        //英雄属性，用于处理英雄的血量减少
        void Start()
        {
            GameObject tmp_GoHero = GameObject.FindGameObjectWithTag(Tag.Player);
            if (tmp_GoHero)
            {
                _heroProperty = tmp_GoHero.GetComponent<Ctrl_HeroProperty>();
            }
        }

        void Update()
        {
            if (Time.frameCount % 2 == 0)
            {
                transform.Translate(Vector3.forward * floArrowSpeed * Time.deltaTime);
            }
        }

        void OnTriggerEnter(Collider _col)
        {
            if (_col.gameObject.tag == Tag.Player)
            {
                _heroProperty.DecreaseHealthValues(intArrowATK);
                PoolManager.PoolsArray["ParticleSys"].RecoverGameObjectToPool(this.gameObject);
            }
        }
    }
}