using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StatsSystem.Enum
{
    [CreateAssetMenu(fileName = "StatsStorage", menuName = "Stats/Storage")]
    public class StatsStorage : ScriptableObject
    {
        [field: SerializeField] public List<Stat> Stats { get; private set; }
    }
}
