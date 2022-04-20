using Demo.Data.DataModels;
using Demo.Data.Repositories.Interfaces;
using Demo.Pages.PageModels;
using Demo.Shared;
using Demo.Shared.ComponentModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Pages
{
    // TODO: add comments
    // BUG: demo not yet functional. child not updating after state has changed.
    public partial class Index
    {
        [Inject]
        private IUnitOfWork unitOfWork { get; set; }
        //[Inject]
        //NavigationManager navigationManager { get; set; }

        public DemoForm Form { get; set; } = new DemoForm();
        

        private List<DemoModel> demoModels = new List<DemoModel>();
        private List<SelectOption> selectOptions = new List<SelectOption>();
        private ESelect eSelect;
        private bool demoModelEditDisabled = false;
        private string updateMessage = string.Empty;


        protected override void OnInitialized()
        {
            demoModels = unitOfWork.DemoModels.GetAll().ToList();
            foreach (DemoModel model in demoModels)
            {
                selectOptions.Add(new SelectOption { Id = model.Id, Value = model.Name });
            }
            Form.SelectedDemoModelName = selectOptions[0].Value;
                
        }

        private void ValidSubmit()
        {            
            DemoModel updatedModel = new DemoModel { Id = eSelect.SelectedOption.Id, Name = Form.SelectedDemoModelName };            
            unitOfWork.DemoModels.Update(updatedModel, updatedModel.Id);
            demoModels[updatedModel.Id] = updatedModel;
            
        }

        private void ProcessMessage()
        {
            updateMessage = "Update has been processed.";
        }

        //private void ToggleDemoModelEditDisabled()
        //{
        //    demoModelEditDisabled = !demoModelEditDisabled;
        //}
    }
}
