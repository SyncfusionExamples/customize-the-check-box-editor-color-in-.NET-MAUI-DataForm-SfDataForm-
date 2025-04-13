using Syncfusion.Maui.DataForm;

namespace CustomizeCheckBoxColor
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm? dataForm;

        private Button? applyButton;

        private Button? cancelButton;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("dataForm");
            if (dataForm != null )
            {
                dataForm.ItemsSourceProvider = new ItemSourceProvider();
                dataForm.RegisterEditor("Gender", DataFormEditorType.RadioGroup);
                dataForm.RegisterEditor("Address", DataFormEditorType.MultilineText);
                dataForm.RegisterEditor("Country", DataFormEditorType.AutoComplete);
                dataForm.RegisterEditor("City", DataFormEditorType.ComboBox);
                dataForm.RegisterEditor("ReadyToRelocate", DataFormEditorType.Switch);
                dataForm.RegisterEditor("BirthDate", DataFormEditorType.Date);
                dataForm.GenerateDataFormItem += OnGenerateDataFormItem;
            }

            this.cancelButton = bindable.FindByName<Button>("cancelButton");
            this.applyButton = bindable.FindByName<Button>("applyButton");

            if (this.cancelButton != null)
            {
                this.cancelButton.Clicked += OnCancelButtonClicked;
            }

            if (this.applyButton != null)
            {
                this.applyButton.Clicked += OnApplyButtonClicked;
            }
        }
        private void OnGenerateDataFormItem(object? sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem!= null)
            {
                if (e.DataFormItem.FieldName == "FirstGraduate" && e.DataFormItem is DataFormCheckBoxItem checkBoxItem)
                {
                    checkBoxItem.Color = Colors.DarkCyan;
                }
            }
        }
        private async void OnApplyButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)
            {
                if (this.dataForm.Validate())
                {
                    await DisplayAlert("", "Applied successfully", "OK");
                }
                else
                {
                    await DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }
        private void OnCancelButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)

            {
                this.dataForm.DataObject = new DataFormModel();
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.cancelButton != null)
            {
                this.cancelButton.Clicked -= OnCancelButtonClicked;
            }

            if (this.applyButton != null)
            {
                this.applyButton.Clicked -= OnApplyButtonClicked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem -= this.OnGenerateDataFormItem;
            }
        }

        /// <summary>
        /// Displays an alert dialog to the user.
        /// </summary>
        /// <param name="title">The title of the alert dialog.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="cancel">The text for the cancel button.</param>
        /// <returns>A task representing the asynchronous alert display operation.</returns>
        private Task DisplayAlert(string title, string message, string cancel)
        {
            return App.Current?.Windows?[0]?.Page!.DisplayAlert(title, message, cancel)
                   ?? Task.FromResult(false);
        }
    }
}