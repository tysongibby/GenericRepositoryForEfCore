using Demo.Shared.ComponentModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.Shared
{
    /// <summary>
    /// Select Blazor component. Holds options available for selection in drop-down style menu of HTML Select element. 
    /// Set "AvailableOptions" by creating a List of SelectOptions: List<SelectOption>{ SelectOption { Id = int, Value = string } }
    /// SelectedOption can be used to retrieve the Option selected by the user by using @ref= to ESelect object in <ESelect /> tag to access ESelect object properties.  
    /// </summary>
    public partial class ESelect
    {
        [Parameter, EditorRequired]
        public Expression<Func<string>> ValidationFor { get; set; } = default!;
        [Parameter]
        public string Id { get; set; } = "ESelect";
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public bool FloatingLabel { get; set; } = false;
        [Parameter]
        public List<SelectOption> SelectOptions { get; set; } = new List<SelectOption>();
        [Parameter]
        public SelectOption SelectedOption { get; set; }
        [Parameter]
        public Action OnChangeAction { get; set; }
        [Parameter]
        public new string CurrentValue
        {
            get => base.CurrentValue;
            set
            {
                base.CurrentValue = value;
                SelectedOption = SelectOptions.Find(option => option.Value == value);
                OnChangeAction?.Invoke();
            }
        }

        //protected override void OnInitialized()
        //{
        //    SelectedOption = SelectOptions[0];
        //}

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {            
            result = value; 
            validationErrorMessage = null;
            return true;
        }

    }
}