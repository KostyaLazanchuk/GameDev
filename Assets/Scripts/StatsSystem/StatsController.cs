using Assets.Scripts.Core.Servieces.Updater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StatsSystem.Enum
{
    public class StatsController : IDisposable, IStatValueGiver
    {
        private readonly List<Stat> _currentStats;
        private readonly List<StatModificator> _activeModicators;

        public StatsController(List<Stat> currentStats)
        {
            _currentStats = currentStats;
            _activeModicators = new List<StatModificator>();
            ProjectUpdater.Instance.UpdateCalled += OnUpdate;
        }

        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;

        public float GetStatValue(StatType statType) => 
            _currentStats.Find(stat => stat.Type == statType).Value;

        public void ProcessModificator(StatModificator modificator)
        {
            var statToChange = _currentStats.Find(stat => stat.Type == modificator.Stat.Type);
            
            if (statToChange == null)
                return;

            var addedValue = modificator.StatModificatorType == StatModificatorType.Additive ?
                statToChange + modificator.Stat : statToChange * modificator.Stat;

            statToChange.SetStatValue(statToChange + addedValue);
            if (modificator.Duration < 0)
                return;

            if(_activeModicators.Contains(modificator))
            {
                _activeModicators.Remove(modificator);
            }
            else
            {
                var addedStat = new Stat(modificator.Stat.Type, -addedValue);
                var tempModificator = 
                    new StatModificator(addedStat, StatModificatorType.Additive, modificator.Duration, Time.time);
                _activeModicators.Add(tempModificator);
            }
        }

        private void OnUpdate()
        {
            if (_activeModicators.Count == 0)
                return;

            var expiredModificator =
                _activeModicators.Where(modificator => modificator.StartTime + modificator.Duration >= Time.time);

            foreach (var modificator in expiredModificator)
                ProcessModificator(modificator);
        }

    }
}
