using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ArmyManagementApplication
{
    public partial class AddUnitWindow : Window
    {
        public Unit NewUnit { get; private set; }

        private const string PositiveIntegerPattern = @"^[1-9]\d*$";  // Положительное целое число
        private const string PositiveDecimalPattern = @"^[+]?\d*\.\d{2}$";  // Положительное вещественное число с двумя знаками после запятой

        public AddUnitWindow()
        {
            InitializeComponent();
        }

        private bool IsValidInput(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitName.Text) ||
                cmbUnitType.SelectedItem == null ||
                !IsValidInput(txtUnitAttack.Text, PositiveIntegerPattern) ||
                !IsValidInput(txtUnitCost.Text, PositiveDecimalPattern) ||
                !IsValidInput(txtUnitAvailable.Text, PositiveIntegerPattern))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные.");
                return;
            }

            // Создание нового юнита с корректными данными
            NewUnit = new Unit
            {
                Name = txtUnitName.Text,
                Type = (cmbUnitType.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Attack = int.Parse(txtUnitAttack.Text),
                Cost = double.Parse(txtUnitCost.Text),
                AvailableUnits = int.Parse(txtUnitAvailable.Text),
                HiredUnits = 0
            };

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
