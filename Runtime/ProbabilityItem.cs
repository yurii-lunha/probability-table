using System;
using UnityEngine;

namespace Ars.ProbabilityTable
{
    [Serializable]
    public class ProbabilityItem
    {
        [SerializeField, Range(1, 100)] int m_Probability;

        [SerializeField] MonoBehaviour m_ItemBehaviour;
        [SerializeField] GameObject m_ItemObject;
        [SerializeField] int m_ItemInt;
        [SerializeField] float m_ItemFlt;

        public int Probability => m_Probability;

        public MonoBehaviour ItemBehaviour => m_ItemBehaviour;

        public GameObject ItemObject => m_ItemObject;

        public int ItemInt => m_ItemInt;

        public float ItemFlt => m_ItemFlt;
    }
}