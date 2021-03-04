/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 测试层，测试模型数据
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
using Model;
using UnityEngine.UI;

namespace Test
{
    public class Test_ModelLayer : MonoBehaviour
    {
        public Text txt_HP;
        public Text txt_MP;
        public Text txt_ATK;
        public Text txt_DEF;
        public Text txt_DEX;

        public Text txt_MaxHP;
        public Text txt_MaxMP;
        public Text txt_MaxATK;
        public Text txt_MaxDEF;
        public Text txt_MaxDEX;

        public Text txt_Exp;
        public Text txt_KillNumber;
        public Text txt_Level;
        public Text txt_Gold;
        public Text txt_Miamond;
        void Awake()
        {
            Model_PlayerKernalData.event_PlayerKernal += DisplayHP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayATK;
            Model_PlayerKernalData.event_PlayerKernal += DisplayDEF;
            Model_PlayerKernalData.event_PlayerKernal += DisplayDEX;

            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxHP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxMP;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxATK;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxDEF;
            Model_PlayerKernalData.event_PlayerKernal += DisplayMaxDEX;

            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayExp;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayKillNumber;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayLevel;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayGold;
            Model_PlayerExtenalData.event_PlayerExtenalData += DisplayDiamond;
        }
        void Start()
        {
            Model_PlayerKernalDataProxy tmp_PlayerKernalDataProxy = new Model_PlayerKernalDataProxy(100, 100, 10, 5, 45, 100, 100, 10, 10, 50, 0, 0, 0);
            Model_PlayerKernalDataProxy.GetInstance().DisplayAllOriginalValues();

            Model_PlayerExtenalDataProxy tmp_PlayerExtenalDataProxy = new Model_PlayerExtenalDataProxy(0, 0, 0, 0, 0);
            Model_PlayerExtenalDataProxy.GetInstance().DisplayAllOriginalValue();
        }

        #region 事件用户点击
        public void IncreaseHP()
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseHealthValues(10);
        }
        public void DecreaseHP()
        {
            Model_PlayerKernalDataProxy.GetInstance().DecreaseHealthValues(20);
        }
        public void IncreaseMP()
        {
            Model_PlayerKernalDataProxy.GetInstance().IncreaseMagicValues(30);
        }
        public void DecreaseMP()
        {
            Model_PlayerKernalDataProxy.GetInstance().DecreaseMagicValues(40);
        }
        public void AddExp()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddExp(30);
        }
        public void AddKillNumber()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddKillNumber();
        }
        public void AddLevel()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddLevel();
        }
        public void AddGold()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddGold(40);
        }
        public void AddDiamond()
        {
            Model_PlayerExtenalDataProxy.GetInstance().AddDiamonds(35);
        }
        #endregion

        #region 事件注册方法
        private void DisplayHP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Health"))
            {
                txt_HP.text = _kv.Value.ToString();
            }
        }
        private void DisplayMP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Magic"))
            {
                txt_MP.text = _kv.Value.ToString();
            }
        }
        private void DisplayATK(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Attack"))
            {
                txt_ATK.text = _kv.Value.ToString();
            }
        }
        private void DisplayDEF(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Defence"))
            {
                txt_DEF.text = _kv.Value.ToString();
            }
        }
        private void DisplayDEX(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Dexterity"))
            {
                txt_DEX.text = _kv.Value.ToString();
            }
        }
        private void DisplayMaxHP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxHealth"))
            {
                txt_MaxHP.text = _kv.Value.ToString();
            }
        }
        private void DisplayMaxMP(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxMagic"))
            {
                txt_MaxMP.text = _kv.Value.ToString();
            }
        }
        private void DisplayMaxATK(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxAttack"))
            {
                txt_MaxATK.text = _kv.Value.ToString();
            }
        }
        private void DisplayMaxDEF(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxDefence"))
            {
                txt_MaxDEF.text = _kv.Value.ToString();
            }
        }
        private void DisplayMaxDEX(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("MaxDexterity"))
            {
                txt_MaxDEX.text = _kv.Value.ToString();
            }
        }

        private void DisplayExp(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Experience"))
            {
                txt_Exp.text = _kv.Value.ToString();
            }
        }
        private void DisplayKillNumber(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("KillNumber"))
            {
                txt_KillNumber.text = _kv.Value.ToString();
            }
        }
        private void DisplayLevel(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Level"))
            {
                txt_Level.text = _kv.Value.ToString();
            }
        }
        private void DisplayGold(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Gold"))
            {
                txt_Gold.text = _kv.Value.ToString();
            }
        }
        private void DisplayDiamond(KeyValueUpdate _kv)
        {
            if (_kv.Key.Equals("Diamond"))
            {
                txt_Miamond.text = _kv.Value.ToString();
            }
        }
        #endregion
    }
}