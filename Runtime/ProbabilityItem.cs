using System;
using UnityEngine;

namespace Ars.ProbabilityTable
{
    [Serializable]
    public class ProbabilityItem
    {
        [Range(1, 100)] public int probability;

        public MonoBehaviour itemBehaviour;
        public GameObject itemObject;
    }
}