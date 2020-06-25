using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teamp2.Library.Framework.DataType
{
    public abstract class BaseSharedVariable<T> : ScriptableObject where T : struct
    {
        [SerializeField]
        protected T value;

        [Multiline]
        public string description;

        #if UNITY_EDITOR
        [SerializeField] private bool defaultOnExitPlayMode;

        [ConditionalDraw(nameof(defaultOnExitPlayMode))]
        [SerializeField] private T defaultValue;
        #endif

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString() => $"{value}";

        #if UNITY_EDITOR
        private void OnDisable()
        {
            if (defaultOnExitPlayMode)
                value = defaultValue;
        }
        #endif
    }
}
