using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Movement.Data
{
    [Serializable]
    public class JumpData
    {
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public int GravityScale { get; private set; }
        [field: SerializeField] public int MaxJump { get; private set; }
    }
}
