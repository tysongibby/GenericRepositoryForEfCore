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
    // TODO: demo not yet functional. ESelect control needs to set correct value in ESelect.SelectedOption
    public partial class Index
    {
        [Inject]
        private IUnitOfWork unitOfWork { get; set; }

        public DemoForm Form { get; set; } = new DemoForm();
        

        private List<DemoModel> demoModels = new List<DemoModel>();
        private List<SelectOption> selectOptions = new List<SelectOption>();
        private ESelect eSelect;


        protected override void OnInitialized()
        {
            demoModels = unitOfWork.DemoModels.GetAll().ToList();
            foreach (DemoModel model in demoModels)
            {
                selectOptions.Add(new SelectOption { Id = model.Id, Value = model.Name });
            }
                
        }

        public void ValidSubmit()
        {
            DemoModel updatedModel = new DemoModel { Id = 1, Name = "new Name"};
            unitOfWork.DemoModels.Update(updatedModel, updatedModel.Id);
        }
    }
}
