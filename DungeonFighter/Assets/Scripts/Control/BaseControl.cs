/*
 * 
 * 项目：暗黑角斗场
 * 
 * Title: 控制层，父类控制层
 * 
 * Description:
 *      具体作用：
 *      1、把控制层脚本中公共部分的内容写在该父类中
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using Global;
using Kernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control
{
    public class BaseControl : MonoBehaviour
    {
        /// <summary>
        /// 进入下一个场景
        /// </summary>
        /// <param name="场景的枚举名称"></param>
        protected void EnterNextScene(e_ScenesEnum _sceneEnumName)
        {
            //场景切换   
            GlobalParaMgr.NextScenesName = _sceneEnumName;
            Application.LoadLevelAsync(ConvertEnumToStr.GetInstance().GetSrtByEnumScene(e_ScenesEnum.LoadingScene));
        }

        /// <summary>
        /// 公共方法，攻击敌人
        /// </summary>
        /// <param name="_attackArea">攻击范围</param>
        /// <param name="_attackPowerMultiple">攻击力度(倍率)</param>
        /// <param name="_isDirection">是否具有方向性</param>
        protected void AttackEnemy(List<GameObject> _listEnemies, Transform _traNearestEnemy, float _attackArea, int _attackPowerMultiple, bool _isDirection = true)
        {
            if (_listEnemies == null && _listEnemies.Count <= 0)
            {
                _traNearestEnemy = null;
                return;
            }
            foreach (GameObject tmp_GoEnemyItem in _listEnemies)
            {
                if (tmp_GoEnemyItem && tmp_GoEnemyItem.GetComponent<Ctrl_BaseEnemyProperty>())
                {
                    if (tmp_GoEnemyItem.GetComponent<Ctrl_BaseEnemyProperty>().CurrentState != e_EnemyState.Death)
                    {
                        //敌我距离
                        float tmp_FloDistance = Vector3.Distance(this.transform.position, tmp_GoEnemyItem.transform.position);

                        if (_isDirection)
                        {
                            //主角与敌人的方向
                            Vector3 tmp_Dir = (tmp_GoEnemyItem.transform.position - this.transform.position).normalized;
                            //主角与敌人面前的夹角
                            float tmp_FloDirection = Vector3.Dot(tmp_Dir, this.transform.forward);
                            //tmp_FloDirection夹角大于0则在前方，并且在有限距离内
                            if ((tmp_FloDirection > 0.5f) && (tmp_FloDistance <= _attackArea))
                            {
                                tmp_GoEnemyItem.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK() * _attackPowerMultiple, SendMessageOptions.DontRequireReceiver);
                            }
                        }
                        else
                        {
                            if (tmp_FloDistance <= _attackArea)
                            {
                                tmp_GoEnemyItem.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK() * _attackPowerMultiple, SendMessageOptions.DontRequireReceiver);
                            }
                        }
                    }
                }
            }//foreach end
        }//AttackEnemy() end

        /// <summary>
        /// 加载粒子特效的公共方法
        /// </summary>
        /// <param name="_internalTime">间隔时间</param>
        /// <param name="_ParticalEffectPath">粒子预设的路径</param>
        /// <param name="_isUseCache">是否把粒子加入缓存</param>
        /// <param name="_particalEffectPos">粒子特效的位置</param>
        /// <param name="_quaParticalEffect">旋转角度</param>
        /// <param name="_traParent">父对象</param>
        /// <param name="_audioEffect">音频</param>
        /// <param name="_destroyTime">销毁时间</param>
        /// <returns></returns>
        protected IEnumerator LoadParticalEffect(float _internalTime, string _ParticalEffectPath, bool _isUseCache,
            Vector3 _particalEffectPos, Quaternion _quaParticalEffect, Transform _traParent, string _audioEffect = null, float _destroyTime = 0)
        {
            //间隔时间
            yield return new WaitForSeconds(_internalTime);
            //加载粒子预设
            GameObject tmp_GoParticlePrefab = ResourcesManager.GetInstance().LoadResource(_ParticalEffectPath, true);
            //设置粒子位置
            tmp_GoParticlePrefab.transform.position = _particalEffectPos;
            //设置粒子的旋转
            tmp_GoParticlePrefab.transform.rotation = _quaParticalEffect;
            //设置父子对象
            if (_traParent != null)
            {
                tmp_GoParticlePrefab.transform.parent = _traParent;
            }
            //定义特效音频
            if (!string.IsNullOrEmpty(_audioEffect))
            {
                AudioManager.PlayAudioEffectA(_audioEffect);
            }
            //销毁时间
            if (_destroyTime > 0)
            {
                Destroy(tmp_GoParticlePrefab, _destroyTime);
            }
        }


        /// <summary>
        /// 粒子特效加载(使用缓存池)
        /// </summary>
        /// <param name="_internalTime">间隔时间</param>
        /// <param name="_goParEffPrefab">粒子特效预设</param>
        /// <param name="_posParEffect">位置</param>
        /// <param name="_quaParEffect">旋转角度</param>
        /// <param name="_traParent">父节点</param>
        /// <param name="_acEffect">音频(可选)</param>
        /// <returns></returns>
        protected IEnumerator LoadParticalEffect_UsePool(float _internalTime, GameObject _goParEffPrefab, Vector3 _posParEffect, Quaternion _quaParEffect, Transform _traParent, AudioClip _acEffect = null)
        {
            yield return new WaitForSeconds(_internalTime);
            //在"对象缓存池"中激活指定对象
            GameObject tmp_GoCloneByPool = PoolManager.PoolsArray["ParticleSys"].GetGameObjectByPool(_goParEffPrefab, _goParEffPrefab.transform.position, Quaternion.identity);
            tmp_GoCloneByPool.transform.position = _posParEffect;
            tmp_GoCloneByPool.transform.rotation = _quaParEffect;
            //确定父对象
            if (_traParent)
            {
                tmp_GoCloneByPool.transform.parent = _traParent;
            }
            //特效音效
            if (_acEffect)
            {
                AudioManager.PlayAudioEffectB(_acEffect);
            }
        }


        /// <summary>
        /// "飘字"特效缓存池方法
        /// </summary>
        /// <param name="_internalTime">间隔时间</param>
        /// <param name="_goParEffPrefab">粒子特效预设</param>
        /// <param name="_posParEffect">位置</param>
        /// <param name="_quaParEffect">旋转角度</param>
        /// <param name="_goTargetObj">目标对象</param>
        /// <param name="_displayNum">"飘字"显示数值</param>
        /// <param name="_traParent">父节点</param>
        /// <param name="_acEffect">音频(可选)</param>
        /// <returns></returns>
        protected IEnumerator LoadParticalEffectInPool_MoveUpLabel(float _internalTime, GameObject _goParEffPrefab, Vector3 _posParEffect,
            Quaternion _quaParEffect, GameObject _goTargetObj, int _displayNum, Transform _traParent, AudioClip _acEffect = null)
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            //在"对象缓存池"中激活指定对象
            GameObject tmp_GoCloneByPool = PoolManager.PoolsArray["ParticleSys"].GetGameObjectByPool(_goParEffPrefab, _goParEffPrefab.transform.position, Quaternion.identity);
            //参数赋值
            if (tmp_GoCloneByPool)
            {
                tmp_GoCloneByPool.GetComponent<MoveUpLabel>().SetTarget(_goTargetObj);
                tmp_GoCloneByPool.GetComponent<MoveUpLabel>().SetReduceHpNumber(_displayNum);
            }
            //确定父对象
            if (_traParent)
            {
                tmp_GoCloneByPool.transform.parent = _traParent;
            }
            //特效音效
            if (_acEffect)
            {
                AudioManager.PlayAudioEffectB(_acEffect);
            }
        }

        /// <summary>
        /// 生成敌人(使用缓存)
        /// </summary>
        /// <param name="_enemyPrefab">敌人预设</param>
        /// <param name="_createEnemyNum">生成的数量</param>
        /// <param name="_enemySpawnPos">生成地点</param>
        /// <returns></returns>
        protected IEnumerator SpawnEnemy(GameObject _enemyPrefab, int _createEnemyNum, Transform[] _enemySpawnPos, bool _isCreateHpBar = true, float _floHPPrefabLength = 0.5f)
        {
            yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_0DOT5);
            for (int i = 0; i < _createEnemyNum; i++)
            {
                yield return new WaitForSeconds(GlobalParameter.INTERVAL_TIME_1);
                //随机获得出生点
                Transform tmp_TranEnemySpawnPos = GetRandomEnemySpawnPos(_enemySpawnPos);
                //克隆位置
                _enemyPrefab.transform.position = new Vector3(tmp_TranEnemySpawnPos.position.x, tmp_TranEnemySpawnPos.position.y, tmp_TranEnemySpawnPos.position.z);
                //在对象池中取出对象
                GameObject tmp_GoCloneByPool = PoolManager.PoolsArray["Enemies"].GetGameObjectByPool(_enemyPrefab, _enemyPrefab.transform.position, Quaternion.identity);

                if (_isCreateHpBar)
                {
                    /* 敌人的血条 */
                    GameObject tmp_GoEnemyHP = ResourcesManager.GetInstance().LoadResource("Prefabs/UI/Sli_EnemyHPBar", true);
                    //确定父节点
                    tmp_GoEnemyHP.transform.parent = GameObject.FindGameObjectWithTag(Tag.UIPlayerInfo).transform;
                    //参数赋值
                    tmp_GoEnemyHP.GetComponent<EnemyHPBar>().SetTargetEnemy(tmp_GoCloneByPool);
                    tmp_GoEnemyHP.GetComponent<EnemyHPBar>().floHPPrefabLength = _floHPPrefabLength;

                }

                //克隆敌人出现特效
                // EnemySpawnParticalEffect(goWarriorPrefab_Green);
            }
        }

        /// <summary>
        /// 随机得到敌人的出生点
        /// </summary>
        /// <param name="_enemyCreatePos">敌人位置数组</param>
        /// <returns></returns>
        private Transform GetRandomEnemySpawnPos(Transform[] _enemyCreatePos)
        {
            int tmp_RandomNum = UnityHelper.GetInstance().GetRandomNum(0, _enemyCreatePos.Length - 1);
            return _enemyCreatePos[tmp_RandomNum];
        }


        private bool _isSingleTime = true;

        /// <summary>
        /// 主角升级
        /// </summary>
        protected void LevelUp(KeyValueUpdate _kv, AudioClip _ac_LevelUp)
        {
            if (_kv.Key.Equals("Level"))
            {
                if (_isSingleTime)
                {
                    _isSingleTime = false;
                }
                else
                {
                    HeroLevelUp(_ac_LevelUp);
                }
            }
        }

        private void HeroLevelUp(AudioClip _ac_LevelUp)
        {
            ResourcesManager.GetInstance().LoadResource("ParticleProps/Hero_Levelup", true);
            AudioManager.PlayAudioEffectA(_ac_LevelUp);
        }

    }//class end
}