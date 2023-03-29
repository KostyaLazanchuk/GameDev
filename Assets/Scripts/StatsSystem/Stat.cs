using Assets.Scripts.StatsSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Scripts.StatsSystem
{
    [Serializable]
    public class Stat
    {
        [field: SerializeField] public StatType Type { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public Stat(StatType statType, float values)
        {
            Type = statType;
            Value = values;
        }

        public void SetStatValue(float value) => Value = value;

        public static implicit operator float(Stat stat) => stat?.Value ?? 0;

        public Stat GetCopy() => new Stat(Type, Value);
    }
}
