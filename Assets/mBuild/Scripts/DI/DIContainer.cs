using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mBuild.Scripts.DI {
    public sealed class DIContainer
    {
        private readonly DIContainer _parentContainer;
        public DIContainer(DIContainer parentContainer)
        {
            _parentContainer = parentContainer;
        }
    }
}