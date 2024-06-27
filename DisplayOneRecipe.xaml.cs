using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for DisplayOneRecipe.xaml
    /// </summary>
    public partial class DisplayOneRecipe : Window
    {
        private Dictionary<string, string> RecipeDictionary;

        public static string recName;
        public DisplayOneRecipe(Dictionary<string, string>  recipes)
        {
            InitializeComponent();
            RecipeDictionary = recipes;
            ShowAllRecipes(RecipeDictionary);
        }
        public DisplayOneRecipe()
        {
            InitializeComponent();
            
        }

        private void btnDisplayOne_Click(object sender, RoutedEventArgs e)
        {
            ChooseARecipe(RecipeDictionary);
        }

        private void txtChooseRName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

         private void btnAddRecipes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void btnDisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            DisplayAllRecipes dispall = new DisplayAllRecipes();
            dispall.Show();
            this.Hide();
        }

        private void btnDisplayARecipe_Click(object sender, RoutedEventArgs e)
        {
            DisplayOneRecipe dispone = new DisplayOneRecipe();
            dispone.Show();
            this.Hide();
        }



        private void ShowAllRecipes(Dictionary<string, string> allrecipes)
        {
            foreach (var recipe in allrecipes)
            {
                lstChooseRecipe.Items.Add($"Recipe Name: {recipe.Key}\nDescription: {recipe.Value}\n");
            }
        }


        private void ChooseARecipe(Dictionary<string, string> allrecipes)
        {
            recName = txtRName.Text;
            if (allrecipes.TryGetValue(recName, out string description))
            {
                lstChosenRecipe.Items.Add($"Recipe Name: {recName}\nDescription: {description}\n");
            }
            else
            {
                MessageBox.Show("Recipe not found", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
