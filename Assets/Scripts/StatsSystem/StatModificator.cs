using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StatsSystem.Enum
{
    [Serializable]
    public class StatModificator
    {

        [field: SerializeField] public Stat Stat { get; private set; }
        [field: SerializeField] public StatModificatorType StatModificatorType { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }

        public float StartTime { get; }

        public StatModificator(Stat stat, StatModificatorType statModificatorType, float duration, float sartTime)
        {
            Stat = stat;
            StatModificatorType = statModificatorType;
            Duration = duration;
            StartTime = sartTime;
        }
    }
}