using System.Collections.Generic;
using System.Linq;
using Ars.Extensions.Runtime;
using UnityEngine;

namespace Ars.ProbabilityTable
{
    public class ProbabilityTable : MonoBehaviour
    {
        [SerializeField] List<ProbabilityItem> probabilityItems = new();

        public List<ProbabilityItem> ProbabilityItems => probabilityItems;

        /// <summary>
        ///     Return random item based on probability
        /// </summary>
        /// <returns><see cref="ProbabilityItem" /> - as result you can use itemBehaviour or itemObject.</returns>
        public ProbabilityItem GetRandom()
        {
            var sortedItems = probabilityItems.OrderBy(i => i.probability);
            var value = Random.Range(1, 101);
            var step = 0;
            var itemsInRange = new List<ProbabilityItem>();

            foreach (var item in sortedItems)
            {
                if (!itemsInRange.Any()) step += item.probability;

                if (value <= step) itemsInRange.Add(item);
            }

            if (itemsInRange.Count > 1) return itemsInRange.RandomOne();

            if (itemsInRange.Any()) return itemsInRange.First();

            return probabilityItems.Any() ? probabilityItems.First() : null;
        }
    }
}