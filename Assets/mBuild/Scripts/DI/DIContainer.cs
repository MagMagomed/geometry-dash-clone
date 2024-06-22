using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuild.Scripts.DI {
    public sealed class DIContainer
    {
        private readonly DIContainer _parentContainer;
        private readonly Dictionary<(string tag, Type type), DIRegistration> _registration;
        public DIContainer(DIContainer parentContainer)
        {
            _parentContainer = parentContainer;
        }
        /// <summary>
        /// Регистрирует фабрику
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="factory"></param>
        public void RegisterTransient<T>(Func<DIContainer, T> factory)
        {
            RegisterTransient(null, factory);
        }
        /// <summary>
        /// Регистрирует фабрику
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="factory"></param>
        public void RegisterTransient<T>(string tag, Func<DIContainer, T> factory)
        {
            Register(tag, factory, false);
        }
        /// <summary>
        /// Регистрирует инстанс (всегда синглтон)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Instance"></param>
        public void RegisterInstance<T>(T Instance)
        {
            RegisterInstance(null, Instance);
        }
        /// <summary>
        /// Регистрирует инстанс (всегда синглтон)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Instance"></param>
        public void RegisterInstance<T>(string tag, T Instance)
        {
            var key = (tag, typeof(T));
            _registration.Add(key, new DIRegistration() { Instance = Instance, IsSingleton = true});
        }
        /// <summary>
        /// Регистрирует синглтон
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        public void RegisterSingleton<T>(Func<DIContainer, T> factory)
        {
            RegisterSingleton(null, factory);
        }
        /// <summary>
        /// Регистрирует синглтон
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="factory"></param>
        public void RegisterSingleton<T>(string tag, Func<DIContainer, T> factory)
        {
            Register(tag, factory, true);
        }
        public T Resolve<T>(string tag) where T : class
        {
            if(_registration.TryGetValue((tag, typeof(T)), out DIRegistration registration)) 
            {
                if(registration.IsSingleton)
                {
                    registration.Instance = registration.Factory(this);
                    return (T)registration.Instance;
                }
                return (T)registration.Factory(this);
            }
            if(_parentContainer is not null)
            {
                return _parentContainer.Resolve<T>(tag);
            }
            throw new Exception($"{typeof(T)} не зарегистрирован");
        }
        private void Register<T>(string tag, Func<DIContainer, T> factory, bool isSingleton = false)
        {
            var key = (tag, typeof(T));
            _registration.Add(key, new DIRegistration() { Factory = _ => factory(_), IsSingleton = isSingleton }) ;
        }
    }
}