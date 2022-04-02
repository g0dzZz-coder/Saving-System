using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Depra.Saving.Runtime.UI
{
    public class SaveDisplay : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Image _icon;

        private void Awake()
        {
            _deleteButton.onClick.AddListener(OnDeleteButtonClicked);
        }

        public void FreeResources()
        {
            if (_icon.sprite != null)
            {
                Destroy(_icon.sprite);
            }
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            
        }

        private void OnDeleteButtonClicked()
        {
            
        }
    }
    
    public class SavePanel : MonoBehaviour
    {
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;
        [SerializeField] private Button _deleteButton;

        private void Awake()
        {
            _saveButton.onClick.AddListener(OnSaveButtonClicked);
            _loadButton.onClick.AddListener(OnLoadButtonClicked);
            _deleteButton.onClick.AddListener(OnDeleteItemClicked);
        }

        private void OnSaveButtonClicked()
        {
            
        }

        private void OnLoadButtonClicked()
        {
            
        }

        private void OnDeleteItemClicked()
        {
            
        }
    }
}
