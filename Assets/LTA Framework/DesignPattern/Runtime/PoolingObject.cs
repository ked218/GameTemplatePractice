using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.DesignPattern
{
    public interface IOnDestoyPool
    {
        void OnOnDestoyPool();
    }

    public class PoolingObject : Singleton<PoolingObject>
    {
        public static Dictionary<string, List<MonoBehaviour>> dic_PoolingObject = new Dictionary<string, List<MonoBehaviour>>();

        public static void DestroyPooling<Obj>(Obj _Object) where Obj : MonoBehaviour
        {
            DestroyPooling(_Object,_Object.GetType());
        }

        public static Obj CreatePooling<Obj>(Obj _Object) where Obj : MonoBehaviour
        {
            return (Obj)CreatePooling(_Object.GetType());
        }

        public static void DestroyPooling(MonoBehaviour _Object,Type type)
        {
            string Type = type.Name;
            if (dic_PoolingObject.ContainsKey(Type))
            {
                _Object.gameObject.SetActive(false);
                dic_PoolingObject[Type].Add(_Object);
                IOnDestoyPool onDestoyPool = (IOnDestoyPool)_Object;
                if (onDestoyPool != null)
                {
                    onDestoyPool.OnOnDestoyPool();
                }
                return;
            }
            GameObject.Destroy(_Object.gameObject);
        }

        public static MonoBehaviour CreatePooling(Type type)
        {
            string Type = type.Name;
            List<MonoBehaviour> listObjects;
            if (!dic_PoolingObject.ContainsKey(Type))
            {
                listObjects = new List<MonoBehaviour>();
                dic_PoolingObject[Type] = listObjects;
                return null;
            }
            else
            {
                listObjects = dic_PoolingObject[Type];
                while (listObjects.Count > 0)
                {
                    MonoBehaviour obj = listObjects[0];
                    listObjects.Remove(obj);
                    if (obj == null) continue;
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                return null;
            }
        }
    }
}
