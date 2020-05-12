using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BusinessErrorV2.Models
{
    class CheckValidations
    {
        public string errorMessage { get; set; }
        public bool CheckValidation(TextBox query, DatePicker from, DatePicker to)
        {
            if(query.Text.Length > 26)
            {
                errorMessage = "Their is a maximum of 26 characters allowed in the search box";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                return false;
            }
            //Validated 
            if(query.Text != "" && from.Text == "" && to.Text == "")
            {
                return true;
            }
            if(query.Text != "" && from.Text != "" && to.Text != "")
            {
                return true;
            }
            if (query.Text == "" && from.Text != "" && to.Text != "")
            {
                return true;
            }
            //invalidated

            if (query.Text != "" && from.Text == "" && to.Text != "")
            {
                errorMessage = "if date is used both date (from) and (to) needs to be set. If not both should be emty";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                return false;
            }
            if (query.Text != "" && from.Text != "" && to.Text == "")
            {
                errorMessage = "if date is used both date (from) and (to) needs to be set. If not both should be emty";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                return false;
            }
            if (query.Text == "" && from.Text == "" && to.Text != "")
            {
                errorMessage = "if date is used both date (from) and (to) needs to be set. If not both should be emty";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                return false;
            }
            if (query.Text != "" && from.Text != "" && to.Text == "")
            {
                errorMessage = "if date is used both date (from) and (to) needs to be set. If not both should be emty";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                return false;
            }
            if (query.Text == "" && from.Text != "" && to.Text == "")
            {
                errorMessage = "if date is used both date (from) and (to) needs to be set. If not both should be emty";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                return false;
            }
            if (query.Text == "" && from.Text == "" && to.Text == "")
            {
                errorMessage = "You must set at least one search query";
                MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
                
                return false;
            }
                errorMessage = "Their was a genral error in the request";
                MessageBoxResult result = MessageBox.Show(errorMessage, "Confirmation",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Question);
            return false;

        }

    }
}
