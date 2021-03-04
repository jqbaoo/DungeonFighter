/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 公共层，进行游戏的存盘与调用
 * 
 * Description:
 *      原理：对于"模型层"数据做"对象持久化"处理。
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
using Model;

namespace Global
{
    public class SaveAndLoading : MonoBehaviour
    {
        private static SaveAndLoading _instance;
        /* 数据持久化路径 */
        //全局参数对象路径
        private static string _fileNameByGlobalParameterData = Application.persistentDataPath + "/GlobalParaData.xml";
        //玩家核心数据对象路径
        private static string _fileNameByKernalData = Application.persistentDataPath + "/KernalData.xml";
        //玩家扩展数据对象路径
        private static string _fileNameByExtenalData = Application.persistentDataPath + "/ExtenalData.xml";
        //玩家背包数据对象路径
        private static string _fileNameByPackageData = Application.persistentDataPath + "/PackageData.xml";
        //模型层代理类
        private Model_PlayerExtenalDataProxy _playerExtenalDataProxy;
        private Model_PlayerKernalDataProxy _playerKernalDataProxy;
        private Model_PlayerPackageDataProxy _playerPackageDataProxy;

        /// <summary>
        /// 得到本脚本实例
        /// </summary>
        /// <returns></returns>
        public static SaveAndLoading GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameObject("SaveAndLoading").AddComponent<SaveAndLoading>();
            }
            return _instance;
        }
        #region 存储游戏进度
        
        /// <summary>
        /// 存储游戏进度
        /// </summary>
        /// <returns></returns>
        public bool SaveGameProcess()
        {
            _playerExtenalDataProxy = Model_PlayerExtenalDataProxy.GetInstance();
            _playerKernalDataProxy = Model_PlayerKernalDataProxy.GetInstance();
            _playerPackageDataProxy = Model_PlayerPackageDataProxy.GetInstance();

            //存储游戏全局参数
            StoreToXML_GlobalParaData();
            //存储玩家核心数据
            StoreToXML_KernalData();
            //存储玩家扩展数据
            StoreToXML_ExtenalData();
            //存储玩家背包数据
            StoreToXML_PackageData();

            return false;
        }

        /// <summary>
        /// 存储全局参数数据
        /// </summary>
        private void StoreToXML_GlobalParaData()
        {
            string tmp_PlayerName = GlobalParaMgr.PlayerName;
            e_ScenesEnum tmp_ScenesName = GlobalParaMgr.NextScenesName;

            GlobalParameterData tmp_GPD = new GlobalParameterData(tmp_ScenesName, tmp_PlayerName);
            
            //对象序列化
            string tmp_Serialize = XmlOperation.GetInstance().SerializeObject(tmp_GPD, typeof(GlobalParameterData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_fileNameByGlobalParameterData))
            {
                XmlOperation.GetInstance().CreateXML(_fileNameByGlobalParameterData, tmp_Serialize);
            }
            //Log.Write(GetType() + "/StoreToXML_GlobalParaData()/XML Path = " + _fileNameByGlobalParameterData);
        }

        /// <summary>
        /// 存储玩家核心数据
        /// </summary>
        private void StoreToXML_KernalData()
        {
            //数据准备
            float tmp_Health = _playerKernalDataProxy.Health;
            float tmp_Magic = _playerKernalDataProxy.Magic;
            float tmp_Attak = _playerKernalDataProxy.Attack;
            float tmp_Defence = _playerKernalDataProxy.Defence;
            float tmp_Dexterity = _playerKernalDataProxy.Dexterity;

            float tmp_CurrentHealth = _playerKernalDataProxy.MaxHealth;
            float tmp_CurrentMagic = _playerKernalDataProxy.MaxMagic;
            float tmp_CurrentAttak = _playerKernalDataProxy.MaxAttack;
            float tmp_CurrentDefence = _playerKernalDataProxy.MaxDefence;
            float tmp_CurrentDexterity = _playerKernalDataProxy.MaxDexterity;

            float tmp_AttackByProp = _playerKernalDataProxy.AttackByProp;
            float tmp_DefenceByProp = _playerKernalDataProxy.DefenceByProp;
            float tmp_DexterityByProp = _playerKernalDataProxy.DexterityByProp;

            //实例化"类"
            Model_PlayerKernalData tmp_PKDP = new Model_PlayerKernalData(tmp_Health, tmp_Magic, tmp_Attak, tmp_Defence, tmp_Dexterity, 
                tmp_CurrentHealth, tmp_CurrentMagic, tmp_CurrentAttak, tmp_CurrentDefence, tmp_CurrentDexterity,
                tmp_AttackByProp, tmp_DefenceByProp, tmp_DexterityByProp);


            //对象序列化
            string tmp_Serialize = XmlOperation.GetInstance().SerializeObject(tmp_PKDP, typeof(Model_PlayerKernalData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_fileNameByKernalData))
            {
                XmlOperation.GetInstance().CreateXML(_fileNameByKernalData, tmp_Serialize);
            }
        }

        /// <summary>
        /// 存储玩家拓展数据
        /// </summary>
        private void StoreToXML_ExtenalData()
        {
            //数据准备
            int tmp_Experience = _playerExtenalDataProxy.Experience;
            int tmp_KillNumber = _playerExtenalDataProxy.KillNumber;
            int tmp_Level = _playerExtenalDataProxy.Level;
            int tmp_Gold = _playerExtenalDataProxy.Gold;
            int tmp_Diamonds = _playerExtenalDataProxy.Diamonds;


            Model_PlayerExtenalData tmp_PED = new Model_PlayerExtenalData(tmp_Experience, tmp_KillNumber, tmp_Level, tmp_Gold, tmp_Diamonds);

            //对象序列化
            string tmp_Serialize = XmlOperation.GetInstance().SerializeObject(tmp_PED, typeof(Model_PlayerExtenalData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_fileNameByExtenalData))
            {
                XmlOperation.GetInstance().CreateXML(_fileNameByExtenalData, tmp_Serialize);
            }
        }
        /// <summary>
        /// 存储玩家背包数据
        /// </summary>
        private void StoreToXML_PackageData()
        {
            //数据准备
            int tmp_BloodBottleNum = _playerPackageDataProxy.BloodBottleNumber;
            int tmp_MagicBottleNum = _playerPackageDataProxy.MagicBottleNumber;
            int tmp_ATKNum = _playerPackageDataProxy.PropATKNumber;
            int tmp_DEFNum = _playerPackageDataProxy.PropDEFNumber;
            int tmp_DEXNum = _playerPackageDataProxy.PropDEXNumber;

            Model_PlayerPackageData tmp_PPD = new Model_PlayerPackageData(tmp_BloodBottleNum, tmp_MagicBottleNum, tmp_ATKNum, tmp_DEFNum, tmp_DEXNum);
            
            //对象序列化
            string tmp_Serialize = XmlOperation.GetInstance().SerializeObject(tmp_PPD, typeof(Model_PlayerPackageData));
            //创建XML文件，且写入
            if (!string.IsNullOrEmpty(_fileNameByPackageData))
            {
                XmlOperation.GetInstance().CreateXML(_fileNameByPackageData, tmp_Serialize);
            }
        }
        #endregion

        #region 提取游戏进度

        /// <summary>
        /// 提取游戏全局参数数据
        /// </summary>
        /// <returns></returns>
        public bool LoadingGame_GlobalParameter()
        {
            //读取游戏的全局参数
            ReadFromXML_GlobalParaData();
            return false;
        }

        /// <summary>
        /// 提取游戏玩家数据
        /// </summary>
        /// <returns></returns>
        public bool LoadingGame_PlayerData()
        {
            //读取玩家核心数据
            ReadFromXML_PlayerKernalData();
            //读取玩家扩展数据
            ReadFromXML_PlayerExtenalData();
            //读取玩家背包数据
            ReadFromXML_PlayerPackageData();
            return false;
        }

        /// <summary>
        /// 读取游戏的全局参数
        /// </summary>
        private void ReadFromXML_GlobalParaData()
        {
            GlobalParameterData tmp_GPD = null;
            if (string.IsNullOrEmpty(_fileNameByGlobalParameterData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_GlobalParaData()/_fileNameByGlobalParameterData为空");
                return;
            }

            try
            {
                //读取XML数据
                string tmp_StrTemp = XmlOperation.GetInstance().LoadXML(_fileNameByGlobalParameterData);
                //反序列化
                tmp_GPD = XmlOperation.GetInstance().DeserializeObject(tmp_StrTemp, typeof(GlobalParameterData)) as GlobalParameterData;
                //赋值
                GlobalParaMgr.PlayerName = tmp_GPD.PlayerName;
                GlobalParaMgr.NextScenesName = tmp_GPD.NextScenesName;
                GlobalParaMgr.CurrentGameType = e_CurrentGameType.Continue;
            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_GlobalParaData()/读取游戏的全局参数不成功，请检查!");                
            }
        }

        /// <summary>
        /// 读取游戏的核心数据
        /// </summary>
        private void ReadFromXML_PlayerKernalData()
        {
            Model_PlayerKernalData tmp_PKD = null;
            if (string.IsNullOrEmpty(_fileNameByKernalData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerKernalData()/_fileNameByKernalData为空");
                return;
            }

            try
            {
                //读取XML数据
                string tmp_StrTemp = XmlOperation.GetInstance().LoadXML(_fileNameByKernalData);
                //反序列化
                tmp_PKD = XmlOperation.GetInstance().DeserializeObject(tmp_StrTemp, typeof(Model_PlayerKernalData)) as Model_PlayerKernalData;
                //赋值
                Model_PlayerKernalDataProxy.GetInstance().Health = tmp_PKD.Health;
                Model_PlayerKernalDataProxy.GetInstance().Magic = tmp_PKD.Magic;
                Model_PlayerKernalDataProxy.GetInstance().Attack = tmp_PKD.Attack;
                Model_PlayerKernalDataProxy.GetInstance().Defence = tmp_PKD.Defence;
                Model_PlayerKernalDataProxy.GetInstance().Dexterity = tmp_PKD.Dexterity;

                Model_PlayerKernalDataProxy.GetInstance().MaxHealth = tmp_PKD.MaxHealth;
                Model_PlayerKernalDataProxy.GetInstance().MaxMagic = tmp_PKD.MaxMagic;
                Model_PlayerKernalDataProxy.GetInstance().MaxAttack = tmp_PKD.MaxAttack;
                Model_PlayerKernalDataProxy.GetInstance().MaxDefence = tmp_PKD.MaxDefence;
                Model_PlayerKernalDataProxy.GetInstance().MaxDexterity = tmp_PKD.MaxDexterity;

                Model_PlayerKernalDataProxy.GetInstance().AttackByProp = tmp_PKD.AttackByProp;
                Model_PlayerKernalDataProxy.GetInstance().DefenceByProp = tmp_PKD.DefenceByProp;
                Model_PlayerKernalDataProxy.GetInstance().DexterityByProp = tmp_PKD.DexterityByProp;

            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerKernalData()/读取游戏的全局参数不成功，请检查!");
            }
        }

        /// <summary>
        /// 读取游戏的扩展数据
        /// </summary>
        private void ReadFromXML_PlayerExtenalData()
        {
            Model_PlayerExtenalData tmp_PED = null;
            if (string.IsNullOrEmpty(_fileNameByExtenalData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerExtenalData()/_fileNameByExtenalData为空");
                return;
            }

            try
            {
                //读取XML数据
                string tmp_StrTemp = XmlOperation.GetInstance().LoadXML(_fileNameByExtenalData);
                //反序列化
                tmp_PED = XmlOperation.GetInstance().DeserializeObject(tmp_StrTemp, typeof(Model_PlayerExtenalData)) as Model_PlayerExtenalData;
                //赋值
                Model_PlayerExtenalDataProxy.GetInstance().Diamonds = tmp_PED.Diamonds;
                Model_PlayerExtenalDataProxy.GetInstance().Gold = tmp_PED.Gold;
                Model_PlayerExtenalDataProxy.GetInstance().KillNumber = tmp_PED.KillNumber;
                Model_PlayerExtenalDataProxy.GetInstance().Level = tmp_PED.Level;
                Model_PlayerExtenalDataProxy.GetInstance().Experience = tmp_PED.Experience;
                Log.Write("Level: " + Model_PlayerExtenalDataProxy.GetInstance().Level);
            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerExtenalData()/读取游戏的全局参数不成功，请检查!");
            }
        }
        
        /// <summary>
        /// 读取游戏的背包数据
        /// </summary>
        private void ReadFromXML_PlayerPackageData()
        {
            Model_PlayerPackageData tmp_PPD = null;
            if (string.IsNullOrEmpty(_fileNameByPackageData))
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerPackageData()/_fileNameByPackageData为空");
                return;
            }

            try
            {
                //读取XML数据
                string tmp_StrTemp = XmlOperation.GetInstance().LoadXML(_fileNameByPackageData);
                //反序列化
                tmp_PPD = XmlOperation.GetInstance().DeserializeObject(tmp_StrTemp, typeof(Model_PlayerPackageData)) as Model_PlayerPackageData;
                //赋值
                Model_PlayerPackageDataProxy.GetInstance().BloodBottleNumber = tmp_PPD.BloodBottleNumber;
                Model_PlayerPackageDataProxy.GetInstance().MagicBottleNumber = tmp_PPD.MagicBottleNumber;
                Model_PlayerPackageDataProxy.GetInstance().PropATKNumber = tmp_PPD.PropATKNumber;
                Model_PlayerPackageDataProxy.GetInstance().PropATKNumber = tmp_PPD.PropATKNumber;
                Model_PlayerPackageDataProxy.GetInstance().PropDEFNumber = tmp_PPD.PropDEFNumber;
                Model_PlayerPackageDataProxy.GetInstance().PropDEXNumber = tmp_PPD.PropDEXNumber;


            }
            catch
            {
                Debug.LogError(GetType() + "/ReadFromXML_PlayerPackageData()/读取游戏的全局参数不成功，请检查!");
            }
        }
        #endregion
    }
}