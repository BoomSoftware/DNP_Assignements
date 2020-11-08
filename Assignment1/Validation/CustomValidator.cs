namespace Assignment1.Validation
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    namespace BlazorSample.Client
    {
        public class CustomValidator : ComponentBase
        {
            private ValidationMessageStore messageStore;

            [CascadingParameter]
            private EditContext CurrentEditContext { get; set; }

            protected override void OnInitialized()
            {
                if (CurrentEditContext == null)
                {
                    throw new InvalidOperationException(
                        $"{nameof(CustomValidator)} requires a cascading " +
                        $"parameter of type {nameof(EditContext)}. " +
                        $"For example, you can use {nameof(CustomValidator)} " +
                        $"inside an {nameof(EditForm)}.");
                }

                messageStore = new ValidationMessageStore(CurrentEditContext);

                CurrentEditContext.OnValidationRequested += (s, e) => 
                    messageStore.Clear();
                CurrentEditContext.OnFieldChanged += (s, e) => 
                    messageStore.Clear(e.FieldIdentifier);
            }

            public void DisplayErrors(Dictionary<string, string> errors)
            {
                foreach (var err in errors)
                {
                    Console.WriteLine("\tDisplaying error " + err.Key + " with value " + err.Value);
                    messageStore.Add(CurrentEditContext.Field(err.Key), err.Value);
                }

                CurrentEditContext.NotifyValidationStateChanged();
            }

            public void ClearErrors()
            {
                messageStore.Clear();
                CurrentEditContext.NotifyValidationStateChanged();
            }
        }
    }
}