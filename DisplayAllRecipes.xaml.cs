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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for DisplayAllRecipes.xaml
    /// </summary>
   
    public partial class DisplayAllRecipes : Window
    {
        private Dictionary<string, string> RecipeDictionary;
        public static Dictionary<string, string> localList = new Dictionary<string, string>();
        public DisplayAllRecipes(Dictionary<string, string> recipes)
        {
            InitializeComponent();
            RecipeDictionary = recipes;
            ShowAllRecipes(recipes);
        }
        public DisplayAllRecipes()
        {
            InitializeComponent();
            
        }

        private void cmbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAddRecipes_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void btnDisplayARecipe_Click(object sender, RoutedEventArgs e)
        {
           
            DisplayOneRecipe dispone = new DisplayOneRecipe(RecipeDictionary);
            dispone.Show();
            this.Hide();
        }

        private void btnDisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowAllRecipes(Dictionary<string, string> allrecipes)
        {
            foreach (var recipe in allrecipes)
            {
                lstRecipes.Items.Add($"Recipe Name: {recipe.Key}\nDescription: {recipe.Value}\n");
                localList.Add(recipe.Key, recipe.Value );
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
