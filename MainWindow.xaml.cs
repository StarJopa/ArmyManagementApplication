using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ArmyManagementApplication
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Unit> units;
        private double playerMoney = 1000;
        private bool isSaved = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeUnits();
            dataGridUnits.ItemsSource = units;
            txtPlayerMoney.Text = $"Золото: {playerMoney}";
        }

        private void InitializeUnits()
        {
            units = new ObservableCollection<Unit>
            {
                // Воин
                new Unit
                {
                    Name = "Воин",
                    Type = "Melee",
                    Attack = 10,
                    Cost = 50,
                    AvailableUnits = 10,
                    MaxHP = 100,
                    CurrentHP = 100,
                    Defense = 15,
                    Arrows = 0,
                    Mana = 0,
                    Level = 1
                },

                // Лучник
                new Unit
                {
                    Name = "Лучник",
                    Type = "Ranged",
                    Attack = 7,
                    Cost = 40,
                    AvailableUnits = 15,
                    MaxHP = 75,
                    CurrentHP = 75,
                    Defense = 10,
                    Arrows = 50,
                    Mana = 0,
                    Level = 1
                },

                // Маг
                new Unit
                {
                    Name = "Маг",
                    Type = "Magic",
                    Attack = 12,
                    Cost = 60,
                    AvailableUnits = 5,
                    MaxHP = 50,
                    CurrentHP = 50,
                    Defense = 5,
                    Arrows = 0,
                    Mana = 100,
                    Level = 1
                }
            };
        }


        // Метод для сохранения юнитов
        private void SaveUnits_Click(object sender, RoutedEventArgs e)
        {
            isSaved = true;
            MessageBox.Show("Армия сохранена успешно!");

            int totalAttack = units.Sum(unit => unit.TotalAttack);
            string report = "Состав армии:\n\n";

            foreach (var unit in units)
            {
                double contribution = totalAttack > 0 ? (unit.TotalAttack / (double)totalAttack) * 100 : 0;
                report += $"{unit.Name}: {unit.HiredUnits} юнитов, вклад: {contribution:F2}%\n";
            }

            MessageBox.Show(report);
        }

        // Метод для сброса юнитов
        private void ResetUnits_Click(object sender, RoutedEventArgs e)
        {
            isSaved = false;
            playerMoney = 1000;
            InitializeUnits();
            dataGridUnits.ItemsSource = units;
            txtPlayerMoney.Text = $"Золото: {playerMoney}";
        }

        // Метод для открытия окна добавления нового юнита
        private void OpenAddUnitWindow_Click(object sender, RoutedEventArgs e)
        {
            var addUnitWindow = new AddUnitWindow();
            if (addUnitWindow.ShowDialog() == true)
            {
                units.Add(addUnitWindow.NewUnit);
                dataGridUnits.Items.Refresh();
            }
        }

        // Метод для найма юнита
        private void HireUnit_Click(object sender, RoutedEventArgs e)
        {
            var selectedUnit = (Unit)dataGridUnits.SelectedItem;
            if (selectedUnit != null)
            {
                if (playerMoney >= selectedUnit.Cost && selectedUnit.AvailableUnits > 0)
                {
                    playerMoney -= selectedUnit.Cost;
                    selectedUnit.HiredUnits++;
                    selectedUnit.AvailableUnits--;

                    dataGridUnits.Items.Refresh();
                    txtPlayerMoney.Text = $"Золото: {playerMoney}";
                }
                else
                {
                    MessageBox.Show("Не хватает денег или доступных юнитов!");
                }
            }
        }

        // Метод для увольнения юнита
        private void FireUnit_Click(object sender, RoutedEventArgs e)
        {
            var selectedUnit = (Unit)dataGridUnits.SelectedItem;
            if (selectedUnit != null && selectedUnit.HiredUnits > 0)
            {
                playerMoney += selectedUnit.Cost;
                selectedUnit.HiredUnits--;
                selectedUnit.AvailableUnits++;

                dataGridUnits.Items.Refresh();
                txtPlayerMoney.Text = $"Золото: {playerMoney}";
            }
            else
            {
                MessageBox.Show("Нет юнитов для увольнения!");
            }
        }
    }
}
