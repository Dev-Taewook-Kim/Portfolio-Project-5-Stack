using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Teamp2.Library.Framework.DataType
{
    [CreateAssetMenu(fileName = "New Shared Variable String", menuName = "Teamp2/Utility/Framework/Data Type/String")]
    public class SharedVariableString : BaseSharedVariable<StringWrapper>
    {
        public new string Value => value.value;

        public override string ToString() => value.value;
    }

    [System.Serializable]
    public struct StringWrapper
    {
        public string value;
    }
}
