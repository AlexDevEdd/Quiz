using UnityEngine;
using UnityEngine.UI;

public class TaskText : MonoBehaviour
{
    [SerializeField] private Text _taskValue;

    public Text TaskValue => _taskValue;
}
