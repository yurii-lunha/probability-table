﻿#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Ars.ProbabilityTable
{
    [CustomEditor(typeof(ProbabilityTable))]
    public class ProbabilityTableEditor : Editor
    {
        GUIStyle _labelsStyle;

        void OnEnable()
        {
            _labelsStyle = new GUIStyle { fontStyle = FontStyle.Bold, fontSize = 16 };
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var table = target as ProbabilityTable;
            var probabilitySum = table.ProbabilityItems.Sum(i => i.probability);
            var is50 = probabilitySum / table.ProbabilityItems.Count == 50;

            var color = new Color(1f, 0.45f, 0.07f);

            if (probabilitySum == 100)
                color = new Color(0.17f, 1f, 0f);
            else if (is50) color = new Color(0.26f, 0.26f, .8f);

            var text = $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{probabilitySum}%</color>";

            if (probabilitySum == 100)
                text += " - Ok";
            else if (is50)
                text += " - Equal";
            else
                text += " - Disbalance";

            GUILayout.Label(text, _labelsStyle);
        }
    }
}
#endif