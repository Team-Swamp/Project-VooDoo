﻿using UnityEngine;

namespace Framework
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                
                _instance = FindObjectOfType<T>();

                if (_instance != null) 
                    return _instance;
                
                GameObject singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
                DontDestroyOnLoad(singletonObject);

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(this.gameObject);
                return;
            }
            
            Destroy(this.gameObject);
        }
    }
}