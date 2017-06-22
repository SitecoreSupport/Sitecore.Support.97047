namespace Sitecore.Support.Hooks
{
    using Sitecore.Configuration;
    using Sitecore.Diagnostics;
    using Sitecore.Events.Hooks;
    using Sitecore.SecurityModel;
    using System;

    public class UpdateNumberFieldDefinitionItem : IHook
    {
        public void Initialize()
        {
            using (new SecurityDisabler())
            {
                var databaseName = "master";
                var itemPath = "/sitecore/system/Settings/Validation Rules/Field Rules/Required";
                var fieldName = "Type";

                var type = typeof(Sitecore.Support.Data.Validators.FieldValidators.RequiredFieldValidator);

                var typeName = type.FullName;
                var assemblyName = type.Assembly.GetName().Name;
                var fieldValue = "Sitecore.Support.Data.Validators.FieldValidators.RequiredFieldValidator, Sitecore.Support.97047";

                var database = Factory.GetDatabase(databaseName);
                var item = database.GetItem(itemPath);

                if (string.Equals(item[fieldName], fieldValue, StringComparison.Ordinal))
                {
                    return;
                }

                Log.Info("Installing Sitecore.Support.97047", this);

                item.Editing.BeginEdit();
                item[fieldName] = fieldValue;
                item.Editing.EndEdit();
            }
        }
    }
}