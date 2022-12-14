using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContentsStats
{
    public EnvironmentEnum environmentEnum;
    public string question = string.Empty;
    public string firstProblem = string.Empty;
    public string secondProblem = string.Empty;
    public string thirdProblem = string.Empty;
}


[CreateAssetMenu(menuName = "Item")]
public class ContentState : Contents
{
        [SerializeField] protected List<ContentsStats> contentsStats = new List<ContentsStats>();
        public List<ContentsStats> ContentsStats { get { return contentsStats; } }
}
