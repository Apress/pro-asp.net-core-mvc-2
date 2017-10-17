using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace ConventionsAndConstraints.Infrastructure {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AddActionAttribute : Attribute {

        public string AdditionalName { get; }

        public AddActionAttribute(string name) {
            AdditionalName = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AdditionalActionsAttribute : Attribute,
            IControllerModelConvention {

        public void Apply(ControllerModel controller) {
            var actions = controller.Actions
                .Select(a => new {
                    Action = a,
                    Names = a.Attributes.Select(attr =>
                        (attr as AddActionAttribute)?.AdditionalName)
                });

            foreach (var item in actions.ToList()) {
                foreach (string name in item.Names) {
                    controller.Actions.Add(new ActionModel(item.Action) {
                        ActionName = name
                    });
                }
            }
        }
    }
}
