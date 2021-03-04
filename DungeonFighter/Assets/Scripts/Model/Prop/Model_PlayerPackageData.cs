/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 模型层，玩家背包数据
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

namespace Model
{
    public class Model_PlayerPackageData
    {
        public static del_PlayerKernalModel event_PlayerPackageData;                                    //玩家背包数据事件
        private int _intBlootBottleNumber;     
        private int _intMagicBottleNumber;                                                              //蓝瓶数量
        private int _intPropATKNumber;                                                                  //攻击力道具数量
        private int _intPropDEFNumber;                                                                  //防御力道具数量
        private int _intPropDEXNumber;                                                                  //敏捷度道具数量

        #region 属性
        public int BloodBottleNumber
        {
            get { return _intBlootBottleNumber; }
            set 
            { 
                _intBlootBottleNumber = value;
                if (event_PlayerPackageData!=null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("BloodBottleNumber", BloodBottleNumber);
                    event_PlayerPackageData(tmp_KV);
                }
            }
        }
        public int MagicBottleNumber
        {
            get { return _intMagicBottleNumber; }
            set
            {
                _intMagicBottleNumber = value; if (event_PlayerPackageData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("MagicBottleNumber", MagicBottleNumber);
                    event_PlayerPackageData(tmp_KV);
                }
            }
        }
        public int PropATKNumber
        {
            get { return _intPropATKNumber; }
            set
            {
                _intPropATKNumber = value; if (event_PlayerPackageData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("PropATKNumber", PropATKNumber);
                    event_PlayerPackageData(tmp_KV);
                }
            }
        }
        public int PropDEFNumber
        {
            get { return _intPropDEFNumber; }
            set
            {
                _intPropDEFNumber = value; if (event_PlayerPackageData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("PropDEFNumber", PropDEFNumber);
                    event_PlayerPackageData(tmp_KV);
                }
            }
        }
        public int PropDEXNumber
        {
            get { return _intPropDEXNumber; }
            set
            {
                _intPropDEXNumber = value; if (event_PlayerPackageData != null)
                {
                    KeyValueUpdate tmp_KV = new KeyValueUpdate("PropDEXNumber", PropDEXNumber);
                    event_PlayerPackageData(tmp_KV);
                }
            }
        }
        #endregion

        private Model_PlayerPackageData() { }

        public Model_PlayerPackageData(int _bloodBottleNum, int _magicBottleNum, int _atkNum, int _defNum, int _dexNum)
        {
            this._intBlootBottleNumber = _bloodBottleNum;
            this._intMagicBottleNumber = _magicBottleNum;
            this._intPropATKNumber = _atkNum;
            this._intPropDEFNumber = _defNum;
            this._intPropDEXNumber = _dexNum;
        }
    }//class end
}